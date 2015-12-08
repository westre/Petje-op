using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetjeOp.QuestionnaireDetail
{
    public partial class QuestionnaireDetailView : UserControl
    {
        public QuestionnaireDetailController Controller { get; set; }

        public QuestionnaireDetailView(QuestionnaireDetailController controller)
        {
            InitializeComponent();
            Controller = controller;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Controller.GoToQuestionnaireOverview();
        }

        private void QuestionnaireDetailView_Load(object sender, EventArgs e)
        {
            Controller.setLabels();
        }
    }
}