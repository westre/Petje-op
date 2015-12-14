namespace PetjeOp.AddQuestionnaire
{
    partial class QuestionsView
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
            this.components = new System.ComponentModel.Container();
            this.lblNoQuestionsInQuestionaire = new System.Windows.Forms.Label();
            this.lblNoNodeSelectedError = new System.Windows.Forms.Label();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.btnEditQuestion = new System.Windows.Forms.Button();
            this.tvQuestions = new System.Windows.Forms.TreeView();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.epNoQuestions = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epNoQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNoQuestionsInQuestionaire
            // 
            this.lblNoQuestionsInQuestionaire.AutoSize = true;
            this.lblNoQuestionsInQuestionaire.ForeColor = System.Drawing.Color.Red;
            this.lblNoQuestionsInQuestionaire.Location = new System.Drawing.Point(508, 427);
            this.lblNoQuestionsInQuestionaire.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoQuestionsInQuestionaire.Name = "lblNoQuestionsInQuestionaire";
            this.lblNoQuestionsInQuestionaire.Size = new System.Drawing.Size(0, 25);
            this.lblNoQuestionsInQuestionaire.TabIndex = 26;
            // 
            // lblNoNodeSelectedError
            // 
            this.lblNoNodeSelectedError.AutoSize = true;
            this.lblNoNodeSelectedError.ForeColor = System.Drawing.Color.Red;
            this.lblNoNodeSelectedError.Location = new System.Drawing.Point(1052, 8);
            this.lblNoNodeSelectedError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoNodeSelectedError.Name = "lblNoNodeSelectedError";
            this.lblNoNodeSelectedError.Size = new System.Drawing.Size(211, 25);
            this.lblNoNodeSelectedError.TabIndex = 25;
            this.lblNoNodeSelectedError.Text = "Selecteer een vraag!";
            this.lblNoNodeSelectedError.Visible = false;
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Enabled = false;
            this.btnDeleteQuestion.Location = new System.Drawing.Point(1276, 117);
            this.btnDeleteQuestion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(152, 48);
            this.btnDeleteQuestion.TabIndex = 24;
            this.btnDeleteQuestion.Text = "Verwijder";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // btnEditQuestion
            // 
            this.btnEditQuestion.Enabled = false;
            this.btnEditQuestion.Location = new System.Drawing.Point(1276, 46);
            this.btnEditQuestion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditQuestion.Name = "btnEditQuestion";
            this.btnEditQuestion.Size = new System.Drawing.Size(152, 48);
            this.btnEditQuestion.TabIndex = 23;
            this.btnEditQuestion.Text = "Wijzig";
            this.btnEditQuestion.UseVisualStyleBackColor = true;
            this.btnEditQuestion.Click += new System.EventHandler(this.btnEditQuestion_Click);
            // 
            // tvQuestions
            // 
            this.tvQuestions.HideSelection = false;
            this.tvQuestions.Location = new System.Drawing.Point(4, 46);
            this.tvQuestions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tvQuestions.Name = "tvQuestions";
            this.tvQuestions.Size = new System.Drawing.Size(1260, 362);
            this.tvQuestions.TabIndex = 22;
            this.tvQuestions.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvQuestions_BeforeSelect);
            this.tvQuestions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvQuestions_AfterSelect);
            this.tvQuestions.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tvQuestions_ControlAdded);
            this.tvQuestions.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tvQuestions_ControlRemoved);
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(4, 413);
            this.btnAddQuestion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(480, 50);
            this.btnAddQuestion.TabIndex = 21;
            this.btnAddQuestion.Text = "+ Voeg vraag toe";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // lblQuestions
            // 
            this.lblQuestions.AutoSize = true;
            this.lblQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestions.Location = new System.Drawing.Point(-2, 8);
            this.lblQuestions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestions.Name = "lblQuestions";
            this.lblQuestions.Size = new System.Drawing.Size(87, 25);
            this.lblQuestions.TabIndex = 20;
            this.lblQuestions.Text = "Vragen";
            // 
            // epNoQuestions
            // 
            this.epNoQuestions.ContainerControl = this;
            // 
            // QuestionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNoQuestionsInQuestionaire);
            this.Controls.Add(this.lblNoNodeSelectedError);
            this.Controls.Add(this.btnDeleteQuestion);
            this.Controls.Add(this.btnEditQuestion);
            this.Controls.Add(this.tvQuestions);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.lblQuestions);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "QuestionsView";
            this.Size = new System.Drawing.Size(1436, 471);
            this.Load += new System.EventHandler(this.QuestionsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epNoQuestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblNoQuestionsInQuestionaire;
        public System.Windows.Forms.Label lblNoNodeSelectedError;
        public System.Windows.Forms.Button btnDeleteQuestion;
        public System.Windows.Forms.Button btnEditQuestion;
        public System.Windows.Forms.TreeView tvQuestions;
        public System.Windows.Forms.Button btnAddQuestion;
        public System.Windows.Forms.ErrorProvider epNoQuestions;
        public System.Windows.Forms.Label lblQuestions;
    }
}
