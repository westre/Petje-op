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
            //Haal alle data op uit de database
            Controller.GetAllData();
            //Set alle data naar de data van de model
            Controller.Model.TimeNow = DateTime.Now;
            dtpStarttimeDate.MinDate = Controller.Model.TimeNow;
            dtpStarttimeTime.MinDate = Controller.Model.TimeNow;
            dtpEndtimeTime.MinDate = Controller.Model.TimeNow;
            //Vul de comboboxes
            Controller.FillSubjectsCb();
        }

        //Wanneer de onderwerpcombobox veranderd, vul de comboboxes van Questionnaire en Class.
        private void cbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Controller.CheckIfCbEnabled())
                Controller.FillQuestionnaireAndClassCb();
            Controller.CheckLabels();
        }

        //Wanneer de questionnairecombobox veranderd, kijk of de opslagknop enabled kan worden.
        private void cbQuestionnaires_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.CheckLabels();

        }
        //Wanneer de klassencombobox veranderd, kijk of de opslagknop enabled kan worden.

        private void cbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.CheckLabels();

        }

        //Wanneer de datetimepicker van de starttimedate veranderd, kijk of de opslagknop enabled kan worden.
        private void dtpStarttimeDate_ValueChanged(object sender, EventArgs e)
        {
            Controller.CheckLabels();
        }

        //Wanneer de datetimepicker van de starttimetime veranderd, kijk of de opslagknop enabled kan worden.
        private void dtpStarttimeTime_ValueChanged(object sender, EventArgs e)
        {
            Controller.CheckLabels();
        }

        //Wanneer de datetimepicker van de endttimetime veranderd, kijk of de opslagknop enabled kan worden.
        private void dtpEndtimeTime_ValueChanged(object sender, EventArgs e)
        {
            Controller.CheckLabels();

        }
        
        //Wanneer er op de opslaanknop geklikt wordt: Voeg de opslaanfunctie uit.
        private void btnSaveExam_Click(object sender, EventArgs e)
        {
            Controller.SaveExam();
        }
    }
}