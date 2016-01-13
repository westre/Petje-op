using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetjeOp {
    partial class ExamOverviewStudentView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.viewPanel = new System.Windows.Forms.Panel();
            this.lbExams = new System.Windows.Forms.ListView();
            this.ChQuestionnaireName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChTeacher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEndtime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewPanel
            // 
            this.viewPanel.AutoSize = true;
            this.viewPanel.BackColor = System.Drawing.Color.Transparent;
            this.viewPanel.Controls.Add(this.lbExams);
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 0);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(788, 428);
            this.viewPanel.TabIndex = 4;
            // 
            // lbExams
            // 
            this.lbExams.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lbExams.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbExams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ChQuestionnaireName,
            this.ChTeacher,
            this.ChSubject,
            this.chStartTime,
            this.chEndtime,
            this.ChState});
            this.lbExams.FullRowSelect = true;
            this.lbExams.Location = new System.Drawing.Point(3, 3);
            this.lbExams.Name = "lbExams";
            this.lbExams.Scrollable = false;
            this.lbExams.Size = new System.Drawing.Size(782, 422);
            this.lbExams.TabIndex = 8;
            this.lbExams.UseCompatibleStateImageBehavior = false;
            this.lbExams.View = System.Windows.Forms.View.Details;
            this.lbExams.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listviewname_ColumnWidthChanging);
            this.lbExams.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // ChQuestionnaireName
            // 
            this.ChQuestionnaireName.Text = "Vragenlijstnaam";
            this.ChQuestionnaireName.Width = 193;
            // 
            // ChTeacher
            // 
            this.ChTeacher.Text = "Docent";
            this.ChTeacher.Width = 202;
            // 
            // ChSubject
            // 
            this.ChSubject.Text = "Vak";
            this.ChSubject.Width = 69;
            // 
            // chStartTime
            // 
            this.chStartTime.Text = "Starttijd";
            this.chStartTime.Width = 98;
            // 
            // chEndtime
            // 
            this.chEndtime.Text = "Eindtijd";
            this.chEndtime.Width = 104;
            // 
            // ChState
            // 
            this.ChState.Text = "Status";
            this.ChState.Width = 188;
            // 
            // ExamOverviewStudentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewPanel);
            this.Name = "ExamOverviewStudentView";
            this.Size = new System.Drawing.Size(788, 428);
            this.viewPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            int i = lbExams.SelectedIndices[0];

            AnswerQuestionnaireController aqc = (AnswerQuestionnaireController)Controller.MasterController.GetController(typeof(AnswerQuestionnaireController));

            aqc.setExam((int)lbExams.Items[i].Tag);
            aqc.Init((int)lbExams.Items[i].Tag);
            Controller.MasterController.SetController(aqc);
        }

        private void listviewname_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            //e.Cancel = true;
            //e.NewWidth = lbExams.Columns[e.ColumnIndex].Width;
        }

        #endregion
        public Panel viewPanel;
        public ListView lbExams;
        private ColumnHeader ChQuestionnaireName;
        private ColumnHeader ChTeacher;
        private ColumnHeader ChSubject;
        private ColumnHeader chStartTime;
        private ColumnHeader chEndtime;
        private ColumnHeader ChState;
    }
}
