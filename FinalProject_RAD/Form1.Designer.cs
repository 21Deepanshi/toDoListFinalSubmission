namespace FinalProject_RAD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            btnSearch = new Button();
            panel3 = new Panel();
            label1 = new Label();
            btnClose = new Button();
            button1 = new Button();
            btnMaximize = new Button();
            btnMinimize = new Button();
            calendarControl1 = new CalendarControl();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            lblAll = new Label();
            lblPending = new Label();
            lblCompleted = new Label();
            lblManageSetting = new Label();
            bindingSource1 = new BindingSource(components);
            btnDeleteTask = new Button();
            btnAddTask = new Button();
            toolStrip1 = new ToolStrip();
            toolStripLabel3 = new ToolStripLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(255, 130, 163);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnMaximize);
            panel1.Controls.Add(btnMinimize);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1370, 51);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.AutoSize = true;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Image = Properties.Resources._5402443_search_find_magnifier_magnifying_magnifying_glass_icon1;
            btnSearch.ImageAlign = ContentAlignment.MiddleLeft;
            btnSearch.Location = new Point(880, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(300, 38);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search item...";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.AutoSize = true;
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel3.Location = new Point(885, 40);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 4);
            panel3.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(49, 9);
            label1.Name = "label1";
            label1.Size = new Size(91, 31);
            label1.TabIndex = 2;
            label1.Text = "To - Do";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.AutoSize = true;
            btnClose.BackColor = Color.FromArgb(255, 130, 163);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = Properties.Resources._9104213_close_cross_remove_delete_icon__1_;
            btnClose.Location = new Point(1316, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(51, 48);
            btnClose.TabIndex = 4;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = Color.FromArgb(255, 130, 163);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources._8665744_list_check_icon;
            button1.Location = new Point(1, 1);
            button1.Name = "button1";
            button1.Size = new Size(51, 48);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = false;
            // 
            // btnMaximize
            // 
            btnMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximize.AutoSize = true;
            btnMaximize.BackColor = Color.FromArgb(255, 130, 163);
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.ForeColor = Color.White;
            btnMaximize.Image = Properties.Resources._326558_blank_check_box_icon__2_;
            btnMaximize.Location = new Point(1270, 2);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(51, 48);
            btnMaximize.TabIndex = 1;
            btnMaximize.UseVisualStyleBackColor = false;
            btnMaximize.Click += btnMaximize_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.AutoSize = true;
            btnMinimize.BackColor = Color.FromArgb(255, 130, 163);
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Image = Properties.Resources._211863_minus_round_icon;
            btnMinimize.Location = new Point(1219, 2);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(51, 48);
            btnMinimize.TabIndex = 3;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // calendarControl1
            // 
            calendarControl1.AutoSize = true;
            calendarControl1.Location = new Point(3, 55);
            calendarControl1.Name = "calendarControl1";
            calendarControl1.Size = new Size(403, 453);
            calendarControl1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Silver;
            panel2.Location = new Point(412, 121);
            panel2.Name = "panel2";
            panel2.Size = new Size(1, 600);
            panel2.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(2, 14, 53);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = Color.FromArgb(2, 14, 53);
            dataGridView1.Location = new Point(424, 121);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(939, 627);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // lblAll
            // 
            lblAll.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAll.ForeColor = SystemColors.Control;
            lblAll.Image = Properties.Resources._8664801_calendar_icon1;
            lblAll.ImageAlign = ContentAlignment.MiddleLeft;
            lblAll.Location = new Point(12, 511);
            lblAll.Name = "lblAll";
            lblAll.Size = new Size(394, 52);
            lblAll.TabIndex = 8;
            lblAll.Text = "All";
            lblAll.TextAlign = ContentAlignment.MiddleCenter;
            lblAll.Click += lblAll_Click;
            // 
            // lblPending
            // 
            lblPending.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPending.ForeColor = SystemColors.Control;
            lblPending.Image = Properties.Resources._11121107_fi_rr_calendar_exclamation_icon;
            lblPending.ImageAlign = ContentAlignment.MiddleLeft;
            lblPending.Location = new Point(12, 569);
            lblPending.Name = "lblPending";
            lblPending.Size = new Size(394, 52);
            lblPending.TabIndex = 9;
            lblPending.Text = "Pending";
            lblPending.TextAlign = ContentAlignment.MiddleCenter;
            lblPending.Click += lblPending_Click;
            // 
            // lblCompleted
            // 
            lblCompleted.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompleted.ForeColor = SystemColors.Control;
            lblCompleted.Image = Properties.Resources._8665744_list_check_icon;
            lblCompleted.ImageAlign = ContentAlignment.MiddleLeft;
            lblCompleted.Location = new Point(12, 628);
            lblCompleted.Name = "lblCompleted";
            lblCompleted.Size = new Size(394, 52);
            lblCompleted.TabIndex = 10;
            lblCompleted.Text = "Completed";
            lblCompleted.TextAlign = ContentAlignment.MiddleCenter;
            lblCompleted.Click += lblCompleted_Click;
            // 
            // lblManageSetting
            // 
            lblManageSetting.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManageSetting.ForeColor = SystemColors.Control;
            lblManageSetting.Image = Properties.Resources._8679946_settings_fill_icon;
            lblManageSetting.ImageAlign = ContentAlignment.MiddleLeft;
            lblManageSetting.Location = new Point(12, 688);
            lblManageSetting.Name = "lblManageSetting";
            lblManageSetting.Size = new Size(394, 52);
            lblManageSetting.TabIndex = 11;
            lblManageSetting.Text = "Manage Setting";
            lblManageSetting.TextAlign = ContentAlignment.MiddleCenter;
            lblManageSetting.Click += lblManageSetting_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteTask.FlatStyle = FlatStyle.Flat;
            btnDeleteTask.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteTask.ForeColor = Color.White;
            btnDeleteTask.Location = new Point(1179, 57);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(188, 46);
            btnDeleteTask.TabIndex = 12;
            btnDeleteTask.Text = "Delete Selected?";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // btnAddTask
            // 
            btnAddTask.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddTask.BackColor = Color.FromArgb(255, 130, 163);
            btnAddTask.FlatAppearance.BorderSize = 0;
            btnAddTask.FlatStyle = FlatStyle.Flat;
            btnAddTask.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTask.ForeColor = Color.White;
            btnAddTask.Location = new Point(1067, 57);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(103, 46);
            btnAddTask.TabIndex = 13;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = false;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(2, 14, 53);
            toolStrip1.BackgroundImageLayout = ImageLayout.None;
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStrip1.GripMargin = new Padding(0);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel3 });
            toolStrip1.Location = new Point(424, 57);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0);
            toolStrip1.Size = new Size(41, 25);
            toolStrip1.TabIndex = 14;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(0, 22);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 14, 53);
            ClientSize = new Size(1370, 760);
            Controls.Add(toolStrip1);
            Controls.Add(btnAddTask);
            Controls.Add(btnDeleteTask);
            Controls.Add(lblManageSetting);
            Controls.Add(lblCompleted);
            Controls.Add(lblPending);
            Controls.Add(lblAll);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(calendarControl1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "To-do List";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label1;
        private Button btnMinimize;
        private Button btnMaximize;
        private Button btnClose;
        private CalendarControl calendarControl1;
        private Panel panel2;
        private Panel panel3;
        private Button btnSearch;
        private DataGridView dataGridView1;
        private Label lblAll;
        private Label lblPending;
        private Label lblCompleted;
        private Label lblManageSetting;
        private BindingSource bindingSource1;
        private Button btnDeleteTask;
        private Button btnAddTask;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel3;
    }
}
