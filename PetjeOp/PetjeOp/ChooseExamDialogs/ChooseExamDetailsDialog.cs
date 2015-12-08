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
        private TeacherController Controller;

        public ChooseExamDetailsDialog(TeacherController Controller, QuestionnaireDetailController Controller2)
        {
            this.Controller = Controller;
            Questionnaire = Controller2.Model.Questionnaire;
            InitializeComponent();
        }

        private void ChooseExamDialog_Load(object sender, EventArgs e)
        {
            // hier worden de afnamemomenten toegevoegd aan de lijst in het dialog
            List<Exam> exams = Controller.MasterController.DB.GetExamsByQuestionnaire(Questionnaire);

            foreach (Exam ex in exams)
            {
                listBox1.Items.AddRange(new object[] { ex });
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
