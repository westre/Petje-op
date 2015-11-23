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

        //De MasterController wordt altijd meegegeven, gebruik is bijv. alsvolgt:
        //Question q = masterController.DB.GetQuestion(id);
        public Database DB { get; private set; }

        public MasterController() {
            InitializeComponent();
            Controllers = new List<Controller>();

            // Initialiseer de controllers
            Controllers.Add(new ExampleController(this));
            Controllers.Add(new ExampleTwoController(this));
            Controllers.Add(new AddQuestionnaireController(this));

            // We beginnen met deze view
            mainPanel.Controls.Add(GetController(typeof(AddQuestionnaireController)).GetView());


            // Kevin: Doe dit anders in de constructor van AddQuestionnaireController
            AddQuestionnaireController addQuestionnaireController = (AddQuestionnaireController)GetController(typeof(AddQuestionnaireController));
            if (addQuestionnaireController != null) {
                addQuestionnaireController.View.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
                mainPanel.AutoScroll = true;
                addQuestionnaireController.View.Width -= 180;
                addQuestionnaireController.View.Height += 10;

                Console.WriteLine("Not null");
            }

            //Creëer database instantie
            DB = new Database();
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
            // Eerst verwijderen we de view
            mainPanel.Controls.Clear();

            // Dan voegen we de nieuwe view toe
            mainPanel.Controls.Add(controller.GetView());
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
