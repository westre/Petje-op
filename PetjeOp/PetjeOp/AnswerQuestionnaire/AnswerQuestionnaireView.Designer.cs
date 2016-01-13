using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetjeOp {
    partial class AnswerQuestionnaireView {
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
            this.lblTitle_Results_Title = new System.Windows.Forms.Label();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.VraagBox = new System.Windows.Forms.CheckedListBox();
            this.viewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle_Results_Title
            // 
            this.lblTitle_Results_Title.AutoEllipsis = true;
            this.lblTitle_Results_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle_Results_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_Results_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(98)))));
            this.lblTitle_Results_Title.Location = new System.Drawing.Point(0, 0);
            this.lblTitle_Results_Title.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle_Results_Title.MinimumSize = new System.Drawing.Size(0, 100);
            this.lblTitle_Results_Title.Name = "lblTitle_Results_Title";
            this.lblTitle_Results_Title.Size = new System.Drawing.Size(788, 100);
            this.lblTitle_Results_Title.TabIndex = 4;
            this.lblTitle_Results_Title.Text = "test text";
            this.lblTitle_Results_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // viewPanel
            // 
            this.viewPanel.AutoSize = true;
            this.viewPanel.BackColor = System.Drawing.Color.Transparent;
            this.viewPanel.Controls.Add(this.VraagBox);
            this.viewPanel.Controls.Add(this.lblTitle_Results_Title);
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 0);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(788, 428);
            this.viewPanel.TabIndex = 4;
            // 
            // VraagBox
            // 
            this.VraagBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.VraagBox.CheckOnClick = true;
            this.VraagBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VraagBox.Location = new System.Drawing.Point(145, 103);
            this.VraagBox.MinimumSize = new System.Drawing.Size(500, 4);
            this.VraagBox.Name = "VraagBox";
            this.VraagBox.Size = new System.Drawing.Size(500, 249);
            this.VraagBox.TabIndex = 5;
            this.VraagBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.VraagBox_ItemCheck);
            // 
            // AnswerQuestionnaireView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewPanel);
            this.Name = "AnswerQuestionnaireView";
            this.Size = new System.Drawing.Size(788, 428);
            this.viewPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblTitle_Results_Title;
        public Panel viewPanel;

        public CheckedListBox VraagBox;
    }
}
