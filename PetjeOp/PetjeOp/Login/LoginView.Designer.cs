namespace PetjeOp {
    partial class LoginView {
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
            this.btnStudentLogin = new System.Windows.Forms.Button();
            this.btnLoginTeacher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStudentLogin
            // 
            this.btnStudentLogin.Location = new System.Drawing.Point(135, 158);
            this.btnStudentLogin.Name = "btnStudentLogin";
            this.btnStudentLogin.Size = new System.Drawing.Size(115, 31);
            this.btnStudentLogin.TabIndex = 0;
            this.btnStudentLogin.Text = "Inloggen als student";
            this.btnStudentLogin.UseVisualStyleBackColor = true;
            this.btnStudentLogin.Click += new System.EventHandler(this.btnStudentLogin_Click);
            // 
            // btnLoginTeacher
            // 
            this.btnLoginTeacher.Location = new System.Drawing.Point(135, 219);
            this.btnLoginTeacher.Name = "btnLoginTeacher";
            this.btnLoginTeacher.Size = new System.Drawing.Size(115, 39);
            this.btnLoginTeacher.TabIndex = 1;
            this.btnLoginTeacher.Text = "Inloggen als teacher";
            this.btnLoginTeacher.UseVisualStyleBackColor = true;
            this.btnLoginTeacher.Click += new System.EventHandler(this.btnLoginTeacher_Click);
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoginTeacher);
            this.Controls.Add(this.btnStudentLogin);
            this.Name = "LoginView";
            this.Size = new System.Drawing.Size(390, 294);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStudentLogin;
        private System.Windows.Forms.Button btnLoginTeacher;
    }
}
