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
using System.Drawing.Printing;
using System.IO;

namespace AssetAce
{
    public partial class AddOrder : UserControl
    {
        public AddOrder()
        {
            InitializeComponent();
        }

            private void PrintReceipt(object sender, PrintPageEventArgs e)
            {
                Font font = new Font("Bahnschrift", 16);
                float lineHeight = font.GetHeight();

                string receiptText = rtb_receipt.Text;
                float yPosition = e.MarginBounds.Top;

                StringReader reader = new StringReader(receiptText);
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    e.Graphics.DrawString(line, font, Brushes.Black, e.MarginBounds.Left, yPosition, new StringFormat());
                    yPosition += lineHeight;
                }
            }
        private void AddOrder_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ProductName FROM Product", connection);
                SqlDataReader reader = command.ExecuteReader();
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

        private void txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            if (txt_id.Text != "" && cb_product.Text != "" && num_quantity.Text != "" && num_quantity.Text != "0" && cb_customer.Text != "")
            {

                int ordID = int.Parse(txt_id.Text);
                decimal quantity = num_quantity.Value;
                string prodName = cb_product.Text, cusName = cb_customer.Text, date = dtp_date.Text;

                using (SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True"))
                {
                    connection.Open();

                    //Get Product ID
                    string query = "SELECT ProductID FROM Product WHERE ProductName = @ProductName";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductName", prodName);

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
                    command1.Parameters.AddWithValue("@CustomerName", cusName);

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
                    command2.Parameters.AddWithValue("@ProductName", prodName);

                    SqlDataReader reader2 = command2.ExecuteReader();
                    decimal prodPrice= 0;

                    if (reader2.Read())
                    {

                        prodPrice = reader2.GetDecimal(0);

                    }

                    reader2.Close();
                    decimal TotalPrice = quantity*prodPrice;
 
                    //Add values to database
                    SqlCommand com = new SqlCommand("INSERT INTO Orders (OrderID, Quantity, ProductID, CustomerID, ProductName, CustomerName, OrderTime, Price) VALUES (@OrderID, @Quantity, @ProductID, @CustomerID, @ProductName, @CustomerName, @OrderTime, @Price)", connection);

                    com.Parameters.AddWithValue("@OrderID", ordID);
                    com.Parameters.AddWithValue("@Quantity", quantity);
                    com.Parameters.AddWithValue("@ProductID", prodid);
                    com.Parameters.AddWithValue("@CustomerID", cusid);
                    com.Parameters.AddWithValue("@ProductName", prodName);
                    com.Parameters.AddWithValue("@CustomerName", cusName);
                    com.Parameters.AddWithValue("@OrderTime", date);
                    com.Parameters.AddWithValue("@Price", TotalPrice);

                    try
                    {

                        //add record into orders database
                        SqlCommand getStock = new SqlCommand("SELECT CountInStock FROM Product WHERE ProductID = @ProductID", connection);
                        getStock.Parameters.AddWithValue("@ProductID", prodid);

                        int stock = (int)getStock.ExecuteScalar();
                      
                        if (stock > quantity) {
                                com.ExecuteNonQuery(); //execute add function
                                MessageBox.Show("Your order has been added!");

                                DateTime transactionTime = DateTime.Now;

                                string receiptText = $"AssetAce\n\nTransaction Time: {transactionTime}\nOrder Time: {date}\nCustomer: {cusName}\nProduct: {prodName}\nQuantity: {quantity:C}\nPrice: {TotalPrice:C}";

                                rtb_receipt.Text = receiptText;

                                txt_id.Text = cb_product.Text = num_quantity.Text = cb_customer.Text = "";
                                dtp_date.Value = transactionTime;


                                SqlCommand updateStock = new SqlCommand("UPDATE Product SET CountInStock = CountInStock - @AmountToSubtract WHERE ProductID = @ProductID", connection);
                                updateStock.Parameters.AddWithValue("@AmountToSubtract", quantity);
                                updateStock.Parameters.AddWithValue("@ProductID", prodid);
                                updateStock.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show($"There are only {stock} of this product left!");
                            }
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("This ID already exists within the database");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in all values!");
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            rtb_receipt.Text = "";
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintReceipt);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;

            ppd.ShowDialog();
        }
    }
}
