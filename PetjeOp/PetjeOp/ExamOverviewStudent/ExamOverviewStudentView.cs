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
    public partial class ExamOverviewStudentView : UserControl {
        public ExamOverviewStudentController Controller;

        public ExamOverviewStudentView(ExamOverviewStudentController controller) {
            this.Controller = controller;
            InitializeComponent();
        }

        private void btnStudentLogin_Click(object sender, EventArgs e) {

        }

        private void btnLoginTeacher_Click(object sender, EventArgs e) {

        }

        private void viewPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Results_Title_Click(object sender, EventArgs e)
        {

        }
    }
}
