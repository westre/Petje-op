using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PetjeOp {
    public partial class AnswerQuestionnaireView : UserControl {
        public AnswerQuestionnaireController Controller;

        public AnswerQuestionnaireView(AnswerQuestionnaireController controller) {
            InitializeComponent();
        }

        private void VraagBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < VraagBox.Items.Count; ++ix)
                    if (e.Index != ix) VraagBox.SetItemChecked(ix, false);
        }
    }
}
