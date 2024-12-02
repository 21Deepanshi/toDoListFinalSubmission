using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalProject_RAD
{
    public partial class FormManageCategories : Form
    {
        private ListBox lstCategories;
        private string connectionString = "Data Source= LAPTOPD\\SQLEXPRESS; Initial Catalog= ToDoTasks; Integrated Security = True"; //Deepanshi
        //private string connectionString = "Data Source=DELLNIRIYA\\SQLEXPRESS; Initial Catalog= ToDoTasks; Integrated Security=True"; //Niriya
       // private string connectionString = "Data Source= LAPTOP-87I00F5J\SQLEXPRESS01; Initial Catalog=ToDoTasks; Integrated Security=True"; //Simranjot Kaur
        private Form1 mainForm;
        public FormManageCategories(Form1 form1)
        {
            InitializeComponent();
            SetupForm();
            mainForm = form1;
        }

        private void SetupForm()
        {
            // Set form properties
            this.BackColor = Color.FromArgb(34, 33, 75);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = 400;
            this.Height = 300;

            // Add header panel
            Panel headerPanel = new Panel
            {
                BackColor = Color.FromArgb(255, 130, 163), 
                Dock = DockStyle.Top,
                Height = 50
            };
            this.Controls.Add(headerPanel);

            // Add header label
            Label lblTitle = new Label
            {
                Text = "Manage Categories",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };
            headerPanel.Controls.Add(lblTitle);

            // Add close button
            Button btnClose = new Button
            {
                Text = "X",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Width = 30,
                Height = 30,
                Dock = DockStyle.Right
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();
            headerPanel.Controls.Add(btnClose);

            // Add Add and Delete buttons
            Button btnAddCategory = new Button
            {
                Text = "Add Category",
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.FromArgb(255, 130, 163),
                Width = 180,
                Height = 40,
                Location = new Point(10, 60)
            };
            btnAddCategory.Click += BtnAddCategory_Click; // Attach the click event
            this.Controls.Add(btnAddCategory);

            Button btnDeleteCategory = new Button
            {
                Text = "Delete Category",
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.White,
                Width = 180,
                Height = 40,
                Location = new Point(190, 60)
            };
            btnDeleteCategory.Click += BtnDeleteCategory_Click; // Attach the click event
            this.Controls.Add(btnDeleteCategory);

            //// Initialize category list (ListBox) at the class level
            lstCategories = new ListBox
            {
                ForeColor = Color.White,
                BackColor = Color.FromArgb(51, 50, 100),
                Font = new Font("Segoe UI", 10F),
                Location = new Point(10, 110),
                ItemHeight = 40,  // Set a fixed height for each item
                Width = this.ClientSize.Width - 20,  
                Height = this.ClientSize.Height - 120 
            };

            // Set the DrawMode to OwnerDrawFixed to enable custom drawing
            lstCategories.DrawMode = DrawMode.OwnerDrawFixed;

            // Handle the DrawItem event to customize item drawing
            lstCategories.DrawItem += (sender, e) =>
            {
                // Check if the item is selected
                bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

                // Alternate row colors
                if (e.Index % 2 == 0)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 60)), e.Bounds);
                    
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 80)), e.Bounds);
                }

                // If selected, change the background color
                if (isSelected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, 70, 130)), e.Bounds);
                }

                // Draw the item text
                e.Graphics.DrawString(lstCategories.Items[e.Index].ToString(), e.Font, Brushes.White, e.Bounds);
            };

            // Set the size of the ListBox after the form has loaded
            this.Load += (sender, e) =>
            {
                lstCategories.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 120);
                this.Controls.Add(lstCategories);
            };

            // Add the ListBox to the form
            this.Controls.Add(lstCategories);

            LoadCategoriesFromDatabase();

        }

        private void LoadCategoriesFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Category FROM CategoryTable";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lstCategories.Items.Add(reader["Category"].ToString());
                    }
                }
            }
        }

        //add and delete
        private void AddCategory(string categoryName)
        {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO CategoryTable (Category) VALUES (@Category)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Category", categoryName);
                    cmd.ExecuteNonQuery();
                }

                // Refresh the ToolStrip in Form1
                lstCategories.Items.Add(categoryName);
                mainForm.RefreshToolStrip();
        }

        private void DeleteCategory(string categoryName)
        {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM CategoryTable WHERE Category = @Category";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Category", categoryName);
                    cmd.ExecuteNonQuery();
                }

                // Refresh the ToolStrip in Form1
                mainForm.RefreshToolStrip();
        }
        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            // Prompt the user to enter a new category
            string newCategory = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter the name of the new category:",
                "Add New Category",
                "New Category");

            // Check if input is not empty
            if (!string.IsNullOrWhiteSpace(newCategory))
            {
                AddCategory(newCategory);
            }
            else
            {
                MessageBox.Show("Category name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (lstCategories.SelectedItem != null)
            {
                string categoryToDelete = lstCategories.SelectedItem.ToString();
                DeleteCategory(categoryToDelete);
                lstCategories.Items.Remove(lstCategories.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a category to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}