using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetjeOp;
using PetjeOp.Questionnaires;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire;

namespace PetjeOpTests
{
    [TestClass]
    public class QuestionnaireDetailUnitTest
    {
        private QuestionnaireDetailController qdc = new QuestionnaireDetailController(new MasterController());

        [TestMethod]
        public void CheckSetQuestionnaire()
        {
            Questionnaire q = qdc.MasterController.DB.GetQuestionnaire(5);
            qdc.SetQuestionnaire(q);

            Assert.IsNotNull(qdc.Model.Questionnaire);
        }

        [TestMethod]
        public void CheckGoToQuestionnaireOverview()
        {
            qdc.GoToQuestionnaireOverview();
            Assert.IsInstanceOfType(qdc.MasterController.GetController(typeof(QuestionnaireOverviewController)), typeof(QuestionnaireOverviewController));
        }

        [TestMethod]
        public void CheckSetLabels()
        {
            Questionnaire q = qdc.MasterController.DB.GetQuestionnaire(5);
            qdc.SetLabels();

            Assert.AreEqual(q.Name, qdc.View.lblNameData.Text);
            Assert.AreEqual(q.Subject.Name, qdc.View.lblSubjectData);
            Assert.IsTrue(qdc.View.lblAuthorData.Text.Any());
        }
    }
}