using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetjeOp;
using PetjeOp.Questionnaires;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire;

namespace PetjeOpTests
{
    [TestClass]
    public class AddQuestionnaireUnitTest
    {
        private AddQuestionnaireController aqc = new AddQuestionnaireController(new MasterController());

        [TestMethod]
        public void CheckGetView()
        {
            Assert.IsNotNull(aqc.GetView());
        }

        [TestMethod]
        public void CheckAddSubjects()
        {
            aqc.AddSubjects();
            Assert.IsNotNull(aqc.View.cbSubjects.Items.Count);
        }

        [TestMethod]
        public void CheckSetSubject()
        {
            aqc.AddSubjects();
            aqc.SetSubject();
            Assert.AreEqual(aqc.View.cbSubjects.SelectedItem, aqc.Model.Questionnaire.Subject);
        }

        [TestMethod]
        public void CheckGoToQuestionnaireOverview()
        {
            aqc.GoToQuestionnaireOverview();
            Assert.IsInstanceOfType(aqc.MasterController.GetController(typeof(QuestionnaireOverviewController)), typeof(QuestionnaireOverviewController));
        }

        [TestMethod]
        public void CheckClearControls()
        {
            aqc.ClearControls();
            Assert.IsTrue(aqc.View.tbQuestionnaireName.Text == "");
            Assert.IsTrue(aqc.View.cbSubjects.SelectedIndex == -1);
            Assert.IsTrue(aqc.View.questionsView1.tvQuestions.Nodes.Count == 0);
        }
    }
}