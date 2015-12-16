using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using PetjeOp;
using System.Windows.Forms;

namespace PetjeOpPowerPoint
{
    public partial class ThisAddIn
    {
        private Database DB { get; set; }
        private DatabaseListener DL { get; set; }
        public PowerPoint.Slide CurrentSlide { get; set; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            DB = new Database();
            Application.SlideSelectionChanged += Application_SlideSelectionChanged;
            Application.SlideShowNextSlide += Application_SlideShowNextSlide;

            DL = new DatabaseListener();
            DL.OnChange += DL_OnChange;
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
            if (slide.Tags["isResultSlide"] == "1") {
                List<Result> allResults = DB.GetResultsByExamId(Convert.ToInt32(slide.Tags["examId"]));

                //int questionId = Convert.ToInt32(slide.Tags["questionId"]);
                Question question = DB.GetQuestion(Convert.ToInt32(slide.Tags["questionId"]));
                ResultSlide.Add(allResults, question, slide);
            }

            if (slide.Tags != null && slide.Tags["questionId"] != null && slide.Tags["examId"] != null) {
                DL.Stop();
                DL.TrackedQuery = "SELECT [answer] FROM [dbo].[result] WHERE exam = " + slide.Tags["examId"] + " AND question = " + slide.Tags["questionId"];
                DL.Start();

                DB.UpdateExamCurrentQuestion(int.Parse(slide.Tags["examId"]), int.Parse(slide.Tags["questionId"]));
            }
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

            if (slide.Tags["questionId"].Length == 0)
                slide.Tags.Add("questionId", "-1");

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
