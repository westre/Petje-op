using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire.AddQuestion;

namespace PetjeOp.AddQuestionnaire
{
    public partial class AddQuestionnaireView : UserControl
    {
        public AddQuestionnaireController Controller { get; set; }

        public AddQuestionnaireView(AddQuestionnaireController controller)
        {
            Controller = controller;
            InitializeComponent();
        }

        //Als je op de AddQuestion klikt, laat een dialoogvenster zien.
        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            Controller.ShowQuestionDialog();
        }

        //Nadat er een node is geselecteerd in de treeview, controleer of de knoppen enabled kunnen worden.
        private void tvQuestions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Controller.ControlEditDeleteButtons();
        }

        //Wanneer er op de EditQuestion button is geklikt, open het wijzig vraag scherm.
        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            Controller.editQuestion();
        }

        //Wanneer er op de DeleteQuestion button is geklikt, open het verwijder vraag scherm.
        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            Controller.DeleteQuestion();
        }

        //Wanneer de tekst in de QuestionnaireName textbox is aangepast, kijk of de buttons enabled kunnen worden.
        private void tbQuestionnaireName_TextChanged(object sender, EventArgs e)
        {
            Controller.CheckButtons();
        }

        //Wanneer er op de SaveQuestionnaire button is geklikt, wijzig het vak van de vragenlijst en sla hem dan op.
        private void btnSaveQuestionnaire_Click(object sender, EventArgs e)
        {
            Controller.setSubject();
            Controller.SaveQuestionnaire();
        }

        //Wanneer de QuestionnaireView is geladen, voeg vakken toe.
        private void AddQuestionnaireView_Load(object sender, EventArgs e)
        {
            Controller.AddSubjects();
        }
    }
}
