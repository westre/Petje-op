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
    public partial class TeacherHomeView : UserControl {
        public TeacherHomeController Controller;

        public TeacherHomeView(TeacherHomeController controller) {
            InitializeComponent();

            Controller = controller;
        }

        private void TeacherHomeView_Load(object sender, EventArgs e)
        {
            //Laad de titel met naam van docent
            Controller.InitializeTitle();
        }

        private void btnGoToResults_Click(object sender, EventArgs e)
        {
            //Ga naar resultatenscherm
            Controller.GoToResults();
        }

        private void btnGoToQuestionnaires_Click(object sender, EventArgs e)
        {
            //Ga naar vragenlijsten
            Controller.GoToQuestionnaires();
        }
    }
}