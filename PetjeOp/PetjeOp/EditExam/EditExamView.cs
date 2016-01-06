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
    public partial class EditExamView : UserControl {
        public EditExamController Controller;

        public EditExamView(EditExamController controller) {
            InitializeComponent();

            Controller = controller;
        }

        private void btnStarttimeEdit_Click(object sender, EventArgs e) {
            Controller.StartTimeEdit();
        }

        private void btnEndtimeEdit_Click(object sender, EventArgs e) {
            Controller.EndTimeEdit();
        }

        private void btnLectureEdit_Click(object sender, EventArgs e) {
            Controller.LectureEdit();
        }

        private void btnQuestionnaireEdit_Click(object sender, EventArgs e) {
            Controller.QuestionnaireEdit();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            Controller.EditClicked();
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            Controller.RemoveClicked();
        }
    }
}