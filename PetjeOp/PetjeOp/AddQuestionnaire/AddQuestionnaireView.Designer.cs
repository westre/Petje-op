namespace PetjeOp.AddQuestionnaire
{
    partial class AddQuestionnaireView
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
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAddQuestionnaire
            // 
            this.lblAddQuestionnaire.AutoSize = true;
            this.lblAddQuestionnaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddQuestionnaire.Location = new System.Drawing.Point(4, 15);
            this.lblAddQuestionnaire.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblAddQuestionnaire.Name = "lblAddQuestionnaire";
            this.lblAddQuestionnaire.Size = new System.Drawing.Size(502, 55);
            this.lblAddQuestionnaire.TabIndex = 0;
            this.lblAddQuestionnaire.Text = "Vragenlijst Toevoegen";
            this.lblAddQuestionnaire.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(14, 138);
            this.btnAddQuestion.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(960, 96);
            this.btnAddQuestion.TabIndex = 11;
            this.btnAddQuestion.Text = "+ Voeg vraag toe";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // lblQuestions
            // 
            this.lblQuestions.Location = new System.Drawing.Point(99, 313);
            this.lblQuestions.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblQuestions.Name = "lblQuestions";
            this.lblQuestions.Size = new System.Drawing.Size(200, 44);
            this.lblQuestions.TabIndex = 12;
            // 
            // AddQuestionnaireView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.lblAddQuestionnaire);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddQuestionnaireView";
            this.Size = new System.Drawing.Size(3118, 1792);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddQuestionnaire;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Label lblQuestions;
    }
}
