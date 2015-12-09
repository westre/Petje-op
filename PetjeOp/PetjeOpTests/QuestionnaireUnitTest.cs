using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetjeOp;

namespace PetjeOpTests
{
    [TestClass]
    public class QuestionnaireUnitTest
    {
        [TestMethod]
        public void TestIfListExists()
        {
            Questionnaire questionnaire = new Questionnaire("test vrgenlijst");

            Assert.IsNotNull(questionnaire.Questions);
        }
    }
}
