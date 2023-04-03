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
    public partial class AskPassword : Form
    {
        private string employeeID;
        private object[] newProfile = new Object[5];
        public AskPassword(object[] profile, string prof_employeeID)
        {
            InitializeComponent();
            newProfile = profile;
            employeeID = prof_employeeID;
        }

        private void cb_showpw_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_showpw.Checked == true)
            {
                txt_password.PasswordChar = '\0';
            }
            else
            {
                txt_password.PasswordChar = '*';
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (txt_password.Text != "")
            {
                bool match = UserDatabase.ValidateUser(employeeID, txt_password.Text);
                if (match == true) //Password entered is correct
                {
                    bool result = UserDatabase.UpdateProfile(newProfile, employeeID);
                    if (result == true)
                        MessageBox.Show("Profile updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_password.Text = "";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password is not correct!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Password needs to be entered to edit profile!", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AskPassword_Load(object sender, EventArgs e)
        {
            MouveForm.Mouve.Go(panel_header);
        }
    }
}
