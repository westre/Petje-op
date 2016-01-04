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
        private List<Exam> Exams;
        
        public ChooseExamDialog(TeacherController Controller)
        {
            this.Controller = Controller;
            InitializeComponent();
        }

        private void ChooseExamDialog_Load(object sender, EventArgs e)
        {

            FillList();
          

            // hier worden de subjects toegevoegd aan de lijst met subjects
            List<Subject> subjects = Controller.MasterController.DB.GetSubjects();

            cbSubject.Items.Add("Alle vakken");

            foreach (Subject sb in subjects)
            {
                cbSubject.Items.Add(sb);
                cbSubject.Sorted = true;
            }
            cbSubject.SelectedIndex = 0;

            // hier worden de klassen toegevoegd aan de lijst met klassen
            List<Class> cs = Controller.MasterController.DB.GetAllClasses();

            cbClass.Items.Add("Alle klassen");

            foreach (Class c in cs)
            {
                cbClass.Items.Add(c);
                cbClass.Sorted = true;
            }
            cbClass.SelectedIndex = 0;

            // hier worden de vragenlijsten toegevoegd aan de lijst met vragenlijsten
            List<Questionnaire> qtn = Controller.MasterController.DB.GetAllQuestionnaires();

            cbQuestionnaire.Items.Add("Alle vragenlijsten");

            foreach (Questionnaire q in qtn)
            {
                cbQuestionnaire.Items.Add(q);
                cbQuestionnaire.Sorted = true;
                
            }
            cbQuestionnaire.SelectedIndex = 0;


        }
        public void FillList()
        {
            listView1.Items.Clear();
            int count = 0;
            // hier worden de afnamemomenten toegevoegd aan de lijst in het dialog
            Exams = Controller.MasterController.DB.GetAllExams();

            

            foreach (Exam ex in Exams)
            {
                Console.WriteLine(ex);
                listView1.Items.Add(ex.Questionnaire.Name);
                listView1.Items[count].SubItems.Add(Convert.ToString(ex.Questionnaire.Subject));
                listView1.Items[count].SubItems.Add(Convert.ToString(ex.Starttime));
                listView1.Items[count].SubItems.Add(Convert.ToString(ex.Endtime));
                count++;
            }
            
        }
        public void FillListFilter(Exam ex, int count)
        {


           


                listView1.Items.Add(ex.Questionnaire.Name);
                listView1.Items[count].SubItems.Add(Convert.ToString(ex.Questionnaire.Subject));
                listView1.Items[count].SubItems.Add(Convert.ToString(ex.Starttime));
                listView1.Items[count].SubItems.Add(Convert.ToString(ex.Endtime));
                count++;


            
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
           

            //foreach (Exam ex in Exams)
            //{
            //    if (ex.starttime > dateTimePicker1.Value.Date && ex.starttime < dateTimePicker1.Value.Date.AddDays(1))
                    
                    
                    
            //}
            
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

            listView1.Items.Clear();


            if (cbSubject.GetItemText(cbSubject.SelectedItem) == "Alle vakken")
            {
               // FillList();
            }

            else
            {
                int count = 0;
                foreach (Exam ex in Exams)
                {
                    //if (ex.questionnaire.Subject.Name == cbSubject.GetItemText(cbSubject.SelectedItem))
                    //{

                    //    FillListFilter(ex, count);
                    //}

                }

            }
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbClass.GetItemText(cbClass.SelectedItem) == "Alle klassen")
            {
                foreach (Exam ex in Exams)
                {
                    listBox1.Items.Add(ex);
                }
            }

            else
            {
                foreach (Exam ex in Exams)
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

            foreach (Exam ex in Exams)
            {
                listBox1.Items.Add(ex);
            }
        }

        private void cbQuestionnaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            Console.WriteLine(cbQuestionnaire.SelectedItem);
            if (cbQuestionnaire.GetItemText(cbQuestionnaire.SelectedItem) == "Alle vragenlijsten")
            {
                foreach (Exam ex in Exams)
                {
                    
                    listBox1.Items.Add(ex);
                }
            }

            else
            
                foreach (Exam ex in Exams)
                {
                    
                    if (String.Format("{0}: {1}", ex.Questionnaire.Subject, ex.Questionnaire.Name) == cbQuestionnaire.GetItemText(cbQuestionnaire.SelectedItem))
                    {
                       
                        listBox1.Items.Add(ex);
                    }
                }
            }

        }
    }
