using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class AnswerQuestionnaireController : Controller {
        public AnswerQuestionnaireView View { get; set; }
        public AnswerQuestionnaireModel Model { get; set; }
        public Exam Exam { get; set; }

        public AnswerQuestionnaireController(MasterController masterController) : base(masterController) {
            Model = new AnswerQuestionnaireModel();
            View = new AnswerQuestionnaireView(this);
        }

        public override UserControl GetView() {
            return View;
        }

        public Panel GetViewPanel() {
            return View.viewPanel;
        }

        public void setExam(int examID)
        {
            this.Exam = MasterController.DB.GetExam(examID);
            MultipleChoiceQuestion question = MasterController.DB.GetQuestion(Exam.questionnaire.Questions.SingleOrDefault(s => s.ID == Exam.CurrenQuestion).ID);
            View.lblTitle_Results_Title.Text = question.Description;
            foreach (Answer answer in question.AnswerOptions)
            {
                View.VraagBox.Items.Add(answer.Description);
            }
        }
    }
}
