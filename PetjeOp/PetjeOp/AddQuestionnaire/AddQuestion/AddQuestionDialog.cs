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
        public AddQuestionnaireController Controller { get; set; }
        private int toBeAdded;

        public AddQuestionDialog(AddQuestionnaireController controller)
        {
            InitializeComponent();
            addQuestionView1.lblNonSufficientAnswers.ForeColor = Color.Red;
            addQuestionView1.SetQuestionDialog(this);
            Controller = controller;
            toBeAdded = 1;
        }

        public AddQuestionDialog(AddQuestionnaireController controller, MultipleChoiceQuestion question) : this(controller)
        {
            Question = question;
            toBeAdded = 0;
            Text = btnAddQuestion.Text = "Vraag Wijzigen";
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (ValidateAnswers())
                {
                    Question = new MultipleChoiceQuestion(addQuestionView1.tbQuestion.Text);

                    foreach (var item in addQuestionView1.clbAnswers.Items)
                    {
                        Answer ans = new Answer(item.ToString());
                        answers.Add(ans);

                        if (addQuestionView1.clbAnswers.CheckedItems.Contains(item))
                        {
                            correct = ans;
                        }
                    }

                    Question.AddAnswerOptions(answers);

                    Question.AddCorrectAnswer(correct);

                    Question.QuestionNumber = Controller.Model.Questions.Count + toBeAdded;
                    this.Close();
                }
            }
            else
            {
                addQuestionView1.lblNonSufficientAnswers.Text = "Er moeten minimaal twee antwoorden opgegeven worden!";
            }     
        }

        private bool ValidateInput()
        {
            if (addQuestionView1.clbAnswers.CheckedItems.Count == 0)
            {
                return false;
            } else if (addQuestionView1.tbQuestion.Text == null)
            {
                return false;
            } else if (addQuestionView1.clbAnswers.Items.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidateAnswers()
        {
            if (addQuestionView1.clbAnswers.Items.Count >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddQuestionDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Question != null)
            Controller.AddDialogInformation(Question);
        }
        

        private void AddQuestionDialog_Load(object sender, EventArgs e)
        {
            if (Question != null)
            {
                addQuestionView1.tbQuestion.Text = Question.Description;

                foreach (Answer a in Question.AnswerOptions)
                {
                    int addedIndex = addQuestionView1.clbAnswers.Items.Add(a.Description);

                    if (a == Question.Answer)
                    {
                        addQuestionView1.clbAnswers.SetItemChecked(addedIndex, true);
                    }
                }
            }

            addQuestionView1.checkQuestionView();
        }
    }
}
