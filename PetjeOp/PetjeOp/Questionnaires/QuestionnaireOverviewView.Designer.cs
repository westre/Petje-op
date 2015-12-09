namespace PetjeOp.Questionnaires
{
    partial class QuestionnaireOverviewView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAddQuestionnaire = new System.Windows.Forms.Label();
            this.tvQuestionnaires = new System.Windows.Forms.TreeView();
            this.btnAddQuestionnaire = new System.Windows.Forms.Button();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cbSubjects = new System.Windows.Forms.ComboBox();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbShowArchive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblAddQuestionnaire
            // 
            this.lblAddQuestionnaire.AutoSize = true;
            this.lblAddQuestionnaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddQuestionnaire.ForeColor = System.Drawing.Color.Black;
            this.lblAddQuestionnaire.Location = new System.Drawing.Point(2, 8);
            this.lblAddQuestionnaire.Margin = new System.Windows.Forms.Padding(2);
            this.lblAddQuestionnaire.Name = "lblAddQuestionnaire";
            this.lblAddQuestionnaire.Size = new System.Drawing.Size(301, 55);
            this.lblAddQuestionnaire.TabIndex = 1;
            this.lblAddQuestionnaire.Text = "Vragenlijsten";
            // 
            // tvQuestionnaires
            // 
            this.tvQuestionnaires.Location = new System.Drawing.Point(12, 254);
            this.tvQuestionnaires.Margin = new System.Windows.Forms.Padding(4);
            this.tvQuestionnaires.Name = "tvQuestionnaires";
            this.tvQuestionnaires.Size = new System.Drawing.Size(1124, 581);
            this.tvQuestionnaires.TabIndex = 2;
            this.tvQuestionnaires.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvQuestionnaires_BeforeSelect);
            this.tvQuestionnaires.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvQuestionnaires_AfterSelect);
            // 
            // btnAddQuestionnaire
            // 
            this.btnAddQuestionnaire.Location = new System.Drawing.Point(11, 861);
            this.btnAddQuestionnaire.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddQuestionnaire.Name = "btnAddQuestionnaire";
            this.btnAddQuestionnaire.Size = new System.Drawing.Size(292, 77);
            this.btnAddQuestionnaire.TabIndex = 3;
            this.btnAddQuestionnaire.Text = "+ Vragenlijst Toevoegen";
            this.btnAddQuestionnaire.UseVisualStyleBackColor = true;
            this.btnAddQuestionnaire.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(6, 123);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(55, 25);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Vak:";
            // 
            // cbSubjects
            // 
            this.cbSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubjects.FormattingEnabled = true;
            this.cbSubjects.Items.AddRange(new object[] {
            "Alle vakken"});
            this.cbSubjects.Location = new System.Drawing.Point(74, 117);
            this.cbSubjects.Margin = new System.Windows.Forms.Padding(4);
            this.cbSubjects.Name = "cbSubjects";
            this.cbSubjects.Size = new System.Drawing.Size(328, 33);
            this.cbSubjects.TabIndex = 5;
            this.cbSubjects.SelectedIndexChanged += new System.EventHandler(this.cbSubjects_SelectedIndexChanged);
            // 
            // btnDetails
            // 
            this.btnDetails.Enabled = false;
            this.btnDetails.Location = new System.Drawing.Point(1146, 254);
            this.btnDetails.Margin = new System.Windows.Forms.Padding(6);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(150, 44);
            this.btnDetails.TabIndex = 6;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(1146, 310);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 44);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Verwijder";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbShowArchive
            // 
            this.cbShowArchive.AutoSize = true;
            this.cbShowArchive.Location = new System.Drawing.Point(74, 170);
            this.cbShowArchive.Name = "cbShowArchive";
            this.cbShowArchive.Size = new System.Drawing.Size(371, 29);
            this.cbShowArchive.TabIndex = 8;
            this.cbShowArchive.Text = "Toon Gearchiveerde Vragenlijsten";
            this.cbShowArchive.UseVisualStyleBackColor = true;
            this.cbShowArchive.CheckedChanged += new System.EventHandler(this.cbShowArchive_CheckedChanged);
            // 
            // QuestionnaireOverviewView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.cbShowArchive);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.cbSubjects);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.btnAddQuestionnaire);
            this.Controls.Add(this.tvQuestionnaires);
            this.Controls.Add(this.lblAddQuestionnaire);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "QuestionnaireOverviewView";
            this.Size = new System.Drawing.Size(1318, 1011);
            this.Load += new System.EventHandler(this.QuestionnaireOverviewView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddQuestionnaire;
        public System.Windows.Forms.TreeView tvQuestionnaires;
        private System.Windows.Forms.Button btnAddQuestionnaire;
        private System.Windows.Forms.Label lblSubject;
        public System.Windows.Forms.ComboBox cbSubjects;
        public System.Windows.Forms.Button btnDetails;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.CheckBox cbShowArchive;
    }
}
