﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire;
using PetjeOp.Questionnaires;
using PetjeOp.Login;

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
            Controllers.Add(new TeacherHomeController(this));
            Controllers.Add(new AddExamController(this));
            Controllers.Add(new ExamOverviewStudentController(this));
            Controllers.Add(new ExamOverviewTeacherController(this));
            Controllers.Add(new EditExamController(this));

            //Creëer databaseinstantie
            DB = new Database();
            DB.AnswerCleanup();

            Resize += MasterController_Resize;
        }

        // Deze functie wordt gebruikt om een bepaald type controller uit de lijst van Controllers op te halen
        // Deze voor aangemaakte controller kan dan vervolgens gebruikt worden om als actieve Controller in te stellen
        public Controller GetController(Type type)
        {
            foreach (Controller controller in Controllers)
            {
                if (controller.GetType() == type)
                    return controller;
            }
            return null;
        }

        // Dez functie wordt gebruikt om de actieve controller te wijzigen, in andere woorden van scherm te wisselen
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

                // Initialisatie van TeacherHomeController wanneer we in TeacherController zitten
                TeacherHomeController teacherHomeController = (TeacherHomeController)GetController(typeof(TeacherHomeController));
                teacherHomeController.InitializeView();
                SetController(teacherHomeController);
            }
            else if (controller is StudentController)
            {
                mainPanel.Controls.Clear();

                ActiveParentContainer = (StudentController)controller;
                mainPanel.Controls.Add(ActiveParentContainer.GetView());

                // Initialisatie van ExamOverviewStudentController wanneer we in StudentController zitten
                ExamOverviewStudentController questionnaireOverviewController = (ExamOverviewStudentController)GetController(typeof(ExamOverviewStudentController));
                questionnaireOverviewController.Init();
                questionnaireOverviewController.InitializeView();
                SetController(questionnaireOverviewController);
            }
        }

        private void MasterController_Resize(object sender, EventArgs e)
        {
            if (ActiveParentContainer != null)
            {
                // Resize de parent container met de form
                ActiveParentContainer.GetView().Width = mainPanel.Width;
                ActiveParentContainer.GetView().Height = mainPanel.Height;

                ActiveParentContainer.GetHeaderPanel().Width = Width;
                if (Width > 930)
                    ActiveParentContainer.GetLogoutButton().Location = new Point(Width - ActiveParentContainer.GetLogoutButton().Size.Width - 25, ActiveParentContainer.GetLogoutButton().Location.Y);
            }
        }

        public void Logout()
        {
            this.User = null;
            this.Visible = false;
            this.ActiveParentContainer = null;

            //Application.Restart();

            LoginView LoginView = new LoginView((LoginController)this.GetController(typeof(LoginController)));
            if (LoginView.ShowDialog() == DialogResult.OK) //Als login dialog OK returnt dan MasterController uitvoeren
            {
                this.Visible = true;
            }
            else
            {
               Application.Exit();
            }
        }
    }
}