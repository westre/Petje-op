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
        // Voor database acties
        private Database DB { get; set; }
        
        // Voor het afhandelen van dynamische resultaten
        private DatabaseListener DL { get; set; }

        // Zodat we makkelijk de slide kunnen achterhalen
        public PowerPoint.Slide CurrentSlide { get; set; }

        // Voor vragen met tijdsrestrictie
        public Timer Timer { get; set; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            DB = new Database();
            // Wanneer er op een andere slide wordt geklikt, vuur event
            Application.SlideSelectionChanged += Application_SlideSelectionChanged;
            // Wanneer er in fullscreen naar een andere slide, vuur slide
            Application.SlideShowNextSlide += Application_SlideShowNextSlide;

            DL = new DatabaseListener();
            DL.OnChange += DL_OnChange;

            Timer = new Timer();
        }

        private void DL_OnChange(System.Data.SqlClient.SqlNotificationEventArgs eventArgs) {
            if(CurrentSlide != null && CurrentSlide.Tags["isResultSlide"] == "1") {
                // Haal alle resultaten op die bij deze examen hoort
                List<Result> allResults = DB.GetResultsByExamId(Convert.ToInt32(CurrentSlide.Tags["examId"]));

                // Hall question object
                Question question = DB.GetQuestion(Convert.ToInt32(CurrentSlide.Tags["questionId"]));

                // Voeg resultaat toe aan slide
                ResultSlide.Add(allResults, question, CurrentSlide);
            }
        }

        // Dit wordt geroepen wanneer er van slide wordt veranderd
        private void ProcessSlide(PowerPoint.Slide slide) {
            Timer.Stop();

            // Is het een resultaten dia?
            if (slide.Tags["isResultSlide"] == "1") {
                // Haal eerst alle resultaten op
                List<Result> allResults = DB.GetResultsByExamId(Convert.ToInt32(slide.Tags["examId"]));

                // Haal dan de vraag op
                Question question = DB.GetQuestion(Convert.ToInt32(slide.Tags["questionId"]));

                // Doe een request in combinatie met exam en questio
                ResultSlide.Add(allResults, question, slide);
            }
            // Is het een vraag dia?
            else if(slide.Tags["isResultSlide"] == "0") {
                // Haal question object op
                Question question = DB.GetQuestion(Convert.ToInt32(slide.Tags["questionId"]));

                // Tijdsrestrictie variabel
                int seconds = (int)question.TimeRestriction.TotalSeconds;

                // Heeft de vraag in kwestie een tijdsrestrictie?
                if (question.TimeRestriction != TimeSpan.Zero) {
                    // De vraag is niet gesloten
                    if(slide.Tags["isClosed"] == "0") {
                        // Voeg een tag toe om het makkelijker te maken
                        slide.Tags.Add("timeRestriction", seconds.ToString());

                        // Start de timer
                        StartTimedSlide(slide, seconds);
                    }
                    // De vraag is gesloten
                    else if(slide.Tags["isClosed"] == "1") {
                        // Verwijder timer label
                        foreach (PowerPoint.Shape shape in CurrentSlide.Shapes) {
                            if (shape.Tags["timer"] == "1") {
                                shape.Delete();
                            }
                        }

                        // Voeg een gesloten label toe
                        PowerPoint.Shape timerLabel = CurrentSlide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Width - 150, 10, 150, 100);
                        timerLabel.TextFrame.TextRange.InsertAfter("Gesloten");
                        timerLabel.TextFrame.TextRange.Font.Size = 28;
                        timerLabel.TextFrame.TextRange.Font.Color.RGB = BGR(Color.Red);
                        timerLabel.Tags.Add("timer", "1");
                    }
                }
            }

            // Resultaat updaten
            if (slide.Tags != null && slide.Tags["questionId"] != null && slide.Tags["examId"] != null) {
                DL.Stop();
                DL.TrackedQuery = "SELECT [answer] FROM [dbo].[result] WHERE exam = " + slide.Tags["examId"] + " AND question = " + slide.Tags["questionId"];
                DL.Start();

                // Zeg tegen de database dat we op een andere current question zitten, zodat de studentenomgeving ook wordt geupdatet
                DB.UpdateExamCurrentQuestion(int.Parse(slide.Tags["examId"]), int.Parse(slide.Tags["questionId"]));
            }
        }

        // Dit wordt geroepen wanneer een dia/vraag een tijdsrestrictie heeft
        public void StartTimedSlide(PowerPoint.Slide slide, int seconds) {
            int secondsPassed = 0;
            PowerPoint.Shape timerLabel = null;

            // Timer draait per seconde
            Timer = new Timer();
            Timer.Interval = 1000;
            Timer.Tick += (t, args) => {
                PowerPoint.Slide CurrentSlide = slide;

                int secondsLeft = seconds - secondsPassed;

                // Update tijd label
                foreach (PowerPoint.Shape shape in CurrentSlide.Shapes) {
                    if (shape.Tags["timer"] == "1") {
                        shape.Delete();
                    }
                }

                // Update tijd label
                timerLabel = CurrentSlide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Width - 100, 10, 100, 100);
                timerLabel.TextFrame.TextRange.InsertAfter(secondsLeft.ToString());
                timerLabel.TextFrame.TextRange.Font.Size = 28;
                timerLabel.Tags.Add("timer", "1");

                // Tijd is op
                if (secondsPassed == seconds) {
                    // Verander de tag en zeg dat het gesloten is
                    CurrentSlide.Tags.Add("isClosed", "1");
                    // Check of er een dia na onze dia bestaat
                    if (Globals.ThisAddIn.Application.ActivePresentation.Slides[CurrentSlide.SlideIndex + 1] != null) {
                        try {
                            // Dit is voor normale view
                            Globals.ThisAddIn.Application.ActivePresentation.Slides[CurrentSlide.SlideIndex + 1].Select();
                        }
                        catch {
                            // Dit is voor fullscreen view
                            Globals.ThisAddIn.Application.SlideShowWindows[1].View.Next();
                            slide = Globals.ThisAddIn.Application.SlideShowWindows[1].View.Slide;
                        }
                    }
                    // Er komt geen dia na onze dia
                    else {
                        MessageBox.Show("Geen volgende slide gevonden");
                    }

                    // Stop de timer, aangezien het toch al klaar is
                    Timer.Stop();
                }
                secondsPassed++;
            };

            // Start de timer!
            Timer.Start();
        }

        // Event voor volgende slide in fullscreen
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

        // Event voor andere slide in overview screen
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

        // Dit wordt geroepen wanneer er van slide is veranderd
        private void AttachTags(PowerPoint.Slide slide) {
            // isResultSlide == -1, geen functionaliteit
            // isResultSlide == 0, vraag slide
            // isResultSlide == 1, resultaten slide
            if (slide.Tags["isResultSlide"].Length == 0)
                slide.Tags.Add("isResultSlide", "-1");

            // isClosed == -1, geen functionaliteit
            // isClosed == 0, vraag slide, niet gesloten
            // isClosed == 1, vraag slide, gesloten
            if (slide.Tags["isClosed"].Length == 0)
                slide.Tags.Add("isClosed", "-1");

            // Default waarde
            if (slide.Tags["questionId"].Length == 0)
                slide.Tags.Add("questionId", "-1");

            // Default waarde
            if (slide.Tags["timeRestriction"].Length == 0)
                slide.Tags.Add("timeRestriction", "-1");

            // Default waarde
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
