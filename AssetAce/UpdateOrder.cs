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
    public partial class UpdateOrder : UserControl
    {
        public UpdateOrder()
        {
            InitializeComponent();
        }

        private void Search(string searchValue)
        {
            dgv_order.ClearSelection(); // Clear any existing selections

            foreach (DataGridViewRow row in dgv_order.Rows)
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
        private void UpdateOrder_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True");

            string query = "SELECT * FROM Orders";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Bind the DataTable to a DataGridView
            dgv_order.DataSource = dataTable;

            using (connection)
            {

                connection.Open();
                SqlCommand com = new SqlCommand("SELECT ProductName FROM Product", connection);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    cb_product.Items.Add(reader.GetString(0));
                }
                // Close the data reader and the SQL connection
                reader.Close();


                SqlCommand command1 = new SqlCommand("SELECT CustomerName FROM Customer", connection);
                SqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    cb_customer.Items.Add(reader1.GetString(0));
                }
                // Close the data reader and the SQL connection
                reader1.Close();
                connection.Close();
            }
        }

        private void dgv_order_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_order.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgv_order.SelectedRows[0];

                // Populate the textboxes with data from the selected row
                txt_id.Text = selectedRow.Cells["OrderID"].Value.ToString();
                num_quantity.Text = selectedRow.Cells["Quantity"].Value.ToString();
                cb_product.Text = selectedRow.Cells["ProductName"].Value.ToString();
                cb_customer.Text = selectedRow.Cells["CustomerName"].Value.ToString();
                dtp_date.Text = selectedRow.Cells["OrderTime"].Value.ToString();

            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True"); ;

            string query = "SELECT ProductID FROM Product WHERE ProductName = @ProductName";

            connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", cb_product.Text);

                SqlDataReader reader = command.ExecuteReader();
                string prodid = null;

                if (reader.Read())
                {

                    prodid = reader.GetInt32(0).ToString();

                }

                reader.Close();

                //Get Customer ID
                string query1 = "SELECT CustomerID FROM Customer WHERE CustomerName = @CustomerName";

                SqlCommand command1 = new SqlCommand(query1, connection);
                command1.Parameters.AddWithValue("@CustomerName", cb_customer.Text);

                SqlDataReader reader1 = command1.ExecuteReader();
                string cusid = null;

                if (reader1.Read())
                {

                    cusid = reader1.GetInt32(0).ToString();

                }

                reader1.Close();

                //Get product price
                string query2 = "SELECT ProductPrice FROM Product WHERE ProductName = @ProductName";

                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@ProductName", cb_product.Text);

                SqlDataReader reader2 = command2.ExecuteReader();
                decimal prodPrice = 0;

                if (reader2.Read())
                {

                    prodPrice = reader2.GetDecimal(0);

                }

                reader2.Close();
                decimal TotalPrice = decimal.Parse(num_quantity.Text) * prodPrice;

            string query3 = "UPDATE Orders SET Quantity = @quantity, ProductID = @productID, CustomerID = @customerID, ProductName = @productName, CustomerName = @customerName, OrderTime = @orderTime, Price = @price WHERE OrderID = @orderID";

            SqlCommand com = new SqlCommand(query3, connection);

            if (!string.IsNullOrEmpty(txt_id.Text) && !string.IsNullOrEmpty(num_quantity.Text) && num_quantity.Text != "0" && !string.IsNullOrEmpty(cb_customer.Text) && !string.IsNullOrEmpty(cb_product.Text) && !string.IsNullOrEmpty(dtp_date.Text))
            {
                com.Parameters.AddWithValue("@orderID", txt_id.Text);
                com.Parameters.AddWithValue("@quantity", num_quantity.Text);
                com.Parameters.AddWithValue("@productID", prodid);
                com.Parameters.AddWithValue("@customerID", cusid);
                com.Parameters.AddWithValue("@productName", cb_product.Text);
                com.Parameters.AddWithValue("@customerName", cb_customer.Text);
                com.Parameters.AddWithValue("@orderTime", dtp_date.Text);
                com.Parameters.AddWithValue("@price", TotalPrice);

                try
                {
                 
                    SqlCommand getStock = new SqlCommand("SELECT CountInStock FROM Product WHERE ProductID = @ProductID", connection);
                    getStock.Parameters.AddWithValue("@ProductID", prodid);

                    int stock = (int)getStock.ExecuteScalar();

                    SqlCommand getCurrentQuantity = new SqlCommand("SELECT Quantity FROM Orders WHERE OrderID = @OrderID", connection);
                    getCurrentQuantity.Parameters.AddWithValue("@OrderID", txt_id.Text);

                    int currentQuantity = (int)getCurrentQuantity.ExecuteScalar();
                    decimal balance = num_quantity.Value - currentQuantity;
                    decimal balance1 = currentQuantity - num_quantity.Value;
                    int quan = (int)num_quantity.Value;

                    if (currentQuantity < quan)
                    {
                        if (stock > balance)
                        {
                            SqlCommand updateStock = new SqlCommand("UPDATE Product SET CountInStock = CountInStock - @AmountToSubtract WHERE ProductID = @ProductID", connection);
                            updateStock.Parameters.AddWithValue("@AmountToSubtract", balance);
                            updateStock.Parameters.AddWithValue("@ProductID", prodid);
                            updateStock.ExecuteNonQuery();
                            com.ExecuteNonQuery();
                            MessageBox.Show("Order record has been updated");
                        }
                        else
                        {
                            MessageBox.Show($"There are only {stock} of this product left!");
                        }
                    } else if(currentQuantity > quan)
                    {
                        SqlCommand AddStock = new SqlCommand("UPDATE Product SET CountInStock = CountInStock + @AmountToAdd WHERE ProductID = @ProductID", connection);
                        AddStock.Parameters.AddWithValue("@AmountToAdd", balance1);
                        AddStock.Parameters.AddWithValue("@ProductID", prodid);
                        AddStock.ExecuteNonQuery();
                        com.ExecuteNonQuery();
                        MessageBox.Show("Order record has been updated");
                    }
                    else
                    {
                        com.ExecuteNonQuery();
                        MessageBox.Show("Order record has been updated");
                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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

            string query = "DELETE FROM Orders WHERE OrderID = @orderId";

            SqlCommand command = new SqlCommand(query, connection);

            if (!string.IsNullOrEmpty(txt_id.Text))
            {
                int orderIdToDelete = int.Parse(txt_id.Text);
                command.Parameters.AddWithValue("@orderId", orderIdToDelete);

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Order has been deleted");
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

        private void btn_print_Click(object sender, EventArgs e)
        {
            OrderReport or = new OrderReport();
            or.Show();
        }
    }
}
