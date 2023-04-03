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
    public partial class UpdateProduct : UserControl
    {
        public UpdateProduct()
        {
            InitializeComponent();
        }

        private void Search(string searchValue)
        {
            dgv_product.ClearSelection(); // Clear any existing selections

            foreach (DataGridViewRow row in dgv_product.Rows)
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

        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True");

            string query = "SELECT * FROM Product";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Bind the DataTable to a DataGridView
            dgv_product.DataSource = dataTable;

            using (connection)
            {
                connection.Open();
                SqlCommand com = new SqlCommand("SELECT CategoryName FROM Category", connection);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    cb_category.Items.Add(reader.GetString(0));
                }

                // Close the data reader and the SQL connection
                reader.Close();
                connection.Close();
            }
        }

        private void dgv_product_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_product.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgv_product.SelectedRows[0];

                // Populate the textboxes with data from the selected row
                txt_id.Text = selectedRow.Cells["ProductID"].Value.ToString();
                txt_name.Text = selectedRow.Cells["ProductName"].Value.ToString();
                txt_desc.Text = selectedRow.Cells["ProductDesc"].Value.ToString();
                txt_price.Text = selectedRow.Cells["ProductPrice"].Value.ToString();
                num_stock.Text = selectedRow.Cells["CountInStock"].Value.ToString();
                cb_category.Text = selectedRow.Cells["CategoryName"].Value.ToString();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True");

            connection.Open();
            string query1 = "SELECT CategoryID FROM Category WHERE CategoryName = @categoryName";

            SqlCommand command1 = new SqlCommand(query1, connection);
            command1.Parameters.AddWithValue("@categoryName", cb_category.Text);

            SqlDataReader reader = command1.ExecuteReader();
            string id = null;

            if (reader.Read())
            {

                id = reader.GetInt32(0).ToString();

            }

            reader.Close();

            string query = "UPDATE Product SET ProductName = @productName, ProductDesc = @productDesc, ProductPrice = @productPrice, CountInStock = @countInStock, CategoryID = @categoryID, CategoryName = @categoryName WHERE ProductID = @productID";
            SqlCommand command = new SqlCommand(query, connection);
            if (!string.IsNullOrEmpty(txt_id.Text) && !string.IsNullOrEmpty(txt_name.Text) && !string.IsNullOrEmpty(txt_desc.Text) && !string.IsNullOrEmpty(txt_price.Text) && !string.IsNullOrEmpty(num_stock.Text) && num_stock.Text != "0" && !string.IsNullOrEmpty(cb_category.Text))
            {
                // Add parameters to the SqlCommand object
                command.Parameters.AddWithValue("@productID", txt_id.Text);
                command.Parameters.AddWithValue("@productName", txt_name.Text);
                command.Parameters.AddWithValue("@productDesc", txt_desc.Text);
                command.Parameters.AddWithValue("@productPrice", txt_price.Text);
                command.Parameters.AddWithValue("@countInStock", num_stock.Text);
                command.Parameters.AddWithValue("@categoryID", id);
                command.Parameters.AddWithValue("@categoryName", cb_category.Text);

                try
                {
                    // Open the connection to the database
                 
                    command.ExecuteNonQuery();
                     MessageBox.Show("Product record has been updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Close the connection to the database
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

            string query = "DELETE FROM Product WHERE ProductID = @productId";

            SqlCommand command = new SqlCommand(query, connection);

            if (!string.IsNullOrEmpty(txt_id.Text))
            {
                int productIdToDelete = int.Parse(txt_id.Text);
                command.Parameters.AddWithValue("@productId", productIdToDelete);

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes) { 
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product has been deleted");
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
