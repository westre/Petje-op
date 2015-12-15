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
            this.btnRecover = new System.Windows.Forms.Button();
            this.cbAuthors = new System.Windows.Forms.ComboBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.cbOwnQuestionnairesOnly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblAddQuestionnaire
            // 
            this.lblAddQuestionnaire.AutoSize = true;
            this.lblAddQuestionnaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddQuestionnaire.ForeColor = System.Drawing.Color.Black;
            this.lblAddQuestionnaire.Location = new System.Drawing.Point(1, 4);
            this.lblAddQuestionnaire.Margin = new System.Windows.Forms.Padding(1);
            this.lblAddQuestionnaire.Name = "lblAddQuestionnaire";
            this.lblAddQuestionnaire.Size = new System.Drawing.Size(153, 29);
            this.lblAddQuestionnaire.TabIndex = 1;
            this.lblAddQuestionnaire.Text = "Vragenlijsten";
            // 
            // tvQuestionnaires
            // 
            this.tvQuestionnaires.Location = new System.Drawing.Point(5, 161);
            this.tvQuestionnaires.Margin = new System.Windows.Forms.Padding(2);
            this.tvQuestionnaires.Name = "tvQuestionnaires";
            this.tvQuestionnaires.Size = new System.Drawing.Size(564, 304);
            this.tvQuestionnaires.TabIndex = 2;
            this.tvQuestionnaires.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvQuestionnaires_BeforeSelect);
            this.tvQuestionnaires.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvQuestionnaires_AfterSelect);
            // 
            // btnAddQuestionnaire
            // 
            this.btnAddQuestionnaire.Location = new System.Drawing.Point(5, 477);
            this.btnAddQuestionnaire.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddQuestionnaire.Name = "btnAddQuestionnaire";
            this.btnAddQuestionnaire.Size = new System.Drawing.Size(146, 40);
            this.btnAddQuestionnaire.TabIndex = 3;
            this.btnAddQuestionnaire.Text = "+ Vragenlijst Toevoegen";
            this.btnAddQuestionnaire.UseVisualStyleBackColor = true;
            this.btnAddQuestionnaire.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(16, 63);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(29, 13);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Vak:";
            // 
            // cbSubjects
            // 
            this.cbSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubjects.FormattingEnabled = true;
            this.cbSubjects.Items.AddRange(new object[] {
            "Alle vakken"});
            this.cbSubjects.Location = new System.Drawing.Point(50, 60);
            this.cbSubjects.Margin = new System.Windows.Forms.Padding(2);
            this.cbSubjects.Name = "cbSubjects";
            this.cbSubjects.Size = new System.Drawing.Size(166, 21);
            this.cbSubjects.TabIndex = 5;
            this.cbSubjects.SelectedIndexChanged += new System.EventHandler(this.cbSubjects_SelectedIndexChanged);
            // 
            // btnDetails
            // 
            this.btnDetails.Enabled = false;
            this.btnDetails.Location = new System.Drawing.Point(572, 161);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 6;
            this.btnDetails.Text = "Details/Wijzig";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(572, 190);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Archiveer";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbShowArchive
            // 
            this.cbShowArchive.AutoSize = true;
            this.cbShowArchive.Location = new System.Drawing.Point(49, 125);
            this.cbShowArchive.Margin = new System.Windows.Forms.Padding(2);
            this.cbShowArchive.Name = "cbShowArchive";
            this.cbShowArchive.Size = new System.Drawing.Size(187, 17);
            this.cbShowArchive.TabIndex = 8;
            this.cbShowArchive.Text = "Toon Gearchiveerde Vragenlijsten";
            this.cbShowArchive.UseVisualStyleBackColor = true;
            this.cbShowArchive.CheckedChanged += new System.EventHandler(this.cbShowArchive_CheckedChanged);
            // 
            // btnRecover
            // 
            this.btnRecover.Location = new System.Drawing.Point(572, 190);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(75, 23);
            this.btnRecover.TabIndex = 9;
            this.btnRecover.Text = "Herstel";
            this.btnRecover.UseVisualStyleBackColor = true;
            this.btnRecover.Visible = false;
            this.btnRecover.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cbAuthors
            // 
            this.cbAuthors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuthors.FormattingEnabled = true;
            this.cbAuthors.Items.AddRange(new object[] {
            "Alle Docenten"});
            this.cbAuthors.Location = new System.Drawing.Point(50, 85);
            this.cbAuthors.Margin = new System.Windows.Forms.Padding(2);
            this.cbAuthors.Name = "cbAuthors";
            this.cbAuthors.Size = new System.Drawing.Size(166, 21);
            this.cbAuthors.TabIndex = 11;
            this.cbAuthors.SelectedIndexChanged += new System.EventHandler(this.cbAuthor_SelectedIndexChanged);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(7, 88);
            this.lblAuthor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(41, 13);
            this.lblAuthor.TabIndex = 10;
            this.lblAuthor.Text = "Auteur:";
            // 
            // cbOwnQuestionnairesOnly
            // 
            this.cbOwnQuestionnairesOnly.AutoSize = true;
            this.cbOwnQuestionnairesOnly.Location = new System.Drawing.Point(224, 88);
            this.cbOwnQuestionnairesOnly.Name = "cbOwnQuestionnairesOnly";
            this.cbOwnQuestionnairesOnly.Size = new System.Drawing.Size(173, 17);
            this.cbOwnQuestionnairesOnly.TabIndex = 12;
            this.cbOwnQuestionnairesOnly.Text = "Toon alleen eigen vragenlijsten";
            this.cbOwnQuestionnairesOnly.UseVisualStyleBackColor = true;
            this.cbOwnQuestionnairesOnly.CheckedChanged += new System.EventHandler(this.cbOwnQuestionnairesOnly_CheckedChanged);
            // 
            // QuestionnaireOverviewView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.cbOwnQuestionnairesOnly);
            this.Controls.Add(this.cbAuthors);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.btnRecover);
            this.Controls.Add(this.cbShowArchive);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.cbSubjects);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.btnAddQuestionnaire);
            this.Controls.Add(this.tvQuestionnaires);
            this.Controls.Add(this.lblAddQuestionnaire);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuestionnaireOverviewView";
            this.Size = new System.Drawing.Size(659, 526);
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
        public System.Windows.Forms.Button btnRecover;
        public System.Windows.Forms.ComboBox cbAuthors;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.CheckBox cbOwnQuestionnairesOnly;
    }
}
