using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Can connect to cloud database

namespace major_nav
{
    public partial class frm_newPassword : Form
    {
        //This public variables is set when the user logins in and store which user is currently logged in
        public static string user = "";

        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //String to connect and log in to cloud database

        private frm_forgetPassword forgetPasswordForm; //Create a form reference so that the forgetPassword form can be closed once new password created

        public frm_newPassword(Form callingForm)
        {
            InitializeComponent();
            forgetPasswordForm = callingForm as frm_forgetPassword;
            Setup();
        }

        private void Setup()
        {
            txt_user.Text = user; //Set username to user that has requested password reset
            PopulateWithUserInfo();
        }

        private void PopulateWithUserInfo() //Fill with their information
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get user information for use
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username='{user}'";

            //Execute command to find rows which match username
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);

            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            //Place this data in datagrid view for use
            dgv_userReset.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }


        private void txt_password_Click_1(object sender, EventArgs e)
        {
            if (txt_password.Text == "New Password") //Only revert format if user has not entered new input
            {
                txt_password.Text = "";
                txt_password.UseSystemPasswordChar = true; //As user starts typing, hide password
            }
        }

        private void txt_password_Leave_1(object sender, EventArgs e)
        {
            if (txt_password.Text == "") //Only revert format if user has not entered new input
            {
                txt_password.Text = "New Password";
                txt_password.UseSystemPasswordChar = false; //If no password has been entered then return to showing show password label
            }
        }

        private void btn_register_generatePass_Click(object sender, EventArgs e)
        {
            txt_password.UseSystemPasswordChar = true; //As password now shown, hide it
            GeneratePassword();
        }

        private void GeneratePassword() //Randomly generate a password
        {
            string passwordGenerated = ""; //Reset the password string to empty (prevent the password just being added on to)
            Random randomIndex = new Random(); //Initialize random number function to create a random index (which is used to choose a random character from the allowed characters)

            string allowedCharacters = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-"; //These are the characters the password can be created from
            char[] passwordCharacters = new char[12]; //Create a character array for the password that is 12 characters long

            for (int i = 0; i < 12; i++) //For 12 characters
            {
                passwordCharacters[i] = allowedCharacters[randomIndex.Next(0, allowedCharacters.Length)]; //For each character in the password array (1-12), choose a random number between 0 and the length of the allowed characters.
                //NOTE: Because Random.Next goes from min-value to max-value, allowedCharacters.Length does not need - 1 (because it does not include the complete length)
            }

            foreach (var character in passwordCharacters) //As generating the password involved breaking the password into a 12 character array then assigning each character, piece together the password in a complete string
            {
                passwordGenerated += character; //Add each character into a string version of the password generated
            }

            txt_password.Text = passwordGenerated; //Insert the randomly generated password string into the textbox
        }

        private void txt_oneTimeCode_Click(object sender, EventArgs e)
        {
            if (txt_oneTimeCode.Text == "One-Time Code") //Only revert format if user has not entered new input
            {
                txt_oneTimeCode.Text = "";
            }
        }

        private void txt_oneTimeCode_Leave(object sender, EventArgs e)
        {
            if (txt_oneTimeCode.Text == "") //Only revert format if user has not entered new input
            {
                txt_oneTimeCode.Text = "One-Time Code";
            }
        }

        private void btn_resetPassword_Click(object sender, EventArgs e)
        {
            string usersCode = dgv_userReset.Rows[0].Cells[4].Value.ToString(); //Contain the correct temporary code for the user (needed to reset the password)
            //Ensure that the user has filled out all the fields
            if (txt_oneTimeCode.Text == "" || txt_oneTimeCode.Text == "One-Time Code" || txt_password.Text == "Password" || txt_password.Text =="")
            {
                MessageBox.Show($"Please complete all fields (none can be default).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Ensure that the code is valid before checking
            else if (txt_oneTimeCode.TextLength < 4)
            {
                    MessageBox.Show($"Code must be 4 numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //If the user has entered the wrong oneTime code then it won't match the one stored in the database
            else if (txt_oneTimeCode.Text != usersCode)
            {
                MessageBox.Show($"Invalid code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //If user has successfully entered the temporary code, then update their password and deactive the temporary code
            {
                ChangePassword(); //Change password
                MessageBox.Show("Password successfully changed. Your temporary code has now been reset. Please log-in with new details.", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                forgetPasswordForm.CloseForget(); //Close the fogotPassword form called before this form (to return to the login screen)
                Close(); //Close this form
            }
        }

        private void ChangePassword() //Reupdate the user's password
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Reset the user's security code and insert their new password
            sqlcommand2.CommandText = $"UPDATE Users SET securityCode='', password='{txt_password.Text}' WHERE username='{txt_user.Text}'";
            //Execute command 
            sqlcommand2.ExecuteNonQuery();
            //Close connection with cloud server
            con.Close();
        }

        private void lbl_return_Click(object sender, EventArgs e)
        {
            //Return to the forget password form if desired
            Close();
        }


        private void btn_showPass_MouseEnter(object sender, EventArgs e)
        {
            if (txt_password.Text != "New Password") //Only revert format if user has not entered new input
            {
                txt_password.HideSelection = true; //For aeshtetics
                btn_showPass.Text = "HIDE"; //Indicate that the password can he hidden 
                txt_password.UseSystemPasswordChar = false; //Change the textbox to use plain text (hide the password)

            }
        }
         
        private void btn_showPass_MouseLeave(object sender, EventArgs e)
        {
            if (txt_password.Text != "New Password") //Only revert format if user has not entered new input
            {
                btn_showPass.Text = "SHOW"; //Indicate that the password can he hidden 
                txt_password.UseSystemPasswordChar = true; //Change the textbox to use plain text (show the password)

            }
        }
    }

}
