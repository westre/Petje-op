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
            //Hier worden alle exams van een bepaalde vragenlijst opgehaald uit de database.
            List<Exam> exams = Controller.MasterController.DB.GetExamsByQuestionnaire(Questionnaire);
            int count = 0;

            //Voor elke exam die de vragenlijst heeft, vul de listbox. 
            if (exams.Any())
            {
                foreach (Exam ex in exams)
                {
                    lbExams.Items.Add(string.Empty + ex.Examnr);
                    lbExams.Items[count].SubItems.Add(ex.Questionnaire.Name);
                    lbExams.Items[count].SubItems.Add(string.Empty + ex.Starttime.Day + "-" +
                                                      ex.Starttime.Month + "-" + ex.Starttime.Year);
                    lbExams.Items[count].SubItems.Add(string.Empty + ex.Starttime.TimeOfDay);
                    lbExams.Items[count].SubItems.Add(string.Empty + ex.Endtime.TimeOfDay);
                    count++;
                }
            }
            else
            {
                lbExams.Items.Add("");
                lbExams.Items[0].SubItems.Add("Geen afnamemomenten om weer te geven");
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
