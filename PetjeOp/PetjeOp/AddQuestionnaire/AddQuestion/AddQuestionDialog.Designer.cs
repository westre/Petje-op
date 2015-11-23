namespace PetjeOp.AddQuestionnaire.AddQuestion
{
    partial class AddQuestionDialog
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
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.addQuestionView1 = new PetjeOp.AddQuestionnaire.AddQuestionView();
            this.SuspendLayout();
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddQuestion.Location = new System.Drawing.Point(440, 363);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(242, 40);
            this.btnAddQuestion.TabIndex = 1;
            this.btnAddQuestion.Text = "Vraag Toevoegen";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(688, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(242, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // addQuestionView1
            // 
            this.addQuestionView1.Location = new System.Drawing.Point(12, 12);
            this.addQuestionView1.Name = "addQuestionView1";
            this.addQuestionView1.Size = new System.Drawing.Size(920, 345);
            this.addQuestionView1.TabIndex = 0;
            // 
            // AddQuestionDialog
            // 
            this.AcceptButton = this.btnAddQuestion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(942, 412);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.addQuestionView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddQuestionDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Vraag Toevoegen";
            this.ResumeLayout(false);

        }

        #endregion

        private AddQuestionView addQuestionView1;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Button btnCancel;
    }
}