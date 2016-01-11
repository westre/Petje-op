using System.Windows.Forms;

namespace PetjeOp {
    partial class AddExamView {
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
            this.lblAddExam = new System.Windows.Forms.Label();
            this.lblQuestionnaire = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.cbQuestionnaires = new System.Windows.Forms.ComboBox();
            this.cbClasses = new System.Windows.Forms.ComboBox();
            this.cbSubjects = new System.Windows.Forms.ComboBox();
            this.dtpStarttimeDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStarttimeTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndtimeTime = new System.Windows.Forms.DateTimePicker();
            this.btnSaveExam = new System.Windows.Forms.Button();
            this.lblSubjectError = new System.Windows.Forms.Label();
            this.lblQuestionnaireError = new System.Windows.Forms.Label();
            this.lblClassError = new System.Windows.Forms.Label();
            this.lblEndtimeError = new System.Windows.Forms.Label();
            this.lblStarttimeError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAddExam
            // 
            this.lblAddExam.AutoSize = true;
            this.lblAddExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddExam.Location = new System.Drawing.Point(35, 31);
            this.lblAddExam.Name = "lblAddExam";
            this.lblAddExam.Size = new System.Drawing.Size(311, 29);
            this.lblAddExam.TabIndex = 0;
            this.lblAddExam.Text = "Afnamemoment Toevoegen";
            // 
            // lblQuestionnaire
            // 
            this.lblQuestionnaire.AutoSize = true;
            this.lblQuestionnaire.Location = new System.Drawing.Point(37, 125);
            this.lblQuestionnaire.Name = "lblQuestionnaire";
            this.lblQuestionnaire.Size = new System.Drawing.Size(58, 13);
            this.lblQuestionnaire.TabIndex = 1;
            this.lblQuestionnaire.Text = "Vragenlijst:";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(37, 151);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(30, 13);
            this.lblClass.TabIndex = 2;
            this.lblClass.Text = "Klas:";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(37, 99);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(29, 13);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "Vak:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(37, 180);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(33, 13);
            this.lblDuration.TabIndex = 4;
            this.lblDuration.Text = "Duur:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(295, 178);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(19, 13);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "tot";
            // 
            // cbQuestionnaires
            // 
            this.cbQuestionnaires.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuestionnaires.Enabled = false;
            this.cbQuestionnaires.FormattingEnabled = true;
            this.cbQuestionnaires.Location = new System.Drawing.Point(121, 121);
            this.cbQuestionnaires.Name = "cbQuestionnaires";
            this.cbQuestionnaires.Size = new System.Drawing.Size(367, 21);
            this.cbQuestionnaires.TabIndex = 6;
            this.cbQuestionnaires.SelectedIndexChanged += new System.EventHandler(this.cbQuestionnaires_SelectedIndexChanged);
            // 
            // cbClasses
            // 
            this.cbClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClasses.Enabled = false;
            this.cbClasses.FormattingEnabled = true;
            this.cbClasses.Location = new System.Drawing.Point(121, 148);
            this.cbClasses.Name = "cbClasses";
            this.cbClasses.Size = new System.Drawing.Size(367, 21);
            this.cbClasses.TabIndex = 7;
            this.cbClasses.SelectedIndexChanged += new System.EventHandler(this.cbClasses_SelectedIndexChanged);
            // 
            // cbSubjects
            // 
            this.cbSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubjects.FormattingEnabled = true;
            this.cbSubjects.Location = new System.Drawing.Point(121, 94);
            this.cbSubjects.Name = "cbSubjects";
            this.cbSubjects.Size = new System.Drawing.Size(367, 21);
            this.cbSubjects.TabIndex = 8;
            this.cbSubjects.SelectedIndexChanged += new System.EventHandler(this.cbSubjects_SelectedIndexChanged);
            // 
            // dtpStarttimeDate
            // 
            this.dtpStarttimeDate.CustomFormat = "d-M-yyyy";
            this.dtpStarttimeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStarttimeDate.Location = new System.Drawing.Point(121, 175);
            this.dtpStarttimeDate.Name = "dtpStarttimeDate";
            this.dtpStarttimeDate.Size = new System.Drawing.Size(97, 20);
            this.dtpStarttimeDate.TabIndex = 9;
            this.dtpStarttimeDate.ValueChanged += new System.EventHandler(this.dtpStarttimeDate_ValueChanged);
            // 
            // dtpStarttimeTime
            // 
            this.dtpStarttimeTime.CustomFormat = "HH:mm";
            this.dtpStarttimeTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStarttimeTime.Location = new System.Drawing.Point(224, 175);
            this.dtpStarttimeTime.Name = "dtpStarttimeTime";
            this.dtpStarttimeTime.ShowUpDown = true;
            this.dtpStarttimeTime.Size = new System.Drawing.Size(65, 20);
            this.dtpStarttimeTime.TabIndex = 10;
            this.dtpStarttimeTime.ValueChanged += new System.EventHandler(this.dtpStarttimeTime_ValueChanged);
            // 
            // dtpEndtimeTime
            // 
            this.dtpEndtimeTime.CustomFormat = "HH:mm";
            this.dtpEndtimeTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndtimeTime.Location = new System.Drawing.Point(317, 176);
            this.dtpEndtimeTime.Name = "dtpEndtimeTime";
            this.dtpEndtimeTime.ShowUpDown = true;
            this.dtpEndtimeTime.Size = new System.Drawing.Size(65, 20);
            this.dtpEndtimeTime.TabIndex = 12;
            this.dtpEndtimeTime.ValueChanged += new System.EventHandler(this.dtpEndtimeTime_ValueChanged);
            // 
            // btnSaveExam
            // 
            this.btnSaveExam.Enabled = false;
            this.btnSaveExam.Location = new System.Drawing.Point(40, 315);
            this.btnSaveExam.Name = "btnSaveExam";
            this.btnSaveExam.Size = new System.Drawing.Size(152, 25);
            this.btnSaveExam.TabIndex = 13;
            this.btnSaveExam.Text = "Afnamemoment Opslaan";
            this.btnSaveExam.UseVisualStyleBackColor = true;
            this.btnSaveExam.Click += new System.EventHandler(this.btnSaveExam_Click);
            // 
            // lblSubjectError
            // 
            this.lblSubjectError.AutoSize = true;
            this.lblSubjectError.ForeColor = System.Drawing.Color.Red;
            this.lblSubjectError.Location = new System.Drawing.Point(495, 98);
            this.lblSubjectError.Name = "lblSubjectError";
            this.lblSubjectError.Size = new System.Drawing.Size(0, 13);
            this.lblSubjectError.TabIndex = 14;
            // 
            // lblQuestionnaireError
            // 
            this.lblQuestionnaireError.AutoSize = true;
            this.lblQuestionnaireError.ForeColor = System.Drawing.Color.Red;
            this.lblQuestionnaireError.Location = new System.Drawing.Point(494, 124);
            this.lblQuestionnaireError.Name = "lblQuestionnaireError";
            this.lblQuestionnaireError.Size = new System.Drawing.Size(0, 13);
            this.lblQuestionnaireError.TabIndex = 15;
            // 
            // lblClassError
            // 
            this.lblClassError.AutoSize = true;
            this.lblClassError.ForeColor = System.Drawing.Color.Red;
            this.lblClassError.Location = new System.Drawing.Point(495, 151);
            this.lblClassError.Name = "lblClassError";
            this.lblClassError.Size = new System.Drawing.Size(0, 13);
            this.lblClassError.TabIndex = 16;
            // 
            // lblEndtimeError
            // 
            this.lblEndtimeError.AutoSize = true;
            this.lblEndtimeError.ForeColor = System.Drawing.Color.Red;
            this.lblEndtimeError.Location = new System.Drawing.Point(317, 198);
            this.lblEndtimeError.Name = "lblEndtimeError";
            this.lblEndtimeError.Size = new System.Drawing.Size(0, 13);
            this.lblEndtimeError.TabIndex = 17;
            // 
            // lblStarttimeError
            // 
            this.lblStarttimeError.AutoSize = true;
            this.lblStarttimeError.ForeColor = System.Drawing.Color.Red;
            this.lblStarttimeError.Location = new System.Drawing.Point(118, 198);
            this.lblStarttimeError.Name = "lblStarttimeError";
            this.lblStarttimeError.Size = new System.Drawing.Size(0, 13);
            this.lblStarttimeError.TabIndex = 18;
            // 
            // AddExamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStarttimeError);
            this.Controls.Add(this.lblEndtimeError);
            this.Controls.Add(this.lblClassError);
            this.Controls.Add(this.lblQuestionnaireError);
            this.Controls.Add(this.lblSubjectError);
            this.Controls.Add(this.btnSaveExam);
            this.Controls.Add(this.dtpEndtimeTime);
            this.Controls.Add(this.dtpStarttimeTime);
            this.Controls.Add(this.dtpStarttimeDate);
            this.Controls.Add(this.cbSubjects);
            this.Controls.Add(this.cbClasses);
            this.Controls.Add(this.cbQuestionnaires);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblQuestionnaire);
            this.Controls.Add(this.lblAddExam);
            this.Name = "AddExamView";
            this.Size = new System.Drawing.Size(664, 343);
            this.Load += new System.EventHandler(this.AddExamView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddExam;
        private System.Windows.Forms.Label lblQuestionnaire;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblTo;
        public System.Windows.Forms.ComboBox cbQuestionnaires;
        public System.Windows.Forms.ComboBox cbClasses;
        public System.Windows.Forms.ComboBox cbSubjects;
        public DateTimePicker dtpStarttimeDate;
        public DateTimePicker dtpStarttimeTime;
        public DateTimePicker dtpEndtimeTime;
        public Button btnSaveExam;
        public Label lblSubjectError;
        public Label lblQuestionnaireError;
        public Label lblClassError;
        public Label lblEndtimeError;
        public Label lblStarttimeError;
    }
}