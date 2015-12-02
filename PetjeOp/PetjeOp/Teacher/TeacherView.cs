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

        private void btnResults_Click(object sender, EventArgs e) {
            Controller.ShowExamDialog();
        }

        private void pnlButton_Result_Background_Paint(object sender, PaintEventArgs e) {
            Console.WriteLine("resultaten");
        }

        private void pnlButton_Result_Background_Click_1(object sender, EventArgs e) {
            Console.WriteLine("test");
        }

        private void ResultClick(object sender, EventArgs e) {
            Controller.ShowExamDialog();
        }
    }
}
