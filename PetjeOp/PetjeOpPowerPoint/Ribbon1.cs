using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Excel = Microsoft.Office.Interop.Excel;
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
        public List<Exam> exams;

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            DB = new Database();

            // functie voor vullen dropdown afnamemomenten
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem emptyExams = this.Factory.CreateRibbonDropDownItem();
            // Er wordt een leeg record aangemaakt bovenaan de dropdown lijst
            emptyExams.Label = null;
            ddExams.Items.Add(emptyExams);
            // Vul de rest van de dropdown lijst met afnamemomenten uit de database
            exams = DB.GetAllExams();

            foreach (Exam x in exams)
            {
                Microsoft.Office.Tools.Ribbon.RibbonDropDownItem exam = this.Factory.CreateRibbonDropDownItem();
                exam.Label = "AFNAMEMOMENT: " + x.Questionnaire.Name + ", VAK: " + x.Questionnaire.Subject +  ", STARTTIJD: " +  Convert.ToString(x.Starttime) + ", EINDTIJD: " + Convert.ToString(x.Endtime);
                ddExams.Items.Add(exam);
                
                int index = ddExams.Items.IndexOf(exam);
                ddExams.Items[index].Tag = x;              
            }


            List<Subject> subjects = DB.GetSubjects();
            RibbonDropDownItem empty = Factory.CreateRibbonDropDownItem();
            empty.Label = "Alles";
            empty.Tag = null;
            ddFilterVak.Items.Add(empty);

            foreach (Subject subject in subjects) {
                RibbonDropDownItem ribbonSubject = Factory.CreateRibbonDropDownItem();
                ribbonSubject.Label = subject.Name;
                ribbonSubject.Tag = subject;
                ddFilterVak.Items.Add(ribbonSubject);
            }
        }
       
        private void ddQuestions_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            if (ddQuestions.SelectedItemIndex != 0)
            {
                // Dit wordt aangeroepen wanneer er op een question wordt geklikt
                Exam chosen = (Exam)ddExams.SelectedItem.Tag;
                Question question = (Question)ddQuestions.SelectedItem.Tag;

                // Haal alle resultaten op die bij deze examen hoort
                List<Result> allResults = DB.GetResultsByExamId(chosen.Examnr);
                PowerPoint.Slide currentSld = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Slides.Count + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);
                PowerPoint.Shape textBox = currentSld.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 200, 100, 500, 50);
                
                textBox.TextFrame.TextRange.InsertAfter(question.Description);
                textBox.TextFrame.TextRange.Font.Size = 30;
                textBox.TextFrame.TextRange.InsertAfter("\n\n");

                currentSld.Tags.Add("isResultSlide", "0");
                currentSld.Tags.Add("questionId", question.ID.ToString());
                currentSld.Tags.Add("examId", chosen.Examnr.ToString());
                currentSld.Tags.Add("isClosed", "0");
                string answers = GetFormattedAnswers(question.ID);

                textBox.TextFrame.TextRange.InsertAfter(answers);

                //PowerPoint.Shape winQWatermark = currentSld.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Width - 100, Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Height - 50, 100, 100);
                //winQWatermark.TextFrame.TextRange.InsertAfter("Toegevoegd door WinQ plugin v1.0");
                //winQWatermark.TextFrame.TextRange.Font.Size = 10;

                // volgende slide
                PowerPoint.Slide resultSlide = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Slides.Count + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);
                resultSlide.Tags.Add("isResultSlide", "1");
                resultSlide.Tags.Add("questionId", question.ID.ToString());
                resultSlide.Tags.Add("examId", chosen.Examnr.ToString());

                //ResultSlide.Add(allResults, question.ID, resultSlide);
                ResultSlide.Add(allResults, question, resultSlide);
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
            // Ook hier wordt een leeg record aangemaakt bovenaan de dropdown lijst
            emptyQuestions.Label = null;
            ddQuestions.Items.Add(emptyQuestions);

            if (ddExams.SelectedItemIndex != 0)
            {
                // functie voor vullen dropdown vragen
                // hier wordt de knop voor het toevoegen van alle vragen pas zichtbaar
                btnAllQuestions.Visible = true;
                // Het programma kijkt welk afnamemoment geselecteerd is en vult dan de vragenlijst met vragen in dat afnamemoment
                Exam chosen = (Exam)ddExams.SelectedItem.Tag;
                Questionnaire testquest = DB.GetQuestionnaire(chosen.Questionnaire.ID);

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
                Questionnaire questionnaire = DB.GetQuestionnaire(chosen.Questionnaire.ID);

                // Haal alle resultaten op die bij deze examen hoort
                List<Result> allResults = DB.GetResultsByExamId(chosen.Examnr);

                foreach (Question q in questionnaire.Questions)
                {
                    PowerPoint.Slide questionSlide = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Slides.Count + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);
                    PowerPoint.Shape questionTextBox = questionSlide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, 200, 100, 500, 50);

                    questionTextBox.TextFrame.TextRange.InsertAfter(q.Description);
                    questionTextBox.TextFrame.TextRange.Font.Size = 30;
                    questionTextBox.TextFrame.TextRange.InsertAfter("\n\n");

                    questionSlide.Tags.Add("isResultSlide", "0");
                    questionSlide.Tags.Add("questionId", q.ID.ToString());
                    questionSlide.Tags.Add("examId", chosen.Examnr.ToString());
                    questionSlide.Tags.Add("isClosed", "0");

                    string answers = GetFormattedAnswers(q.ID);
                    questionTextBox.TextFrame.TextRange.InsertAfter(answers);

                    PowerPoint.Shape winQWatermark = questionSlide.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Width - 100, Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.Height - 50, 100, 100);
                    winQWatermark.TextFrame.TextRange.InsertAfter("Toegevoegd door WinQ plugin v1.0");
                    winQWatermark.TextFrame.TextRange.Font.Size = 10;

                    // volgende slide
                    PowerPoint.Slide resultSlide = Globals.ThisAddIn.Application.ActivePresentation.Slides.Add(Globals.ThisAddIn.Application.ActivePresentation.Slides.Count + 1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);
                    resultSlide.Tags.Add("isResultSlide", "1");
                    resultSlide.Tags.Add("questionId", q.ID.ToString());
                    resultSlide.Tags.Add("examId", chosen.Examnr.ToString());

                    //ResultSlide.Add(allResults, q.ID, resultSlide);
                    ResultSlide.Add(allResults, q, resultSlide);
                }
            
        }

        private void btnSlideInfo_Click(object sender, RibbonControlEventArgs e) {
            PowerPoint.Slide CurrentSlide = Globals.ThisAddIn.CurrentSlide;

            if (CurrentSlide != null) {
                string info = "";

                if (CurrentSlide.Tags["isResultSlide"] == "0") {
                    info += "Dit is een vraag slide\n";
                }
                else if (CurrentSlide.Tags["isResultSlide"] == "1") {
                    info += "Dit is een resultaten slide\n";
                }
                else {
                    info += "Dit is een kale slide\n";
                }

                if(CurrentSlide.Tags["questionId"] != "-1")
                    info += "Vraag ID: " + CurrentSlide.Tags["questionId"] + "\n";
                else
                    info += "Vraag ID: n.v.t.\n";

                if (CurrentSlide.Tags["examId"] != "-1")
                    info += "Afnamemoment ID: " + CurrentSlide.Tags["examId"] + "\n";
                else
                    info += "Afnamemoment ID: n.v.t.\n";

                if (CurrentSlide.Tags["timeRestriction"] != "-1")
                    info += "Tijdsrestrictie: " + CurrentSlide.Tags["timeRestriction"] + "s";
                else
                    info += "Tijdsrestrictie: n.v.t.";

                MessageBox.Show(info);
            }
        }

        private void btnReset_Click(object sender, RibbonControlEventArgs e) {
            PowerPoint.Slide CurrentSlide = Globals.ThisAddIn.CurrentSlide;

            if (CurrentSlide.Tags["isResultSlide"] == "0") {
                DB.DeleteResults(int.Parse(CurrentSlide.Tags["examId"]), int.Parse(CurrentSlide.Tags["questionId"]));

                if (CurrentSlide.Tags["isClosed"] == "1" && CurrentSlide.Tags["timeRestriction"] != "-1") {
                    Globals.ThisAddIn.StartTimedSlide(CurrentSlide, int.Parse(CurrentSlide.Tags["timeRestriction"]));
                }
                else if (CurrentSlide.Tags["isClosed"] == "1" && CurrentSlide.Tags["timeRestriction"] == "-1") {
                    // Update tijd label
                    foreach (PowerPoint.Shape shape in CurrentSlide.Shapes) {
                        if (shape.Tags["timer"] == "1") {
                            shape.Delete();
                        }
                    }
                }
            }
        }

        // Wordt nu niet gebruikt
        private void btnStartTimer_Click(object sender, RibbonControlEventArgs e) {
            RibbonButton button = (RibbonButton)sender;
            button.Enabled = false;

            Timer timer = new Timer();
            timer.Interval = (int)button.Tag * 1000;
            timer.Tick += (t, args) => {
                PowerPoint.Slide CurrentSlide = Globals.ThisAddIn.CurrentSlide;

                if(Globals.ThisAddIn.Application.ActivePresentation.Slides[CurrentSlide.SlideIndex + 1] != null) {
                    Globals.ThisAddIn.Application.ActivePresentation.Slides[CurrentSlide.SlideIndex + 1].Select();
                }
                else {
                    MessageBox.Show("Geen volgende slide gevonden");
                }
                
                timer.Enabled = false;
                button.Enabled = true;
            };
            timer.Enabled = true;
        }

        private void ddFilterVak_SelectionChanged(object sender, RibbonControlEventArgs e) {
            // Button 'alle vragen toevoegen' wordt tijdelijk onzichtbaar totdat het programma weet dat er een afnamemoment is gekozen, en niet een leeg record
            ddExams.Items.Clear();
            ddQuestions.Items.Clear();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem emptyQuestions = this.Factory.CreateRibbonDropDownItem();
            emptyQuestions.Label = null;
            ddQuestions.Items.Add(emptyQuestions);
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem emptyExam = this.Factory.CreateRibbonDropDownItem();
            // Ook hier wordt een leeg record aangemaakt bovenaan de dropdown lijst
            emptyExam.Label = null;
            ddExams.Items.Add(emptyExam);

            Subject chosen = (Subject)ddFilterVak.SelectedItem.Tag;
            if(chosen != null) {
                foreach (Exam exam in exams) {
                    if (chosen.Id == exam.Questionnaire.Subject.Id) {
                        RibbonDropDownItem examRibbon = this.Factory.CreateRibbonDropDownItem();
                        examRibbon.Label = "AFNAMEMOMENT: " + exam.Questionnaire.Name + ", STARTTIJD: " + Convert.ToString(exam.Starttime) + ", EINDTIJD: " + Convert.ToString(exam.Endtime);
                        examRibbon.Tag = exam;
                        ddExams.Items.Add(examRibbon);
                    }
                }
            }
            else {
                foreach (Exam exam in exams) {
                    RibbonDropDownItem examRibbon = this.Factory.CreateRibbonDropDownItem();
                    examRibbon.Label =  "AFNAMEMOMENT: " + exam.Questionnaire.Name + ", VAK: " + exam.Questionnaire.Subject
                                        + ", STARTTIJD: " + Convert.ToString(exam.Starttime) + ", EINDTIJD: " + Convert.ToString(exam.Endtime);
                    examRibbon.Tag = exam;
                    ddExams.Items.Add(examRibbon);
                }
            }
        }
    }
}
