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

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            DB = new Database();
            Application.SlideSelectionChanged += Application_SlideSelectionChanged;
            Application.SlideShowNextSlide += Application_SlideShowNextSlide;
        }

        private void Application_SlideShowNextSlide(PowerPoint.SlideShowWindow Wn) {  
            try {
                PowerPoint.Slide slide = Wn.View.Slide;
                AttachTags(slide);

                //MessageBox.Show("Application_SlideShowNextSlide SlideId: " + slide.SlideID.ToString() + "ExamId: " + slide.Tags["examId"] + ", QuestionId: " + slide.Tags["questionId"]);

                if (slide.Tags != null && slide.Tags["questionId"] != null && slide.Tags["examId"] != null) {
                    DB.UpdateExamCurrentQuestion(int.Parse(slide.Tags["examId"]), int.Parse(slide.Tags["questionId"]));
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void Application_SlideSelectionChanged(PowerPoint.SlideRange SldRange) {
            try {
                if(SldRange.Count > 0) {
                    PowerPoint.Slide slide = Application.ActivePresentation.Slides.FindBySlideID(SldRange.SlideID);
                    AttachTags(slide);

                    //MessageBox.Show("Application_SlideSelectionChanged SlideId: " + SldRange.SlideID.ToString() + "ExamId: " + slide.Tags["examId"] + ", QuestionId: " + slide.Tags["questionId"]);

                    if (slide.Tags != null && slide.Tags["questionId"] != null && slide.Tags["examId"] != null) {
                        DB.UpdateExamCurrentQuestion(int.Parse(slide.Tags["examId"]), int.Parse(slide.Tags["questionId"]));
                    }
                }   
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AttachTags(PowerPoint.Slide slide) {
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
