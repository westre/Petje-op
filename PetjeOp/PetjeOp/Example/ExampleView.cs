using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public partial class ExampleView : UserControl {
        public ExampleController Controller;

        public ExampleView(ExampleController controller) {
            InitializeComponent();

            Controller = controller;
        }

        private void button1_Click(object sender, EventArgs e) {
            // Hier roepen we de MasterController aan en zeggen we dat we een andere controller willen gebruiken
            Controller.MasterController.SetController(MasterController.Controllers.AddQuestionnaireController);
        }
    }
}
