using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetjeOp;
using PetjeOp.Questionnaires;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire;
using PetjeOp.QuestionnaireDetail;

namespace PetjeOpTests
{
    [TestClass]
    public class QuestionnaireDetailUnitTest
    {
        private QuestionnaireDetailController qdc = new QuestionnaireDetailController(new MasterController());

        [TestMethod]
        public void CheckSetQuestionnaire()
        {
            qdc.MasterController.User = qdc.MasterController.DB.GetTeacher("eltjo1");
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
            qdc.Model.Questionnaire = q;
            qdc.SetLabels();

            Assert.AreEqual(q.Name, qdc.View.lblNameData.Text);
            Assert.AreEqual(q.Subject.Name, qdc.View.lblSubjectData.Text);
            Assert.IsTrue(qdc.View.lblAuthorData.Text.Any());
        }

        [TestMethod]
        public void CheckFillCbSelectQuestionnaire()
        {
            qdc.Model.Questionnaires = qdc.MasterController.DB.GetAllQuestionnaires();
            qdc.FillCbSelectQuestionnaire();
            Assert.AreNotEqual(0, qdc.View.cbSelectQuestionnaire.Items.Count);
        }

        [TestMethod]
        public void CheckFillCbSubjects()
        {
            qdc.FillCbSubjects();
            Assert.AreNotEqual(0, qdc.View.cbSubject.Items.Count);
        }

        [TestMethod]
        public void CheckSelectSubject()
        {
            qdc.FillCbSubjects();
            List<Subject> subjects = qdc.MasterController.DB.GetAllSubjects();
            Subject s = subjects[1];
            qdc.SelectSubject(s);

            Assert.AreNotEqual(0, subjects.Count);
            Assert.IsNotNull(qdc.View.cbSubject.SelectedItem);
        }

        [TestMethod]
        public void CheckSaveQuestionnaireDetails()
        {
            qdc.Model.Questionnaire = qdc.MasterController.DB.GetQuestionnaire(5);
            qdc.View.tbNameEdit.Text = "Test";

            qdc.FillCbSubjects();
            List<Subject> subjects = qdc.MasterController.DB.GetAllSubjects();
            Subject s = subjects[1];
            qdc.SelectSubject(s);

            qdc.SaveQuestionnaireDetails();

            Assert.AreEqual(qdc.View.tbNameEdit.Text, qdc.Model.Questionnaire.Name);
            Assert.AreEqual(qdc.View.cbSubject.SelectedItem, qdc.Model.Questionnaire.Subject);
        }

        [TestMethod]
        public void CheckCheckForErrors()
        {
            Assert.AreEqual("", qdc.View.epTbEdit.GetError(qdc.View.tbNameEdit));

            qdc.View.epTbEdit.SetError(qdc.View.tbNameEdit, "Error");

            Assert.AreEqual("Error", qdc.View.epTbEdit.GetError(qdc.View.tbNameEdit));
        }
    }
}