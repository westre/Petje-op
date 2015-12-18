using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetjeOp;
using PetjeOp.Questionnaires;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire;

namespace PetjeOpTests
{
    [TestClass]
    public class QuestionnaireOverviewTest
    {
        private QuestionnaireOverviewController qoc = new QuestionnaireOverviewController(new MasterController());
        private Teacher t = new Teacher("2222222", "Patricia", "van Meel - Mansveld");
        private Subject s = new Subject(7, "C#");

        [TestMethod]
        public void CheckGetAllQuestionnairesAndSubjects()
        {
            qoc.GetAllQuestionnairesAndSubjects();

            Assert.IsNotNull(qoc.Model.AllQuestionnaires);
            Assert.IsNotNull(qoc.Model.Subjects);
            Assert.IsNotNull(qoc.Model.Teachers);
        }

        [TestMethod]
        public void CheckFillComboBoxes()
        {
            qoc.GetAllQuestionnairesAndSubjects();
            qoc.FillComboBoxes();

            Assert.AreNotEqual(0, qoc.View.cbSubjects.Items.Count);
            Assert.AreNotEqual(0, qoc.View.cbAuthors.Items.Count);
        }

        [TestMethod]
        public void CheckFilterQuestionnairesTeacher()
        {
            qoc.GetAllQuestionnairesAndSubjects();
            qoc.FillTreeView();
            qoc.FilterQuestionnaires(t);

            Assert.IsNotNull(qoc.Model.ListQuestionnaires);
        }

        [TestMethod]
        public void CheckFilterQuestionnairesSubject()
        {
            qoc.GetAllQuestionnairesAndSubjects();
            qoc.FillTreeView();
            qoc.FilterQuestionnaires(s);

            Assert.IsNotNull(qoc.Model.ListQuestionnaires);
        }

        [TestMethod]
        public void CheckGoToAddQuestionnaire()
        {
            qoc.GoToAddQuestionnaire();
            Assert.IsInstanceOfType(qoc.MasterController.GetController(typeof(AddQuestionnaireController)), typeof(AddQuestionnaireController));
        }

        [TestMethod]
        public void CheckGoToQuestionnaireDetails()
        {
            qoc.GoToQuestionnaireDetails();
            Assert.IsInstanceOfType(qoc.MasterController.GetController(typeof(QuestionnaireDetailController)), typeof(QuestionnaireDetailController));
        }

        [TestMethod]
        public void CheckFillTreeview()
        {
            qoc.GetAllQuestionnairesAndSubjects();
            qoc.FillTreeView();

            Assert.AreNotEqual(0, qoc.View.tvQuestionnaires.Nodes.Count);
        }

        [TestMethod]
        public void CheckFilterOnOwnQuestionnaires()
        {
            qoc.MasterController.User = t;
            qoc.GetAllQuestionnairesAndSubjects();
            qoc.FillComboBoxes();
            qoc.View.cbOwnQuestionnairesOnly.Checked = true;
            qoc.FilterOnOwnQuestionnaires();

            Assert.AreEqual(t.TeacherNr, ((Teacher)qoc.View.cbAuthors.SelectedItem).TeacherNr);
        }

        [TestMethod]
        public void CheckResetLists()
        {
            qoc.GetAllQuestionnairesAndSubjects();
            qoc.ResetLists();

            Assert.IsNotNull(qoc.Model.ListQuestionnaires);
        }
    }
}