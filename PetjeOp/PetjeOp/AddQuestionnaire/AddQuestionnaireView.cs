using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp.AddQuestionnaire
{
    public partial class AddQuestionnaireView : UserControl
    {
        public AddQuestionnaireController Controller;

        public AddQuestionnaireView(AddQuestionnaireController controller)
        {
            Controller = controller;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) {
            // Test
            Controller targetController = Controller.MasterController.GetController(typeof(ExampleController));
            Controller.MasterController.SetController(targetController);
        }
    }
}
