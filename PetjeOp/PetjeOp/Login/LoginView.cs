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

            pbLoading.Image = Properties.Resources.loadgif;
            pbLoading.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void btnVraagOverzicht_Click(object sender, EventArgs e) //Tijdelijk, moet nog worden verwijderd!
        {
            Controller.QuestionnaireDetail();
        }

        private void btnAnswerQuestion_Click(object sender, EventArgs e) //Tijdelijk, moet nog worden verwijderd!
        {
            Controller.AnswerQuestion(1);
        }

        private void LoginCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginBtn_Click(sender,e);
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Controller.BackgroundWorker.RunWorkerAsync();

            //pbLogin.MarqueeAnimationSpeed = 30;
            //pbLogin.Show();

            pbLoading.Show();
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtLoginCode; //Zorgt ervoor dat je direct bij het starten van de applicatie kan typen in dit textbox
        }
    }
}
