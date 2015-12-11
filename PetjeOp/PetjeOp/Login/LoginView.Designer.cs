namespace PetjeOp.Login
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAnswerQuestion = new System.Windows.Forms.Button();
            this.PnlLogin = new System.Windows.Forms.Panel();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.txtLoginCode = new System.Windows.Forms.TextBox();
            this.pnlButton_Logout_Background = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.pnlButton_Logout_Background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackgroundImage = global::PetjeOp.Properties.Resources.WinQ_Logo;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(92, 12);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(312, 108);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // btnAnswerQuestion
            // 
            this.btnAnswerQuestion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAnswerQuestion.Location = new System.Drawing.Point(184, 50);
            this.btnAnswerQuestion.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAnswerQuestion.Name = "btnAnswerQuestion";
            this.btnAnswerQuestion.Size = new System.Drawing.Size(114, 42);
            this.btnAnswerQuestion.TabIndex = 5;
            this.btnAnswerQuestion.Text = "Answer";
            this.btnAnswerQuestion.UseVisualStyleBackColor = true;
            this.btnAnswerQuestion.Click += new System.EventHandler(this.btnAnswerQuestion_Click);
            // 
            // PnlLogin
            // 
            this.PnlLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PnlLogin.AutoSize = true;
            this.PnlLogin.Controls.Add(this.pbLoading);
            this.PnlLogin.Controls.Add(this.txtLoginCode);
            this.PnlLogin.Controls.Add(this.pnlButton_Logout_Background);
            this.PnlLogin.Controls.Add(this.Error);
            this.PnlLogin.Location = new System.Drawing.Point(78, 140);
            this.PnlLogin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.PnlLogin.Name = "PnlLogin";
            this.PnlLogin.Size = new System.Drawing.Size(354, 192);
            this.PnlLogin.TabIndex = 4;
            // 
            // pbLoading
            // 
            this.pbLoading.BackColor = System.Drawing.Color.Transparent;
            this.pbLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbLoading.Location = new System.Drawing.Point(284, 26);
            this.pbLoading.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(64, 64);
            this.pbLoading.TabIndex = 8;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // txtLoginCode
            // 
            this.txtLoginCode.AcceptsReturn = true;
            this.txtLoginCode.Location = new System.Drawing.Point(52, 38);
            this.txtLoginCode.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtLoginCode.Name = "txtLoginCode";
            this.txtLoginCode.Size = new System.Drawing.Size(230, 31);
            this.txtLoginCode.TabIndex = 2;
            this.txtLoginCode.Text = "2222222";
            this.txtLoginCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginCode_KeyDown);
            // 
            // pnlButton_Logout_Background
            // 
            this.pnlButton_Logout_Background.BackColor = System.Drawing.Color.Transparent;
            this.pnlButton_Logout_Background.BackgroundImage = global::PetjeOp.Properties.Resources.Button_Background;
            this.pnlButton_Logout_Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlButton_Logout_Background.Controls.Add(this.label2);
            this.pnlButton_Logout_Background.Controls.Add(this.pictureBox1);
            this.pnlButton_Logout_Background.Location = new System.Drawing.Point(4, 88);
            this.pnlButton_Logout_Background.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlButton_Logout_Background.Name = "pnlButton_Logout_Background";
            this.pnlButton_Logout_Background.Size = new System.Drawing.Size(330, 80);
            this.pnlButton_Logout_Background.TabIndex = 16;
            this.pnlButton_Logout_Background.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 14F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(98)))));
            this.label2.Location = new System.Drawing.Point(122, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 46);
            this.label2.TabIndex = 14;
            this.label2.Text = "Inloggen";
            this.label2.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(60, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // Error
            // 
            this.Error.AutoSize = true;
            this.Error.ForeColor = System.Drawing.Color.DarkRed;
            this.Error.Location = new System.Drawing.Point(46, 6);
            this.Error.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(244, 25);
            this.Error.TabIndex = 5;
            this.Error.Text = "Woops.. Er ging iets mis";
            this.Error.Visible = false;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(460, 314);
            this.Controls.Add(this.btnAnswerQuestion);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.PnlLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(486, 385);
            this.MinimumSize = new System.Drawing.Size(486, 385);
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - WinQ";
            this.Load += new System.EventHandler(this.LoginView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.PnlLogin.ResumeLayout(false);
            this.PnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.pnlButton_Logout_Background.ResumeLayout(false);
            this.pnlButton_Logout_Background.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAnswerQuestion;
        private System.Windows.Forms.Panel PnlLogin;
        public System.Windows.Forms.Panel pnlButton_Logout_Background;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label Error;
        public System.Windows.Forms.TextBox txtLoginCode;
        public System.Windows.Forms.PictureBox pbLoading;
    }
}