namespace PetjeOp {
    partial class ExamOverviewTeacherView {
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
            this.clnExams = new Calendar.NET.Calendar();
            this.lblExams = new System.Windows.Forms.Label();
            this.btnAddExam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clnExams
            // 
            this.clnExams.AllowEditingEvents = true;
            this.clnExams.CalendarDate = new System.DateTime(2016, 1, 5, 19, 51, 3, 51);
            this.clnExams.CalendarView = Calendar.NET.CalendarViews.Month;
            this.clnExams.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.clnExams.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.clnExams.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.clnExams.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.clnExams.DimDisabledEvents = true;
            this.clnExams.HighlightCurrentDay = true;
            this.clnExams.LoadPresetHolidays = false;
            this.clnExams.Location = new System.Drawing.Point(0, 71);
            this.clnExams.Margin = new System.Windows.Forms.Padding(6);
            this.clnExams.Name = "clnExams";
            this.clnExams.ShowArrowControls = true;
            this.clnExams.ShowDashedBorderOnDisabledEvents = true;
            this.clnExams.ShowDateInHeader = true;
            this.clnExams.ShowDisabledEvents = false;
            this.clnExams.ShowEventTooltips = true;
            this.clnExams.ShowTodayButton = true;
            this.clnExams.Size = new System.Drawing.Size(2242, 1134);
            this.clnExams.TabIndex = 0;
            this.clnExams.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // lblExams
            // 
            this.lblExams.AutoSize = true;
            this.lblExams.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExams.Location = new System.Drawing.Point(0, 0);
            this.lblExams.Name = "lblExams";
            this.lblExams.Size = new System.Drawing.Size(418, 55);
            this.lblExams.TabIndex = 1;
            this.lblExams.Text = "Afnamemomenten";
            // 
            // btnAddExam
            // 
            this.btnAddExam.Location = new System.Drawing.Point(20, 1214);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(335, 75);
            this.btnAddExam.TabIndex = 3;
            this.btnAddExam.Text = "Afnamemoment Toevoegen";
            this.btnAddExam.UseVisualStyleBackColor = true;
            // 
            // ExamOverviewTeacherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddExam);
            this.Controls.Add(this.lblExams);
            this.Controls.Add(this.clnExams);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ExamOverviewTeacherView";
            this.Size = new System.Drawing.Size(2231, 1564);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Calendar.NET.Calendar clnExams;
        private System.Windows.Forms.Label lblExams;
        private System.Windows.Forms.Button btnAddExam;
    }
}