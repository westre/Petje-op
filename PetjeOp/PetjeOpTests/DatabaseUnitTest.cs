using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetjeOp;
using System.Collections.Generic;


namespace PetjeOpTests {

    [TestClass]
    public class DatabaseUnitTest
    {
        private Database db = new Database();

        [TestMethod]
        public void TestIfQuestionnairesIsFullyFilled()
        {
            List<Questionnaire> questionnaires = db.GetAllQuestionnaires();

            Assert.IsNotNull(questionnaires, "Questionnaires is null");

            foreach (Questionnaire questionnaire in questionnaires)
            {
                Assert.IsNotNull(questionnaire.Questions, "Questions is null");

                foreach (Question question in questionnaire.Questions)
                {
                    Assert.IsNotNull(((MultipleChoiceQuestion)question).AnswerOptions, "Answer is null");
                }
            }
        }
        [TestMethod]
        public void TestGetQuestionnaire()
        {
            Questionnaire questionnaire = db.GetQuestionnaire(5);
            Assert.IsNotNull(questionnaire, "Questionnaire is null");
        }

        [TestMethod]
        public void TestGetQuestion()   
        {
            Question question = db.GetQuestion(1);
            Assert.IsNotNull(question, "Questionnaire is null");
        }

        [TestMethod]
        public void TestUpdateQuestionnaire()
        {
            Questionnaire questionnaire = db.GetQuestionnaire(1023);
            questionnaire.Name = "NewName";
            db.UpdateQuestionnaire(questionnaire);
            questionnaire = db.GetQuestionnaire(1023);
            Assert.AreEqual(questionnaire.Name, "NewName");

        }
    }
}
