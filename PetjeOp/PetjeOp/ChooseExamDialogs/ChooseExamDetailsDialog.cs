using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PetjeOp.ViewResults.ChooseExam;

namespace PetjeOp.ChooseExamDialogs
{
    public partial class ChooseExamDetailsDialog : Form
    {


        public Questionnaire Questionnaire { get; set; }
        private QuestionnaireDetailController Controller { get; }

        public ChooseExamDetailsDialog(QuestionnaireDetailController Controller)
        {
            this.Controller = Controller;
            Questionnaire = Controller.Model.Questionnaire;
            InitializeComponent();
        }

        private void ChooseExamDialog_Load(object sender, EventArgs e)
        {
            // hier worden de afnamemomenten toegevoegd aan de lijst in het dialog
            List<Exam> exams = Controller.MasterController.DB.GetExamsByQuestionnaire(Questionnaire);
            int count = 0;
            foreach (Exam ex in exams)
            {
                //lbExams.Items.AddRange(new object[] { ex });
                lbExams.Items.Add(string.Empty + ex.Examnr);
                lbExams.Items[count].SubItems.Add(ex.questionnaire.Name);
                lbExams.Items[count].SubItems.Add(string.Empty + ex.starttime.Value.TimeOfDay);
                lbExams.Items[count].SubItems.Add(string.Empty + ex.endtime.Value.TimeOfDay);
                count++;
            }

        }

        public virtual void btnOk_Click(object sender, EventArgs e)
        {
            // hier kun je op OK klikken als je een afnamemoment hebt gekozen
            MessageBox.Show("Error Message", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
