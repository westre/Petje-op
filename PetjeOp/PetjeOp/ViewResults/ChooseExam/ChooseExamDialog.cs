using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetjeOp.ViewResults.ChooseExam {
    public partial class ChooseExamDialog : Form
    {

        private TeacherController Controller;
        public ChooseExamDialog(TeacherController Controller)
        {
            this.Controller = Controller;
            InitializeComponent();
        }

        private void ChooseExamDialog_Load(object sender, EventArgs e)
        {
            // hier worden de afnamemomenten toegevoegd aan de lijst in het dialog
            List<Exam> exams = Controller.MasterController.DB.GetAllExams();

            foreach (Exam ex in exams)
            {
                listBox1.Items.AddRange(new object[] { ex });
            }

          




        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // hier kun je op OK klikken als je een afnamemoment hebt gekozen
            Controller.x = (Exam)listBox1.SelectedItem;
            if (Controller.x != null)
            {
                this.Close();
                Controller.GoToResults();
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

    }
}