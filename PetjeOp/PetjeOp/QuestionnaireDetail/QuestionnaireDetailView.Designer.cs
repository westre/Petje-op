namespace PetjeOp.QuestionnaireDetail
{
    partial class QuestionnaireDetailView
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblErrorSubject = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblNoNodeSelectedError = new System.Windows.Forms.Label();
            this.lblQuestionaireNameError = new System.Windows.Forms.Label();
            this.btnSaveQuestionnaire = new System.Windows.Forms.Button();
            this.lblQuestionnaireName = new System.Windows.Forms.Label();
            this.lblShowQuestionnaire = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblAuthorData = new System.Windows.Forms.Label();
            this.lblNameData = new System.Windows.Forms.Label();
            this.lblSubjectData = new System.Windows.Forms.Label();
            this.lblNoQuestionsInQuestionaire = new System.Windows.Forms.Label();
            this.btnExams = new System.Windows.Forms.Button();
            this.cbSelectQuestionnaire = new System.Windows.Forms.ComboBox();
            this.lblSelectQuestionnaire = new System.Windows.Forms.Label();
            this.btnConfirmQuestionnaire = new System.Windows.Forms.Button();
            this.questionsView1 = new PetjeOp.AddQuestionnaire.QuestionsView();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(293, 514);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(210, 49);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Annuleer";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblErrorSubject
            // 
            this.lblErrorSubject.AutoSize = true;
            this.lblErrorSubject.ForeColor = System.Drawing.Color.Red;
            this.lblErrorSubject.Location = new System.Drawing.Point(382, 213);
            this.lblErrorSubject.Name = "lblErrorSubject";
            this.lblErrorSubject.Size = new System.Drawing.Size(0, 13);
            this.lblErrorSubject.TabIndex = 35;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(17, 149);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(29, 13);
            this.lblSubject.TabIndex = 33;
            this.lblSubject.Text = "Vak:";
            // 
            // lblNoNodeSelectedError
            // 
            this.lblNoNodeSelectedError.AutoSize = true;
            this.lblNoNodeSelectedError.ForeColor = System.Drawing.Color.Red;
            this.lblNoNodeSelectedError.Location = new System.Drawing.Point(770, 267);
            this.lblNoNodeSelectedError.Name = "lblNoNodeSelectedError";
            this.lblNoNodeSelectedError.Size = new System.Drawing.Size(0, 13);
            this.lblNoNodeSelectedError.TabIndex = 31;
            // 
            // lblQuestionaireNameError
            // 
            this.lblQuestionaireNameError.AutoSize = true;
            this.lblQuestionaireNameError.ForeColor = System.Drawing.Color.Red;
            this.lblQuestionaireNameError.Location = new System.Drawing.Point(382, 187);
            this.lblQuestionaireNameError.Name = "lblQuestionaireNameError";
            this.lblQuestionaireNameError.Size = new System.Drawing.Size(0, 13);
            this.lblQuestionaireNameError.TabIndex = 30;
            // 
            // btnSaveQuestionnaire
            // 
            this.btnSaveQuestionnaire.Enabled = false;
            this.btnSaveQuestionnaire.Location = new System.Drawing.Point(20, 514);
            this.btnSaveQuestionnaire.Name = "btnSaveQuestionnaire";
            this.btnSaveQuestionnaire.Size = new System.Drawing.Size(267, 49);
            this.btnSaveQuestionnaire.TabIndex = 29;
            this.btnSaveQuestionnaire.Text = "Vragenlijst Opslaan";
            this.btnSaveQuestionnaire.UseVisualStyleBackColor = true;
            // 
            // lblQuestionnaireName
            // 
            this.lblQuestionnaireName.AutoSize = true;
            this.lblQuestionnaireName.Location = new System.Drawing.Point(17, 120);
            this.lblQuestionnaireName.Name = "lblQuestionnaireName";
            this.lblQuestionnaireName.Size = new System.Drawing.Size(38, 13);
            this.lblQuestionnaireName.TabIndex = 27;
            this.lblQuestionnaireName.Text = "Naam:";
            // 
            // lblShowQuestionnaire
            // 
            this.lblShowQuestionnaire.AutoSize = true;
            this.lblShowQuestionnaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowQuestionnaire.Location = new System.Drawing.Point(11, 19);
            this.lblShowQuestionnaire.Margin = new System.Windows.Forms.Padding(2);
            this.lblShowQuestionnaire.Name = "lblShowQuestionnaire";
            this.lblShowQuestionnaire.Size = new System.Drawing.Size(256, 29);
            this.lblShowQuestionnaire.TabIndex = 26;
            this.lblShowQuestionnaire.Text = "Vragenlijst Weergeven";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(17, 174);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(41, 13);
            this.lblAuthor.TabIndex = 38;
            this.lblAuthor.Text = "Auteur:";
            // 
            // lblAuthorData
            // 
            this.lblAuthorData.AutoSize = true;
            this.lblAuthorData.Location = new System.Drawing.Point(101, 174);
            this.lblAuthorData.Name = "lblAuthorData";
            this.lblAuthorData.Size = new System.Drawing.Size(0, 13);
            this.lblAuthorData.TabIndex = 39;
            // 
            // lblNameData
            // 
            this.lblNameData.AutoSize = true;
            this.lblNameData.Location = new System.Drawing.Point(101, 121);
            this.lblNameData.Name = "lblNameData";
            this.lblNameData.Size = new System.Drawing.Size(0, 13);
            this.lblNameData.TabIndex = 40;
            // 
            // lblSubjectData
            // 
            this.lblSubjectData.AutoSize = true;
            this.lblSubjectData.Location = new System.Drawing.Point(101, 148);
            this.lblSubjectData.Name = "lblSubjectData";
            this.lblSubjectData.Size = new System.Drawing.Size(0, 13);
            this.lblSubjectData.TabIndex = 41;
            // 
            // lblNoQuestionsInQuestionaire
            // 
            this.lblNoQuestionsInQuestionaire.AutoSize = true;
            this.lblNoQuestionsInQuestionaire.ForeColor = System.Drawing.Color.Red;
            this.lblNoQuestionsInQuestionaire.Location = new System.Drawing.Point(278, 461);
            this.lblNoQuestionsInQuestionaire.Name = "lblNoQuestionsInQuestionaire";
            this.lblNoQuestionsInQuestionaire.Size = new System.Drawing.Size(0, 13);
            this.lblNoQuestionsInQuestionaire.TabIndex = 32;
            // 
            // btnExams
            // 
            this.btnExams.Location = new System.Drawing.Point(685, 514);
            this.btnExams.Name = "btnExams";
            this.btnExams.Size = new System.Drawing.Size(197, 49);
            this.btnExams.TabIndex = 42;
            this.btnExams.Text = "Afnamemomenten";
            this.btnExams.UseVisualStyleBackColor = true;
            // 
            // cbSelectQuestionnaire
            // 
            this.cbSelectQuestionnaire.FormattingEnabled = true;
            this.cbSelectQuestionnaire.Location = new System.Drawing.Point(591, 33);
            this.cbSelectQuestionnaire.Name = "cbSelectQuestionnaire";
            this.cbSelectQuestionnaire.Size = new System.Drawing.Size(210, 21);
            this.cbSelectQuestionnaire.TabIndex = 43;
            // 
            // lblSelectQuestionnaire
            // 
            this.lblSelectQuestionnaire.AutoSize = true;
            this.lblSelectQuestionnaire.Location = new System.Drawing.Point(588, 17);
            this.lblSelectQuestionnaire.Name = "lblSelectQuestionnaire";
            this.lblSelectQuestionnaire.Size = new System.Drawing.Size(130, 13);
            this.lblSelectQuestionnaire.TabIndex = 44;
            this.lblSelectQuestionnaire.Text = "Snel vragenlijst selecteren";
            // 
            // btnConfirmQuestionnaire
            // 
            this.btnConfirmQuestionnaire.Location = new System.Drawing.Point(807, 31);
            this.btnConfirmQuestionnaire.Name = "btnConfirmQuestionnaire";
            this.btnConfirmQuestionnaire.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmQuestionnaire.TabIndex = 45;
            this.btnConfirmQuestionnaire.Text = "Selecteren";
            this.btnConfirmQuestionnaire.UseVisualStyleBackColor = true;
            // 
            // questionsView1
            // 
            this.questionsView1.Dialog = null;
            this.questionsView1.Location = new System.Drawing.Point(22, 238);
            this.questionsView1.Margin = new System.Windows.Forms.Padding(2);
            this.questionsView1.Name = "questionsView1";
            this.questionsView1.ParentController = null;
            this.questionsView1.Size = new System.Drawing.Size(834, 246);
            this.questionsView1.TabIndex = 37;
            this.questionsView1.Load += new System.EventHandler(this.questionsView1_Load);
            // 
            // QuestionnaireDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrorSubject);
            this.Controls.Add(this.lblQuestionaireNameError);
            this.Controls.Add(this.lblNoNodeSelectedError);
            this.Controls.Add(this.btnConfirmQuestionnaire);
            this.Controls.Add(this.lblSelectQuestionnaire);
            this.Controls.Add(this.cbSelectQuestionnaire);
            this.Controls.Add(this.btnExams);
            this.Controls.Add(this.lblSubjectData);
            this.Controls.Add(this.lblNameData);
            this.Controls.Add(this.lblAuthorData);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblNoQuestionsInQuestionaire);
            this.Controls.Add(this.btnSaveQuestionnaire);
            this.Controls.Add(this.lblQuestionnaireName);
            this.Controls.Add(this.lblShowQuestionnaire);
            this.Controls.Add(this.questionsView1);
            this.Name = "QuestionnaireDetailView";
            this.Size = new System.Drawing.Size(909, 583);
            this.Load += new System.EventHandler(this.QuestionnaireDetailView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lblErrorSubject;
        private System.Windows.Forms.Label lblSubject;
        public System.Windows.Forms.Label lblNoNodeSelectedError;
        public System.Windows.Forms.Label lblQuestionaireNameError;
        public System.Windows.Forms.Button btnSaveQuestionnaire;
        private System.Windows.Forms.Label lblQuestionnaireName;
        private System.Windows.Forms.Label lblShowQuestionnaire;
        private System.Windows.Forms.Label lblAuthor;
        public System.Windows.Forms.Label lblAuthorData;
        public System.Windows.Forms.Label lblNameData;
        public System.Windows.Forms.Label lblSubjectData;
        public AddQuestionnaire.QuestionsView questionsView1;
        public System.Windows.Forms.Label lblNoQuestionsInQuestionaire;
        private System.Windows.Forms.Button btnExams;
        private System.Windows.Forms.ComboBox cbSelectQuestionnaire;
        private System.Windows.Forms.Label lblSelectQuestionnaire;
        private System.Windows.Forms.Button btnConfirmQuestionnaire;
    }
}
