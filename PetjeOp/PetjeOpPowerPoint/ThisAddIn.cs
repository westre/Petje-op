using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using PetjeOp;
using System.Windows.Forms;
using System.Drawing;

namespace PetjeOpPowerPoint
{
    public partial class ThisAddIn
    {
        private Database DB { get; set; }
        private DatabaseListener DL { get; set; }
        public PowerPoint.Slide CurrentSlide { get; set; }
        public Timer Timer { get; set; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            DB = new Database();
            Application.SlideSelectionChanged += Application_SlideSelectionChanged;
            Application.SlideShowNextSlide += Application_SlideShowNextSlide;

            DL = new DatabaseListener();
            DL.OnChange += DL_OnChange;

            Timer = new Timer();
        }

        private void DL_OnChange(System.Data.SqlClient.SqlNotificationEventArgs eventArgs) {
            if(CurrentSlide != null && CurrentSlide.Tags["isResultSlide"] == "1") {
                // Haal alle resultaten op die bij deze examen hoort
                List<Result> allResults = DB.GetResultsByExamId(Convert.ToInt32(CurrentSlide.Tags["examId"]));

                //int questionId = Convert.ToInt32(CurrentSlide.Tags["questionId"]); 
                Question question = DB.GetQuestion(Convert.ToInt32(CurrentSlide.Tags["questionId"]));
                ResultSlide.Add(allResults, question, CurrentSlide);
            }
        }

        private void ProcessSlide(PowerPoint.Slide slide) {
            Timer.Enabled = false;

            if (slide.Tags["isResultSlide"] == "1") {
                List<Result> allResults = DB.GetResultsByExamId(Convert.ToInt32(slide.Tags["examId"]));

                //int questionId = Convert.ToInt32(slide.Tags["questionId"]);
                Question question = DB.GetQuestion(Convert.ToInt32(slide.Tags["questionId"]));
                ResultSlide.Add(allResults, question, slide);
            }
            else if(slide.Tags["isResultSlide"] == "0") {
                Question question = DB.GetQuestion(Convert.ToInt32(slide.Tags["questionId"]));
                int seconds = (int)question.TimeRestriction.TotalSeconds;

                if (question.TimeRestriction != TimeSpan.Zero) {
                    if(slide.Tags["isClosed"] == "0") {
                        slide.Tags.Add("timeRestriction", seconds.ToString());

                        StartTimedSlide(slide, seconds);
                    }
                    else if(slide.Tags["isClosed"] == "1") {
                        foreach (PowerPoint.Shape shape in CurrentSlide.Shapes) {
                            if (shape.Tags["timer"] == "1") {
                                shape.Delete();
                            }
                        }

                        PowerPoint.Shape timerLabel = CurrentSlide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Width - 150, 10, 150, 100);
                        timerLabel.TextFrame.TextRange.InsertAfter("Gesloten");
                        timerLabel.TextFrame.TextRange.Font.Size = 28;
                        timerLabel.TextFrame.TextRange.Font.Color.RGB = BGR(Color.Red);
                        timerLabel.Tags.Add("timer", "1");
                    }
                }
            }

            if (slide.Tags != null && slide.Tags["questionId"] != null && slide.Tags["examId"] != null) {
                DL.Stop();
                DL.TrackedQuery = "SELECT [answer] FROM [dbo].[result] WHERE exam = " + slide.Tags["examId"] + " AND question = " + slide.Tags["questionId"];
                DL.Start();

                DB.UpdateExamCurrentQuestion(int.Parse(slide.Tags["examId"]), int.Parse(slide.Tags["questionId"]));
            }
        }

        public void StartTimedSlide(PowerPoint.Slide slide, int seconds) {
            int secondsPassed = 0;
            PowerPoint.Shape timerLabel = null;

            Timer.Interval = 1000;
            Timer.Tick += (t, args) => {
                PowerPoint.Slide CurrentSlide = slide;

                int secondsLeft = seconds - secondsPassed;
                foreach (PowerPoint.Shape shape in CurrentSlide.Shapes) {
                    if (shape.Tags["timer"] == "1") {
                        shape.Delete();
                    }
                }

                timerLabel = CurrentSlide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Width - 100, 10, 100, 100);
                timerLabel.TextFrame.TextRange.InsertAfter(secondsLeft.ToString());
                timerLabel.TextFrame.TextRange.Font.Size = 28;
                timerLabel.Tags.Add("timer", "1");

                if (secondsPassed == seconds) {
                    CurrentSlide.Tags.Add("isClosed", "1");
                    if (Globals.ThisAddIn.Application.ActivePresentation.Slides[CurrentSlide.SlideIndex + 1] != null) {
                        try {
                            Globals.ThisAddIn.Application.ActivePresentation.Slides[CurrentSlide.SlideIndex + 1].Select();
                        }
                        catch {
                            Globals.ThisAddIn.Application.SlideShowWindows[1].View.Next(); // Fullscreen
                            slide = Globals.ThisAddIn.Application.SlideShowWindows[1].View.Slide;
                        }
                    }
                    else {
                        MessageBox.Show("Geen volgende slide gevonden");
                    }

                    Timer.Enabled = false;
                }
                secondsPassed++;
            };
            Timer.Enabled = true;
        }

        private void Application_SlideShowNextSlide(PowerPoint.SlideShowWindow Wn) {  
            try {
                PowerPoint.Slide slide = Wn.View.Slide;
                CurrentSlide = slide;
                AttachTags(slide);
                ProcessSlide(slide);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void Application_SlideSelectionChanged(PowerPoint.SlideRange SldRange) {
            try {
                if(SldRange.Count > 0) {
                    PowerPoint.Slide slide = Application.ActivePresentation.Slides.FindBySlideID(SldRange.SlideID);
                    CurrentSlide = slide;
                    AttachTags(slide);
                    ProcessSlide(slide);
                }   
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AttachTags(PowerPoint.Slide slide) {
            if (slide.Tags["isResultSlide"].Length == 0)
                slide.Tags.Add("isResultSlide", "-1");

            if (slide.Tags["isClosed"].Length == 0)
                slide.Tags.Add("isClosed", "-1");

            if (slide.Tags["questionId"].Length == 0)
                slide.Tags.Add("questionId", "-1");

            if (slide.Tags["timeRestriction"].Length == 0)
                slide.Tags.Add("timeRestriction", "-1");

            if (slide.Tags["examId"].Length == 0) {
                Exam chosen = (Exam)Globals.Ribbons.Ribbon1.ddExams.SelectedItem.Tag;
                if (chosen != null) {
                    slide.Tags.Add("examId", chosen.Examnr.ToString());
                }
                else {
                    slide.Tags.Add("examId", "-1");
                }
            }
        }

        private int BGR(Color color) {
            // PowerPoint's color codes seem to be reversed (i.e., BGR) not RGB
            //      0x0000FF    produces RED not BLUE
            //      0xFF0000    produces BLUE not RED
            // so we have to produce the color "in reverse"

            int iColor = color.R + 0xFF * color.G + 0xFFFF * color.B;

            return iColor;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            Application.SlideSelectionChanged -= Application_SlideSelectionChanged;
            Application.SlideShowNextSlide -= Application_SlideShowNextSlide;
        }
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
