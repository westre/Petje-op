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
        private List<Class> Classes;
        private List<Lecture> Lectures;
        private List<Exam> ExamFilter;
        private List<Subject> Subjects;
        private List<Questionnaire> Questionnaires;
        
        public ChooseExamDialog(TeacherController Controller)
        {
            this.Controller = Controller;
            InitializeComponent();
        }

        private void ChooseExamDialog_Load(object sender, EventArgs e)
        {
            // Begin door de benodigde gegevens uit de database te halen
            Classes = Controller.MasterController.DB.GetAllClasses();
            Lectures = Controller.MasterController.DB.GetAllLectures();
            Exams = Controller.MasterController.DB.GetAllExams();
            Subjects = Controller.MasterController.DB.GetSubjects();
            Questionnaires = Controller.MasterController.DB.GetAllQuestionnaires();

            // Alvast een lijst maken voor het filteren van afnamemomenten
            ExamFilter = new List<Exam>();
          
            // Vul de afnamemomenten met de juiste Class en Lecture
            foreach(Exam ex in Exams)
            {
                foreach(Lecture le in Lectures)

                    if(le.ID == ex.Lecture.ID)
                    {
                        ex.Lecture = le;
                    }

                foreach(Class cls in Classes)
                {
                    if(cls.Code == ex.Lecture.Class.Code)
                    {
                        ex.Class = cls;
                    }
                }
            }

            // hier worden de subjects toegevoegd aan de lijst met subjects
            // het eerste item in de lijst is een standaard string waardoor niets gefilterd wordt
            cbSubject.Items.Add("Alle vakken");

            foreach (Subject sb in Subjects)
            {
                cbSubject.Items.Add(sb);
                cbSubject.Sorted = true;
            }
            cbSubject.SelectedIndex = 0;

            // hier worden de klassen toegevoegd aan de lijst met klassen
            // ook hier is het eerste item in de lijst een standaard string waardoor niets gefilterd wordt
            cbClass.Items.Add("Alle klassen");

            foreach (Class c in Classes)
            {
                cbClass.Items.Add(c);
                cbClass.Sorted = true;
            }

            cbClass.SelectedIndex = 0;
            FillList();
            }
        public void FillList()
        {
            listView1.Items.Clear();

            // hier worden alle afnamemomenten in een lijst toegevoegd aan de listview, deze functie wordt alleen aangeroepen bij het openen van het scherm en het resetten van de filters
            foreach (Exam ex in Exams)
            {
                ListViewItem item = listView1.Items.Add(ex.Questionnaire.Name);
                item.SubItems.Add(Convert.ToString(ex.Questionnaire.Subject));
                item.SubItems.Add(Convert.ToString(ex.Starttime));
                item.SubItems.Add(Convert.ToString(ex.Endtime));
                item.Tag = ex;
            }
        }
        public void FillListFilter(Exam ex)
        {
            // deze functie voegt één afnamemoment toe aan de listview, wordt aangeroepen in de filter functie voor elk afnamemoment dat door de filters heen komt
                listView1.Items.Add(ex.Questionnaire.Name);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(Convert.ToString(ex.Questionnaire.Subject));
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(Convert.ToString(ex.Starttime));
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(Convert.ToString(ex.Endtime));
                listView1.Items[listView1.Items.Count - 1].Tag = ex;
        }

        public virtual void btnOk_Click(object sender, EventArgs e)
        {
            // Wanneer je op OK klikt nadat je een afnamemoment hebt gekozen, gaat het programma door naar de resultaten voor dat afnamemoment
            // Als er geen afnamemoment geselecteerd is krijg je een melding
            if (listView1.SelectedItems.Count > 0)
            {
                Controller.x = (Exam)listView1.SelectedItems[0].Tag;
            }
            if (Controller.x != null)
            {
                this.Close();
                Controller.GoToResults();
            }
            else
            {
                MessageBox.Show("Je hebt geen afnamemoment geselecteerd", "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ApplyFilter();
                }
                    
        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ApplyFilter();

            // Wanneer het geselecteerde item in de lijst met vakken verandert, wordt de lijst met vragenlijsten ook meteen bijgewerkt
            // Wanneer er geen filter voor vak is gekozen, worden alle vragenlijsten toegevoegd aan de lijst met vragenlijsten
            // Wanneer er wel een filter is gekozen, kijkt de applicatie welke vragenlijsten er bij dat vak horen, en voegt het deze vervolgens toe aan de lijst met vragenlijsten
            if (cbSubject.GetItemText(cbSubject.SelectedItem) == "Alle vakken")
            {
                FillQuestionnaire();
            }
            else
            {
                cbQuestionnaire.Items.Clear();
                // ook hier is het eerste item in de lijst een standaard string waardoor niets gefilterd wordt
                cbQuestionnaire.Items.Add("Alle vragenlijsten");

                foreach (Questionnaire q in Questionnaires)
                {
                    if(q.Subject.Name == cbSubject.GetItemText(cbSubject.SelectedItem)){
                        
                        cbQuestionnaire.Items.Add(q);
                        cbQuestionnaire.Sorted = true;
                    }
                }

                cbQuestionnaire.SelectedIndex =0;
            }
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ApplyFilter();
         }


        private void btnReset_Click(object sender, EventArgs e)
            {
            // Alle filters worden ge-reset en de listview wordt gevuld met alle afnamemomenten
            dateTimePicker1.Value = DateTime.Now;
            cbSubject.SelectedIndex = 0;
            cbClass.SelectedIndex = 0;
            cbQuestionnaire.SelectedIndex = 0;
            checkBox_Date.Checked = true;
            listView1.Items.Clear();

                foreach (Exam ex in Exams)
                {
                    FillList();
                }
            }

        private void cbQuestionnaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ApplyFilter();
        }

        private void FillQuestionnaire()
        {
            // hier worden alle vragenlijsten toegevoegd aan de lijst met vragenlijsten
            cbQuestionnaire.Items.Clear();
            // ook hier is het eerste item in de lijst een standaard string waardoor niets gefilterd wordt
            cbQuestionnaire.Items.Add("Alle vragenlijsten");

            foreach (Questionnaire q in Questionnaires)
            {
                cbQuestionnaire.Items.Add(q);
                cbQuestionnaire.Sorted = true;
                    }

            cbQuestionnaire.SelectedIndex = 0;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                Exam exam = (Exam)listView1.SelectedItems[0].Tag;
            }
        }
        private void ApplyFilter()
        {
            // Functie om de afnamemomenten die voldoen aan de filters in de listview te zetten, wordt elke keer dat een filter verandert aangeroepen
            // Sorteren van de lijst wordt tijdelijk uitgezet, omdat de lijst anders gesorteerd wordt voordat de subitems worden toegevoegd
            listView1.Sorting = SortOrder.None;

            // De lijst met gefilterde afnamemomenten wordt leeggehaald, en opnieuw gevuld met de afnamemomenten die voldoen aan de filters
            ExamFilter.Clear();

            foreach (Exam ex in Exams)
            {
                if (cbSubject.GetItemText(cbSubject.SelectedItem) == "Alle vakken" || cbSubject.GetItemText(cbSubject.SelectedItem) == ex.Questionnaire.Subject.Name)
                {
                    if(cbClass.GetItemText(cbClass.SelectedItem) == "Alle klassen" || cbClass.GetItemText(cbClass.SelectedItem) == ex.Class.Code)
            {
                        if(cbQuestionnaire.GetItemText(cbQuestionnaire.SelectedItem) == "Alle vragenlijsten" || String.Format("{0}: {1}", ex.Questionnaire.Subject, ex.Questionnaire.Name) == cbQuestionnaire.GetItemText(cbQuestionnaire.SelectedItem))
                {
                            if(checkBox_Date.Checked || ex.Starttime > dateTimePicker1.Value.Date && ex.Starttime < dateTimePicker1.Value.Date.AddDays(1))
                    {
                                ExamFilter.Add(ex);
                            }
                    }
                }
                    }
                }
            // Lijst met gefilterde afnamemomenten wordt toegevoegd aan de listview
            foreach(Exam ex in ExamFilter)
        {
                FillListFilter(ex);
            }
            // Sorteren van de lijst wordt hier weer aangezet
            listView1.Sorting = SortOrder.Ascending;
            }

        //Wanneer checkbox1 van waarde veranderd, clear de listview en voeg de filter toe.
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
            listView1.Items.Clear();
            ApplyFilter();
        }
    }
    }
