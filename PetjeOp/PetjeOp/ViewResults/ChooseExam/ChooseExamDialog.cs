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
           // Controller.x = (Exam);
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

      

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            int count = 0;
            foreach (Exam ex in Exams)
            {
                if (ex.Starttime > dateTimePicker1.Value.Date && ex.Starttime < dateTimePicker1.Value.Date.AddDays(1))
                {
                    FillListFilter(ex, count);



                }

            }
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            Console.WriteLine(cbQuestionnaire.SelectedItem);

            if (cbSubject.GetItemText(cbSubject.SelectedItem) == "Alle vakken")
            {
                FillList();
                
                FillQuestionnaire();

            }

            else
            {
                int count = 0;
                foreach (Exam ex in Exams)
                {
                    if (ex.Questionnaire.Subject.Name == cbSubject.GetItemText(cbSubject.SelectedItem))
                    {

                        FillListFilter(ex, count);
                        
                    }

                }
                List<Questionnaire> qtn = Controller.MasterController.DB.GetAllQuestionnaires();
                cbQuestionnaire.Items.Clear();
                cbQuestionnaire.ResetText();
                
                cbQuestionnaire.Items.Add("Alle vragenlijsten");
                foreach (Questionnaire q in qtn)
                {
                    if(q.Subject.Name == cbSubject.GetItemText(cbSubject.SelectedItem)){
                        
                        cbQuestionnaire.Items.Add(q);
                        cbQuestionnaire.Sorted = true;
                       
                    }
                    
                    cbQuestionnaire.SelectedIndex = 0;
                }

            }
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (cbClass.GetItemText(cbClass.SelectedItem) == "Alle klassen")
            {
                foreach (Exam ex in Exams)
                {
                    FillList();

                }
            }

            else
            {
                int count = 0;
                
                List<Exam> cse = Controller.MasterController.DB.GetExamByClass(cbClass.GetItemText(cbClass.SelectedItem));
                foreach (Exam ex in cse)
                    {


                        FillListFilter(ex, count);

                    }

                }
            }


        private void btnResetDate_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            listView1.Items.Clear();

            foreach (Exam ex in Exams)
            {
                FillList();
            }
        }

        private void cbQuestionnaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            
            if (cbQuestionnaire.GetItemText(cbQuestionnaire.SelectedItem) == "Alle vragenlijsten")
            {
                foreach (Exam ex in Exams)
                {

                    FillList();
                }
            }

            else
            {
                int count = 0;
                foreach (Exam ex in Exams)
                {

                    if (String.Format("{0}: {1}", ex.Questionnaire.Subject, ex.Questionnaire.Name) == cbQuestionnaire.GetItemText(cbQuestionnaire.SelectedItem))
                    {

                        FillListFilter(ex, count);
                    }
                }
            }
        }

        private void listView1_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            listView1.Sort();
        }

        private void FillQuestionnaire()
        {
            // hier worden de vragenlijsten toegevoegd aan de lijst met vragenlijsten
            cbQuestionnaire.Items.Clear();
            List<Questionnaire> qtn = Controller.MasterController.DB.GetAllQuestionnaires();

            cbQuestionnaire.Items.Add("Alle vragenlijsten");

            foreach (Questionnaire q in qtn)
            {
                cbQuestionnaire.Items.Add(q);
                cbQuestionnaire.Sorted = true;

            }
            cbQuestionnaire.SelectedIndex = 0;
        }
    }
    }
