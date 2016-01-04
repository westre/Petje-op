using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class ExamOverviewStudentController : Controller{
        public ExamOverviewStudentView View { get; set; }
        public ExamOverviewStudentModel Model { get; set; }
        public Exam Exam { get; set; }
        private DatabaseListener changeListener = new DatabaseListener();
        private DatabaseListener resultListener = new DatabaseListener();

        private Thread demoThread;
        public ExamOverviewStudentController(MasterController masterController) : base(masterController) {
            Model = new ExamOverviewStudentModel();
            View = new ExamOverviewStudentView(this);
        }

        public void Init()
        {
            View.lbExams.Items.Clear();
            foreach(tblExam exam in MasterController.DB.GetExamsOfStudent(((Student)(MasterController.User)).StudentNr)){
                View.lbExams.Items.Add(new ListViewItem(new[] {
                                                                exam.tblQuestionnaire.description,
                                                                (exam.tblLecture.tblTeacher.firstname + " " + exam.tblLecture.tblTeacher.surname),
                                                                exam.tblLecture.@class,
                                                                exam.starttime.ToString(),
                                                                exam.endtime.ToString(),
                                                                (exam.currentquestion != null ? "Running..." : "Not Running...")}));
                View.lbExams.Items[View.lbExams.Items.Count - 1].Tag = exam.id;
            }
        }


        public override UserControl GetView() {
            return View;
        }

        public Panel GetViewPanel() {
            return View.viewPanel;
        }
    }
}
