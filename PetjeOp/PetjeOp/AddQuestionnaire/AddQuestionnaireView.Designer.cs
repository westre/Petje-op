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
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Antwoordmogelijkheden = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddQuestionnaire
            // 
            this.lblAddQuestionnaire.AutoSize = true;
            this.lblAddQuestionnaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddQuestionnaire.Location = new System.Drawing.Point(3, 15);
            this.lblAddQuestionnaire.Margin = new System.Windows.Forms.Padding(3);
            this.lblAddQuestionnaire.Name = "lblAddQuestionnaire";
            this.lblAddQuestionnaire.Size = new System.Drawing.Size(502, 55);
            this.lblAddQuestionnaire.TabIndex = 0;
            this.lblAddQuestionnaire.Text = "Vragenlijst Toevoegen";
            this.lblAddQuestionnaire.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 567);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(480, 50);
            this.button2.TabIndex = 11;
            this.button2.Text = "+ Voeg vraag toe";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Antwoordmogelijkheden);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(21, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(921, 288);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vraag 1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 47);
            this.button1.TabIndex = 11;
            this.button1.Text = "+ Voeg antwoord toe";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Antwoordmogelijkheden
            // 
            this.Antwoordmogelijkheden.FormattingEnabled = true;
            this.Antwoordmogelijkheden.Items.AddRange(new object[] {
            "Antwoord 1",
            "Antwoord 2"});
            this.Antwoordmogelijkheden.Location = new System.Drawing.Point(13, 146);
            this.Antwoordmogelijkheden.Name = "Antwoordmogelijkheden";
            this.Antwoordmogelijkheden.Size = new System.Drawing.Size(467, 56);
            this.Antwoordmogelijkheden.TabIndex = 10;
            // 
            // label5
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAddQuestionnaire);
            this.Name = "AddQuestionnaireView";
            this.Size = new System.Drawing.Size(1559, 932);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddQuestionnaire;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox Antwoordmogelijkheden;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}
