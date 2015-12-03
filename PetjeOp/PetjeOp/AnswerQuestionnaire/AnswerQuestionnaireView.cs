using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public partial class AnswerQuestionnaireView : UserControl {
        public AnswerQuestionnaireController Controller;

        public AnswerQuestionnaireView(AnswerQuestionnaireController controller) {
            InitializeComponent();

            Controller = controller;
        }

        private void btnStudentLogin_Click(object sender, EventArgs e) {

        }

        private void btnLoginTeacher_Click(object sender, EventArgs e) {

        }
    }
}
