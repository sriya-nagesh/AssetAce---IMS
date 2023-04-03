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
    public partial class AddCategory : UserControl
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            int catID = int.Parse(txt_id.Text);
            string catName = txt_name.Text;
          
            if(txt_id != null && txt_name != null) {
                using (SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO Category (CategoryID, CategoryName) VALUES (@categoryID, @categoryName)", connection);

                    command.Parameters.AddWithValue("@categoryID", catID);
                    command.Parameters.AddWithValue("@categoryName", catName);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Your category has been added!");
                    }
                    catch
                    {
                        MessageBox.Show("This ID already exists within the database");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in all values");
            }
        }

        private void txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_id.Text = txt_name.Text = "";
        }
    }
    }

