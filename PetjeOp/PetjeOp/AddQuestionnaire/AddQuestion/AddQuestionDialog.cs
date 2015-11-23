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
        public Question question;
        public List<Answer> answers = new List<Answer>();
        public Answer correct;

        public AddQuestionDialog()
        {
            InitializeComponent();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            foreach (var item in addQuestionView1.clbAnswers.Items)
            {
                Answer ans = new Answer(item.ToString());
                answers.Add(ans);
            }

            foreach (var item in addQuestionView1.clbAnswers.CheckedItems)
            {
                correct = new Answer(item.ToString());
            }

            string questionName = addQuestionView1.tbQuestion.Text;

            question = new MultipleChoiceQuestion();
        }
    }
}
