using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calendar.NET;

namespace PetjeOp {
    public partial class ExamOverviewTeacherView : UserControl {
        public ExamOverviewTeacherController Controller;

        public ExamOverviewTeacherView(ExamOverviewTeacherController controller) {
            InitializeComponent();
            Controller = controller;         
        }
    }
}