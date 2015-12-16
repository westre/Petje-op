using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

        //Bij laden van UserControl
        private void QuestionnaireOverviewView_Load(object sender, EventArgs e)
        {
            //Vraag gegevens op uit database
            Controller.GetAllQuestionnairesAndSubjects();

            //Vul ComboBox met vakken
            Controller.FillComboBoxes();

            Controller.CheckButtons();
        }

        //Als op knop 'Vragenlijst Toevoegen' is geklikt
        private void button1_Click(object sender, EventArgs e)
        {
            //Zet scherm naar AddQuestionnaire
           Controller.GoToAddQuestionnaire();
        }

        //Als er een ander vak is geselecteerd
        private void cbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.FilterTreeView();
        }

        //Als er een andere author is geselecteerd
        private void cbAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.FilterTreeView();
        }

        private void tvQuestionnaires_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //Als de node geen parent heeft, mag deze worden geselecteerd
            if (e.Node.Parent != null)
            {
                e.Cancel = true;
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            //Zet scherm naar QuestionnaireDetails
            Controller.GoToQuestionnaireDetails();
        }

        private void tvQuestionnaires_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Controleer of de knoppen aangezet kunnen worden
            Controller.CheckButtons();
        }

        private void cbShowArchive_CheckedChanged(object sender, EventArgs e)
        {
            //Vraag gegevens op uit database
            Controller.GetAllQuestionnairesAndSubjects();

            //Vul ComboBox met vakken
            Controller.FillComboBoxes();

            Controller.CheckButtons();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Controller.ArchiveQuestionnaire();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Controller.UnarchiveQuestionnaire();
        }

        private void cbOwnQuestionnairesOnly_CheckedChanged(object sender, EventArgs e)
        {
            Controller.FilterOnOwnQuestionnaires();
        }
    }
}