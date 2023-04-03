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
    public partial class AddCustomer : UserControl
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            int cusID = int.Parse(txt_id.Text);
            string cusName = txt_name.Text, cusPhone =txt_num.Text, cusEmail = txt_email.Text;

            if (txt_id != null && txt_name != null && txt_num != null && txt_email != null)
            {
                using (SqlConnection connection = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO Customer (CustomerID, CustomerName, CustomerPhone, CustomerEmail) VALUES (@customerID, @customerName, @customerPhone, @customerEmail)", connection);

                    command.Parameters.AddWithValue("@customerID", cusID);
                    command.Parameters.AddWithValue("@customerName", cusName);
                    command.Parameters.AddWithValue("@customerPhone", cusPhone);
                    command.Parameters.AddWithValue("@customerEmail", cusEmail);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Customer record has been added!");
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
            txt_id.Text = txt_name.Text = txt_num.Text = txt_email.Text = "";
        }
    }
}
