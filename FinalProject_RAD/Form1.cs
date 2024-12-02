using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FinalProject_RAD
{
    public partial class Form1 : Form
    {
        private BindingList<TaskItem> tasks = new BindingList<TaskItem>();
        private DatabaseManager databaseManager;
        //private string connectionString = "Data Source=DELLNIRIYA\\SQLEXPRESS; Initial Catalog= ToDoTasks; Integrated Security=True"; //Niriya
        private string connectionString = "Data Source= LAPTOPD\\SQLEXPRESS; Initial Catalog=ToDoTasks; Integrated Security=True"; //Deepanshi
        private TextBox txtSearch;

        public Form1()
        {
            InitializeComponent();
            databaseManager = new DatabaseManager();
            tasks = new BindingList<TaskItem>(databaseManager.GetTasks());
            InitializeTasks();
            DisplayTasks("All");
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void AddCheckBoxColumn()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Select",
                Name = "Select",
                Width = 40
            };
            dataGridView1.Columns.Insert(0, checkBoxColumn);
        }

        private void CustomizeDataGridView()
        {
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].Width = 225;
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[3].Width = 140;
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.Columns[5].Width = 160;

            // Hide the Id column (assuming the Id column is at index 0)
            dataGridView1.Columns["Id"].Visible = true;

            // Set background and font colors
            dataGridView1.BackgroundColor = Color.FromArgb(2, 14, 53);
            dataGridView1.ForeColor = Color.White;  // White text

            dataGridView1.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);

            // Adjust row heights dynamically
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 55;
            }

            // Handle new rows dynamically
            dataGridView1.RowsAdded += (sender, e) =>
            {
                for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
                {
                    dataGridView1.Rows[i].Height = 55;
                }
            };

            // Row styles
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(2, 14, 53);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10F);

            // Alternating row styles (lighter for contrast)
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(2, 14, 53);
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            // Column headers styling
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(2, 14, 53);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);

            // Remove grid lines (optional)
            //dataGridView1.GridColor = Color.FromArgb(51, 50, 100);
            dataGridView1.EnableHeadersVisualStyles = false;
        }


        //added for testing the task
        private void InitializeTasks()
        {
            // Bind tasks to DataGridView
            dataGridView1.DataSource = tasks;
        }

        private void DisplayTasks(string filter)
        {
            if (filter == "All")
            {
                // Show all tasks
                dataGridView1.DataSource = tasks;
            }
            else
            {
                // Filter tasks and update DataGridView
                var filteredTasks = new BindingList<TaskItem>(tasks.Where(t => t.Status == filter).ToList());
                dataGridView1.DataSource = filteredTasks;
            }
        }
        private void HighlightLabel(Control clickedLabel)
        {
            // Reset all label colors
            lblAll.BackColor = Color.FromArgb(2, 14, 53);
            lblPending.BackColor = Color.FromArgb(2, 14, 53);
            lblCompleted.BackColor = Color.FromArgb(2, 14, 53);
            lblManageSetting.BackColor = Color.FromArgb(2, 14, 53);

            //Fore color
            lblAll.ForeColor = Color.White;
            lblPending.ForeColor = Color.White;
            lblCompleted.ForeColor = Color.White;
            lblManageSetting.ForeColor = Color.White;

            // Highlight the clicked label
            clickedLabel.BackColor = Color.FromArgb(255, 130, 163);
            clickedLabel.ForeColor = Color.Black;
        }
        private void InitializeSearchComponents()
        {
            btnSearch = new Button
            {
                Text = "Search",
                Location = new Point(882, 7),
                Size = new Size(80, 25)
            };
            btnSearch.Click += btnSearch_Click;
            Controls.Add(btnSearch);
        }
        private void calendarControl1_Load(object sender, EventArgs e)
        {

        }

        private void calendarControl1_Load_1(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblAll_Click(object sender, EventArgs e)
        {
            HighlightLabel(lblAll);
            DisplayTasks("All");
        }

        private void lblPending_Click(object sender, EventArgs e)
        {
            HighlightLabel(lblPending);
            DisplayTasks("Pending");
        }

        private void lblCompleted_Click(object sender, EventArgs e)
        {
            HighlightLabel(lblCompleted);
            DisplayTasks("Completed");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                TaskItem selectedTask = tasks[e.RowIndex]; // Get the selected task

                // Open TaskDetailsForm for editing
                using (TaskDetailsForm taskDetailsForm = new TaskDetailsForm(selectedTask))
                {
                    if (taskDetailsForm.ShowDialog() == DialogResult.OK)
                    {
                        // Update task in the database
                        databaseManager.UpdateTask(selectedTask);

                        // Refresh the task list
                        RefreshTaskList();
                    }
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeSearchComponents(); // Add the search controls
            lblAll.BackColor = Color.FromArgb(255, 130, 163);
            lblAll.ForeColor = Color.Black;

            DisplayTasks("All");
            CustomizeDataGridView();
            AddCheckBoxColumn();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void lblManageSetting_Click(object sender, EventArgs e)
        {
            HighlightLabel(lblManageSetting);
            DisplayTasks("Manage Setting");
            FormManageCategories manageCategories = new FormManageCategories();

            manageCategories.StartPosition = FormStartPosition.CenterScreen;
            manageCategories.Size = new Size(800, 400);

            manageCategories.Show();
        }
        public void AddTask(TaskItem task)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Tasks (Description, Category, StartDate, EndDate, Status) " +
                                   "VALUES (@Description, @Category, @StartDate, @EndDate, @Status)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Description", task.Description);
                    command.Parameters.AddWithValue("@Category", task.Category);
                    command.Parameters.AddWithValue("@StartDate", task.StartDate);
                    command.Parameters.AddWithValue("@EndDate", task.EndDate);
                    command.Parameters.AddWithValue("@Status", task.Status);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if rows were affected
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No rows were affected. Task not added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the task: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DeleteTask(int taskId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Tasks WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", taskId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    // Debugging to verify rows are being affected
                    Console.WriteLine($"Rows affected by delete query: {rowsAffected}");

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("No rows were deleted. Task with specified ID may not exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting task: {ex.Message}");
                throw;
            }
        }

        private void RefreshTaskList()
        {
            tasks = new BindingList<TaskItem>(databaseManager.GetTasks());
            dataGridView1.DataSource = tasks;
        }
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            //AddTask();
            using (TaskDetailsForm taskDetailsForm = new TaskDetailsForm())
            {
                if (taskDetailsForm.ShowDialog() == DialogResult.OK)
                {
                    TaskItem newTask = taskDetailsForm.Task;
                    databaseManager.AddTask(newTask);
                    RefreshTaskList();
                    MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.CurrentRow; // Get the current row
            if (selectedRow != null)
            {
                var taskItem = selectedRow.DataBoundItem as TaskItem;
                if (taskItem != null)
                {
                    // Proceed with deleting the task
                    databaseManager.DeleteTask(taskItem.Id);
                    tasks.Remove(taskItem);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = tasks;
                    dataGridView1.Refresh();

                    MessageBox.Show("Task deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Check if the TextBox already exists
            if (txtSearch == null)
            {
                // Dynamically create the TextBox
                txtSearch = new TextBox
                {
                    Location = new Point(btnSearch.Location.X + +btnSearch.Height + 5, btnSearch.Location.Y), // Place it next to the button
                    Size = new Size(200, 25),
                    PlaceholderText = "Search tasks..."
                };

                // Add an event to search on pressing Enter
                txtSearch.KeyDown += TxtSearch_KeyDown;

                Controls.Add(txtSearch);
                txtSearch.BringToFront(); // Ensure the TextBox is visible
                txtSearch.Focus(); // Set focus to the TextBox
            }
            else
            {
                // If the TextBox already exists, perform the search
                PerformSearch();
            }
        }
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
                e.Handled = true; // Prevent default behavior
                e.SuppressKeyPress = true; // Prevent ding sound
            }
        }

        private void PerformSearch()
        {
            if (txtSearch == null) return;

            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // If the search term is empty, display all tasks
                dataGridView1.DataSource = tasks;
            }
            else
            {
                // Filter the tasks based on the search term
                var filteredTasks = tasks.Where(task =>
                    task.Description.ToLower().Contains(searchTerm) ||
                    task.Category.ToLower().Contains(searchTerm) ||
                    task.Status.ToLower().Contains(searchTerm)).ToList();

                // Update the DataGridView with the filtered list
                dataGridView1.DataSource = new BindingList<TaskItem>(filteredTasks);
            }
        }
    }
}
