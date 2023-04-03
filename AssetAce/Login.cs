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
using System.IO;
using MouveForm;

namespace AssetAce
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            MouveForm.Mouve.Go(panel_header);
            if (Properties.Settings.Default.EmployeeID != "")
            {
                txt_id.Text = Properties.Settings.Default.EmployeeID;
                txt_password.Text = Properties.Settings.Default.Password;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbl_register_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void lbl_fp_Click(object sender, EventArgs e)
        {
            SendCode sc = new SendCode();
            sc.Show();
            this.Close();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            if (cb_remember.Checked == true) //assign the text in both fields to the variables created in  Properties Settings
            {
                Properties.Settings.Default.EmployeeID = txt_id.Text;
                Properties.Settings.Default.Password = txt_password.Text;
                Properties.Settings.Default.Save(); //save the values assigned
            }
            else //assign empty strings to the variables created in Properties Settings 
            {
                Properties.Settings.Default.EmployeeID = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save(); //save the values assigned
            }

            if (txt_id.Text == "" || txt_password.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Login Failed", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                string employeeID = txt_id.Text;
                string password = txt_password.Text;
                //Calling the ValidateUser method in UserDatabase class to validate the employee ID + password
                bool result = UserDatabase.ValidateUser(employeeID, password);
                if (result == false)
                {
                    MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    Dashboard ds = new Dashboard(employeeID);
                    ds.Show();
                    this.Close();
                }
            }

        }

        public void Clear()
        {
            txt_id.Text = txt_password.Text = "";
        }

        private void btn_view_MouseDown(object sender, MouseEventArgs e)
        {
            txt_password.PasswordChar = '\0';
        }

        private void btn_view_MouseUp(object sender, MouseEventArgs e)
        {
            txt_password.PasswordChar = '*';
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SendCode sc = new SendCode();
            sc.Show();
            this.Close();
        }
    }

    public static class UserDatabase
    {
        private static string connectionstring = "Data Source=SRIYA-PC\\SQLEXPRESS;Initial Catalog=AssetAce;Integrated Security=True";

        public static bool AddUser(string employeeID, string fname, string lname, string email, string password) //This method will add a user to the database
        {
            // First create a new Guid for the user. This will be unique for each user
            Guid userid = System.Guid.NewGuid();
            // Hash the password together with the unique userGuid created
            string hashedPassword = Security.HashSHA1(password + userid.ToString());
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                byte[] image = { 0 };
                con.Open();
                //Add the input as parameters to avoid SQL injections
                SqlCommand cmd = new SqlCommand("INSERT INTO Employee VALUES (@employeeid, @firstname, @lastname, @password, @userid, @email, @role, @profilepic, @deptno)", con);
                cmd.Parameters.AddWithValue("@employeeID", employeeID);
                cmd.Parameters.AddWithValue("@firstname", fname);
                cmd.Parameters.AddWithValue("@lastname", lname);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@role", "");
                cmd.Parameters.Add(new SqlParameter("@profilepic", image));
                cmd.Parameters.AddWithValue("@deptno", 10);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    //violation of primary key
                    return false;
                }
            }
            return true;
        }

        public static bool ValidateUser(string employeeID, string password) //This method will validate the Employee ID with the password
        {
             bool match = false;
             using (SqlConnection con = new SqlConnection(connectionstring))
             {
             con.Open();
             SqlCommand cmd = new SqlCommand("SELECT Password, Userid FROM Employee WHERE EmployeeID = '" + employeeID + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
             while (dr.Read())
             {
             string dbPassword = Convert.ToString(dr["Password"]); //converting from object to string
                string dbUserid = Convert.ToString(dr["Userid"]);
                // Now we hash the UserGuid from the database with the password we want to check
                // In the same way as when we saved it to the database in the first place. 
                string hashedPassword = Security.HashSHA1(password + dbUserid);
             // if the password is correct, the result of the hash will be the same as in the database
             if (dbPassword == hashedPassword) //password entered and the pasword in the DB are the same
             {
             match = true;
             }
             }
             }
             return match; //true if matching username + password, false if username and/or password is wrong.
            }

            public static string FindEmail(string employeeID) //to find the user's email in the database
            {
                string email = "";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Email FROM Employee WHERE EmployeeID = '" + employeeID + "' ", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        email = Convert.ToString(dr["Email"]);
                    }
                }
                return email;
            }

        public static bool ChangePassword(string employeeID, string password) //This method will change  the password in the database
        {
            // First create a new Guid for the user. This will be unique for each user
            Guid userid = System.Guid.NewGuid();
             // Hash the password together with the unique userGuid created
             string hashedPassword = Security.HashSHA1(password + userid.ToString());
             using (SqlConnection con = new SqlConnection(connectionstring))
             {
             con.Open();
             //Add the input as parameters to avoid SQL injections
             SqlCommand cmd = new SqlCommand("UPDATE Employee SET Password = @password, UserID = @userid WHERE EmployeeID = '" + employeeID + "' ", con);
                cmd.Parameters.AddWithValue("@password", hashedPassword); //store the hashedPassword
                cmd.Parameters.AddWithValue("@userid", userid); //store the Guid
             try
             {
             cmd.ExecuteNonQuery();
             }
             catch
            {
                return false;
            }
             }
             return true;
}
            public static void ReadProfile(object[] profile, string employeeID) //to read and store user’s first name, last name, and email in an object array
            {
            byte[] image = { 0 };
            using (SqlConnection con = new SqlConnection(connectionstring))
                 {
                 con.Open();
                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = con;
                 cmd.CommandText = "SELECT ProfilePic, FirstName, LastName, Role, Email FROM Employee WHERE EmployeeID = '" + employeeID + "' ";
                 SqlDataReader dr = cmd.ExecuteReader();
                 while (dr.Read())
                 {
                 profile[0] = Convert.ToString(dr["FirstName"]);
                 profile[1] = Convert.ToString(dr["LastName"]);
                 profile[2] = Convert.ToString(dr["Role"]);
                 profile[3] = Convert.ToString(dr["Email"]);
                    image = (byte[])dr["ProfilePic"];
                }
                 }
            
        }

        public static byte[] ReadImage(string employeeID) //to return the user’s profile pic
        {
            byte[] image = { 0 };
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT ProfilePic FROM Employee WHERE EmployeeID = '" + employeeID + "' ";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    image = (byte[])dr["ProfilePic"];
                }
            }
            return image;
        }

        public static bool UpdateProfile(object[] profile, string employeeID) //to update the user’s profile in the database
        {
            byte[] image = { 0 };
            if (Convert.ToString(profile[4]) != "")
            {
                FileStream fStream = new FileStream(profile[4].ToString(), FileMode.Open, FileAccess.Read);
                BinaryReader bReader = new BinaryReader(fStream);
                image = bReader.ReadBytes((int)fStream.Length);
            }
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                if (Convert.ToString(profile[4]) != "") //user update profile pic
                {
                    string profilePicStr = Convert.ToString(profile[4]);
                    byte[] profilePicBytes = Encoding.ASCII.GetBytes(profilePicStr);
                    SqlParameter profilePicParam = new SqlParameter("@profilepic", SqlDbType.VarBinary, 50);
                    profilePicParam.Value = profilePicBytes;                  

                    SqlCommand cmd = new SqlCommand("UPDATE Employee SET FirstName = @firstname, LastName = @lastname, Role =  @role, ProfilePic = @profilepic, Email = @email WHERE EmployeeID = @employeeid ", con);
                   
                    cmd.Parameters.AddWithValue("@employeeid", employeeID);
                    cmd.Parameters.AddWithValue("@firstname", profile[0]);
                    cmd.Parameters.AddWithValue("@lastname", profile[1]);
                    cmd.Parameters.AddWithValue("@role", profile[2]);
                    cmd.Parameters.Add(profilePicParam);
                    cmd.Parameters.AddWithValue("@email", profile[3]);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Error with updating your profile!");
                        return false; //update failed
                    }
                }
                else //user didn't update profile pic
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Employee SET FirstName = @firstname, LastName = @lastname, Role =  @role, Email = @email WHERE EmployeeID = @employeeid ", con);
                   
                    cmd.Parameters.AddWithValue("@employeeid", employeeID);
                    cmd.Parameters.AddWithValue("@firstname", profile[0]);
                    cmd.Parameters.AddWithValue("@lastname", profile[1]);
                    cmd.Parameters.AddWithValue("@role", profile[2]);
                    cmd.Parameters.AddWithValue("@email", profile[3]);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your profile has been updated!");
                    }
                    catch
                    {
                        return false; //update failed
                    }
                }
                return true;
            }
        }

        public static string FindFname(string employeeID) //to find and return the user's first name
        {
            string name = "";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT FirstName FROM Employee WHERE EmployeeID = '" + employeeID + "' ";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    name = Convert.ToString(dr["FirstName"]);
                }
            }
            return name;
        }
    }
    public static class Security
    {
        public static string HashSHA1(string value)
        {
            // SHA-1 which will return a string with a length of 40 no matter what the input value is
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }

    public class MyApplicationContext : ApplicationContext
    {
        public MyApplicationContext(Form mainForm) : base(mainForm)
        { }
        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            if (Form.ActiveForm != null)
            {
                this.MainForm = Form.ActiveForm;
            }
            else
            {
                base.OnMainFormClosed(sender, e);
            }
        }
    }
}
