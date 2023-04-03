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
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //get count of todays orders
                string query = "SELECT COUNT(*) FROM Orders WHERE CONVERT(date, OrderTime) = CONVERT(date, GETDATE())";
                SqlCommand command = new SqlCommand(query, connection);
                int countOrders = (int)command.ExecuteScalar();
                lbl_nOrders.Text= countOrders.ToString();

                //get count of total customers
                string query1 = "SELECT COUNT(*) FROM Customer";
                SqlCommand command1 = new SqlCommand(query1, connection);
                int countCustomers = (int)command1.ExecuteScalar();
                lbl_nCustomers.Text = countCustomers.ToString();

                //get revenue earned today
                string query2 = "SELECT SUM(Price) FROM Orders WHERE CONVERT(date, OrderTime) = CONVERT(date, GETDATE())";
                SqlCommand command2 = new SqlCommand(query2, connection);
                var revenue = command2.ExecuteScalar();
                lbl_revenue.Text = $"RM {revenue.ToString()}";

                //get total inventory units
                string query3 = "SELECT SUM(CountInStock) FROM Product";
                SqlCommand command3 = new SqlCommand(query3, connection);
                int countStock = (int)command3.ExecuteScalar();
                lbl_unitsStock.Text = countStock.ToString();

                //get total units sold
                string query4 = "SELECT SUM(Quantity) FROM Orders";
                SqlCommand command4 = new SqlCommand(query4, connection);
                int countStockSold = (int)command4.ExecuteScalar();
                lbl_unitsSold.Text = countStockSold.ToString();

                //get total revenue earned
                string query5 = "SELECT SUM(Price) FROM Orders";
                SqlCommand command5 = new SqlCommand(query5, connection);
                var trevenue = command5.ExecuteScalar();
                lbl_totalRevenue.Text = $"RM {trevenue.ToString()}";

            }
        }
    }
}
