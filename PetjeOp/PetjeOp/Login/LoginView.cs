using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetjeOp.Login
{
    public partial class LoginView : Form
    {
        LoginController Controller;
        public LoginView(LoginController Controller)
        {
            InitializeComponent();
            this.Controller = Controller; // Stelt de controller in van het Login Dialog
            this.Controller.View = this; // Stelt verwijzing van de view in de controller naar dit Dialog
        }

        private void btnVraagOverzicht_Click(object sender, EventArgs e) //Tijdelijk, moet nog worden verwijderd!
        {
            Controller.QuestionnaireDetail();
        }

        private void btnAnswerQuestion_Click(object sender, EventArgs e) //Tijdelijk, moet nog worden verwijderd!
        {
            Controller.AnswerQuestion(1);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (txtLoginCode.Text == "") // Controleert of het text-veld blanco is, en zet het label naar een ERROR.
            {
                Error.Text = "U heeft niks ingevuld.";
                Error.Visible = true;
            }
            else
            {
                if (Controller.MasterController.DB.GetStudent(txtLoginCode.Text) != null) // Controleer op een code van een Student
                {
                    Controller.MasterController.User = Controller.MasterController.DB.GetStudent(txtLoginCode.Text); // Haal de Student uit de DB.
                    Controller.StudentLogin(); // Zet de client over naar Student omgeving
                }
                else if (Controller.MasterController.DB.GetTeacher(txtLoginCode.Text) != null) // Controleer op een code van een Teacher
                {
                    Controller.MasterController.User = Controller.MasterController.DB.GetTeacher(txtLoginCode.Text); // Haal de Teacher uit de DB.
                    Controller.TeacherLogin(); // Zet de client over naar Teacher omgeving
                }
                else // Zet het label naar een ERROR
                {
                    Error.Text = "Woops.. Er ging wat mis.";
                    Error.Visible = true;
                }
            }
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtLoginCode; //Zorgt ervoor dat je direct bij het starten van de applicatie kan typen in dit textbox
        }
    }
}
