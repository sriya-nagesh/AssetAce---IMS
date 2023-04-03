using System;
using System.Windows.Forms;
using MouveForm;

namespace AssetAce
{
    public partial class Dashboard : Form
    {
        private string dash_employeeID;
        public Dashboard(string EmployeeID)
        {
            InitializeComponent();
            dash_employeeID = EmployeeID;   
        }

        private void HideSubMenu()
        {
            if (panel_profile.Visible == true)
                panel_profile.Visible = false;
            if (panel_products.Visible == true)
                panel_products.Visible = false;
            if (panel_categories.Visible == true)
                panel_categories.Visible = false;
            if (panel_orders.Visible == true)
                panel_orders.Visible = false;
            if (panel_customers.Visible == true)
                panel_customers.Visible = false;
    
        }
        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void ShowControl(Control control)
        {
            panel_con.Controls.Clear();

            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();

            panel_con.Controls.Add(control);
        }


        private void btn_home_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            ShowControl(home);

            HideSubMenu();
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_profile);
        }

        private void btn_products_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_products);
        }

        private void btn_categories_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_categories);
        }

        private void btn_orders_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_orders);
        }

        private void btn_customers_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_customers);
        }

       

        private void Dashboard_Load(object sender, EventArgs e)
        {

            MouveForm.Mouve.Go(panel_header);
            Home home = new Home();
            ShowControl(home);

            HideSubMenu();

            lbl_fname.Text =$"Hello {UserDatabase.FindFname(dash_employeeID)}" ;

        }

        private void btn_editPassword_Click(object sender, EventArgs e)
        {
            EditPassword editPassword = new EditPassword(dash_employeeID);
            ShowControl(editPassword);
        }

        private void btn_editProfile_Click(object sender, EventArgs e)
        {
            EditProfile editProfile = new EditProfile(dash_employeeID);
            ShowControl(editProfile);
        }

        private void btn_addP_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            ShowControl(addProduct);
        }

        private void btn_updateP_Click(object sender, EventArgs e)
        {
            UpdateProduct updateProduct = new UpdateProduct();
            ShowControl(updateProduct);
        }

        private void btn_addC_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            ShowControl(addCategory);
        }

        private void btn_updateC_Click(object sender, EventArgs e)
        {
            UpdateCategory updateCategory = new UpdateCategory();
            ShowControl(updateCategory);
        }

        private void btn_addO_Click(object sender, EventArgs e)
        {
            AddOrder addOrder = new AddOrder();
            ShowControl(addOrder);
        }

        private void btn_updateO_Click(object sender, EventArgs e)
        {
            UpdateOrder updateOrder = new UpdateOrder();
            ShowControl(updateOrder);
        }

        private void btn_addCus_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            ShowControl(addCustomer);
        }

        private void btn_updateCus_Click(object sender, EventArgs e)
        {
            UpdateCustomer updateCustomer = new UpdateCustomer();
            ShowControl(updateCustomer);
        }


        private void btn_updateE_Click(object sender, EventArgs e)
        {
            UpdateCustomer updateCustomer = new UpdateCustomer();
            ShowControl(updateCustomer);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Login log = new Login();
                log.Show();
                this.Close();
            }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
