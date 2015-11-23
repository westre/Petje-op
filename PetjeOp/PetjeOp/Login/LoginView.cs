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
    public partial class LoginView : UserControl {
        public LoginController Controller;

        public LoginView(LoginController controller) {
            InitializeComponent();

            Controller = controller;
        }

        private void btnStudentLogin_Click(object sender, EventArgs e) {
            Controller.StudentLogin();
        }

        private void btnLoginTeacher_Click(object sender, EventArgs e) {
            Controller.TeacherLogin();
        }
    }
}
