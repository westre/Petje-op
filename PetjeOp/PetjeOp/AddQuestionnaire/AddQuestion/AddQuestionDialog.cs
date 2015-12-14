using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp.AddQuestionnaire.AddQuestion
{
    public partial class AddQuestionDialog : Form
    {
        public MultipleChoiceQuestion Question { get; set; }
        public List<Answer> answers = new List<Answer>();
        public Answer correct;
        //public AddQuestionnaireController Controller { get; set; }
        private int QuestionIndex { get; }
        public QuestionsView QuestionsView { get; set; }

        /*Constructor voor het toevoegen van een vraag
        public AddQuestionDialog(AddQuestionnaireController controller)
        {
            InitializeComponent();
            addQuestionView1.SetQuestionDialog(this);
            Controller = controller;
            QuestionIndex = 0;
        } */

        public AddQuestionDialog(QuestionsView qv)
        {
            InitializeComponent();
            addQuestionView1.SetQuestionDialog(this);
            QuestionsView = qv;
            QuestionIndex = 0;
        }

        /*Constructor voor het wijzigen van een vraag
        public AddQuestionDialog(AddQuestionnaireController controller, MultipleChoiceQuestion question,
            int questionIndex) : this(controller)
        {
            QuestionIndex = questionIndex;
            Question = question;
            Text = btnAddQuestion.Text = "Vraag Wijzigen";
        } */

        //Constructor voor het wijzigen van een vraag
        public AddQuestionDialog(QuestionsView qv, MultipleChoiceQuestion question,
            int questionIndex) : this(qv)
        {
            QuestionIndex = questionIndex;
            Question = question;
            Text = btnAddQuestion.Text = "Vraag Wijzigen";
        }

        //Functie voor afhandeling van klik op 'Vraag Toevoegen'
        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            //Maak het vraagobject aan
            Question = new MultipleChoiceQuestion(addQuestionView1.tbQuestion.Text);

            //Loop voor alle ingevoerde antwoorden
            foreach (var item in addQuestionView1.clbAnswers.Items)
            {
                // Check of het antwoord al in de database bestaat
                /*Answer ans = Controller.MasterController.DB.GetAnswer(item.ToString());
                if(ans == null) {
                    // Het bestaat niet :(, dus maken we een nieuwe record aan!
                    ans = Controller.MasterController.DB.AddAnswer(item.ToString());
                }*/

                //Maak een antwoordobject aan
                Answer ans = new Answer(item.ToString());

                //Voeg het antwoord toe aan de lijst met antwoorden
                answers.Add(ans);

                //Controleer of het antwoord het correcte antwoord is
                if (addQuestionView1.clbAnswers.CheckedItems.Contains(item))
                {
                    //Stel het correcte antwoord gelijk aan het huidge antwoord in de loop
                    correct = ans;
                }
            }

            //Voeg antwoorden toe aan het vraagobject
            Question.AddAnswerOptions(answers);

            //Voeg correct antwoord toe aan het vraagobject
            Question.CorrectAnswer = correct;

            //Voeg tijdsrestrictie toe aan vraag
            if (addQuestionView1.rbLimit.Checked)
            {
                try
                {
                    int seconds = int.Parse(addQuestionView1.tbSeconds.Text);
                    Question.TimeRestriction = new TimeSpan(0, 0, seconds);
                }
                catch (FormatException fe)
                {
                    Question.TimeRestriction = TimeSpan.Zero;
                }
            }
            else
            {
                Question.TimeRestriction = TimeSpan.Zero;
            }

            //Controleer of QuestionIndex 0 is
            if (QuestionIndex != 0)
            {
                //Nee, de Question index moet gelijk zijn aan de meegegeven index
                Question.QuestionIndex = QuestionIndex;
            }
            else
            {
                //Ja, er wordt een nieuwe index gegenereerd
                //Question.QuestionIndex = QuestionsView.Questionnaire.Questions.Count + 1;
                if (QuestionsView.ParentController is AddQuestionnaireController)
                {
                    Question.QuestionIndex =
                        ((AddQuestionnaireController) QuestionsView.ParentController).Model.Questionnaire.Questions
                            .Count + 1;
                }
                else
                {
                     Question.QuestionIndex =
                        ((QuestionnaireDetailController)QuestionsView.ParentController).Model.Questionnaire.Questions
                            .Count + 1;
                }
            }

            // Maak nieuwe question record aan in tabel
            //MultipleChoiceQuestion dbQuestion = Controller.MasterController.DB.AddMultipleChoiceQuestion(Question, Controller.Model.Questionnaire.ID);

            // Update lokale Question variabel met ID van DBQuestion
            //Question.ID = dbQuestion.ID;

            // Nu kunnen we er door heen loopen aangezien we nu een ID hebben van Question
            //foreach(Answer answer in answers) {
                // DB link
            //    Controller.MasterController.DB.LinkAnswerToQuestion(dbQuestion, answer);
            //}

            //Sluit het dialoog
            Close();
        }

        //Afhandeling annuleerknop
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Sluit dialoog
            Close();
        }

        //Wanneer dialoog sluit
        private void AddQuestionDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Check of QuestionIndex 0 is. Zo ja, update TreeView anders niet
            bool update = !(QuestionIndex != 0);

            if(Question != null && this.DialogResult == DialogResult.OK)
                QuestionsView.AddDialogInformation(Question, update);


        }
        
        //Wanneer dialoog laadt
        private void AddQuestionDialog_Load(object sender, EventArgs e)
        {
            //Stel kleur in voor errors
            addQuestionView1.lblNonSufficientAnswers.ForeColor = Color.Red;

            //Controleer of er een vraagobject is meegegeven
            if (Question != null)
            {
                //Vul tekstbox met vraag
                addQuestionView1.tbQuestion.Text = Question.Description;

                //Vul CheckedListBox met antwoorden
                foreach (Answer a in Question.AnswerOptions)
                {
                    int addedIndex = addQuestionView1.clbAnswers.Items.Add(a.Description);

                    if (a.Equals(Question.CorrectAnswer))
                    {
                        //Vink correct antwoord aan
                        addQuestionView1.clbAnswers.SetItemChecked(addedIndex, true);
                    }
                }

                //Stel tijdslimiet in
                if (Question.TimeRestriction != TimeSpan.Zero)
                {
                    addQuestionView1.rbLimit.Checked = true;
                    addQuestionView1.tbSeconds.Text = Question.TimeRestriction.TotalSeconds.ToString();
                }
            }

            if (Question != null)
            {
                //Valideer gegevens
                //addQuestionView1.checkQuestionView();
            }
        }
    }
}