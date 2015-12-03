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
        private void btnVraagOverzicht_Click(object sender, EventArgs e)
        {
            Controller.QuestionnaireDetail();
        }

        private void btnLoginTeacher_Click(object sender, EventArgs e) {
            Controller.TeacherLogin();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "") // Controleert of het text-veld blanco is, en zet het label naar een ERROR.
            {
                Error.Text = "U heeft niks ingevuld.";
                Error.Visible = true;
            }
            else
            {
                if (Controller.MasterController.DB.GetStudent(textBox1.Text) != null) // Controleer op een code van een Student
                {
                    Controller.MasterController.User = Controller.MasterController.DB.GetStudent(textBox1.Text); // Haal de Student uit de DB.
                    Controller.StudentLogin(); // Zet de client over naar Student omgeving
                }
                else if (Controller.MasterController.DB.GetTeacher(textBox1.Text) != null) // Controleer op een code van een Teacher
                {
                    Controller.MasterController.User = Controller.MasterController.DB.GetTeacher(textBox1.Text); // Haal de Teacher uit de DB.
                    Controller.TeacherLogin(); // Zet de client over naar Teacher omgeving
                }
                else // Zet het label naar een ERROR
                {
                    Error.Text = "Woops.. Er ging wat mis.";
                    Error.Visible = true;
                }
            }
            
        }

        private void viewPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
