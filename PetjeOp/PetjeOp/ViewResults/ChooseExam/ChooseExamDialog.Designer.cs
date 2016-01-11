namespace PetjeOp.ViewResults.ChooseExam
{
    partial class ChooseExamDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseExamDialog));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.cbQuestionnaire = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStarttime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEndtime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblQuestionnaire = new System.Windows.Forms.Label();
            this.checkBox_Date = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(1002, 965);
            this.btnOk.Margin = new System.Windows.Forms.Padding(6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 44);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1164, 965);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 44);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "DD-MM-YYYY";
            this.dateTimePicker1.Location = new System.Drawing.Point(254, 269);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(674, 31);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cbSubject
            // 
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(254, 17);
            this.cbSubject.Margin = new System.Windows.Forms.Padding(6);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(674, 33);
            this.cbSubject.TabIndex = 4;
            this.cbSubject.SelectedIndexChanged += new System.EventHandler(this.cbSubject_SelectedIndexChanged);
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(254, 96);
            this.cbClass.Margin = new System.Windows.Forms.Padding(6);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(674, 33);
            this.cbClass.TabIndex = 5;
            this.cbClass.SelectedIndexChanged += new System.EventHandler(this.cbClass_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(24, 971);
            this.btnReset.Margin = new System.Windows.Forms.Padding(6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(206, 38);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset alle filters";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbQuestionnaire
            // 
            this.cbQuestionnaire.FormattingEnabled = true;
            this.cbQuestionnaire.Location = new System.Drawing.Point(254, 183);
            this.cbQuestionnaire.Margin = new System.Windows.Forms.Padding(6);
            this.cbQuestionnaire.Name = "cbQuestionnaire";
            this.cbQuestionnaire.Size = new System.Drawing.Size(674, 33);
            this.cbQuestionnaire.TabIndex = 7;
            this.cbQuestionnaire.SelectedIndexChanged += new System.EventHandler(this.cbQuestionnaire_SelectedIndexChanged);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chSubject,
            this.chStarttime,
            this.chEndtime});
            this.listView1.Location = new System.Drawing.Point(24, 350);
            this.listView1.Margin = new System.Windows.Forms.Padding(6);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1286, 600);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "Naam";
            this.chName.Width = 225;
            // 
            // chSubject
            // 
            this.chSubject.Text = "Vak";
            this.chSubject.Width = 206;
            // 
            // chStarttime
            // 
            this.chStarttime.Text = "Starttijd";
            this.chStarttime.Width = 165;
            // 
            // chEndtime
            // 
            this.chEndtime.Text = "Eindtijd";
            this.chEndtime.Width = 173;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDate.Location = new System.Drawing.Point(26, 281);
            this.lblDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(77, 26);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "Datum";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSubject.Location = new System.Drawing.Point(26, 23);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(50, 26);
            this.lblSubject.TabIndex = 10;
            this.lblSubject.Text = "Vak";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblClass.Location = new System.Drawing.Point(26, 102);
            this.lblClass.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(55, 26);
            this.lblClass.TabIndex = 11;
            this.lblClass.Text = "Klas";
            // 
            // lblQuestionnaire
            // 
            this.lblQuestionnaire.AutoSize = true;
            this.lblQuestionnaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblQuestionnaire.Location = new System.Drawing.Point(26, 188);
            this.lblQuestionnaire.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblQuestionnaire.Name = "lblQuestionnaire";
            this.lblQuestionnaire.Size = new System.Drawing.Size(114, 26);
            this.lblQuestionnaire.TabIndex = 12;
            this.lblQuestionnaire.Text = "Vragenlijst";
            // 
            // checkBox_Date
            // 
            this.checkBox_Date.AutoSize = true;
            this.checkBox_Date.Checked = true;
            this.checkBox_Date.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Date.Location = new System.Drawing.Point(1002, 273);
            this.checkBox_Date.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox_Date.Name = "checkBox_Date";
            this.checkBox_Date.Size = new System.Drawing.Size(179, 29);
            this.checkBox_Date.TabIndex = 13;
            this.checkBox_Date.Text = "Negeer datum";
            this.checkBox_Date.UseVisualStyleBackColor = true;
            this.checkBox_Date.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ChooseExamDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 1033);
            this.Controls.Add(this.checkBox_Date);
            this.Controls.Add(this.lblQuestionnaire);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.cbQuestionnaire);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.cbSubject);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ChooseExamDialog";
            this.Text = "Kies een afnamemoment";
            this.Load += new System.EventHandler(this.ChooseExamDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cbQuestionnaire;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chSubject;
        private System.Windows.Forms.ColumnHeader chStarttime;
        private System.Windows.Forms.ColumnHeader chEndtime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblQuestionnaire;
        private System.Windows.Forms.CheckBox checkBox_Date;
    }
}