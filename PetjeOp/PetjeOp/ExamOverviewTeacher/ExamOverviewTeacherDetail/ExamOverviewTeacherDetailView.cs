using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetjeOp.ExamOverviewTeacher.ExamOverviewTeacherDetail {
    public partial class ExamOverviewTeacherDetailView : UserControl {
        public ExamOverviewTeacherDetailView() {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            ((ExamOverviewTeacherDetailDialog)Parent).EditClicked();
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            ((ExamOverviewTeacherDetailDialog)Parent).RemoveClicked();
        }

        private void btnStarttimeEdit_Click(object sender, EventArgs e) {
            ((ExamOverviewTeacherDetailDialog)Parent).StartTimeEdit();
        }

        private void btnEndtimeEdit_Click(object sender, EventArgs e) {
            ((ExamOverviewTeacherDetailDialog)Parent).EndTimeEdit();
        }

        private void btnLectureEdit_Click(object sender, EventArgs e) {
            ((ExamOverviewTeacherDetailDialog)Parent).LectureEdit();
        }

        private void btnQuestionnaireEdit_Click(object sender, EventArgs e) {
            ((ExamOverviewTeacherDetailDialog)Parent).QuestionnaireEdit();
        }
    }
}
