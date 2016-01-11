using System;

namespace PetjeOp.ExamOverviewTeacher.ExamOverviewTeacherDetail {
    partial class ExamOverviewTeacherDetailDialog {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamOverviewTeacherDetailDialog));
            this.examOverviewTeacherDetailView = new PetjeOp.ExamOverviewTeacher.ExamOverviewTeacherDetail.ExamOverviewTeacherDetailView();
            this.SuspendLayout();
            // 
            // examOverviewTeacherDetailView
            // 
            this.examOverviewTeacherDetailView.Location = new System.Drawing.Point(24, 23);
            this.examOverviewTeacherDetailView.Margin = new System.Windows.Forms.Padding(12);
            this.examOverviewTeacherDetailView.Name = "examOverviewTeacherDetailView";
            this.examOverviewTeacherDetailView.Size = new System.Drawing.Size(876, 593);
            this.examOverviewTeacherDetailView.TabIndex = 0;
            // 
            // ExamOverviewTeacherDetailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 629);
            this.Controls.Add(this.examOverviewTeacherDetailView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ExamOverviewTeacherDetailDialog";
            this.Text = "Details Afnamemoment";
            this.Load += new System.EventHandler(this.ExamOverviewTeacherDetailDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ExamOverviewTeacherDetailView examOverviewTeacherDetailView;
    }
}