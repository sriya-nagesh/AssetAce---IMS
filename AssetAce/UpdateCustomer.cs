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
    public partial class UpdateCustomer : UserControl
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void Search(string searchValue)
        {
            dgv_customer.ClearSelection(); // Clear any existing selections

            foreach (DataGridViewRow row in dgv_customer.Rows)
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
        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True");

            string query = "SELECT * FROM Customer";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Bind the DataTable to a DataGridView
            dgv_customer.DataSource = dataTable;
        }

        private void dgv_customer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_customer.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgv_customer.SelectedRows[0];

                // Populate the textboxes with data from the selected row
                txt_id.Text = selectedRow.Cells["CustomerID"].Value.ToString();
                txt_name.Text = selectedRow.Cells["CustomerName"].Value.ToString();
                txt_num.Text = selectedRow.Cells["CustomerPhone"].Value.ToString();
                txt_email.Text = selectedRow.Cells["CustomerEmail"].Value.ToString();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True");

            string query = "UPDATE Customer SET CustomerName = @customerName, CustomerPhone = @customerPhone, CustomerEmail = @customerEmail WHERE CustomerID = @customerID";

            SqlCommand command = new SqlCommand(query, connection);

            if (!string.IsNullOrEmpty(txt_id.Text) && !string.IsNullOrEmpty(txt_name.Text) && !string.IsNullOrEmpty(txt_num.Text) && !string.IsNullOrEmpty(txt_email.Text))
            {
                command.Parameters.AddWithValue("@customerID", txt_id.Text);
                command.Parameters.AddWithValue("@customerName", txt_name.Text);
                command.Parameters.AddWithValue("@customerPhone", txt_num.Text);
                command.Parameters.AddWithValue("@customerEmail", txt_email.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Customer record has been updated");
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

            string query = "DELETE FROM Customer WHERE CustomerID = @customerId";

            SqlCommand command = new SqlCommand(query, connection);

            if (!string.IsNullOrEmpty(txt_id.Text))
            {
                int customerIdToDelete = int.Parse(txt_id.Text);
                command.Parameters.AddWithValue("@customerId", customerIdToDelete);

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Customer has been deleted");
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
