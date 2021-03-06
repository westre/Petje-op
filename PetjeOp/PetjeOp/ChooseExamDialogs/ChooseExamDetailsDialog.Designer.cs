﻿namespace PetjeOp.ChooseExamDialogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseExamDetailsDialog));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lbExams = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLecture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEndtime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddExam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1038, 517);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 44);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(876, 517);
            this.btnOk.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 44);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lbExams
            // 
            this.lbExams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chLecture,
            this.chDate,
            this.chStartTime,
            this.chEndtime});
            this.lbExams.Location = new System.Drawing.Point(24, 23);
            this.lbExams.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lbExams.Name = "lbExams";
            this.lbExams.Size = new System.Drawing.Size(1160, 479);
            this.lbExams.TabIndex = 7;
            this.lbExams.UseCompatibleStateImageBehavior = false;
            this.lbExams.View = System.Windows.Forms.View.Details;
            // 
            // chId
            // 
            this.chId.Text = "ID";
            this.chId.Width = 39;
            // 
            // chLecture
            // 
            this.chLecture.Text = "Vragenlijstnaam";
            this.chLecture.Width = 427;
            // 
            // chDate
            // 
            this.chDate.Text = "Datum";
            this.chDate.Width = 195;
            // 
            // chStartTime
            // 
            this.chStartTime.Text = "Starttijd";
            this.chStartTime.Width = 237;
            // 
            // chEndtime
            // 
            this.chEndtime.Text = "Eindtijd";
            this.chEndtime.Width = 258;
            // 
            // btnAddExam
            // 
            this.btnAddExam.Location = new System.Drawing.Point(24, 517);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(300, 44);
            this.btnAddExam.TabIndex = 8;
            this.btnAddExam.Text = "Afnamemoment Toevoegen";
            this.btnAddExam.UseVisualStyleBackColor = true;
            this.btnAddExam.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChooseExamDetailsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 585);
            this.Controls.Add(this.btnAddExam);
            this.Controls.Add(this.lbExams);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ChooseExamDetailsDialog";
            this.Text = "Afnamemomenten Per Vragenlijst";
            this.Load += new System.EventHandler(this.ChooseExamDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ListView lbExams;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chStartTime;
        private System.Windows.Forms.ColumnHeader chEndtime;
        private System.Windows.Forms.ColumnHeader chLecture;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.Button btnAddExam;
    }
}