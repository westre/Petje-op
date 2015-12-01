using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire;
using System.Collections.Generic;

namespace PetjeOp.Questionnaires
{
    public class QuestionnaireOverviewController : Controller
    {
        public QuestionnaireOverviewView View { get; set; }
        public QuestionnaireOverviewModel Model { get; set; }

        public QuestionnaireOverviewController(MasterController masterController) : base(masterController) {
            Model = new QuestionnaireOverviewModel();
            View = new QuestionnaireOverviewView(this);
        }

        public override UserControl GetView()
        {
            return View;
        }

        //Verander scherm naar AddQuestionnaire
        public void GoToAddQuestionnaire()
        {
            AddQuestionnaireController aqc = (AddQuestionnaireController)MasterController.GetController(typeof(AddQuestionnaireController));
            MasterController.SetController(aqc);
        }

        //Vraag alle Questionnaires en Subjects op
        public void GetAllQuestionnairesAndSubjects()
        {
            //Toon LoadingDialog
            LoadingDialog l = new LoadingDialog();
            l.Show();
            Application.DoEvents();

            //Vraag Questionnaires op
            Model.Questionnaires = MasterController.DB.GetAllQuestionnaires();

            //Vraag Subjects op
            Model.Subjects = MasterController.DB.GetSubjects();

            //Verberg LoadingDialog
            l.Hide();
        }

        //Vul de TreeView met gegevens
        public void FillTreeView()
        {
            //TreeView leegmaken
            View.tvQuestionnaires.Nodes.Clear();

            //Loop over Questionnaires
            foreach (Questionnaire questionnaire in Model.Questionnaires)
            {
                //Voeg Node toe
                TreeNode questionnaireTreeNode = View.tvQuestionnaires.Nodes.Add(questionnaire.Name + " (" + questionnaire.Subject + ")");
                questionnaireTreeNode.Tag = questionnaire;

                //Loop over Questions
                foreach (MultipleChoiceQuestion question in questionnaire.Questions)
                {
                    //Voeg Node toe
                    TreeNode questionTreeNode =
                        questionnaireTreeNode.Nodes.Add(question.QuestionIndex + ": " + question.Description);
                    questionTreeNode.Tag = question;

                    //Loop over Answers
                    foreach (Answer answer in question.AnswerOptions)
                    {
                        //Check of antwoord correct antwoord is
                        if (answer.ID == question.CorrectAnswer.ID)
                        {
                            TreeNode addedAnswer = questionTreeNode.Nodes.Add(question.CorrectAnswer.Description);
                            addedAnswer.Tag = answer;
                            addedAnswer.ForeColor = Color.Green;
                        }
                        else
                        {
                            TreeNode addedAnswer = questionTreeNode.Nodes.Add(answer.Description);
                            addedAnswer.Tag = answer;
                            addedAnswer.ForeColor = Color.Red;
                        }
                    }
                }
            }

            //Sorteer Nodes alfabetisch
            View.tvQuestionnaires.Sort();
        }

        //Vul ComboBox met Subjects
        public void FillSubjects()
        {
            //Maak ComboBox leeg
            View.cbSubjects.Items.Clear();

            //Voeg item toe om alle vakken te laden
            View.cbSubjects.Items.Add("Alle Vakken");

            //Loop over Subjects
            foreach (Subject s in Model.Subjects)
            {
                //Subject toevoegen
                View.cbSubjects.Items.Add(s);
            }

            //Selecteer eerste index
            View.cbSubjects.SelectedIndex = 0;
        }

        //Filter de Questionnaires
        public void FilterQuestionnaires(Subject s)
        {
            //Maak nieuwe List
            List<Questionnaire> newList = new List<Questionnaire>();

            //Loop over Questionnaires
            foreach (Questionnaire q in Model.Questionnaires)
            {
                //Als SubjectID van Questonnair gelijk is aan ID van gekozen Subject
                if (q.Subject.Id == s.Id)
                    //Voeg toe aan nieuwe List
                    newList.Add(q);
            }

            //Vervang oude list door nieuwe List
            Model.Questionnaires = newList;
        }
    }
}
