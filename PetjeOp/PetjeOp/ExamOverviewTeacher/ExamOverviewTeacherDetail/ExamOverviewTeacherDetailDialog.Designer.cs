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
            this.examOverviewTeacherDetailView = new PetjeOp.ExamOverviewTeacher.ExamOverviewTeacherDetail.ExamOverviewTeacherDetailView();
            this.SuspendLayout();
            // 
            // examOverviewTeacherDetailView
            // 
            this.examOverviewTeacherDetailView.Location = new System.Drawing.Point(12, 12);
            this.examOverviewTeacherDetailView.Name = "examOverviewTeacherDetailView";
            this.examOverviewTeacherDetailView.Size = new System.Drawing.Size(385, 297);
            this.examOverviewTeacherDetailView.TabIndex = 0;
            // 
            // ExamOverviewTeacherDetailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 321);
            this.Controls.Add(this.examOverviewTeacherDetailView);
            this.Name = "ExamOverviewTeacherDetailDialog";
            this.Text = "ExamOverviewTeacherDetailDialog";
            this.Load += new System.EventHandler(this.ExamOverviewTeacherDetailDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ExamOverviewTeacherDetailView examOverviewTeacherDetailView;
    }
}