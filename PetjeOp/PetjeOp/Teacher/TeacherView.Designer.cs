namespace PetjeOp {
    partial class TeacherView {
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnDebugGetQuestionnaires = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnResults = new System.Windows.Forms.Button();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.btnQuestionnaires = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Menu;
            this.pnlHeader.Controls.Add(this.btnDebugGetQuestionnaires);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1398, 137);
            this.pnlHeader.TabIndex = 2;
            // 
            // btnDebugGetQuestionnaires
            // 
            this.btnDebugGetQuestionnaires.Location = new System.Drawing.Point(1160, 56);
            this.btnDebugGetQuestionnaires.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnDebugGetQuestionnaires.Name = "btnDebugGetQuestionnaires";
            this.btnDebugGetQuestionnaires.Size = new System.Drawing.Size(204, 52);
            this.btnDebugGetQuestionnaires.TabIndex = 1;
            this.btnDebugGetQuestionnaires.Text = "kevin\'s q debug";
            this.btnDebugGetQuestionnaires.UseVisualStyleBackColor = true;
            this.btnDebugGetQuestionnaires.Click += new System.EventHandler(this.btnDebugGetQuestionnaires_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 31.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 96);
            this.label1.TabIndex = 0;
            this.label1.Text = "WinQ";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.Menu;
            this.pnlMenu.Controls.Add(this.btnQuestionnaires);
            this.pnlMenu.Controls.Add(this.label2);
            this.pnlMenu.Controls.Add(this.btnResults);
            this.pnlMenu.Location = new System.Drawing.Point(0, 137);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(258, 779);
            this.pnlMenu.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(150)))));
            this.label2.Location = new System.Drawing.Point(10, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 49);
            this.label2.TabIndex = 1;
            this.label2.Text = "Menu";
            // 
            // btnResults
            // 
            this.btnResults.Location = new System.Drawing.Point(6, 123);
            this.btnResults.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(246, 44);
            this.btnResults.TabIndex = 2;
            this.btnResults.Text = "Resultaten";
            this.btnResults.UseVisualStyleBackColor = true;
            this.btnResults.Click += new System.EventHandler(this.button1_Click);
            // 
            // viewPanel
            // 
            this.viewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewPanel.Location = new System.Drawing.Point(270, 148);
            this.viewPanel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(1128, 762);
            this.viewPanel.TabIndex = 4;
            // 
            // btnQuestionnaires
            // 
            this.btnQuestionnaires.Location = new System.Drawing.Point(6, 67);
            this.btnQuestionnaires.Margin = new System.Windows.Forms.Padding(6);
            this.btnQuestionnaires.Name = "btnQuestionnaires";
            this.btnQuestionnaires.Size = new System.Drawing.Size(246, 44);
            this.btnQuestionnaires.TabIndex = 3;
            this.btnQuestionnaires.Text = "Vragenlijsten";
            this.btnQuestionnaires.UseVisualStyleBackColor = true;
            this.btnQuestionnaires.Click += new System.EventHandler(this.btnQuestionnaires_Click);
            // 
            // TeacherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "TeacherView";
            this.Size = new System.Drawing.Size(1398, 915);
            this.Load += new System.EventHandler(this.TeacherView_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.Button btnResults;
        public System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDebugGetQuestionnaires;
        private System.Windows.Forms.Button btnQuestionnaires;
    }
}
