using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetjeOp
{
    public partial class ViewResultsView : UserControl
    {
        public ViewResultsController Controller { get; set; }

        public ViewResultsView(ViewResultsController controller)
        {
            Controller = controller;
            InitializeComponent();
            
          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.ShowChart();
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Controller.GoToMainMenu();
        }
    }
}
