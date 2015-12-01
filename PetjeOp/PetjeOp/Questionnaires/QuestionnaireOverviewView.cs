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

        private void lblAddQuestionnaire_Click(object sender, EventArgs e)
        {

        }

        private void QuestionnaireOverviewView_Load(object sender, EventArgs e)
        {
            Controller.UpdateTreeView();
        }

        private void tvQuestionnaires_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void tvQuestionnaires_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           Controller.GoToAddQuestionnaire();
        }
    }
}
