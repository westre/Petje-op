using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PetjeOp.ChooseExamDialogs;

namespace PetjeOp.QuestionnaireDetail
{
    public partial class QuestionnaireDetailView : UserControl
    {
        public QuestionnaireDetailController Controller { get; set; }

        public QuestionnaireDetailView(QuestionnaireDetailController controller)
        {
            InitializeComponent();
            Controller = controller;
        }

        //Ga terug naar het vragenlijstoverzicht wanneer je op de knop drukt.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Controller.GoToQuestionnaireOverview();
        }

        //Wanneer het scherm geladen wordt, set dan de labels en vul de combobox.
        private void QuestionnaireDetailView_Load(object sender, EventArgs e)
        {
            Controller.setLabels();
            Controller.FillCbSelectQuestionnaire();
            Controller.FillCbSubjects();
        }

        //Wanneer de index van de combobox wordt gewijzigd, verander de huidige questionnaire, set de labels opnieuw en update de treeview.
        private void cbSelectQuestionnaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.Model.Questionnaire = (Questionnaire)cbSelectQuestionnaire.SelectedItem;
            Controller.setLabels();
            Controller.View.questionsView1.UpdateTreeView();
        }

        //Wanneer de afnamemomentknop aangeklikt wordt, open het examendialoog.
        private void btnExams_Click(object sender, EventArgs e)
        {
            ChooseExamDetailsDialog ExamsDialog = new ChooseExamDetailsDialog(Controller);
            ExamsDialog.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            tbNameEdit.Text = lblNameData.Text;
            tbNameEdit.Show();
            
            Controller.SelectSubject(Controller.Model.Questionnaire.Subject);
            cbSubject.Show();

            btnSave.Show();
            btnCancelEdit.Show();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            tbNameEdit.Hide();

            cbSubject.Hide();

            btnSave.Hide();
            btnCancelEdit.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Controller.SaveQuestionnaireDetails();
        }
    }
}