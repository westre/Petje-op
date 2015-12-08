using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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

        //Bij laden van UserControl
        private void QuestionnaireOverviewView_Load(object sender, EventArgs e)
        {
            //Vraag gegevens op uit database
            Controller.GetAllQuestionnairesAndSubjects();

            //Vul ComboBox met vakken
            Controller.FillSubjects();
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
            //Vraag geselecteerd object op
            object selectedItem = cbSubjects.SelectedItem;

            //Check of selectedItem een vak is
            if (selectedItem is Subject)
            {
                //Cast het object naar een Subjectobject
                Subject selectedSubject = (Subject) cbSubjects.SelectedItem;
                
                //Filter de lijst met Questionnaires, zodat alleen de questionnaires van het
                //geselecteerde vak wordt getoond
                Controller.FilterQuestionnaires(selectedSubject);
            }
            else
            {
                //Toon alle vakken
                Controller.ResetList();
            }

            //Vul de TreeView met gegevens
            Controller.FillTreeView();
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
            Controller.GoToQuestionnaireDetails();
        }
    }
}