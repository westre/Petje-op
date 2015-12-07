using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire;
using PetjeOp.Questionnaires;

namespace PetjeOp
{
    public partial class MasterController : Form
    {
        private List<Controller> Controllers { get; set; }
        public IEnvironment ActiveParentContainer { get; set; }

        //De MasterController wordt altijd meegegeven, gebruik is bijv. alsvolgt:
        //Question q = masterController.DB.GetQuestion(id);
        public Database DB { get; private set; }

        //De user is het type gebruiker: Student, Teacher.
        public Person User { get; set; }

        // Voor Yoran, verwijder dit hierna
        public YoranHierKijken Yoran { get; set; }

        public MasterController()
        {
            InitializeComponent();
            Controllers = new List<Controller>();

            // Initialiseer de controllers
            Controllers.Add(new LoginController(this));
            Controllers.Add(new TeacherController(this));
            Controllers.Add(new StudentController(this));
            Controllers.Add(new QuestionnaireDetailController(this));
            Controllers.Add(new AddQuestionnaireController(this));
            Controllers.Add(new ViewResultsController(this));
            Controllers.Add(new QuestionnaireOverviewController(this));
            Controllers.Add(new AnswerQuestionnaireController(this));

            // We beginnen met deze view, verander dit niet!
            mainPanel.Controls.Add(GetController(typeof(LoginController)).GetView());

            //Creëer database instantie
            DB = new Database();

            // verwijder
            Yoran = new YoranHierKijken();
        }

        public Controller GetController(Type type)
        {
            foreach (Controller controller in Controllers)
            {
                if (controller.GetType() == type)
                    return controller;
            }
            return null;
        }

        // Dit wordt bijvoorbeeld aangeroepen wanneer we op een knop klikken (zie ExampleView.button1_Click)
        public void SetController(Controller controller)
        {
            if (ActiveParentContainer != null)
            {
                ActiveParentContainer.GetViewPanel().Controls.Clear();

                // Initialize view met anchors en hoogte en breedte van de parent container
                controller.InitializeView();
                ActiveParentContainer.GetViewPanel().Controls.Add(controller.GetView());

                // call event
                OnResize(EventArgs.Empty);
            }

            if (controller is TeacherController)
            {
                mainPanel.Controls.Clear();

                ActiveParentContainer = (TeacherController)controller;
                mainPanel.Controls.Add(ActiveParentContainer.GetView());

                // Initialisatie van QuestionnaireOverviewController wanneer we in TeacherController zitten
                QuestionnaireOverviewController questionnaireOverviewController = (QuestionnaireOverviewController)GetController(typeof(QuestionnaireOverviewController));
                questionnaireOverviewController.InitializeView();
                SetController(questionnaireOverviewController);
            } else if (controller is StudentController)
            {
                mainPanel.Controls.Clear();

                ActiveParentContainer = (StudentController)controller;
                mainPanel.Controls.Add(ActiveParentContainer.GetView());
            }
            else if (controller is QuestionnaireDetailController)
            {
                mainPanel.Controls.Clear();

                ActiveParentContainer = (QuestionnaireDetailController)controller;
                mainPanel.Controls.Add(ActiveParentContainer.GetView());
            }
            else if (controller is AnswerQuestionnaireController)
            {
                mainPanel.Controls.Clear();

                ActiveParentContainer = (AnswerQuestionnaireController)controller;
                mainPanel.Controls.Add(ActiveParentContainer.GetView());
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}