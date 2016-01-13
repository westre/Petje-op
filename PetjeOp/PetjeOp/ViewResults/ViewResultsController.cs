using PetjeOp;
using PetjeOp.AddQuestionnaire;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.Questionnaires;

namespace PetjeOp {
    public class ViewResultsController : Controller
    {
        public ViewResultsView View { get; set; }
        public ViewResultsModel Model { get; set; }
        public Exam ex;

        public ViewResultsController(MasterController masterController) : base(masterController)
        {
            Model = new ViewResultsModel();
            View = new ViewResultsView(this);
            
        }

        public override UserControl GetView()
        {
            return View;
        }
        // hier worden de resultaten weergegeven
        public void ShowResults(Exam ex)
        {
            View.listQuestions.Items.Clear();
            ClearChart();
            AddQuestionsToList(ex.Questionnaire.Questions);

        }
        // hier worden de vragen die uit de database worden gehaald, toegevoegd aan de lijst met vragen per vragenlijst
        public void AddQuestionsToList(List<Question> questions)
        {
            foreach (Question q in questions)
            {

                View.listQuestions.Items.Add(q);
            }
        }

        // hier wordt de grafiek leeggemaakt
        public void ClearChart()
        {
            View.series1.Points.Clear();
            View.label1.Text = "";
            View.chartArea1.BackColor = System.Drawing.SystemColors.Control;
            View.chart1.BackColor = System.Drawing.SystemColors.Control;
            
        }
        // hier wordt de grafiek gevuld met data
        public void ShowChart()
        {
            //Leeg eerst de grafiek.
            ClearChart();
            //Check of er een item in de lijst is geselecteerd.
            if (View.listQuestions.SelectedItem != null) {
                //Zo ja, maak een question aan met de huidige geselecteerde question
                Question chosen = (Question)View.listQuestions.SelectedItem;
                //Zet de huidige kleur
                View.chartArea1.BackColor = System.Drawing.SystemColors.Window;
                //Zet de tekst naar de beschrijving van de gekozen question.
                View.label1.Text = chosen.Description;
                //Haal alle antwoorden van de gekozen vraag uit de database.
                List<Answer> answers = this.MasterController.DB.GetAnswersByQuestion(chosen.ID);

                //Voer dit uit voor elk antwoord.
                foreach (Answer answer in answers)
                {
                    //Haal alle leerlingAntwoorden op die bij dit antwoord horen.
                    List<Result> results = this.MasterController.DB.GetResultByAnswer(chosen.ID, answer.ID, ex.Examnr);
                    //Tel hoeveel leerlingen dit antwoord hebben gegeven.
                    double amount = results.Count;
                    //Maak een point aan naar hoeveel mensen dit antwoord hebben gegeven.
                    System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, amount);
                    //Print de beschrijving van dit antwoord aan de onderkant van de as.
                    dataPoint1.AxisLabel = Convert.ToString(this.MasterController.DB.GetDescriptionByAnswer(answer.ID));
                    //Wanneer het het goede antwoord is, kleur de balk groen, zo niet, kleur de balk rood.
                    if (answer.ID == chosen.CorrectAnswer.ID)
                    {
                        dataPoint1.Color = Color.Green;
                    }
                    else
                    {
                        dataPoint1.Color = Color.Red;
                    }
                    //Kleur het daadwerkelijke punt.
                    View.series1.Points.Add(dataPoint1);
                }
            }
        }
        // hier ga je terug naar het toevoegen en inzien van vragenlijsten
        public void GoToMainMenu()
        {
            Controller controller = MasterController.GetController(typeof(TeacherHomeController));
            MasterController.SetController(controller);
        }

    }
}