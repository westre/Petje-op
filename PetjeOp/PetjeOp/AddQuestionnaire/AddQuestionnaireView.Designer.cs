namespace PetjeOp.AddQuestionnaire
{
    partial class AddQuestionnaireView {
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
            this.lblAddQuestionnaire = new System.Windows.Forms.Label();
            this.tbQuestionnaireName = new System.Windows.Forms.TextBox();
            this.lblQuestionnaireName = new System.Windows.Forms.Label();
            this.btnSaveQuestionnaire = new System.Windows.Forms.Button();
            this.lblQuestionaireNameError = new System.Windows.Forms.Label();
            this.lblNoNodeSelectedError = new System.Windows.Forms.Label();
            this.lblNoQuestionsInQuestionaire = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cbSubjects = new System.Windows.Forms.ComboBox();
            this.lblErrorSubject = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.questionsView1 = new PetjeOp.AddQuestionnaire.QuestionsView();
            this.SuspendLayout();
            // 
            // lblAddQuestionnaire
            // 
            this.lblAddQuestionnaire.AutoSize = true;
            this.lblAddQuestionnaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddQuestionnaire.Location = new System.Drawing.Point(2, 8);
            this.lblAddQuestionnaire.Margin = new System.Windows.Forms.Padding(2);
            this.lblAddQuestionnaire.Name = "lblAddQuestionnaire";
            this.lblAddQuestionnaire.Size = new System.Drawing.Size(502, 55);
            this.lblAddQuestionnaire.TabIndex = 0;
            this.lblAddQuestionnaire.Text = "Vragenlijst Toevoegen";
            // 
            // tbQuestionnaireName
            // 
            this.tbQuestionnaireName.Location = new System.Drawing.Point(89, 109);
            this.tbQuestionnaireName.Name = "tbQuestionnaireName";
            this.tbQuestionnaireName.Size = new System.Drawing.Size(391, 31);
            this.tbQuestionnaireName.TabIndex = 8;
            this.tbQuestionnaireName.TextChanged += new System.EventHandler(this.tbQuestionnaireName_TextChanged);
            // 
            // lblQuestionnaireName
            // 
            this.lblQuestionnaireName.AutoSize = true;
            this.lblQuestionnaireName.Location = new System.Drawing.Point(8, 109);
            this.lblQuestionnaireName.Name = "lblQuestionnaireName";
            this.lblQuestionnaireName.Size = new System.Drawing.Size(74, 25);
            this.lblQuestionnaireName.TabIndex = 7;
            this.lblQuestionnaireName.Text = "Naam:";
            // 
            // btnSaveQuestionnaire
            // 
            this.btnSaveQuestionnaire.Enabled = false;
            this.btnSaveQuestionnaire.Location = new System.Drawing.Point(21, 721);
            this.btnSaveQuestionnaire.Name = "btnSaveQuestionnaire";
            this.btnSaveQuestionnaire.Size = new System.Drawing.Size(267, 49);
            this.btnSaveQuestionnaire.TabIndex = 13;
            this.btnSaveQuestionnaire.Text = "Vragenlijst Opslaan";
            this.btnSaveQuestionnaire.UseVisualStyleBackColor = true;
            this.btnSaveQuestionnaire.Click += new System.EventHandler(this.btnSaveQuestionnaire_Click);
            // 
            // lblQuestionaireNameError
            // 
            this.lblQuestionaireNameError.AutoSize = true;
            this.lblQuestionaireNameError.ForeColor = System.Drawing.Color.Red;
            this.lblQuestionaireNameError.Location = new System.Drawing.Point(486, 112);
            this.lblQuestionaireNameError.Name = "lblQuestionaireNameError";
            this.lblQuestionaireNameError.Size = new System.Drawing.Size(0, 25);
            this.lblQuestionaireNameError.TabIndex = 17;
            // 
            // lblNoNodeSelectedError
            // 
            this.lblNoNodeSelectedError.AutoSize = true;
            this.lblNoNodeSelectedError.ForeColor = System.Drawing.Color.Red;
            this.lblNoNodeSelectedError.Location = new System.Drawing.Point(852, 255);
            this.lblNoNodeSelectedError.Name = "lblNoNodeSelectedError";
            this.lblNoNodeSelectedError.Size = new System.Drawing.Size(0, 25);
            this.lblNoNodeSelectedError.TabIndex = 18;
            // 
            // lblNoQuestionsInQuestionaire
            // 
            this.lblNoQuestionsInQuestionaire.AutoSize = true;
            this.lblNoQuestionsInQuestionaire.ForeColor = System.Drawing.Color.Red;
            this.lblNoQuestionsInQuestionaire.Location = new System.Drawing.Point(525, 657);
            this.lblNoQuestionsInQuestionaire.Name = "lblNoQuestionsInQuestionaire";
            this.lblNoQuestionsInQuestionaire.Size = new System.Drawing.Size(0, 25);
            this.lblNoQuestionsInQuestionaire.TabIndex = 19;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(10, 174);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(55, 25);
            this.lblSubject.TabIndex = 20;
            this.lblSubject.Text = "Vak:";
            // 
            // cbSubjects
            // 
            this.cbSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubjects.FormattingEnabled = true;
            this.cbSubjects.Location = new System.Drawing.Point(89, 174);
            this.cbSubjects.Name = "cbSubjects";
            this.cbSubjects.Size = new System.Drawing.Size(391, 33);
            this.cbSubjects.TabIndex = 21;
            this.cbSubjects.SelectedIndexChanged += new System.EventHandler(this.cbSubjects_SelectedIndexChanged);
            // 
            // lblErrorSubject
            // 
            this.lblErrorSubject.AutoSize = true;
            this.lblErrorSubject.ForeColor = System.Drawing.Color.Red;
            this.lblErrorSubject.Location = new System.Drawing.Point(486, 177);
            this.lblErrorSubject.Name = "lblErrorSubject";
            this.lblErrorSubject.Size = new System.Drawing.Size(0, 25);
            this.lblErrorSubject.TabIndex = 22;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(294, 721);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(210, 49);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Annuleer";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // questionsView1
            // 
            this.questionsView1.Dialog = null;
            this.questionsView1.Location = new System.Drawing.Point(13, 227);
            this.questionsView1.Name = "questionsView1";
            this.questionsView1.ParentController = null;
            this.questionsView1.Size = new System.Drawing.Size(1092, 472);
            this.questionsView1.TabIndex = 25;
            // 
            // AddQuestionnaireView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblErrorSubject);
            this.Controls.Add(this.cbSubjects);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblNoQuestionsInQuestionaire);
            this.Controls.Add(this.lblNoNodeSelectedError);
            this.Controls.Add(this.lblQuestionaireNameError);
            this.Controls.Add(this.btnSaveQuestionnaire);
            this.Controls.Add(this.tbQuestionnaireName);
            this.Controls.Add(this.lblQuestionnaireName);
            this.Controls.Add(this.lblAddQuestionnaire);
            this.Controls.Add(this.questionsView1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AddQuestionnaireView";
            this.Size = new System.Drawing.Size(1140, 1551);
            this.Load += new System.EventHandler(this.AddQuestionnaireView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddQuestionnaire;
        public System.Windows.Forms.TextBox tbQuestionnaireName;
        private System.Windows.Forms.Label lblQuestionnaireName;
        public System.Windows.Forms.Button btnSaveQuestionnaire;
        public System.Windows.Forms.Label lblQuestionaireNameError;
        public System.Windows.Forms.Label lblNoNodeSelectedError;
        public System.Windows.Forms.Label lblNoQuestionsInQuestionaire;
        private System.Windows.Forms.Label lblSubject;
        public System.Windows.Forms.ComboBox cbSubjects;
        public System.Windows.Forms.Label lblErrorSubject;
        private System.Windows.Forms.Button btnCancel;
        public QuestionsView questionsView1;
    }
}
