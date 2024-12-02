using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_RAD
{
    public partial class TaskDetailsForm : Form
    {
        private TextBox txtDescription;
        private ComboBox cboCategory;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cboStatus;
        private Button btnSave;
        private string connectionString = "Data Source= LAPTOPD\\SQLEXPRESS; Initial Catalog= ToDoTasks; Integrated Security = True"; //Deepanshi
        //Niriya
        //Simran 
        
        public TaskItem Task { get; private set; }


        public TaskDetailsForm()
        {
            InitializeComponents();
            LoadCategories();
        }
        private void InitializeComponents()
        {
            // Form properties
            this.Text = "Add New Task";
            this.Size = new System.Drawing.Size(450, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(2, 14, 53); // Correct background color

            // Font for all controls
            Font controlFont = new Font("Arial", 10, FontStyle.Regular);
            Font headingFont = new Font("Arial", 11, FontStyle.Bold);

            // Label and TextBox for Description
            var lblDescription = new Label
            {
                Text = "Description:",
                Location = new System.Drawing.Point(25, 30),
                AutoSize = true,
                Font = headingFont,
                ForeColor = Color.White // Foreground color set to white
            };
            this.Controls.Add(lblDescription);

            txtDescription = new TextBox
            {
                Location = new System.Drawing.Point(150, 30),
                Width = 250,
                Font = controlFont,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };
            this.Controls.Add(txtDescription);

            // Label and ComboBox for Category
            var lblCategory = new Label
            {
                Text = "Category:",
                Location = new System.Drawing.Point(30, 80),
                AutoSize = true,
                Font = headingFont,
                ForeColor = Color.White // Foreground color set to white
            };
            this.Controls.Add(lblCategory);

            cboCategory = new ComboBox
            {
                Location = new System.Drawing.Point(150, 80),
                Width = 250,
                Font = controlFont,
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
           // cboCategory.Items.AddRange(new[] { "Work", "Personal", "Health", "Education", "Other" });
            this.Controls.Add(cboCategory);

            // Label and DateTimePicker for Start Date
            var lblStartDate = new Label
            {
                Text = "Start Date:",
                Location = new System.Drawing.Point(30, 130),
                AutoSize = true,
                Font = headingFont,
                ForeColor = Color.White // Foreground color set to white
            };
            this.Controls.Add(lblStartDate);

            dtpStartDate = new DateTimePicker
            {
                Location = new System.Drawing.Point(150, 130),
                Width = 250,
                Font = controlFont,
                Format = DateTimePickerFormat.Short,
                CalendarTitleBackColor = Color.SteelBlue,
                BackColor = Color.White
            };
            this.Controls.Add(dtpStartDate);

            // Label and DateTimePicker for End Date
            var lblEndDate = new Label
            {
                Text = "End Date:",
                Location = new System.Drawing.Point(30, 180),
                AutoSize = true,
                Font = headingFont,
                ForeColor = Color.White // Foreground color set to white
            };
            this.Controls.Add(lblEndDate);

            dtpEndDate = new DateTimePicker
            {
                Location = new System.Drawing.Point(150, 180),
                Width = 250,
                Font = controlFont,
                Format = DateTimePickerFormat.Short,
                CalendarTitleBackColor = Color.SteelBlue,
                BackColor = Color.White
            };
            this.Controls.Add(dtpEndDate);

            // Label and ComboBox for Status
            var lblStatus = new Label
            {
                Text = "Status:",
                Location = new System.Drawing.Point(30, 230),
                AutoSize = true,
                Font = headingFont,
                ForeColor = Color.White // Foreground color set to white
            };
            this.Controls.Add(lblStatus);

            cboStatus = new ComboBox
            {
                Location = new System.Drawing.Point(150, 230),
                Width = 250,
                Font = controlFont,
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            cboStatus.Items.AddRange(new[] { "Pending", "Completed" });
            this.Controls.Add(cboStatus);

            // Save Button
            btnSave = new Button
            {
                Text = "Save",
                Location = new System.Drawing.Point(330, 280),
                Width = 70,
                Height = 30,
                Font = controlFont,
                BackColor = Color.FromArgb(255, 130, 163), // Color for heading applied
                ForeColor = Color.White, // Button text color set to white
                FlatStyle = FlatStyle.Flat
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Category FROM CategoryTable"; // Assuming Categories is the table storing categories
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cboCategory.Items.Add(reader["Category"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }
        //For update
        public TaskDetailsForm(TaskItem task) : this() // Calls the default constructor
        {
            this.Text = "Edit Task"; // Update title for editing
            btnSave.Text = "Update"; // Change button text

            // Populate fields with the existing task data
            txtDescription.Text = task.Description;
            cboCategory.SelectedItem = task.Category;
            dtpStartDate.Value = task.StartDate;
            dtpEndDate.Value = task.EndDate;
            cboStatus.SelectedItem = task.Status;

            // Store the task being edited
            Task = task;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            string description = txtDescription.Text;
            string category = cboCategory.SelectedItem?.ToString();
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            string status = cboStatus.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update existing task or create a new one
            if (Task != null)
            {
                // Update the existing task
                Task.Description = description;
                Task.Category = category;
                Task.StartDate = startDate;
                Task.EndDate = endDate;
                Task.Status = status;
            }
            else
            {
                // Create a new task
                Task = new TaskItem
                {
                    Description = description,
                    Category = category,
                    StartDate = startDate,
                    EndDate = endDate,
                    Status = status
                };
            }

            DialogResult = DialogResult.OK; // Signal successful save/update
            this.Close();
        }
    }
}
