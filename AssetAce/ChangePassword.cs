using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MouveForm;

namespace AssetAce
{
    public partial class ChangePassword : Form
    {
        private string cpEmployeeID;
        public ChangePassword(string EmployeeID)
        {
            InitializeComponent();
            this.cpEmployeeID = EmployeeID;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (txt_newpassword.Text == "" || txt_newpassword.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Empty Fields", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            else if (txt_newpassword.Text != txt_newpassword.Text)
            {
                MessageBox.Show("Password does not match! Please re-enter.", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                txt_newpassword.Focus();
                txt_newpassword.SelectAll();
            }
            else
            {
                string password = txt_newpassword.Text;
                bool result = UserDatabase.ChangePassword(cpEmployeeID, password);

                if (result == false)
                {
                    if (MessageBox.Show("Password update failed. \nDo you want to start again?", "Update Failed",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        SendCode sc = new SendCode();
                        sc.Show();
                        this.Close();
                    }
                    else
                    {
                        Login log = new Login();
                        log.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Password changed sucessfully.", "Password Changed", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                    Login log = new Login();
                    log.Show();
                    this.Close();
                }
            }

        }

        private void cb_showpw_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_showpw.Checked)
            {
                txt_newpassword.PasswordChar = '\0';
                txt_conpassword.PasswordChar = '\0';
            }
            else
            {
                txt_newpassword.PasswordChar = '*';
                txt_conpassword.PasswordChar = '*';
            }

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            MouveForm.Mouve.Go(panel_header);
        }
    }
}
