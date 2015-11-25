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
            this.btnTeacherTest = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnResults = new System.Windows.Forms.Button();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTeacherTest
            // 
            this.btnTeacherTest.Location = new System.Drawing.Point(55, 16);
            this.btnTeacherTest.Name = "btnTeacherTest";
            this.btnTeacherTest.Size = new System.Drawing.Size(115, 39);
            this.btnTeacherTest.TabIndex = 1;
            this.btnTeacherTest.Text = "Ingelogd als teacher";
            this.btnTeacherTest.UseVisualStyleBackColor = true;
            this.btnTeacherTest.Click += new System.EventHandler(this.btnLoginTeacher_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlHeader.Controls.Add(this.btnTeacherTest);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(699, 71);
            this.pnlHeader.TabIndex = 2;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMenu.Controls.Add(this.btnResults);
            this.pnlMenu.Location = new System.Drawing.Point(0, 77);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(129, 399);
            this.pnlMenu.TabIndex = 3;
            // 
            // btnResults
            // 
            this.btnResults.Location = new System.Drawing.Point(3, 24);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(97, 23);
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
            this.viewPanel.Location = new System.Drawing.Point(135, 77);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(564, 396);
            this.viewPanel.TabIndex = 4;
            // 
            // TeacherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.Name = "TeacherView";
            this.Size = new System.Drawing.Size(699, 476);
            this.Load += new System.EventHandler(this.TeacherView_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTeacherTest;
        public System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.Button btnResults;
        public System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Panel pnlMenu;
    }
}
