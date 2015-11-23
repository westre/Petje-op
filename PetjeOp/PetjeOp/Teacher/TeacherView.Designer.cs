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
            this.viewPanel = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(390, 69);
            this.pnlHeader.TabIndex = 2;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMenu.Location = new System.Drawing.Point(3, 72);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(126, 219);
            this.pnlMenu.TabIndex = 3;
            // 
            // viewPanel
            // 
            this.viewPanel.Location = new System.Drawing.Point(140, 77);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(540, 386);
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
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTeacherTest;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMenu;
        public System.Windows.Forms.Panel viewPanel;
    }
}
