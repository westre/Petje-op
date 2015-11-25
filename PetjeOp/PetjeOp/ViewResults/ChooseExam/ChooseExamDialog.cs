using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetjeOp.ViewResults.ChooseExam
{
    public partial class ChooseExamDialog : Form
    {
        public ChooseExamDialog()
        {
            InitializeComponent();
        }

        private void ChooseExamDialog_Load(object sender, EventArgs e)
        {
            Questionnaire test = new Questionnaire("Databaseontwerp");
            List<Exam> exams = new List<Exam>();
            exams.Add(new Exam(1, test, DateTime.Now, DateTime.Now, "ICTSE1b"));

            foreach (Exam ex in exams)
            {
                listBox1.Items.AddRange(new object[] {
            ex});
            }
           

           

           
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
