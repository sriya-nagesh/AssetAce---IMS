using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MouveForm;

namespace AssetAce
{
    public partial class Register : Form
    {
        bool errorPassword;
        public Register()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "" || txt_fname.Text == "" || txt_lname.Text == "" || txt_email.Text == "" || txt_password.Text == "" || txt_cpassword.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Incomplete Form", MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation);
            }
            else if (errorPassword==true)
            {
                MessageBox.Show("Please provide valid email address", "Invalid Email", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
            else if (txt_password.Text != txt_cpassword.Text)
            {
                MessageBox.Show("Password does not match! \nPlease re-enter", "Registration Failed",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cpassword.Focus();
                txt_cpassword.SelectAll();
            }
            else
            {
                string employeeID = txt_id.Text;
                string fname = txt_fname.Text;
                string lname = txt_lname.Text;
                string email = txt_email.Text;
                string password = txt_password.Text;
                //Calling the AddUser method in UserDatabase class to create the user account
                bool result = UserDatabase.AddUser(employeeID, fname, lname, email, password);

                if (result == true) //User account is created successfullly
                {
                    MessageBox.Show("Registration Successful!", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Clear();
                    Login log = new Login();
                    log.Show();
                    this.Close();
                }
                else //User account could not be created due to violation of primary key - Employee ID
                {
                    MessageBox.Show("Employee ID has already been registered in the system", "Registration  Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    txt_id.Focus();
                    txt_id.SelectAll();
                }
            }
        }
        private void Clear()
        {
            txt_id.Text = txt_fname.Text = txt_lname.Text = txt_email.Text = txt_password.Text = txt_cpassword.Text = "";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cb_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_showPass.Checked == true)
            {
                txt_password.PasswordChar = '\0';
                txt_cpassword.PasswordChar = '\0';
            }
            else
            {
                txt_password.PasswordChar = '*';
                txt_cpassword.PasswordChar = '*';
            }
        }

        private void lbl_login_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }

        private void txt_email_Leave(object sender, EventArgs e)
        {
            string pattern = "^([a-zA-Z0-9_\\.-]+)@([a-zA-Z0-9_\\.-]+)([a-zA-Z0-9_\\.-]+)\\.([a-zA-Z]{2,6})$";
            if (Regex.IsMatch(txt_email.Text, pattern))
            {
                error_email.Clear();
                errorPassword = false;
            }
            else
            {
                error_email.SetError(this.txt_email, "Please provide valid email address");
                errorPassword = true;
            }
        }

        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            MouveForm.Mouve.Go(panel_header);
        }
    }
}
