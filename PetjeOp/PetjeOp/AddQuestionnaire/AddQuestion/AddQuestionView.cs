using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire.AddQuestion;

namespace PetjeOp.AddQuestionnaire
{
    public partial class AddQuestionView : UserControl
    {
        public AddQuestionDialog AddQuestionDialog { get; set; }

        public AddQuestionView()
        {
            InitializeComponent();
        }

        private void btnAddAnswer_Click(object sender, EventArgs e)
        {
            if (tbAnswer.Text != null)
            {
                clbAnswers.Items.Add(tbAnswer.Text);
                checkQuestionView();
                tbAnswer.Clear();
            }
        }

        public void SetQuestionDialog(AddQuestionDialog questionDialog)
        {
            this.AddQuestionDialog = questionDialog;
        }
        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Weet u zeker dat u dit antwoord wilt verwijderen?", "Let op", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                clbAnswers.Items.Remove(clbAnswers.SelectedItem);
            }
            checkQuestionView();
        }

        private void clbAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbAnswers.SelectedIndex != -1)
            {
                btnDeleteAnswer.Enabled = true;
            }
            else
            {
                btnDeleteAnswer.Enabled = false;
            }
            checkQuestionView();
        }

        private void clbAnswers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int ix = 0; ix < clbAnswers.Items.Count; ++ix)
                {
                    if (e.Index != ix)
                    {
                        clbAnswers.SetItemChecked(ix, false);
                    }
                }
            }
        }

        private void tbAnswer_TextChanged(object sender, EventArgs e)
        {
            if (tbAnswer.Text.Count() > 0)
            {
                btnAddAnswer.Enabled = true;
            }
            else
            {
                btnAddAnswer.Enabled = false;
            }
        }

        public void checkQuestionView()
        {
            bool checkTwoAnswers;
            bool checkQuestion;
            bool checkCorrectAnswer;
            bool checkMaxAnswers;

            if (clbAnswers.Items.Count <= 1)
            {
                lblNonSufficientAnswers.ForeColor = Color.Red;
                lblNonSufficientAnswers.Text = "Er moeten minimaal twee antwoorden opgegeven worden!";
                checkTwoAnswers = false;
            }else
            {
                lblNonSufficientAnswers.Text = "";
                checkTwoAnswers = true;
            }

            if (!tbQuestion.Text.Any())
            {
                lblQuestionError.ForeColor = Color.Red;
                lblQuestionError.Text = "Vul een vraag in!";
                checkQuestion = false;
            }
            else
            {
                lblQuestionError.Text = "";
                checkQuestion = true;
            }

            if (AddQuestionDialog.addQuestionView1.clbAnswers.CheckedItems.Count == 0)
            {
                lblAnswersError.ForeColor = Color.Red;
                checkCorrectAnswer = false;
            }
            else
            {
                lblAnswersError.ForeColor = Color.Black;
                checkCorrectAnswer = true;
            }

            if (AddQuestionDialog.addQuestionView1.clbAnswers.Items.Count > 26)
            {
                lblNonSufficientAnswers.ForeColor = Color.Red;
                lblNonSufficientAnswers.Text = "Er mogen maximaal 26 antwoorden gegeven worden!";
                checkMaxAnswers = false;
            }
            else
            {
                checkMaxAnswers = true;
            }

            
            if (checkTwoAnswers && checkQuestion && checkCorrectAnswer && checkMaxAnswers)
            {
                AddQuestionDialog.btnAddQuestion.Enabled = true;
            }
            else
            {
                AddQuestionDialog.btnAddQuestion.Enabled = false;
            }
        }

        private void tbQuestion_TextChanged(object sender, EventArgs e)
        {
            checkQuestionView();
        }

        private void gbQuestion_Enter(object sender, EventArgs e)
        {

        }
    }
}
