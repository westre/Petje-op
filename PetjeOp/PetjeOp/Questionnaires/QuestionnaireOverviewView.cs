using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetjeOp.Questionnaires
{
    public partial class QuestionnaireOverviewView : UserControl
    {
        public QuestionnaireOverviewController Controller;

        public QuestionnaireOverviewView(QuestionnaireOverviewController controller)
        {
            InitializeComponent();

            Controller = controller;
        }

        private void QuestionnaireOverviewView_Load(object sender, EventArgs e)
        {
            Controller.GetAllQuestionnairesAndSubjects();
            Controller.FillSubjects();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Controller.GoToAddQuestionnaire();
        }

        private void cbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = cbSubjects.SelectedItem;

            if (selectedItem is Subject)
            {
                Subject selectedSubject = (Subject) cbSubjects.SelectedItem;

                Controller.GetAllQuestionnairesAndSubjects();
                Controller.FilterQuestionnaires(selectedSubject);
                Controller.FillTreeView();
            }
            else
            {
                Controller.GetAllQuestionnairesAndSubjects();
                Controller.FillTreeView();
            }
        }
    }
}
