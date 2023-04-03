using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace AssetAce
{
    public partial class EditProfile : UserControl
    {
        private string prof_employeeID, imgLocation = "";
        private object[] profile = new Object[5];
        private object[] newProfile = new Object[5];

        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pbox_image.ImageLocation = imgLocation;
                changePic = true;
            }

        }

        private byte[] RetrieveProfilePictureFromDatabase()
        {

            string query = "SELECT ProfilePic FROM Employee WHERE EmployeeID = @employeeid";
            SqlConnection con = new SqlConnection("Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@employeeid", prof_employeeID);
                byte[] profilePicBytes = (byte[])cmd.ExecuteScalar();
                return profilePicBytes;
            }
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            lbl_id.Text = prof_employeeID;
            UserDatabase.ReadProfile(profile, prof_employeeID);
            txt_fname.Text = Convert.ToString(profile[0]);
            txt_lname.Text = Convert.ToString(profile[1]);
            txt_role.Text = Convert.ToString(profile[2]);
            txt_email.Text = Convert.ToString(profile[3]);

            byte[] profilePicBytes = RetrieveProfilePictureFromDatabase();

            if (profilePicBytes.Length == 0)
            {
            }
            else
            {
                using (MemoryStream ms = new MemoryStream(profilePicBytes))
                {
                    try
                    {
                        using (Image profilePic = Image.FromStream(ms))
                        {
                            pbox_image.Image = profilePic;
                        }
                    }
                    catch 
                    {
                        
                    }

                }
            }
        }
        

        private void btn_editProfile_Click(object sender, EventArgs e)
        {
            newProfile[0] = txt_fname.Text;
            newProfile[1] = txt_lname.Text;
            newProfile[2] = txt_role.Text;
            newProfile[3] = txt_email.Text;
            if (changePic == true)
            {  
            newProfile[4] = imgLocation;
            }
            AskPassword apw = new AskPassword(newProfile, prof_employeeID);
            apw.ShowDialog();

        }

        private bool changePic = false;

        public EditProfile(string employeeID)
        {
            InitializeComponent();
            prof_employeeID = employeeID;
        }
    }
}
