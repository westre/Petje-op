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
        
        //Voer dit uit wanneer er op de EditExamknop is geklikt.
        private void btnEditExam_Click(object sender, EventArgs e) {
            ((ExamOverviewTeacherDetailDialog)Parent).EditExam();
        }
    }
}
