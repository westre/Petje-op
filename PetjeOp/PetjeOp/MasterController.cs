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

namespace PetjeOp {
    public partial class MasterController : Form {
        private List<Controller> Controllers { get; set; }
        private Controller ActiveParentContainer { get; set; }

        public MasterController() {
            InitializeComponent();
            Controllers = new List<Controller>();

            // Initialiseer de controllers
            Controllers.Add(new LoginController(this));
            Controllers.Add(new TeacherController(this));
            Controllers.Add(new StudentController(this));
            Controllers.Add(new AddQuestionnaireController(this));

            // We beginnen met deze view, verander dit niet!
            mainPanel.Controls.Add(GetController(typeof(LoginController)).GetView());
        }

        public Controller GetController(Type type) {
            foreach(Controller controller in Controllers) {
                if (controller.GetType() == type)
                    return controller;
            }
            return null;
        }

        // Dit wordt bijvoorbeeld aangeroepen wanneer we op een knop klikken (zie ExampleView.button1_Click)
        public void SetController(Controller controller) {
            if (ActiveParentContainer is TeacherController) {
                TeacherController teacherController = (TeacherController)ActiveParentContainer;
                teacherController.GetViewPanel().Controls.Add(controller.GetView());
            }
            else if (ActiveParentContainer is StudentController) {
                StudentController studentController = (StudentController)ActiveParentContainer;
                studentController.GetViewPanel().Controls.Add(controller.GetView());
            }

            if (controller is TeacherController) {
                mainPanel.Controls.Clear();

                ActiveParentContainer = (TeacherController)controller;           
                mainPanel.Controls.Add(ActiveParentContainer.GetView());

                // Initialisatie van AddQuestionnaireController wanneer we in TeacherController zitten
                AddQuestionnaireController addQuestionnaireController = (AddQuestionnaireController)GetController(typeof(AddQuestionnaireController));
                addQuestionnaireController.View.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
                addQuestionnaireController.View.Width = ((TeacherController)ActiveParentContainer).GetViewPanel().Width;
                addQuestionnaireController.View.Height = ((TeacherController)ActiveParentContainer).GetViewPanel().Height;
                SetController(GetController(typeof(AddQuestionnaireController)));
            }
            else if(controller is StudentController) {
                mainPanel.Controls.Clear();

                ActiveParentContainer = (StudentController)controller;               
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
