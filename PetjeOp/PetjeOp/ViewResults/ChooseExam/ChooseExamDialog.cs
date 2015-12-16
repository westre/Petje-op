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

            // hier worden de subjects toegevoegd aan de lijst met subjects
            List<Subject> subjects = Controller.MasterController.DB.GetSubjects();

            cbSubject.Items.Add("Alle vakken");

            foreach (Subject sb in subjects)
            {
                cbSubject.Items.AddRange(new object[] { sb });
            }
            cbSubject.SelectedIndex = 0;

            // hier worden de klassen toegevoegd aan de lijst met klassen
            List<Class> cs = Controller.MasterController.DB.GetAllClasses();

            cbClass.Items.Add("Alle klassen");

            foreach (Class c in cs)
            {
                cbClass.Items.AddRange(new object[] { c });
            }
            cbClass.SelectedIndex = 0;

            // hier worden de vragenlijsten toegevoegd aan de lijst met vragenlijsten
            List<Questionnaire> qtn = Controller.MasterController.DB.GetAllQuestionnaires();

            cbQuestionnaire.Items.Add("Alle vragenlijsten");

            foreach (Questionnaire q in qtn)
            {
                cbQuestionnaire.Items.AddRange(new object[] { q });
                
            }
            cbQuestionnaire.SelectedIndex = 0;


        }

        public virtual void btnOk_Click(object sender, EventArgs e)
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<Exam> exams = Controller.MasterController.DB.GetAllExams();

            foreach (Exam ex in exams)
            {
                if (ex.starttime > dateTimePicker1.Value.Date && ex.starttime < dateTimePicker1.Value.Date.AddDays(1))
                    listBox1.Items.AddRange(new object[] { ex });
            }
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            List<Exam> exams = Controller.MasterController.DB.GetAllExams();


            if (cbSubject.GetItemText(cbSubject.SelectedItem) == "Alle vakken")
            {
                foreach (Exam ex in exams)
                {
                    listBox1.Items.AddRange(new object[] { ex });
                }
            }

            else
            {

                foreach (Exam ex in exams)
                {
                    if (ex.questionnaire.Subject.Name == cbSubject.GetItemText(cbSubject.SelectedItem))
                    {
                        listBox1.Items.AddRange(new object[] { ex });
                    }

                }
            }
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            List<Exam> exams = Controller.MasterController.DB.GetAllExams();

            if (cbClass.GetItemText(cbClass.SelectedItem) == "Alle klassen")
            {
                foreach (Exam ex in exams)
                {
                    listBox1.Items.AddRange(new object[] { ex });
                }
            }

            else
            {
                foreach (Exam ex in exams)
                {
                    //if (ex.cs.Code == cbClass.GetItemText(cbSubject.SelectedItem))
                    //{
                    //    listBox1.Items.AddRange(new object[] { ex });
                    //}
                }
            }
        }

        private void btnResetDate_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            listBox1.Items.Clear();
            List<Exam> exams = Controller.MasterController.DB.GetAllExams();

            foreach (Exam ex in exams)
            {
                listBox1.Items.AddRange(new object[] { ex });
            }
        }

        private void cbQuestionnaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            List<Exam> exams = Controller.MasterController.DB.GetAllExams();
            Console.WriteLine(cbQuestionnaire.SelectedItem);
            if (cbQuestionnaire.GetItemText(cbQuestionnaire.SelectedItem) == "Alle vragenlijsten")
            {
                foreach (Exam ex in exams)
                {
                    
                    listBox1.Items.AddRange(new object[] { ex });
                }
            }

            else
            
                foreach (Exam ex in exams)
                {
                    
                    if (String.Format("{0}: {1}", ex.questionnaire.Subject.Name, ex.questionnaire.Name) == cbQuestionnaire.GetItemText(cbSubject.SelectedItem))
                    {
                       
                        listBox1.Items.AddRange(new object[] { ex });
                    }
                }
            }

        }
    }
