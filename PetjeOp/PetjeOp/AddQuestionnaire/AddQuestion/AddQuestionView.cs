using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp.AddQuestionnaire
{
    public partial class AddQuestionView : UserControl
    {

        public AddQuestionView()
        {
            InitializeComponent();
        }

        private void btnAddAnswer_Click(object sender, EventArgs e)
        {
            clbAnswers.Items.Add(tbAnswer.Text);
            tbAnswer.Clear();
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            clbAnswers.Items.Remove(clbAnswers.SelectedItem);
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
    }
}
