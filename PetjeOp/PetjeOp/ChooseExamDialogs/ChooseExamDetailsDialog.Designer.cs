namespace PetjeOp.ChooseExamDialogs
{
    partial class ChooseExamDetailsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.lbExams = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEndtime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLecture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(519, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(438, 269);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(218, 269);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "button1";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // lbExams
            // 
            this.lbExams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chLecture,
            this.chStartTime,
            this.chEndtime});
            this.lbExams.Location = new System.Drawing.Point(12, 12);
            this.lbExams.Name = "lbExams";
            this.lbExams.Size = new System.Drawing.Size(582, 251);
            this.lbExams.TabIndex = 7;
            this.lbExams.UseCompatibleStateImageBehavior = false;
            this.lbExams.View = System.Windows.Forms.View.Details;
            // 
            // chId
            // 
            this.chId.Text = "ID";
            this.chId.Width = 30;
            // 
            // chStartTime
            // 
            this.chStartTime.Text = "Starttijd";
            this.chStartTime.Width = 100;
            // 
            // chEndtime
            // 
            this.chEndtime.Text = "Eindtijd";
            this.chEndtime.Width = 100;
            // 
            // chLecture
            // 
            this.chLecture.Text = "Vragenlijstnaam";
            this.chLecture.Width = 300;
            // 
            // ChooseExamDetailsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 304);
            this.Controls.Add(this.lbExams);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "ChooseExamDetailsDialog";
            this.Text = "ChooseExamDetailsDialog";
            this.Load += new System.EventHandler(this.ChooseExamDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ListView lbExams;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chStartTime;
        private System.Windows.Forms.ColumnHeader chEndtime;
        private System.Windows.Forms.ColumnHeader chLecture;
    }
}