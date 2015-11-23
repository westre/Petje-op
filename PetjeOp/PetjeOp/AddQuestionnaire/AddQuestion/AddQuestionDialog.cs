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

        public AddQuestionDialog()
        {
            InitializeComponent();
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

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Er moeten minimaal twee antwoorden opgegeven worden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
            }
            else
            {
                MessageBox.Show("Niet alle vereiste velden zijn ingevuld!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
