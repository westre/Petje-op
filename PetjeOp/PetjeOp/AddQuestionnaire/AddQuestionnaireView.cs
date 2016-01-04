using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire.AddQuestion;

namespace PetjeOp.AddQuestionnaire
{
    public partial class AddQuestionnaireView : UserControl
    {
        public AddQuestionnaireController Controller { get; set; }

        public AddQuestionnaireView(AddQuestionnaireController controller)
        {
            Controller = controller;
            InitializeComponent();
            questionsView1.ParentController = Controller;
        }

        //Wanneer de tekst in de QuestionnaireName textbox is aangepast, kijk of de buttons enabled kunnen worden.
        private void tbQuestionnaireName_TextChanged(object sender, EventArgs e)
        {
            Controller.CheckButtons();
        }

        //Wanneer er op de SaveQuestionnaire button is geklikt, wijzig het vak van de vragenlijst en sla hem dan op.
        private void btnSaveQuestionnaire_Click(object sender, EventArgs e)
        {
            Controller.SetSubject();
            Controller.SaveQuestionnaire();
        }

        private void AddQuestionnaireView_Load(object sender, EventArgs e)
        {
            Controller.AddSubjects();
            Controller.CheckButtons();
        }

        private void cbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.CheckButtons();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Controller.GoToQuestionnaireOverview();
        }
    }
}
