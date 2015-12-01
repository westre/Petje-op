using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public void UpdateTreeView()
        {
            LoadingDialog l = new LoadingDialog();
            l.Show();
            Application.DoEvents();

            Model.Subjects = MasterController.DB.GetSubjects();

            foreach (Subject s in Model.Subjects)
            {
                View.cbSubjects.Items.Add(s.Name);
            }

            View.tvQuestionnaires.Nodes.Clear();

            Model.Questionnaires = MasterController.DB.GetAllQuestionnaires();

            foreach (Questionnaire questionnaire in Model.Questionnaires)
            {
                TreeNode questionnaireTreeNode = View.tvQuestionnaires.Nodes.Add(questionnaire.Name);
                questionnaireTreeNode.Tag = questionnaire;

                foreach (MultipleChoiceQuestion question in questionnaire.Questions)
                {
                    TreeNode questionTreeNode = questionnaireTreeNode.Nodes.Add(question.QuestionIndex + ": " + question.Description);
                    questionTreeNode.Tag = question;

                    foreach (Answer answer in question.AnswerOptions)
                    {
                        if (answer.ID == question.CorrectAnswer.ID)
                        {
                            TreeNode addedAnswer = questionTreeNode.Nodes.Add(question.CorrectAnswer.Description);
                            addedAnswer.Tag = answer;
                            addedAnswer.ForeColor = Color.Green;
                        } else
                        {
                            TreeNode addedAnswer = questionTreeNode.Nodes.Add(answer.Description);
                            addedAnswer.Tag = answer;
                            addedAnswer.ForeColor = Color.Red;
                        }
                    }
                }
            }

            View.tvQuestionnaires.Sort();

            l.Hide();
        }
    }
}
