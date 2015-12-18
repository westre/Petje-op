using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetjeOp;
using PetjeOp.Questionnaires;
using System.Windows.Forms;

namespace PetjeOpTests
{
    [TestClass]
    public class QuestionnaireOverviewTest
    {
        QuestionnaireOverviewController qoc = new QuestionnaireOverviewController(new MasterController());

        [TestMethod]
        public void CheckGetAllQuestionnairesAndSubjects()
        {
            qoc.GetAllQuestionnairesAndSubjects();
        }  
    }
}
