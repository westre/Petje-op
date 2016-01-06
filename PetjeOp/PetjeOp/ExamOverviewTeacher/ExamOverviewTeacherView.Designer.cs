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
            this.SuspendLayout();
            // 
            // clnExams
            // 
            this.clnExams.AllowEditingEvents = false;
            this.clnExams.CalendarDate = new System.DateTime(2016, 1, 5, 19, 51, 3, 51);
            this.clnExams.CalendarView = Calendar.NET.CalendarViews.Month;
            this.clnExams.DateHeaderFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.clnExams.DayOfWeekFont = new System.Drawing.Font("Arial", 10F);
            this.clnExams.DaysFont = new System.Drawing.Font("Arial", 10F);
            this.clnExams.DayViewTimeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.clnExams.DimDisabledEvents = true;
            this.clnExams.HighlightCurrentDay = true;
            this.clnExams.LoadPresetHolidays = false;
            this.clnExams.Location = new System.Drawing.Point(0, 0);
            this.clnExams.Name = "clnExams";
            this.clnExams.ShowArrowControls = true;
            this.clnExams.ShowDashedBorderOnDisabledEvents = true;
            this.clnExams.ShowDateInHeader = true;
            this.clnExams.ShowDisabledEvents = false;
            this.clnExams.ShowEventTooltips = true;
            this.clnExams.ShowTodayButton = true;
            this.clnExams.Size = new System.Drawing.Size(1178, 674);
            this.clnExams.TabIndex = 0;
            this.clnExams.TodayFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            // 
            // ExamOverviewTeacherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clnExams);
            this.Name = "ExamOverviewTeacherView";
            this.Size = new System.Drawing.Size(1181, 674);
            this.ResumeLayout(false);

        }

        #endregion

        public Calendar.NET.Calendar clnExams;
    }
}