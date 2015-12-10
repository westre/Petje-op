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
    public partial class StudentView : UserControl {
        public StudentController Controller;

        public StudentView(StudentController controller) {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            Controller = controller;
        }

        private void btnStudentLogin_Click(object sender, EventArgs e) {

        }

        private void btnLoginTeacher_Click(object sender, EventArgs e) {

        }
    }
}
