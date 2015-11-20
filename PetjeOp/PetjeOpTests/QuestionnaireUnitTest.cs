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

        [TestMethod]
        public void TestIfListFills()
        {
            MultipleChoiceQuestion q1 = new MultipleChoiceQuestion("Werkt dit?");
            Questionnaire qs = new Questionnaire("Testlijst");

            qs.addQuestion(q1);

            Assert.IsNotNull(qs.Questions[0]);
        }

        [TestMethod]
        public void TestIfQuestionsGetRemoved()
        {
            MultipleChoiceQuestion q1 = new MultipleChoiceQuestion("Werkt dit?");
            Questionnaire qs = new Questionnaire("Testlijst");

            qs.addQuestion(q1);
            qs.deleteQuestion(0);

            Assert.IsTrue(qs.Questions.Count == 0);
        }
    }
}
