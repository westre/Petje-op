using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public partial class TeacherView : UserControl {
        public TeacherController Controller;
        

        public TeacherView(TeacherController controller) {
            InitializeComponent();

            Controller = controller;
        }

        private void btnStudentLogin_Click(object sender, EventArgs e) {

        }

        private void btnLoginTeacher_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Controller.ShowExamDialog();

        }

        private void TeacherView_Load(object sender, EventArgs e) {

        }

        private void ResultClick(object sender, EventArgs e) {
            Controller.ShowExamDialog();
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            Controller.GoToTeacherHome();
        }

        private void pnlButton_QuestionnaireOverview_Background_Click(object sender, EventArgs e)
        {
            Controller.GoToQuestionnaireOverview();
        }
    }
}
