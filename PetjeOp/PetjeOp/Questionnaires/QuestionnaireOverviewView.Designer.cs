namespace PetjeOp.Questionnaires
{
    partial class QuestionnaireOverviewView
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
            this.tvQuestionnaires = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddQuestionnaire
            // 
            this.lblAddQuestionnaire.AutoSize = true;
            this.lblAddQuestionnaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddQuestionnaire.Location = new System.Drawing.Point(2, 2);
            this.lblAddQuestionnaire.Margin = new System.Windows.Forms.Padding(2);
            this.lblAddQuestionnaire.Name = "lblAddQuestionnaire";
            this.lblAddQuestionnaire.Size = new System.Drawing.Size(301, 55);
            this.lblAddQuestionnaire.TabIndex = 1;
            this.lblAddQuestionnaire.Text = "Vragenlijsten";
            this.lblAddQuestionnaire.Click += new System.EventHandler(this.lblAddQuestionnaire_Click);
            // 
            // tvQuestionnaires
            // 
            this.tvQuestionnaires.Location = new System.Drawing.Point(12, 78);
            this.tvQuestionnaires.Name = "tvQuestionnaires";
            this.tvQuestionnaires.Size = new System.Drawing.Size(1123, 628);
            this.tvQuestionnaires.TabIndex = 2;
            this.tvQuestionnaires.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvQuestionnaires_AfterSelect);
            this.tvQuestionnaires.VisibleChanged += new System.EventHandler(this.tvQuestionnaires_VisibleChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 713);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(291, 76);
            this.button1.TabIndex = 3;
            this.button1.Text = "+ Vragenlijst Toevoegen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuestionnaireOverviewView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tvQuestionnaires);
            this.Controls.Add(this.lblAddQuestionnaire);
            this.Name = "QuestionnaireOverviewView";
            this.Size = new System.Drawing.Size(1160, 888);
            this.Load += new System.EventHandler(this.QuestionnaireOverviewView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddQuestionnaire;
        public System.Windows.Forms.TreeView tvQuestionnaires;
        private System.Windows.Forms.Button button1;
    }
}
