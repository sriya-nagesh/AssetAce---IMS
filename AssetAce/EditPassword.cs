using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetAce
{
    public partial class EditPassword : UserControl
    {
        private string prof_employeeID;
        public EditPassword(string employeeID)
        {
            InitializeComponent();
            prof_employeeID = employeeID;
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_curpassword.Text == "" || txt_newpassword.Text == "" || txt_conpassword.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Update Failed", MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation);
            }
            else if (UserDatabase.ValidateUser(prof_employeeID, txt_curpassword.Text) == false)
            {
                MessageBox.Show("Current password is incorrect! Please re-enter", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_curpassword.Focus();
                txt_curpassword.SelectAll();
            }
            else if (txt_newpassword.Text != txt_conpassword.Text)
            {
                MessageBox.Show("Password does not match! Please re-enter.", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                txt_conpassword.Focus();
                txt_conpassword.SelectAll();
            }
            else
            {
                bool result = UserDatabase.ChangePassword(prof_employeeID, txt_newpassword.Text);
                if (result == false)
                {
                    MessageBox.Show("Password update failed. ", "Update Failed", MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Password changed sucessfully.", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_curpassword.Text = txt_newpassword.Text = txt_conpassword.Text = "";
                }
            }
        }
    }
}
