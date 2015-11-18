using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public partial class MasterController : Form {
        // Declareer hieronder alle controllers
        private ExampleController ExampleController { get; set; }
        private ExampleTwoController ExampleTwoController { get; set; }

        // Declareer hier ook wanneer je een nieuwe controller toevoegt
        public enum Controllers {
            ExampleController,
            ExampleControllerTwo
        }

        public MasterController() {
            InitializeComponent();
            mainPanel.Dock = DockStyle.Fill;

            // Initialiseer de controllers
            ExampleController = new ExampleController(this);
            ExampleTwoController = new ExampleTwoController(this);

            // We beginnen met deze view
            mainPanel.Controls.Add(ExampleController.View);
        }

        // Dit wordt bijvoorbeeld aangeroepen wanneer we op een knop klikken (zie ExampleView.button1_Click)
        public void SetController(Controllers controller) {
            // Eerst verwijderen we de view
            mainPanel.Controls.Clear();

            // We voegen dan de view toe aan het paneel
            if(controller == Controllers.ExampleController) {
                mainPanel.Controls.Add(ExampleController.View);
            }
            else if (controller == Controllers.ExampleControllerTwo) {
                mainPanel.Controls.Add(ExampleTwoController.View);
            }
        }
    }
}
