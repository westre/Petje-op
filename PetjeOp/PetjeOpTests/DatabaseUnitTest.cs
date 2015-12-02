using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetjeOp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOpTests {

    [TestClass]
    public class DatabaseUnitTest {
        [TestMethod]
        public void TestIfQuestionnairesIsFullyFilled() {
            Database db = new Database();
            List<Questionnaire> questionnaires = db.GetAllQuestionnaires();

            Assert.IsNotNull(questionnaires, "Questionnaires is null");

            foreach(Questionnaire questionnaire in questionnaires) {
                Assert.IsNotNull(questionnaire.Questions, "Questions is null");

                foreach(Question question in questionnaire.Questions) {
                    Assert.IsNotNull(((MultipleChoiceQuestion)question).AnswerOptions, "Answer is null");
                }
            }
        }
    }
}
