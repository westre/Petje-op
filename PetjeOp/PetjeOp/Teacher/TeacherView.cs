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
    public partial class TeacherView : UserControl {
        public TeacherController Controller;
        

        public TeacherView(TeacherController controller) {
            InitializeComponent();

            Controller = controller;
        }

        private void ResultClick(object sender, EventArgs e) {
            Controller.ShowExamDialog();
        }

        //Log uit
        public void Logout(object sender, EventArgs args)
        {
            Controller.MasterController.Logout();
        }

        //Wanneer er op het logo wordt geklikt, ga naar teacher home
        private void pbLogo_Click(object sender, EventArgs e)
        {
            Controller.GoToTeacherHome();
        }

        //Wanneer er op de QuestionnaireOverview knop wordt geklikt, ga hier naar toe.
        private void pnlButton_QuestionnaireOverview_Background_Click(object sender, EventArgs e)
        {
            Controller.GoToQuestionnaireOverview();
        }

        //Wanneer er op de ViewExamButton wordt geklikt, ga hier naar toe.
        private void ViewExamClick(object sender, EventArgs e) {
            Controller.GoToExamOverview();
        }

        //Wanneer er op de Agenda knop wordt gedrukt, ga hier naar toe
        private void lblTitle_Agenda_Title_Click(object sender, EventArgs e)
        {
            Controller.GoToExamOverview();
        }

        //Wanneer er op de Agenda knop wordt gedrukt, ga hier naar toe
        private void pbIcon_Agenda_Icon_Click(object sender, EventArgs e)
        {
            Controller.GoToExamOverview();
        }

        //Wanneer er op de Questionnaire knop wordt gedrukt, ga hier naar toe
        private void lblTitle_QuestionnaireOverview_Title_Click(object sender, EventArgs e)
        {
            Controller.GoToQuestionnaireOverview();
        }

        //Wanneer er op de Questionnaire knop wordt gedrukt, ga hier naar toe
        private void pbIcon_QuestionnaireOverview_Icon_Click(object sender, EventArgs e)
        {
            Controller.GoToQuestionnaireOverview();
        }
    }
}
