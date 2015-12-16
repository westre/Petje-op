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
    public partial class TeacherHomeView : UserControl {
        public TeacherHomeController Controller;

        public TeacherHomeView(TeacherHomeController controller) {
            InitializeComponent();

            Controller = controller;
        }
    }
}