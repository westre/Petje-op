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
    public partial class AddExamView : UserControl {
        public AddExamController Controller;

        public AddExamView(AddExamController controller) {
            InitializeComponent();
            Controller = controller;
        }

        private void AddExamView_Load(object sender, EventArgs e)
        {
            Controller.GetAllData();
            Controller.Model.TimeNow = DateTime.Now;
            dtpStarttimeDate.MinDate = Controller.Model.TimeNow;
            dtpStarttimeTime.MinDate = Controller.Model.TimeNow;
            dtpEndtimeTime.MinDate = Controller.Model.TimeNow;
            Controller.FillSubjectsCb();
        }

        private void cbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Controller.CheckIfCbEnabled())
                Controller.FillQuestionnaireAndClassCb();
            Controller.CheckLabels();
        }

        private void cbQuestionnaires_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.CheckLabels();

        }

        private void cbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.CheckLabels();

        }

        private void dtpStarttimeDate_ValueChanged(object sender, EventArgs e)
        {
            Controller.CheckLabels();
        }

        private void dtpStarttimeTime_ValueChanged(object sender, EventArgs e)
        {
            Controller.CheckLabels();
        }

        private void dtpEndtimeTime_ValueChanged(object sender, EventArgs e)
        {
            Controller.CheckLabels();

        }

        private void btnSaveExam_Click(object sender, EventArgs e)
        {
            Controller.SaveExam();
        }
    }
}