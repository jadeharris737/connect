using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//DLLs to send mail
using System.Net.Mail;
using System.Net;

using MySql.Data.MySqlClient; //Can connect to cloud database


namespace major_nav
{
    public partial class frm_forgetPassword : Form
    {

        //This public variable is set when the user logins in and stores which user is currently logged in
        public static string user = "";
        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //String to connect and log in to cloud database

        public frm_forgetPassword()
        {
            InitializeComponent();
            if (user != "") //Instantly enter the username that the user was trying to use to log in if one was set
            {
                txt_user.Text = user;
            }
        }

        private void lbl_return_Click(object sender, EventArgs e)
        {
            Close(); //Return to the login form
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (txt_user.Text != "" && txt_user.Text != "Email/Username") //If a username or email has been entered
            {
                bool exists = CheckUserExists(); //Check if a user actually exists for the username/password
                if (exists)
                {
                    string oneTimeCode = dgv_userData.Rows[0].Cells[4].Value.ToString();
                    if (oneTimeCode == "") //If a one time code doesn't already exist for the user, then create and send a temporary code
                    {
                        if (MessageBox.Show($"Are you sure you have access to the email associated with this account? This will send a one-time code. \nNOTE: May Take 5 seconds to send", "Confirmaton", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            Cursor.Current = Cursors.WaitCursor; //As this has a slight delay, visually indicate that the program is working
                            GenerateCode();
                            SetNewCode();
                            CreateNewPassword();
                        }
                    }
                    else
                    {
                        if (MessageBox.Show($"A one-time code has already been sent to the email address associated with this account. If this is not in your inbox, please check your spam folder.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            CreateNewPassword(); //If a code already exists, then forward the user to find this code which has already been sent to log in
                        }
                    }
                }
                else //No user exists (thus no forgot password can be made)
                {
                    MessageBox.Show("No user exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show($"Please enter a username or email (cannot be default or empty).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CloseForget() //Close once user has changed password. Public so that this can be closed from the NewPassword once it has been sent
        {
            Close();
        }

        private void CreateNewPassword()
        {
            frm_newPassword.user = dgv_userData.Rows[0].Cells[1].Value.ToString(); //Display username when resetting password (irrespective of whether user entered email/username)
            frm_newPassword newPassword = new frm_newPassword(this); //Open the new password form
            newPassword.ShowDialog();
        }

        private void SetNewCode()
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Set the security code of the account associated with
            sqlcommand2.CommandText = $"UPDATE Users SET securityCode={codeGenerated} WHERE username='{txt_user.Text}' OR email='{txt_user.Text}'";
            //Execute command 
            sqlcommand2.ExecuteNonQuery();
            //Close connection with cloud server
            con.Close();
        }

        private bool CheckUserExists()
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Select any records where either email or email mathces
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username='{txt_user.Text}' OR email='{txt_user.Text}'";

            //Execute command to find rows which match username
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);

            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            //Place this data in datagrid view for use
            dgv_userData.DataSource = table2;

            //Close connection with cloud server
            con.Close();

            //If row number is >1, then a user does exist.
            if (dgv_userData.Rows.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        string codeGenerated = ""; //public for sending in SendCode function
        private void GenerateCode() //Randomly generate a password
        {
            codeGenerated = ""; //Reset the code string to empty (prevent the password just being added on to)
            int codeLength = 4;
            Random randomIndex = new Random(); //Initialize random number function to create a random index (which is used to choose a random character from the allowed characters)

            string allowedCharacters = "0123456789"; //These are the characters the one-time code can be created from
            char[] codeCharacters = new char[codeLength]; //Create a character array for the password that is 12 characters long

            for (int i = 0; i < codeLength; i++) //For 4characters
            {
                codeCharacters[i] = allowedCharacters[randomIndex.Next(0, allowedCharacters.Length)]; //For each character in the password array (1-12), choose a random number between 0 and the length of the allowed characters.
                //NOTE: Because Random.Next goes from min-value to max-value, allowedCharacters.Length does not need - 1 (because it does not include the complete length)
            }

            foreach (var character in codeCharacters) //As generating the password involved breaking the password into a 12 character array then assigning each character, piece together the password in a complete string
            {
                codeGenerated += character; //Add each character into a string version of the password generated
            }

            EmailCode();
        }

        private void EmailCode() //Create an email
        {
            string to, from, pass, messageBody; //Instantiate many strings for use
            MailMessage message = new MailMessage(); //Create a new email message objext
            to = dgv_userData.Rows[0].Cells[3].Value.ToString(); //Send to the email of whichever user is logged in
            from = "connectmajorwork@gmail.com"; //Send email from the connect account
            pass = "Maj0rw()rk";

            //Body for the email to the user
            string username = dgv_userData.Rows[0].Cells[1].Value.ToString();
            messageBody = $"Your temporary code requested for {username} is {codeGenerated}. \n This will be valid until you reset your password in which case it will be removed. Otherwise, you can log-in to your actual account and under 'My Profile', and select remove pending validation code.";
            //Send the email to the current user's email address
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Reset CONNECT account password";
            message.IsBodyHtml = true;

            //Use SMTP client to execute sending
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass); //Login to email

            smtp.Send(message); //Send email
            Cursor.Current = Cursors.Default; //Once the email has been sent, user no longer has to wait so visually indicate by returning cursor to normal
            MessageBox.Show("Email Sent Successfully", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txt_user_Click(object sender, EventArgs e)
        {
            if (txt_user.Text == "Email/Username") //Only revert format if user has not entered new input
            {
                txt_user.Text = "";
            }
        }

        private void txt_user_Leave(object sender, EventArgs e)
        {
            if (txt_user.Text == "") //Only revert format if user has not entered new input
            {
                txt_user.Text = "Email/Username";
            }
        }

        private void txt_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) //Prevent user entering space as a username (data validation)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 39) //Prevent user entering ' (as the SQL command thinks its end of parameter)
            {
                e.Handled = true;
            }
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {
            if (txt_user.Text != "Email/Username")
            {
                //Ensure if user copy and pastes, not ' or spaces
                txt_user.Text = txt_user.Text.Replace(" ", "");
                txt_user.Text = txt_user.Text.Replace("'", "");
            }
        }
    }
}
