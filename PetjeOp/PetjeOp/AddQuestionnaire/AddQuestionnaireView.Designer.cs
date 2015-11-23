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
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.tbQuestionnaireName = new System.Windows.Forms.TextBox();
            this.lblQuestionnaireName = new System.Windows.Forms.Label();
            this.btnSaveQuestionnaire = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddQuestionnaire
            // 
            this.lblAddQuestionnaire.AutoSize = true;
            this.lblAddQuestionnaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddQuestionnaire.Location = new System.Drawing.Point(2, 8);
            this.lblAddQuestionnaire.Margin = new System.Windows.Forms.Padding(2);
            this.lblAddQuestionnaire.Name = "lblAddQuestionnaire";
            this.lblAddQuestionnaire.Size = new System.Drawing.Size(256, 29);
            this.lblAddQuestionnaire.TabIndex = 0;
            this.lblAddQuestionnaire.Text = "Vragenlijst Toevoegen";
            this.lblAddQuestionnaire.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(21, 600);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(480, 50);
            this.btnAddQuestion.TabIndex = 11;
            this.btnAddQuestion.Text = "+ Voeg vraag toe";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // lblQuestions
            // 
            this.lblQuestions.AutoSize = true;
            this.lblQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestions.Location = new System.Drawing.Point(16, 194);
            this.lblQuestions.Name = "lblQuestions";
            this.lblQuestions.Size = new System.Drawing.Size(47, 13);
            this.lblQuestions.TabIndex = 9;
            this.lblQuestions.Text = "Vragen";
            // 
            // tbQuestionnaireName
            // 
            this.tbQuestionnaireName.Location = new System.Drawing.Point(89, 109);
            this.tbQuestionnaireName.Name = "tbQuestionnaireName";
            this.tbQuestionnaireName.Size = new System.Drawing.Size(391, 20);
            this.tbQuestionnaireName.TabIndex = 8;
            // 
            // lblQuestionnaireName
            // 
            this.lblQuestionnaireName.AutoSize = true;
            this.lblQuestionnaireName.Location = new System.Drawing.Point(8, 109);
            this.lblQuestionnaireName.Name = "lblQuestionnaireName";
            this.lblQuestionnaireName.Size = new System.Drawing.Size(38, 13);
            this.lblQuestionnaireName.TabIndex = 7;
            this.lblQuestionnaireName.Text = "Naam:";
            // 
            // btnSaveQuestionnaire
            // 
            this.btnSaveQuestionnaire.Location = new System.Drawing.Point(21, 698);
            this.btnSaveQuestionnaire.Name = "btnSaveQuestionnaire";
            this.btnSaveQuestionnaire.Size = new System.Drawing.Size(267, 49);
            this.btnSaveQuestionnaire.TabIndex = 13;
            this.btnSaveQuestionnaire.Text = "Vragenlijst Opslaan";
            this.btnSaveQuestionnaire.UseVisualStyleBackColor = true;
            // 
            // AddQuestionnaireView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.Controls.Add(this.btnSaveQuestionnaire);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.tbQuestionnaireName);
            this.Controls.Add(this.lblQuestionnaireName);
            this.Controls.Add(this.lblAddQuestionnaire);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AddQuestionnaireView";
            this.Size = new System.Drawing.Size(763, 485);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddQuestionnaire;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Label lblQuestions;
        private System.Windows.Forms.TextBox tbQuestionnaireName;
        private System.Windows.Forms.Label lblQuestionnaireName;
        private System.Windows.Forms.Button btnSaveQuestionnaire;
    }
}
