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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.Error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStudentLogin
            // 
            this.btnStudentLogin.Location = new System.Drawing.Point(261, 22);
            this.btnStudentLogin.Name = "btnStudentLogin";
            this.btnStudentLogin.Size = new System.Drawing.Size(115, 31);
            this.btnStudentLogin.TabIndex = 0;
            this.btnStudentLogin.Text = "Inloggen als student";
            this.btnStudentLogin.UseVisualStyleBackColor = true;
            this.btnStudentLogin.Click += new System.EventHandler(this.btnStudentLogin_Click);
            // 
            // btnLoginTeacher
            // 
            this.btnLoginTeacher.Location = new System.Drawing.Point(261, 88);
            this.btnLoginTeacher.Name = "btnLoginTeacher";
            this.btnLoginTeacher.Size = new System.Drawing.Size(115, 39);
            this.btnLoginTeacher.TabIndex = 1;
            this.btnLoginTeacher.Text = "Inloggen als teacher";
            this.btnLoginTeacher.UseVisualStyleBackColor = true;
            this.btnLoginTeacher.Click += new System.EventHandler(this.btnLoginTeacher_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inlog Code:";
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(113, 157);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(100, 23);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // Error
            // 
            this.Error.AutoSize = true;
            this.Error.ForeColor = System.Drawing.Color.DarkRed;
            this.Error.Location = new System.Drawing.Point(230, 134);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(120, 13);
            this.Error.TabIndex = 5;
            this.Error.Text = "Woops.. Er ging iets mis";
            this.Error.Visible = false;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Error);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLoginTeacher);
            this.Controls.Add(this.btnStudentLogin);
            this.Name = "LoginView";
            this.Size = new System.Drawing.Size(390, 294);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStudentLogin;
        private System.Windows.Forms.Button btnLoginTeacher;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label Error;
    }
}
