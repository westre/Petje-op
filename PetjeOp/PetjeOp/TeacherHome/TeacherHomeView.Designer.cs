namespace PetjeOp
{
    partial class TeacherHomeView
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
            this.lblQuestionnaires = new System.Windows.Forms.Label();
            this.lblExams = new System.Windows.Forms.Label();
            this.lblResultsExpl = new System.Windows.Forms.Label();
            this.btnGoToResults = new System.Windows.Forms.Button();
            this.btnGoToQuestionnaires = new System.Windows.Forms.Button();
            this.lblQuestionnairesExpl = new System.Windows.Forms.Label();
            this.btnGoToExams = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(3, 47);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(223, 55);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welkom, ";
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.Location = new System.Drawing.Point(8, 170);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(155, 31);
            this.lblResults.TabIndex = 1;
            this.lblResults.Text = "Resultaten";
            // 
            // lblQuestionnaires
            // 
            this.lblQuestionnaires.AutoSize = true;
            this.lblQuestionnaires.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionnaires.Location = new System.Drawing.Point(8, 376);
            this.lblQuestionnaires.Name = "lblQuestionnaires";
            this.lblQuestionnaires.Size = new System.Drawing.Size(184, 31);
            this.lblQuestionnaires.TabIndex = 2;
            this.lblQuestionnaires.Text = "Vragenlijsten";
            // 
            // lblExams
            // 
            this.lblExams.AutoSize = true;
            this.lblExams.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExams.Location = new System.Drawing.Point(8, 607);
            this.lblExams.Name = "lblExams";
            this.lblExams.Size = new System.Drawing.Size(113, 31);
            this.lblExams.TabIndex = 3;
            this.lblExams.Text = "Agenda";
            // 
            // lblResultsExpl
            // 
            this.lblResultsExpl.AutoSize = true;
            this.lblResultsExpl.Location = new System.Drawing.Point(9, 210);
            this.lblResultsExpl.Name = "lblResultsExpl";
            this.lblResultsExpl.Size = new System.Drawing.Size(692, 25);
            this.lblResultsExpl.TabIndex = 4;
            this.lblResultsExpl.Text = "Bij \'resultaten\' kunt u de resultaten inzien van afgenomen vragenlijsten.";
            // 
            // btnGoToResults
            // 
            this.btnGoToResults.Location = new System.Drawing.Point(13, 247);
            this.btnGoToResults.Name = "btnGoToResults";
            this.btnGoToResults.Size = new System.Drawing.Size(422, 72);
            this.btnGoToResults.TabIndex = 5;
            this.btnGoToResults.Text = "Ga naar resultaten";
            this.btnGoToResults.UseVisualStyleBackColor = true;
            this.btnGoToResults.Click += new System.EventHandler(this.btnGoToResults_Click);
            // 
            // btnGoToQuestionnaires
            // 
            this.btnGoToQuestionnaires.Location = new System.Drawing.Point(13, 454);
            this.btnGoToQuestionnaires.Name = "btnGoToQuestionnaires";
            this.btnGoToQuestionnaires.Size = new System.Drawing.Size(422, 72);
            this.btnGoToQuestionnaires.TabIndex = 7;
            this.btnGoToQuestionnaires.Text = "Ga naar vragenlijsten";
            this.btnGoToQuestionnaires.UseVisualStyleBackColor = true;
            this.btnGoToQuestionnaires.Click += new System.EventHandler(this.btnGoToQuestionnaires_Click);
            // 
            // lblQuestionnairesExpl
            // 
            this.lblQuestionnairesExpl.AutoSize = true;
            this.lblQuestionnairesExpl.Location = new System.Drawing.Point(9, 417);
            this.lblQuestionnairesExpl.Name = "lblQuestionnairesExpl";
            this.lblQuestionnairesExpl.Size = new System.Drawing.Size(689, 25);
            this.lblQuestionnairesExpl.TabIndex = 6;
            this.lblQuestionnairesExpl.Text = "Bij \'vragenlijsten\' kunt u vragenlijsten bekijken, wijzigen en archiveren. ";
            // 
            // btnGoToExams
            // 
            this.btnGoToExams.Location = new System.Drawing.Point(13, 687);
            this.btnGoToExams.Name = "btnGoToExams";
            this.btnGoToExams.Size = new System.Drawing.Size(422, 72);
            this.btnGoToExams.TabIndex = 9;
            this.btnGoToExams.Text = "Ga naar agenda";
            this.btnGoToExams.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 650);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Bij \'agenda\' kunt u afnamemomenten inzien en toevoegen.";
            // 
            // TeacherHomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGoToExams);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGoToQuestionnaires);
            this.Controls.Add(this.lblQuestionnairesExpl);
            this.Controls.Add(this.btnGoToResults);
            this.Controls.Add(this.lblResultsExpl);
            this.Controls.Add(this.lblExams);
            this.Controls.Add(this.lblQuestionnaires);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lblWelcome);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TeacherHomeView";
            this.Size = new System.Drawing.Size(1468, 1146);
            this.Load += new System.EventHandler(this.TeacherHomeView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblQuestionnaires;
        private System.Windows.Forms.Label lblExams;
        private System.Windows.Forms.Label lblResultsExpl;
        private System.Windows.Forms.Button btnGoToResults;
        private System.Windows.Forms.Button btnGoToQuestionnaires;
        private System.Windows.Forms.Label lblQuestionnairesExpl;
        private System.Windows.Forms.Button btnGoToExams;
        private System.Windows.Forms.Label label1;
    }
}