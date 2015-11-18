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
    public partial class ExampleTwoView : UserControl {
        public ExampleTwoController Controller;

        public ExampleTwoView(ExampleTwoController controller) {
            InitializeComponent();
        }
    }
}
