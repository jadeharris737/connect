using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; //Enables the help/user manual PDF to be opened
using MySql.Data.MySqlClient; //Enables cloud database to be connected to
using System.Runtime.InteropServices; //Allows user to move forms

namespace major_nav
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //String to connect and log in to cloud database

        private void btn_exit_Click(object sender, EventArgs e) 
        {
            Application.Exit(); //Exit application
        }

        private void txt_username_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "Username") //Only revert format if user has not entered new input
            {
                txt_username.Text = "";
            }
        }

        private void txt_username_Leave(object sender, EventArgs e)
        {
            if (txt_username.Text == "") //Only revert format if user has not entered new input
            {
                txt_username.Text = "Username";
            }
        }

        private void txt_password_Click_1(object sender, EventArgs e)
        {
            if (txt_password.Text == "Password") //Only revert format if user has not entered new input
            {
                txt_password.Text = "";
                txt_password.UseSystemPasswordChar = true; //If password is default, then hide password as user starts typing
            }
        }

        private void txt_password_Leave_1(object sender, EventArgs e)
        {
            if (txt_password.Text == "") //Only revert format if user has not entered new input
            {
                txt_password.Text = "Password"; //Return to password entry if no password has been entered
                txt_password.UseSystemPasswordChar = false; //If nothing entered then show password title
            }
        }


        private void txt_signup_email_Leave(object sender, EventArgs e)
        {
            if (txt_signup_email.Text == "") //Only revert format if user has not entered new input
            {
                txt_signup_email.Text = "Email";
            }
        }

        private void text_signup_username_Leave(object sender, EventArgs e)
        {
            if (txt_signup_username.Text == "") //Only revert format if user has not entered new input
            {
                txt_signup_username.Text = "Username";
            }
        }
        private void txt_signup_username_Click(object sender, EventArgs e)
        {
            if (txt_signup_username.Text == "Username") //Only revert format if user has not entered new input
            {
                txt_signup_username.Text = "";
            }
        }

        private void txt_signup_password_Click(object sender, EventArgs e)
        {
            if (txt_signup_password.Text == "Password") //Only revert format if user has not entered new input
            {
                txt_signup_password.Text = "";
                txt_signup_password.UseSystemPasswordChar = true; //If the signup password is default, then hide password as user begins typing
            }
        }

        private void txt_signup_password_Leave(object sender, EventArgs e)
        {
            if (txt_signup_password.Text == "") //Only revert format if user has not entered new input
            {
                txt_signup_password.Text = "Password"; //Return to password entry if no password has been entered
                txt_signup_password.UseSystemPasswordChar = false; //If Password label default then show password label
            }
        }

        private void txt_signup_email_Click(object sender, EventArgs e)
        {
            if (txt_signup_email.Text == "Email") //Only revert format if user has not entered new input
            {
                txt_signup_email.Text = "";
            }
        }

        private void cb_EULA_Click(object sender, EventArgs e)
        {
            if (cb_EULA.Checked) //If the EULA checkbox is selected once clicked
            {
                Process.Start("EULA.pdf"); //Open the pdf documentation file stored in the bin > debug folder so that the user can read the EULA
                if (MessageBox.Show("Are you sure you have completely read and agree to EULA?", "Confirmaton", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                { //If they agree, then allow the checkbox to continue being checked
                }
                else
                {
                    cb_EULA.Checked = false; //Deselect and do not allow user to create profile (as they do not agree)
                }
            }
        }


        private void btn_register_generatePass_Click(object sender, EventArgs e)
        {
            txt_signup_password.UseSystemPasswordChar = true; //Now that password is being made, conceal password
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

            txt_signup_password.Text = passwordGenerated; //Insert the randomly generated password string into the textbox
        }

        private void btn_register_passwordShow_MouseEnter(object sender, EventArgs e)
        {
            if (txt_signup_password.Text != "Password") //When the user hovers over the button, if the password is not default
            {
                txt_signup_password.HideSelection = true; //For aeshtetics
                btn_register_passwordShow.Text = "HIDE"; //Indicate that the password can he hidden 
                txt_signup_password.UseSystemPasswordChar = false; //Change the textbox to use plain text (show the password)

            }
        }

        private void btn_register_passwordShow_MouseLeave(object sender, EventArgs e)
        {
            if (txt_signup_password.Text != "Password") //When the user stops hovering over the button, if the password is not default
            {
                btn_register_passwordShow.Text = "SHOW"; //Indicate that the password can be shown
                txt_signup_password.UseSystemPasswordChar = true; //Change the textbox to use password characters (censor the password)
            }
        }

        private void btn_login_passwordShow_MouseEnter(object sender, EventArgs e)
        {
            if (txt_password.Text != "Password") // When the user hovers over the button, if the password is not default
            {
                txt_password.HideSelection = true; //For aeshtetics
                btn_login_passwordShow.Text = "HIDE"; //Indicate that the password can he hidden 
                txt_password.UseSystemPasswordChar = false; //Change the textbox to use plain text (show the password)

            }
        }

        private void btn_login_passwordShow_MouseLeave(object sender, EventArgs e)
        {
            if (txt_password.Text != "Password") // When the user stops hovering over the button, if the password is not default
            {
                btn_login_passwordShow.Text = "SHOW"; //Indicate that the password can be shown
                txt_password.UseSystemPasswordChar = true; //Change the textbox to use password characters (censor the password)
            }
        }

        private void btn_logIn_Click(object sender, EventArgs e)
        {
            LogIn(); 
        }

        private void LogIn()
        {
            //Ensure that all fields are completed
            if (txt_username.Text == "" || txt_password.Text == "" || txt_username.Text == "Username" || txt_password.Text == "Password") //If all of the fields to login are NOT complete
            {
                MessageBox.Show("Please complete all fields (none can be default).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Show user that there is an error
            }
            else
            {
                LogInProcess();
            }
        }

        private void LogInProcess()
        {
            GetLoginDetails(); //Populate the datagridview with their information in order to use their details
            CheckLoginDetails(); //Check the login details (password) of the user against this populated datagridview. If their password matches then check if the user is new and allow them to enter to the system accordingly
            SetLoggedIn(); //Set status in datagridview to loggedin because only one account can be logged in at once
        }

        private void SetLoggedIn() //Set status in datagridview to loggedin because only one account can be logged in at once
        {
            //Establish connection
            MySqlConnection con2 = new MySqlConnection(cs);
            //Open the connection to the database
            con2.Open();

            //Used to create command
            MySqlCommand sqlcommand = new MySqlCommand();
            sqlcommand.Connection = con2;
            sqlcommand.CommandType = CommandType.Text;
            //Set the user to be logged in
            sqlcommand.CommandText = $"UPDATE Users SET loggedIn='true' WHERE username ='{txt_username.Text}'";
            sqlcommand.ExecuteNonQuery();

            //Close connection with cloud server
            con2.Close();
        }

        private void GetLoginDetails()
        {
            string username = txt_username.Text;

            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Select all of the rows where the usernamne (should only be one or none) matches the user attempting to log in
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username='{username}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            //Place this data in datagrid view for use
            dgv_user.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }

        private void CheckLoginDetails()
        {
            //If a user exists with that username (dataGridView would be populated with 1 row where the user=username)
            if (dgv_user.Rows.Count > 1)
            {
                //If the password the user has entered matches the password associated with that user 
                if (txt_password.Text == dgv_user.Rows[0].Cells[2].Value.ToString())
                {
                    if (dgv_user.Rows[0].Cells["loggedIn"].Value.ToString() == "false") //Only if the user isn't already logged in
                    {
                        RedirectUser();
                    }
                    //Otherwise, the user must be logged in elsewhere
                    else
                    {
                        MessageBox.Show("Account already logged in on another machine. Two machines cannot use the same account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                //Otherwise if the user has entered a password and it does not match the one associated with the user, then the password must be incorrect
                else
                {
                    MessageBox.Show("Incorrect password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No user exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RedirectUser()
        {
            //Set variables used in the hub form based off which user logged in here
            SetHubFormsUserVariables();
            CheckIfNew();
        }

        private void SetHubFormsUserVariables()
        {
            //Set variables used in the hub form based off which user logged in here
            frm_nav.username = txt_username.Text;
        }


        private void CheckIfNew()
        {
            //Determine whether the 'new' column for the user is True or False. If it is true then the user is new and should be shown the welcome screen, otherwise they can
            //progress straight to the hub form
            bool newUser = bool.Parse(dgv_user.Rows[0].Cells["new"].Value.ToString());
            if (newUser == true)
            {
                Hide();
                frm_welcomeNewUser.user = txt_username.Text;
                //Show the hub form now as user has successfully logged in
                frm_welcomeNewUser welcomeUserForm = new frm_welcomeNewUser();
                welcomeUserForm.ShowDialog();
            }
            else
            {
                //Redirect to hub
                new frm_nav().Show();
                Hide();
            }

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void Register()
        {
            //Ensure all entries are completed
            if (txt_signup_username.Text == "" || txt_signup_password.Text == "" || txt_signup_email.Text == "" || txt_signup_username.Text == "Username" || txt_signup_password.Text == "Password" || txt_signup_email.Text == "Email")
            {
                MessageBox.Show("Please complete all fields (none can be default).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Ensure the EULA is agreed to
                if (cb_EULA.Checked == false)
                {
                    MessageBox.Show("Please read and agree to EULA to create an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool userExists = CheckIfUserExists(); //Return if the username already exists (and thus prevent)
                    bool emailExists = CheckIfEmailExists(); //Return if the email already exists (and thus prevent)
                    if (txt_signup_username.Text.Length < 4)
                    {
                        MessageBox.Show("Username must be greater than 3 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txt_signup_email.Text.Length < 7)
                    {
                        MessageBox.Show("Email must be greater than 8 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txt_signup_password.Text.Length < 9)
                    {
                        MessageBox.Show("Password must be greater than 8 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (userExists == true)
                    {
                        MessageBox.Show("Username already exists. Please try another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (emailExists == true)
                    {
                        MessageBox.Show("Account already exists associated to this email. Please use another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //Increase likelihood of a valid email
                    else if (!txt_signup_email.Text.Contains('@'))
                    {
                        MessageBox.Show("Please enter valid email address (must contain @).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //Thus, must have passed all checks
                    else 
                    {
                        CreateNewUser();
                    }
                }
            }
        }

        private bool CheckIfEmailExists()
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE email='{txt_signup_email.Text}'";
            //Execute command and recieve data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);

            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);

            //Close connection with cloud server
            con.Close();

            //If there is more than one row in the returned select statement, then a record must have been found (thus email exists)
            if (table2.Rows.Count > 0) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfUserExists()
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username='{txt_signup_username.Text}'";


            //Execute command and recieve data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);

            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);

            //Close connection with cloud server
            con.Close();

            //If there is more than one row in the returned select statement, then a record must have been found (thus user exists)
            if (table2.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void CreateNewUser()
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Select all of the rows where the usernamne (should only be one or none) matches the user attempting to log in (by using the username in txt_username.Text)
            sqlcommand2.CommandText = $"INSERT INTO Users (username, password, email, lastUpdated,new,loggedIn) VALUES ('{txt_signup_username.Text}','{txt_signup_password.Text}','{txt_signup_email.Text}','{DateTime.Now}','true','false')";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();

            //If the user has successfully created new account
            ResetFieldsNowNewUser();
        }


        private void ResetFieldsNowNewUser()
        {
            //Confirmation messaeg
            MessageBox.Show("User successfully created. Use log in with your new credentials or create a new account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Resent controls to create a new user
            txt_signup_username.Text = "Username";
            txt_signup_password.Text = "Password";
            txt_signup_password.UseSystemPasswordChar = false;
            txt_signup_email.Text = "Email";
        }

        private void txt_signup_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) //Prevent user entering space (data validation)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 39) //Prevent user entering ' (as the SQL command thinks its end of parameter)
            {
                e.Handled = true;
            }
        }

        private void txt_signup_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) //Prevent user entering space (data validation)
            {
                e.Handled = true;
            }
        }

        private void txt_signup_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) //Prevent user entering space (data validation)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 39) //Prevent user entering ' (as the SQL command thinks its end of parameter)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                //If the enter key is pressed, then automatically attempt to signup
                Register();
            }
        }

        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) //Prevent user entering space (data validation)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 39) //Prevent user entering ' (as the SQL command thinks its end of parameter)
            {
                e.Handled = true;
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) //Prevent user entering space (data validation)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                //If the enter key is pressed, then automatically attempt to login
                LogIn();
            }
        }

        private void lbl_forgotPassword_Click(object sender, EventArgs e)
        {
            //If the user has entered a username, then send that username to the forget username form (so user doesn't have to re-enter)
            if (txt_username.Text != "" && txt_username.Text != "Username")
            {
                //Set variable which holds username in the forgetPassword form
                frm_forgetPassword.user = txt_username.Text;
            }
            frm_forgetPassword forgetPassword = new frm_forgetPassword();
            //Show the forget password form
            forgetPassword.ShowDialog();
        }


        //Allow form to be dragged
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] //Import external User32 windows DLL: causes mouse to let go of any other forms
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")] //Import external User32 windows DLL: sends message to window/windows
        private extern static void SendMessage(IntPtr Window, int WindowsMessage, int AdditionalParameter1, int AdditionalParameter2);


        private void frm_login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture(); //Provide drag functionality when there is no border on the form
            SendMessage(Handle, 0x112, 0xf012, 0);
            //Send message to the windows to drag by passing the window that the control is attached to
            //Handle refers to window (the application) selected
            //0x112 is message when user choses command from windows menu
            //0xf012 refers to use of window menu/topbar specifically
            //0 means no other parameter
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            //Open the pdf documentation file stored in the bin > Debug folder to provide the user with help
            Process.Start("userManual.pdf");
        }

        private void button1_Click(object sender, EventArgs e) //DEBUG TOOL 
        {
            try
            {
                MySqlConnection con2 = new MySqlConnection(cs);
                //Open the connection to the database
                con2.Open();

                //Used to create command
                MySqlCommand sqlcommand = new MySqlCommand();
                sqlcommand.Connection = con2;
                sqlcommand.CommandType = CommandType.Text;
                //Select all of the rows where the usernamne (should only be one or none) matches the user attempting to log in (by using the username in txt_username.Text)
                sqlcommand.CommandText = $"UPDATE Users SET loggedIn='false' WHERE username ='{txt_username.Text}'";
                sqlcommand.ExecuteNonQuery();

                //Close connection with cloud server
                con2.Close();
                MessageBox.Show("You can log in now (check username correct)!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            { 
            }
        }

        private void txt_password_TextChanged(object sender, EventArgs e) 
        {
            //When user TAB's into the control, ensure that password is concealed
            if (txt_password.Text != "Password")
            {
                txt_password.UseSystemPasswordChar = true;
            }
            //Ensure if user copy and pastes, not ' or spaces
            txt_password.Text = txt_password.Text.Replace(" ", "");
            txt_password.Text = txt_password.Text.Replace("'", "");
        }

        private void txt_signup_password_TextChanged(object sender, EventArgs e)
        {
            //When user TAB's into the control, ensure that password is concealed
            if (txt_signup_password.Text != "Password")
            {
                txt_signup_password.UseSystemPasswordChar = true;
                //Ensure if user copy and pastes, not ' or spaces
                txt_signup_password.Text = txt_signup_password.Text.Replace(" ", "");
                txt_signup_password.Text = txt_signup_password.Text.Replace("'", "");
            }
        }
    }
}
