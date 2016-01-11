using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetjeOp;
using System.Collections.Generic;
using System.Runtime.InteropServices;


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
            Question question = db.GetQuestion(4);
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

        [TestMethod]
        public void TestGetStudent()
        {
            Student student = db.GetStudent("1111111");
            Assert.IsNotNull(student);
        }

        [TestMethod]
        public void TestGetTeacher()
        {
            Teacher teacher = db.GetTeacher("2222222");
            Assert.IsNotNull(teacher);
        }

        [TestMethod]
        public void TestGetAnswer()
        {
            tblAnswer answer = db.GetAnswer("Nederland");
            Assert.IsNotNull(answer);
        }

        [TestMethod]
        public void TestGetAllQuestionnaires()
        {
            List<Questionnaire> questionnaires = db.GetAllQuestionnaires();
            Assert.AreNotEqual(0, questionnaires.Count);
        }

        [TestMethod]
        public void TestGetAllExams()
        {
            List<Exam> exams = db.GetAllExams();
            Assert.AreNotEqual(0, exams.Count);
        }

        [TestMethod]
        public void TestGetExamsByTeacher()
        {
            List<Exam> exams = db.GetExamsByTeacher("2222222");
            Assert.AreNotEqual(0, exams.Count);
        }

        [TestMethod]
        public void TestGetAllClasses()
        {
            List<Class> classes = db.GetAllClasses();
            Assert.AreNotEqual(0, classes.Count);
        }

        [TestMethod]
        public void TestGetAllLectures()
        {
            List<Lecture> lectures = db.GetAllLectures();
            Assert.AreNotEqual(0, lectures.Count);
        }

        [TestMethod]
        public void TestGetLecture()
        {
            Lecture lecture = db.GetLecture(1);
            Assert.IsNotNull(lecture);
        }

        [TestMethod]
        public void TestGetExamsByQuestionnaire()
        {
            Questionnaire questionnaire = db.GetQuestionnaire(5);
            List<Exam> exams = db.GetExamsByQuestionnaire(questionnaire);
            Assert.AreNotEqual(0, exams.Count);
        }

        [TestMethod]
        public void TestGetExam()
        {
            Exam exam = db.GetExam(1);
            Assert.IsNotNull(exam);
        }

        [TestMethod]
        public void TestGetSubjects()
        {
            List<Subject> subjects = db.GetSubjects();
            Assert.AreNotEqual(0, subjects.Count);
        }

        [TestMethod]
        public void TestGetSubject()
        {
            Subject subject = db.GetSubject(1);
            Assert.IsNotNull(subject);
        }

        [TestMethod]
        public void TestGetTeachers()
        {
            List<Teacher> teachers = db.GetTeachers();
            Assert.AreNotEqual(0, teachers.Count);
        }

        [TestMethod]
        public void TestGetAnswersByQuestion()
        {
            List<Answer> answers = db.GetAnswersByQuestion(4);
            Assert.AreNotEqual(0, answers.Count);
        }

        [TestMethod]
        public void TestGetDescriptionByAnswer()
        {
            String desc = db.GetDescriptionByAnswer(1);
            Assert.IsNotNull(desc);
        }

        [TestMethod]
        public void TestGetResultsByExamId()
        {
            List<Result> results = db.GetResultsByExamId(1);
            Assert.AreNotEqual(0, results.Count);
        }
    }
}
