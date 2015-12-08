using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Tools.Ribbon;
using Office = Microsoft.Office.Core;
using PetjeOp;
using System.Drawing;
using System.Windows.Forms;

namespace PetjeOpPowerPoint
{
    public partial class Ribbon1
    {
        private Database DB;

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            DB = new Database();

         

            // functie voor vullen dropdown afnamemomenten
            
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem emptyExams = this.Factory.CreateRibbonDropDownItem();
            // Er wordt een leeg record aangemaakt bovenaan de dropdown lijst
            emptyExams.Label = null;
            ddExams.Items.Add(emptyExams);

            // Vul de rest van de dropdown lijst met afnamemomenten uit de database
            List<Exam> exams = DB.GetExams();

            foreach (Exam x in exams)
            {
                Microsoft.Office.Tools.Ribbon.RibbonDropDownItem exam = this.Factory.CreateRibbonDropDownItem();
                exam.Label = "AFNAMEMOMENT: " + x.questionnaire.Name + ", VAK: " + x.questionnaire.Subject +  ", STARTTIJD: " +  Convert.ToString(x.starttime) + ", EINDTIJD: " + Convert.ToString(x.endtime);
                ddExams.Items.Add(exam);
                
                int index = ddExams.Items.IndexOf(exam);
                ddExams.Items[index].Tag = x;              
            }
            //////
        }

        //private void btnViewResultsPPT_Click(object sender, RibbonControlEventArgs e)
        //{
        //    double barHeight = 300;

        //    double percentage1 = 1.00;
        //    double barHeight1 = barHeight * percentage1;

        //    double percentage2 = 0.60;
        //    double barHeight2 = barHeight * percentage2;

        //    double percentage3 = 0.80;
        //    double barHeight3 = barHeight * percentage3;

        //    PowerPoint.Slide currentSld = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Slides.Count + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);

        //    PowerPoint.Shape shape = currentSld.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 10, 10, 100, Convert.ToInt32(barHeight1));
        //    PowerPoint.Shape shape1 = currentSld.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 120, 10 + 300 - (int)barHeight2, 100, Convert.ToInt32(barHeight2));

        //    PowerPoint.Shape shape2 = currentSld.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 230, 10 + 300 - (int)barHeight3, 100, Convert.ToInt32(barHeight3));
        //}

       
        private void ddQuestions_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            if (ddQuestions.SelectedItemIndex != 0)
            {
                // Dit wordt aangeroepen wanneer er op een question wordt geklikt
                Exam chosen = (Exam)ddExams.SelectedItem.Tag;
                Question question = (Question)ddQuestions.SelectedItem.Tag;
                PowerPoint.Slide currentSld = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Slides.Count + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);
                PowerPoint.Shape textBox = currentSld.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 200, 100, 500, 50);
                
                textBox.TextFrame.TextRange.InsertAfter(question.Description);
                textBox.TextFrame.TextRange.Font.Size = 30;
                textBox.TextFrame.TextRange.InsertAfter("\n\n");

                currentSld.Tags.Add("questionId", question.ID.ToString());
                currentSld.Tags.Add("examId", chosen.Examnr.ToString());
                string answers = GetFormattedAnswers(question.ID);

                textBox.TextFrame.TextRange.InsertAfter(answers);

                PowerPoint.Shape winQWatermark = currentSld.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Width - 100, Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Height - 50, 100, 100);
                winQWatermark.TextFrame.TextRange.InsertAfter("Toegevoegd door WinQ plugin v1.0");
                winQWatermark.TextFrame.TextRange.Font.Size = 10;
            }
        }

        public string GetFormattedAnswers(int questionId) {
            List<Answer> listAnswers = DB.GetAnswersByQuestion(questionId);

            StringBuilder answerString = new StringBuilder();
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int index = 0;
            foreach (Answer answer in listAnswers) {
                answerString.Append(alphabet[index] + ": " + answer.Description + (char)13);
                index++;
            }

            if (answerString.Length == 0)
                answerString.Append("Error: geen antwoorden gevonden");

            return answerString.ToString();
        }

        // Dit wordt aangeroepen wanneer er op een afnamemoment is geklikt
        private void ddExams_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            // Button 'alle vragen toevoegen' wordt tijdelijk onzichtbaar totdat het programma weet dat er een afnamemoment is gekozen, en niet een leeg record
            btnAllQuestions.Visible = false;
            ddQuestions.Items.Clear();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem emptyQuestions = this.Factory.CreateRibbonDropDownItem();

            emptyQuestions.Label = null;
            ddQuestions.Items.Add(emptyQuestions);

            if (ddExams.SelectedItemIndex != 0)
            {
                // functie voor vullen dropdown vragen
                
                // hier wordt de knop voor het toevoegen van alle vragen pas zichtbaar
                btnAllQuestions.Visible = true;

                Exam chosen = (Exam)ddExams.SelectedItem.Tag;
            
                Questionnaire testquest = DB.GetQuestionnaire(chosen.questionnaire.ID);

                foreach (Question q in testquest.Questions)
                {
                    Microsoft.Office.Tools.Ribbon.RibbonDropDownItem question = this.Factory.CreateRibbonDropDownItem();
                    question.Label = q.Description;
                    ddQuestions.Items.Add(question);
                    int index = ddQuestions.Items.IndexOf(question);
                    ddQuestions.Items[index].Tag = q;
                }
            }
        }

        // dit is de functionaliteit achter de knop 'Alle vragen toevoegen'
        private void btnAllQuestions_Click(object sender, RibbonControlEventArgs e)
        {
            Exam chosen = (Exam)ddExams.SelectedItem.Tag;
            Questionnaire testquest = DB.GetQuestionnaire(chosen.questionnaire.ID);
            foreach (Question q in testquest.Questions)
            {
                PowerPoint.Slide currentSld = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Slides.Count + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);
                PowerPoint.Shape textBox = currentSld.Shapes.AddTextbox(
                Office.MsoTextOrientation.msoTextOrientationHorizontal, 200, 100, 500, 50);
                textBox.TextFrame.TextRange.InsertAfter(q.Description);
                textBox.TextFrame.TextRange.Font.Size = 30;

                textBox.TextFrame.TextRange.InsertAfter("\n\n");

                currentSld.Tags.Add("questionId", q.ID.ToString());
                currentSld.Tags.Add("examId", chosen.Examnr.ToString());
                string answers = GetFormattedAnswers(q.ID);
                textBox.TextFrame.TextRange.InsertAfter(answers);

                PowerPoint.Shape winQWatermark = currentSld.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Width - 100, Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Height - 50, 100, 100);
                winQWatermark.TextFrame.TextRange.InsertAfter("Toegevoegd door WinQ plugin v1.0");
                winQWatermark.TextFrame.TextRange.Font.Size = 10;
            }
        }
    }
}
