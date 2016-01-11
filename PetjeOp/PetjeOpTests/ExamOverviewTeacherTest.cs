using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetjeOp;

namespace PetjeOpTests
{
    [TestClass]
    public class ExamOverviewTeacherTest
    {
        private ExamOverviewTeacherController eotc = new ExamOverviewTeacherController(new MasterController());
        private Teacher t = new Teacher("2222222", "Patricia", "van Meel - Mansveld");

        [TestMethod]
        public void CheckLoad()
        {
            eotc.MasterController.User = t;
            eotc.Load();
            Assert.AreNotEqual(0, eotc.View.clnExams.CountEvents());
        }
    }
}
