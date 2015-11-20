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
    public partial class JOUWKLASSEView : UserControl {
        public JOUWKLASSEController Controller;

        public JOUWKLASSEView(JOUWKLASSEController controller) {
            InitializeComponent();

            Controller = controller;
        }
    }
}
