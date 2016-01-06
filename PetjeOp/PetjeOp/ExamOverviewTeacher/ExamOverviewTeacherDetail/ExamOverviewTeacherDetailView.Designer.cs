namespace PetjeOp.ExamOverviewTeacher.ExamOverviewTeacherDetail {
    partial class ExamOverviewTeacherDetailView {
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
            this.lblStarttime = new System.Windows.Forms.Label();
            this.lblEndtime = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblPlannedInBy = new System.Windows.Forms.Label();
            this.lblExecutedBy = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStarttime
            // 
            this.lblStarttime.AutoSize = true;
            this.lblStarttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStarttime.Location = new System.Drawing.Point(-4, 58);
            this.lblStarttime.Name = "lblStarttime";
            this.lblStarttime.Size = new System.Drawing.Size(65, 18);
            this.lblStarttime.TabIndex = 0;
            this.lblStarttime.Text = "Start tijd:";
            // 
            // lblEndtime
            // 
            this.lblEndtime.AutoSize = true;
            this.lblEndtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndtime.Location = new System.Drawing.Point(-4, 86);
            this.lblEndtime.Name = "lblEndtime";
            this.lblEndtime.Size = new System.Drawing.Size(63, 18);
            this.lblEndtime.TabIndex = 1;
            this.lblEndtime.Text = "Eind tijd:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(-3, 29);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(64, 18);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Looptijd:";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(-3, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(41, 18);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "Vak: ";
            this.lblSubject.Click += new System.EventHandler(this.lblSubject_Click);
            // 
            // lblPlannedInBy
            // 
            this.lblPlannedInBy.AutoSize = true;
            this.lblPlannedInBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlannedInBy.Location = new System.Drawing.Point(-4, 114);
            this.lblPlannedInBy.Name = "lblPlannedInBy";
            this.lblPlannedInBy.Size = new System.Drawing.Size(105, 18);
            this.lblPlannedInBy.TabIndex = 4;
            this.lblPlannedInBy.Text = "Ingepland door";
            // 
            // lblExecutedBy
            // 
            this.lblExecutedBy.AutoSize = true;
            this.lblExecutedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExecutedBy.Location = new System.Drawing.Point(-4, 143);
            this.lblExecutedBy.Name = "lblExecutedBy";
            this.lblExecutedBy.Size = new System.Drawing.Size(162, 18);
            this.lblExecutedBy.TabIndex = 5;
            this.lblExecutedBy.Text = "Wordt afgenomen door";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(200, 253);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Wijzig";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(281, 253);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Verwijder";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // ExamOverviewTeacherDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblExecutedBy);
            this.Controls.Add(this.lblPlannedInBy);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblEndtime);
            this.Controls.Add(this.lblStarttime);
            this.Name = "ExamOverviewTeacherDetailView";
            this.Size = new System.Drawing.Size(360, 279);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblStarttime;
        public System.Windows.Forms.Label lblEndtime;
        public System.Windows.Forms.Label lblDuration;
        public System.Windows.Forms.Label lblSubject;
        public System.Windows.Forms.Label lblPlannedInBy;
        public System.Windows.Forms.Label lblExecutedBy;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnRemove;
    }
}
