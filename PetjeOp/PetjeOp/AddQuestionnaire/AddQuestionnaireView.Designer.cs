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
            this.lblAddQuestionnaire.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Antwoordmogelijkheden);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(21, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(921, 319);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vraag 1";
            // 
            // tbQuestionnaireName
            // 
            this.button1.Location = new System.Drawing.Point(13, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 47);
            this.button1.TabIndex = 11;
            this.button1.Text = "+ Voeg antwoord toe";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblQuestionnaireName
            // 
            this.Antwoordmogelijkheden.FormattingEnabled = true;
            this.Antwoordmogelijkheden.Items.AddRange(new object[] {
            "Antwoord 1",
            "Antwoord 2"});
            this.Antwoordmogelijkheden.Location = new System.Drawing.Point(13, 146);
            this.Antwoordmogelijkheden.Name = "Antwoordmogelijkheden";
            this.Antwoordmogelijkheden.Size = new System.Drawing.Size(467, 82);
            this.Antwoordmogelijkheden.TabIndex = 10;
            // 
            // btnSaveQuestionnaire
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Antwoordmogelijkheden";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(89, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(391, 31);
            this.textBox2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vraag:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Vragen";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(391, 31);
            this.textBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Naam:";
            // 
            // AddQuestionnaireView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveQuestionnaire);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.tbQuestionnaireName);
            this.Controls.Add(this.lblQuestionnaireName);
            this.Controls.Add(this.lblAddQuestionnaire);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddQuestionnaireView";
            this.Size = new System.Drawing.Size(1559, 932);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
