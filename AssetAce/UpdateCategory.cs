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

namespace AssetAce
{
    public partial class UpdateCategory : UserControl
    {
        public UpdateCategory()
        {
            InitializeComponent();
        }

        private void Search(string searchValue)
        {
            dgv_category.ClearSelection(); // Clear any existing selections

            foreach (DataGridViewRow row in dgv_category.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        row.Selected = true; // Select the row if a match is found
                        break;
                    }
                }
            }
        }
        private void UpdateCategory_Load(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True");

            string query = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Bind the DataTable to a DataGridView
            dgv_category.DataSource = dataTable;

        }

        private void dgv_category_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_category.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgv_category.SelectedRows[0];

                // Populate the textboxes with data from the selected row
                txt_id.Text = selectedRow.Cells["CategoryID"].Value.ToString();
                txt_name.Text = selectedRow.Cells["CategoryName"].Value.ToString();
              
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True");
            string query = "UPDATE Category SET CategoryName = @categoryName WHERE CategoryID = @categoryID";

            SqlCommand command = new SqlCommand(query, connection);

            if (!string.IsNullOrEmpty(txt_id.Text) && !string.IsNullOrEmpty(txt_name.Text))
            {
                command.Parameters.AddWithValue("@categoryID", txt_id.Text);
                command.Parameters.AddWithValue("@categoryName", txt_name.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Your category has been updated");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True");

            string query = "DELETE FROM Category WHERE CategoryID = @categoryId";

            SqlCommand command = new SqlCommand(query, connection);

            if (!string.IsNullOrEmpty(txt_id.Text))
            {
                int categoryIdToDelete = int.Parse(txt_id.Text);
                command.Parameters.AddWithValue("@categoryId", categoryIdToDelete);

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Category has been deleted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("No record has been selected");
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string searchValue = txt_search.Text;
            Search(searchValue);
        }
    }
}
