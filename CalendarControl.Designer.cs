namespace FinalProject_RAD
{
    partial class CalendarControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarControl));
            btnPrevMonth = new Button();
            btnNextMonth = new Button();
            txtMonthYear = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            SuspendLayout();
            // 
            // btnPrevMonth
            // 
            btnPrevMonth.BackColor = Color.FromArgb(2, 14, 53);
            btnPrevMonth.FlatAppearance.BorderSize = 0;
            btnPrevMonth.FlatStyle = FlatStyle.Flat;
            btnPrevMonth.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrevMonth.ForeColor = Color.FromArgb(255, 130, 163);
            btnPrevMonth.Image = (Image)resources.GetObject("btnPrevMonth.Image");
            btnPrevMonth.Location = new Point(0, 0);
            btnPrevMonth.Name = "btnPrevMonth";
            btnPrevMonth.Size = new Size(50, 50);
            btnPrevMonth.TabIndex = 0;
            btnPrevMonth.UseVisualStyleBackColor = false;
            btnPrevMonth.Click += btnPrevMonth_Click;
            // 
            // btnNextMonth
            // 
            btnNextMonth.BackColor = Color.FromArgb(2, 14, 53);
            btnNextMonth.FlatAppearance.BorderSize = 0;
            btnNextMonth.FlatStyle = FlatStyle.Flat;
            btnNextMonth.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextMonth.ForeColor = Color.FromArgb(255, 130, 163);
            btnNextMonth.Image = (Image)resources.GetObject("btnNextMonth.Image");
            btnNextMonth.Location = new Point(350, 0);
            btnNextMonth.Name = "btnNextMonth";
            btnNextMonth.Size = new Size(50, 50);
            btnNextMonth.TabIndex = 1;
            btnNextMonth.UseVisualStyleBackColor = false;
            btnNextMonth.Click += btnNextMonth_Click;
            // 
            // txtMonthYear
            // 
            txtMonthYear.BackColor = Color.FromArgb(2, 14, 53);
            txtMonthYear.BorderStyle = BorderStyle.None;
            txtMonthYear.CausesValidation = false;
            txtMonthYear.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMonthYear.ForeColor = Color.FromArgb(255, 130, 163);
            txtMonthYear.Location = new Point(54, 9);
            txtMonthYear.Name = "txtMonthYear";
            txtMonthYear.Size = new Size(294, 31);
            txtMonthYear.TabIndex = 2;
            txtMonthYear.TextAlign = HorizontalAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(2, 14, 53);
            tableLayoutPanel1.CausesValidation = false;
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ForeColor = Color.White;
            tableLayoutPanel1.Location = new Point(20, 56);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.Size = new Size(380, 380);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // CalendarControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(txtMonthYear);
            Controls.Add(btnNextMonth);
            Controls.Add(btnPrevMonth);
            Name = "CalendarControl";
            Size = new Size(400, 450);
            Load += CalendarControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrevMonth;
        private Button btnNextMonth;
        private TextBox txtMonthYear;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
