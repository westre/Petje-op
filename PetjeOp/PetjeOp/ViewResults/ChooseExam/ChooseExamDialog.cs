using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetjeOp.ViewResults.ChooseExam {
    public partial class ChooseExamDialog : Form {

        private TeacherController Controller;
        public ChooseExamDialog(TeacherController Controller) {
            this.Controller = Controller;
            InitializeComponent();
        }

        private void ChooseExamDialog_Load(object sender, EventArgs e) {



            // DUMMY DATA //
            Questionnaire test = new Questionnaire("Databaseontwerp");
            Question q1 = new MultipleChoiceQuestion("Wat is 1+1?");
            test.addQuestion(q1);
            Result q1result = new Result(1, 35);
            List<Exam> exams = new List<Exam>();
            exams.Add(new Exam(1, test, DateTime.Now, DateTime.Now, "ICTSE1b"));

            Questionnaire test2 = new Questionnaire("UML");
            Question q1q1 = new MultipleChoiceQuestion("Wat is 2+2?");
            test2.addQuestion(q1q1);
            Question q1q2 = new MultipleChoiceQuestion("Wat is 3+3?");
            test2.addQuestion(q1q2);
            // Result q1result = new Result();

            exams.Add(new Exam(2, test2, DateTime.Now, DateTime.Now, "ICTSE1b"));
            ////////
            foreach (Exam ex in exams) {
                listBox1.Items.AddRange(new object[] {
            ex});
            }





        }

        private void btnOk_Click(object sender, EventArgs e) {

            Controller.x = (Exam)listBox1.SelectedItem;
            if (Controller.x != null) {
                this.Close();
                Controller.GoToResults();
            }


        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {



        }
    }
}