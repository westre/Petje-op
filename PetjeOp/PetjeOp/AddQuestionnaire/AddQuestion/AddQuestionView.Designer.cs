namespace PetjeOp.AddQuestionnaire
{
    partial class AddQuestionView
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
            this.gbQuestion = new System.Windows.Forms.GroupBox();
            this.lblAnswersError = new System.Windows.Forms.Label();
            this.lblQuestionError = new System.Windows.Forms.Label();
            this.lblNonSufficientAnswers = new System.Windows.Forms.Label();
            this.btnDeleteAnswer = new System.Windows.Forms.Button();
            this.tbAnswer = new System.Windows.Forms.TextBox();
            this.btnAddAnswer = new System.Windows.Forms.Button();
            this.clbAnswers = new System.Windows.Forms.CheckedListBox();
            this.lblAnswers = new System.Windows.Forms.Label();
            this.tbQuestion = new System.Windows.Forms.TextBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.gbQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbQuestion
            // 
            this.gbQuestion.Controls.Add(this.lblAnswersError);
            this.gbQuestion.Controls.Add(this.lblQuestionError);
            this.gbQuestion.Controls.Add(this.lblNonSufficientAnswers);
            this.gbQuestion.Controls.Add(this.btnDeleteAnswer);
            this.gbQuestion.Controls.Add(this.tbAnswer);
            this.gbQuestion.Controls.Add(this.btnAddAnswer);
            this.gbQuestion.Controls.Add(this.clbAnswers);
            this.gbQuestion.Controls.Add(this.lblAnswers);
            this.gbQuestion.Controls.Add(this.tbQuestion);
            this.gbQuestion.Controls.Add(this.lblQuestion);
            this.gbQuestion.Location = new System.Drawing.Point(2, 2);
            this.gbQuestion.Margin = new System.Windows.Forms.Padding(2);
            this.gbQuestion.Name = "gbQuestion";
            this.gbQuestion.Padding = new System.Windows.Forms.Padding(2);
            this.gbQuestion.Size = new System.Drawing.Size(457, 174);
            this.gbQuestion.TabIndex = 0;
            this.gbQuestion.TabStop = false;
            this.gbQuestion.Text = "Vraag";
            this.gbQuestion.Enter += new System.EventHandler(this.gbQuestion_Enter);
            // 
            // lblAnswersError
            // 
            this.lblAnswersError.AutoSize = true;
            this.lblAnswersError.Location = new System.Drawing.Point(118, 56);
            this.lblAnswersError.Name = "lblAnswersError";
            this.lblAnswersError.Size = new System.Drawing.Size(134, 13);
            this.lblAnswersError.TabIndex = 21;
            this.lblAnswersError.Text = "(vink goede antwoord aan)";
            // 
            // lblQuestionError
            // 
            this.lblQuestionError.AutoSize = true;
            this.lblQuestionError.Location = new System.Drawing.Point(247, 22);
            this.lblQuestionError.Name = "lblQuestionError";
            this.lblQuestionError.Size = new System.Drawing.Size(0, 13);
            this.lblQuestionError.TabIndex = 20;
            // 
            // lblNonSufficientAnswers
            // 
            this.lblNonSufficientAnswers.AutoSize = true;
            this.lblNonSufficientAnswers.Location = new System.Drawing.Point(247, 94);
            this.lblNonSufficientAnswers.MaximumSize = new System.Drawing.Size(200, 26);
            this.lblNonSufficientAnswers.Name = "lblNonSufficientAnswers";
            this.lblNonSufficientAnswers.Size = new System.Drawing.Size(0, 13);
            this.lblNonSufficientAnswers.TabIndex = 19;
            // 
            // btnDeleteAnswer
            // 
            this.btnDeleteAnswer.Enabled = false;
            this.btnDeleteAnswer.Location = new System.Drawing.Point(250, 71);
            this.btnDeleteAnswer.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteAnswer.Name = "btnDeleteAnswer";
            this.btnDeleteAnswer.Size = new System.Drawing.Size(70, 21);
            this.btnDeleteAnswer.TabIndex = 18;
            this.btnDeleteAnswer.Text = "Verwijder";
            this.btnDeleteAnswer.UseVisualStyleBackColor = true;
            this.btnDeleteAnswer.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // tbAnswer
            // 
            this.tbAnswer.Location = new System.Drawing.Point(6, 144);
            this.tbAnswer.Margin = new System.Windows.Forms.Padding(2);
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.Size = new System.Drawing.Size(236, 20);
            this.tbAnswer.TabIndex = 17;
            this.tbAnswer.TextChanged += new System.EventHandler(this.tbAnswer_TextChanged);
            // 
            // btnAddAnswer
            // 
            this.btnAddAnswer.Enabled = false;
            this.btnAddAnswer.Location = new System.Drawing.Point(250, 144);
            this.btnAddAnswer.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddAnswer.Name = "btnAddAnswer";
            this.btnAddAnswer.Size = new System.Drawing.Size(70, 21);
            this.btnAddAnswer.TabIndex = 16;
            this.btnAddAnswer.Text = "Toevoegen";
            this.btnAddAnswer.UseVisualStyleBackColor = true;
            this.btnAddAnswer.Click += new System.EventHandler(this.btnAddAnswer_Click);
            // 
            // clbAnswers
            // 
            this.clbAnswers.CheckOnClick = true;
            this.clbAnswers.FormattingEnabled = true;
            this.clbAnswers.Items.AddRange(new object[] {
            "Paard",
            "Hond",
            "Vierkant"});
            this.clbAnswers.Location = new System.Drawing.Point(6, 71);
            this.clbAnswers.Margin = new System.Windows.Forms.Padding(2);
            this.clbAnswers.Name = "clbAnswers";
            this.clbAnswers.Size = new System.Drawing.Size(236, 64);
            this.clbAnswers.TabIndex = 15;
            this.clbAnswers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbAnswers_ItemCheck);
            this.clbAnswers.SelectedIndexChanged += new System.EventHandler(this.clbAnswers_SelectedIndexChanged);
            // 
            // lblAnswers
            // 
            this.lblAnswers.AutoSize = true;
            this.lblAnswers.Location = new System.Drawing.Point(3, 56);
            this.lblAnswers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAnswers.Name = "lblAnswers";
            this.lblAnswers.Size = new System.Drawing.Size(120, 13);
            this.lblAnswers.TabIndex = 14;
            this.lblAnswers.Text = "Antwoordmogelijkheden";
            // 
            // tbQuestion
            // 
            this.tbQuestion.Location = new System.Drawing.Point(44, 19);
            this.tbQuestion.Margin = new System.Windows.Forms.Padding(2);
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.Size = new System.Drawing.Size(198, 20);
            this.tbQuestion.TabIndex = 13;
            this.tbQuestion.Text = "Yoran is echt een ...";
            this.tbQuestion.TextChanged += new System.EventHandler(this.tbQuestion_TextChanged);
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(3, 19);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(38, 13);
            this.lblQuestion.TabIndex = 12;
            this.lblQuestion.Text = "Vraag:";
            // 
            // AddQuestionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbQuestion);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddQuestionView";
            this.Size = new System.Drawing.Size(460, 179);
            this.gbQuestion.ResumeLayout(false);
            this.gbQuestion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gbQuestion;
        public System.Windows.Forms.Button btnAddAnswer;
        public System.Windows.Forms.CheckedListBox clbAnswers;
        public System.Windows.Forms.Label lblAnswers;
        public System.Windows.Forms.TextBox tbQuestion;
        public System.Windows.Forms.Label lblQuestion;
        public System.Windows.Forms.TextBox tbAnswer;
        public System.Windows.Forms.Button btnDeleteAnswer;
        public System.Windows.Forms.Label lblNonSufficientAnswers;
        private System.Windows.Forms.Label lblQuestionError;
        private System.Windows.Forms.Label lblAnswersError;
    }
}
