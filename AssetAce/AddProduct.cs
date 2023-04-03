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
    public partial class AddProduct : UserControl
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT CategoryName FROM Category", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cb_category.Items.Add(reader.GetString(0));
                }

                // Close the data reader and the SQL connection
                reader.Close();
                connection.Close();
            }
        }

        private void txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            

            if (txt_id.Text != "" && txt_name.Text != "" && txt_desc.Text != "" && txt_price.Text != "" && cb_category.Text != "")
            {

                int prodID = int.Parse(txt_id.Text);
                decimal stock = num_stock.Value;
                var price = txt_price.Text;
                string prodName = txt_name.Text, prodDesc = txt_desc.Text, prodCat = cb_category.Text;

                using (SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True"))
                {
                    connection.Open();

                    string query = "SELECT CategoryID FROM Category WHERE CategoryName = @categoryName";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@categoryName", prodCat);

                        SqlDataReader reader = command.ExecuteReader();
                        string id = null;

                        if (reader.Read())
                        {
                            
                            id = reader.GetInt32(0).ToString();
                          
                        }

                        reader.Close();

                   
                    SqlCommand com = new SqlCommand("INSERT INTO Product (ProductID, ProductName, ProductDesc, ProductPrice, CountInStock, CategoryID, CategoryName) VALUES (@ProductID, @ProductName, @ProductDesc, @ProductPrice, @CountInStock, @CategoryID, @CategoryName)", connection);

                    com.Parameters.AddWithValue("@ProductID", prodID);
                    com.Parameters.AddWithValue("@ProductName", prodName);
                    com.Parameters.AddWithValue("@ProductDesc", prodDesc);
                    com.Parameters.AddWithValue("@ProductPrice", price);
                    com.Parameters.AddWithValue("@CountInStock", stock);
                    com.Parameters.AddWithValue("@CategoryID", int.Parse(id));
                    com.Parameters.AddWithValue("@CategoryName", prodCat);

                    try
                    {
                        com.ExecuteNonQuery();
                        MessageBox.Show("Your product has been added!");
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
            txt_id.Text = txt_name.Text = txt_desc.Text = txt_price.Text = cb_category.Text = "";
        }
    }
}
