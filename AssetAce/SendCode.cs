using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using MouveForm;

namespace AssetAce
{
    public partial class SendCode : Form
    {

        private string randomCode,employeeID;
        public SendCode()
        {
            InitializeComponent();
        }

        private void btn_sendEmail_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            employeeID = txt_id.Text;

            if (employeeID == "")
            {
                MessageBox.Show("Please enter your Employee ID!", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_id.Focus();
            }
            else
            {
                string email = UserDatabase.FindEmail(employeeID);
                if (email == "")
                {
                    MessageBox.Show("Emloyee ID doesn't exist in the system!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    randomCode = (rand.Next(999999)).ToString();

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("thisemailisfortesting687@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "Password reset code for CMS";
                        mail.Body = "Your reset code is " + randomCode;
                        //email.Attachments.Add(new Attachment("the physical file path"));

                        using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")) //gmail's smtp server for outgoing email
                        {
                            smtpClient.Credentials = new NetworkCredential("thisemailisfortesting687@gmail.com", "xppf make kpmt ofpe");
                            smtpClient.EnableSsl = true;
                            try
                            {
                                smtpClient.Send(mail);
                                MessageBox.Show("Code sent successfully. Please check your email.", "Code sent",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                    }
                }
            }
        }

        private void SendCode_Load(object sender, EventArgs e)
        {
            MouveForm.Mouve.Go(panel_header);
        }

        private void btn_validate_Click(object sender, EventArgs e)
        {
            if (txt_code.Text == "")
            {
                MessageBox.Show("Please fill in your code", "Empty Field", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            else if (txt_code.Text == randomCode)
            {
                ChangePassword cp = new ChangePassword(employeeID);
                cp.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong code entered!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
