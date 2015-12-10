using System.Windows.Forms;

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
        private void InitializeComponent()
        {
            this.btnVraagOverzicht = new System.Windows.Forms.Button();
            this.btnAnswerQuestion = new System.Windows.Forms.Button();
            this.btnStudentLogin = new System.Windows.Forms.Button();
            this.btnLoginTeacher = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.Error = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle_Logout_Title = new System.Windows.Forms.Label();
            this.pbIcon_Logout_Icon = new System.Windows.Forms.PictureBox();
            this.pnlButton_Agenda_Background = new System.Windows.Forms.Panel();
            this.pbIcon_Agenda_Icon = new System.Windows.Forms.PictureBox();
            this.lblTitle_Agenda_Title = new System.Windows.Forms.Label();
            this.pnlButton_Result_Background = new System.Windows.Forms.Panel();
            this.pbIcon_Results_Icon = new System.Windows.Forms.PictureBox();
            this.lblTitle_Results_Title = new System.Windows.Forms.Label();
            this.pnlButton_QuestionnaireOverview_Background = new System.Windows.Forms.Panel();
            this.pbIcon_QuestionnaireOverview_Icon = new System.Windows.Forms.PictureBox();
            this.lblTitle_QuestionnaireOverview_Title = new System.Windows.Forms.Label();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.PnlLogin = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Logout_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Agenda_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Results_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_QuestionnaireOverview_Icon)).BeginInit();
            this.viewPanel.SuspendLayout();
            this.PnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btnVraagOverzicht.Location = new System.Drawing.Point(41, 200);
            this.btnVraagOverzicht.Name = "btnStudentLogin";
            this.btnVraagOverzicht.Size = new System.Drawing.Size(115, 31);
            this.btnVraagOverzicht.TabIndex = 0;
            this.btnVraagOverzicht.Text = "vraag";
            this.btnVraagOverzicht.UseVisualStyleBackColor = true;
            this.btnVraagOverzicht.Click += new System.EventHandler(this.btnStudentLogin_Click);
            // 
            // btnStudentLogin
            // 
            this.btnStudentLogin.Location = new System.Drawing.Point(41, 23);
            this.btnStudentLogin.Name = "btnStudentLogin";
            this.btnStudentLogin.Size = new System.Drawing.Size(115, 31);
            this.btnStudentLogin.TabIndex = 0;
            this.btnStudentLogin.Text = "Inloggen als student";
            this.btnStudentLogin.UseVisualStyleBackColor = true;
            this.btnStudentLogin.Click += new System.EventHandler(this.btnStudentLogin_Click);
            // 
            // btnLoginTeacher
            // 
            this.btnLoginTeacher.Location = new System.Drawing.Point(41, 89);
            this.btnLoginTeacher.Name = "btnLoginTeacher";
            this.btnLoginTeacher.Size = new System.Drawing.Size(115, 39);
            this.btnLoginTeacher.TabIndex = 1;
            this.btnLoginTeacher.Text = "Inloggen als teacher";
            this.btnLoginTeacher.UseVisualStyleBackColor = true;
            this.btnLoginTeacher.Click += new System.EventHandler(this.btnLoginTeacher_Click);
            // 
            // btnAnswerQuestion
            // 
            this.btnAnswerQuestion.Location = new System.Drawing.Point(41, 300);
            this.btnAnswerQuestion.Name = "btnLoginTeacher";
            this.btnAnswerQuestion.Size = new System.Drawing.Size(115, 39);
            this.btnAnswerQuestion.TabIndex = 1;
            this.btnAnswerQuestion.Text = "Answer Questionnaire";
            this.btnAnswerQuestion.UseVisualStyleBackColor = true;
            this.btnAnswerQuestion.Click += new System.EventHandler(this.btnAnswerQuestion_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inlog Code:";
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(65, 64);
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
            this.Error.Location = new System.Drawing.Point(175, 41);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(120, 13);
            this.Error.TabIndex = 5;
            this.Error.Text = "Woops.. Er ging iets mis";
            this.Error.Visible = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.AutoSize = true;
            this.pnlHeader.BackgroundImage = global::PetjeOp.Properties.Resources.bannerBackground;
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlHeader.Controls.Add(this.pbLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1184, 59);
            this.pnlHeader.TabIndex = 2;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImage = global::PetjeOp.Properties.Resources.WinQ_Logo;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLogo.Location = new System.Drawing.Point(8, 7);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(150, 50);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblTitle_Logout_Title
            // 
            this.lblTitle_Logout_Title.Location = new System.Drawing.Point(0, 0);
            this.lblTitle_Logout_Title.Name = "lblTitle_Logout_Title";
            this.lblTitle_Logout_Title.Size = new System.Drawing.Size(100, 23);
            this.lblTitle_Logout_Title.TabIndex = 0;
            // 
            // pbIcon_Logout_Icon
            // 
            this.pbIcon_Logout_Icon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon_Logout_Icon.Name = "pbIcon_Logout_Icon";
            this.pbIcon_Logout_Icon.Size = new System.Drawing.Size(100, 50);
            this.pbIcon_Logout_Icon.TabIndex = 0;
            this.pbIcon_Logout_Icon.TabStop = false;
            // 
            // pnlButton_Agenda_Background
            // 
            this.pnlButton_Agenda_Background.Location = new System.Drawing.Point(0, 0);
            this.pnlButton_Agenda_Background.Name = "pnlButton_Agenda_Background";
            this.pnlButton_Agenda_Background.Size = new System.Drawing.Size(200, 100);
            this.pnlButton_Agenda_Background.TabIndex = 0;
            // 
            // pbIcon_Agenda_Icon
            // 
            this.pbIcon_Agenda_Icon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon_Agenda_Icon.Name = "pbIcon_Agenda_Icon";
            this.pbIcon_Agenda_Icon.Size = new System.Drawing.Size(100, 50);
            this.pbIcon_Agenda_Icon.TabIndex = 0;
            this.pbIcon_Agenda_Icon.TabStop = false;
            // 
            // lblTitle_Agenda_Title
            // 
            this.lblTitle_Agenda_Title.Location = new System.Drawing.Point(0, 0);
            this.lblTitle_Agenda_Title.Name = "lblTitle_Agenda_Title";
            this.lblTitle_Agenda_Title.Size = new System.Drawing.Size(100, 23);
            this.lblTitle_Agenda_Title.TabIndex = 0;
            // 
            // pnlButton_Result_Background
            // 
            this.pnlButton_Result_Background.Location = new System.Drawing.Point(0, 0);
            this.pnlButton_Result_Background.Name = "pnlButton_Result_Background";
            this.pnlButton_Result_Background.Size = new System.Drawing.Size(200, 100);
            this.pnlButton_Result_Background.TabIndex = 0;
            // 
            // pbIcon_Results_Icon
            // 
            this.pbIcon_Results_Icon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon_Results_Icon.Name = "pbIcon_Results_Icon";
            this.pbIcon_Results_Icon.Size = new System.Drawing.Size(100, 50);
            this.pbIcon_Results_Icon.TabIndex = 0;
            this.pbIcon_Results_Icon.TabStop = false;
            // 
            // lblTitle_Results_Title
            // 
            this.lblTitle_Results_Title.Location = new System.Drawing.Point(0, 0);
            this.lblTitle_Results_Title.Name = "lblTitle_Results_Title";
            this.lblTitle_Results_Title.Size = new System.Drawing.Size(100, 23);
            this.lblTitle_Results_Title.TabIndex = 0;
            // 
            // pnlButton_QuestionnaireOverview_Background
            // 
            this.pnlButton_QuestionnaireOverview_Background.Location = new System.Drawing.Point(0, 0);
            this.pnlButton_QuestionnaireOverview_Background.Name = "pnlButton_QuestionnaireOverview_Background";
            this.pnlButton_QuestionnaireOverview_Background.Size = new System.Drawing.Size(200, 100);
            this.pnlButton_QuestionnaireOverview_Background.TabIndex = 0;
            // 
            // pbIcon_QuestionnaireOverview_Icon
            // 
            this.pbIcon_QuestionnaireOverview_Icon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon_QuestionnaireOverview_Icon.Name = "pbIcon_QuestionnaireOverview_Icon";
            this.pbIcon_QuestionnaireOverview_Icon.Size = new System.Drawing.Size(100, 50);
            this.pbIcon_QuestionnaireOverview_Icon.TabIndex = 0;
            this.pbIcon_QuestionnaireOverview_Icon.TabStop = false;
            // 
            // lblTitle_QuestionnaireOverview_Title
            // 
            this.lblTitle_QuestionnaireOverview_Title.Location = new System.Drawing.Point(0, 0);
            this.lblTitle_QuestionnaireOverview_Title.Name = "lblTitle_QuestionnaireOverview_Title";
            this.lblTitle_QuestionnaireOverview_Title.Size = new System.Drawing.Size(100, 23);
            this.lblTitle_QuestionnaireOverview_Title.TabIndex = 0;
            // 
            // viewPanel
            // 
            this.viewPanel.AutoSize = true;
            this.viewPanel.Controls.Add(this.PnlLogin);
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Margin = new System.Windows.Forms.Padding(2);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Controls.Add(this.btnLoginTeacher);
            this.viewPanel.Controls.Add(this.btnVraagOverzicht);
            this.viewPanel.Controls.Add(this.btnStudentLogin);
            this.viewPanel.Controls.Add(this.btnAnswerQuestion);
            this.viewPanel.TabIndex = 4;
            this.viewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.viewPanel_Paint);
            // 
            // PnlLogin
            // 
            this.PnlLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PnlLogin.AutoSize = true;
            this.PnlLogin.Location = new System.Drawing.Point((-(PnlLogin.Width / 2) + Error.Width), 0);
            this.PnlLogin.Controls.Add(this.Error);
            this.PnlLogin.Controls.Add(this.LoginBtn);
            this.PnlLogin.Controls.Add(this.label1);
            this.PnlLogin.Controls.Add(this.textBox1);
            this.PnlLogin.Name = "PnlLogin";
            this.PnlLogin.TabIndex = 0;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.pnlHeader);
            this.Name = "LoginView";
            this.Dock = DockStyle.Fill;
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Logout_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Agenda_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Results_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_QuestionnaireOverview_Icon)).EndInit();
            this.viewPanel.ResumeLayout(false);
            this.viewPanel.PerformLayout();
            this.PnlLogin.ResumeLayout(false);
            this.PnlLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void scaleBanner()
        {
            pnlHeader.Size = new System.Drawing.Size(Controller.MasterController.Size.Width, pnlHeader.Size.Height);
        }

        #endregion
        public System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.PictureBox pbIcon_Results_Icon;
        private System.Windows.Forms.PictureBox pbIcon_QuestionnaireOverview_Icon;
        private System.Windows.Forms.PictureBox pbIcon_Agenda_Icon;
        private System.Windows.Forms.PictureBox pbIcon_Logout_Icon;
        private System.Windows.Forms.Label lblTitle_Results_Title;
        private System.Windows.Forms.Label lblTitle_QuestionnaireOverview_Title;
        private System.Windows.Forms.Panel pnlButton_Agenda_Background;
        private System.Windows.Forms.Panel pnlButton_Result_Background;
        private System.Windows.Forms.Panel pnlButton_QuestionnaireOverview_Background;
        private System.Windows.Forms.Label lblTitle_Agenda_Title;
        private System.Windows.Forms.Label lblTitle_Logout_Title;
        public Panel viewPanel;
        private System.Windows.Forms.Button btnVraagOverzicht;
        private System.Windows.Forms.Button btnStudentLogin;
        private System.Windows.Forms.Button btnLoginTeacher;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label Error;
        private Button btnAnswerQuestion;
        private Panel PnlLogin;
    }
}
