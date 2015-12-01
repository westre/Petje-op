using System.Drawing;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire;

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

        public void GoToAddQuestionnaire()
        {
            AddQuestionnaireController aqc = (AddQuestionnaireController)MasterController.GetController(typeof(AddQuestionnaireController));
            MasterController.SetController(aqc);
        }

        public void GetAllQuestionnairesAndSubjects()
        {
            LoadingDialog l = new LoadingDialog();
            l.Show();
            Application.DoEvents();

            Model.Questionnaires = MasterController.DB.GetAllQuestionnaires();
            Model.Subjects = MasterController.DB.GetSubjects();

            l.Hide();
        }

        public void FillTreeView()
        {
            View.tvQuestionnaires.Nodes.Clear();

            foreach (Questionnaire questionnaire in Model.Questionnaires)
            {
                TreeNode questionnaireTreeNode = View.tvQuestionnaires.Nodes.Add(questionnaire.Name + " (" + questionnaire.Subject + ")");
                questionnaireTreeNode.Tag = questionnaire;

                foreach (MultipleChoiceQuestion question in questionnaire.Questions)
                {
                    TreeNode questionTreeNode =
                        questionnaireTreeNode.Nodes.Add(question.QuestionIndex + ": " + question.Description);
                    questionTreeNode.Tag = question;

                    foreach (Answer answer in question.AnswerOptions)
                    {
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

            View.tvQuestionnaires.Sort();
        }

        public void FillSubjects()
        {
            View.cbSubjects.Items.Clear();

            View.cbSubjects.Items.Add("Alle Vakken");

            foreach (Subject s in Model.Subjects)
            {
                View.cbSubjects.Items.Add(s);
            }

            View.cbSubjects.SelectedIndex = 0;
        }

        public void FilterQuestionnaires(Subject s)
        {
            List<Questionnaire> newList = new List<Questionnaire>();

            foreach (Questionnaire q in Model.Questionnaires)
            {
                if (q.Subject.Id == s.Id)
                    newList.Add(q);
            }

            Model.Questionnaires = newList;
        }
    }
}
