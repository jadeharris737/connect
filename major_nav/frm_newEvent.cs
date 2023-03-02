using MySql.Data.MySqlClient; //Can connect to cloud database
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace major_nav
{
    public partial class frm_newEvent : Form
    {
        //String to connect to the database
        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work";
        //Store user logged in
        public static string username;
        //Create a form reference so that the myevents datagridview can be updated with this new event (once created)
        private frm_myEvents eventsForm;

        public frm_newEvent(Form callingForm)
        {
            InitializeComponent();
            eventsForm = callingForm as frm_myEvents;

            SetupForm();
        }

        private void SetupForm()
        {
            PopulateUser(); //Get the user's information
            SetDefaultTimeOptions(); //Set the default time/date options and RSVP
            PopulateFriends(); //Populate the list with the user's friends
        }

        private void PopulateUser() //Get information for the user
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get information for user
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username = '{username}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            dgv_user.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }

        private void PopulateFriends()
        {
            //Get all of the user's friends
            string[] friends = dgv_user.Rows[0].Cells["friends"].Value.ToString().Split(',');

            foreach (string user in friends)
            {
                if (user != "") //Providing the user is not ',' (which makes an empty item)
                {
                    cb_users.Items.Add(user); //Add the user to the checkbox list of users, which allow the user to select them
                }
            }
        }

        private void SetDefaultTimeOptions()
        {
            //Set all of the time options to 2 days ahead from the current date, and the RSVP day to 1 day
            //Just as defualt -> REMEMBER the RSVP must be before the actual event is hosed

            DateTime option = DateTime.Now;
            dtp_option1.Value = option;
            dtp_option2.Value = option;
            dtp_option3.Value = option;
            dtp_rsvp.Value = DateTime.Now.AddDays(1);
        }

        private void lbl_return_Click(object sender, EventArgs e) //Allow user to leave form
        {
            Close();
        }

        //If the user tries to enable the second date/time option and the first option has not been selected, then error
        //(done in order of priority - where highest priority of time option is first)
        private void dtp_option2_MouseDown(object sender, MouseEventArgs e)
        {
            if (dtp_option1.Checked == false) //If the FIRST TIME OPTION has not been selected, then error (out of order)
            {
                MessageBox.Show("Must select times in priority", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_option2.Checked = false; //Deselect the option too
            }
            //Otherwise, if the option has been selected with this click,
            //Then set the endtime (if a duration has been set)
            if (dtp_option2.Checked)
            {
                if (txt_duration.Text != "Duration")
                {
                    lbl_endTime2.Text = dtp_option2.Value.AddHours(float.Parse(txt_duration.Text)).ToString();
                }
            }
            else //Otherwise, user must be attmepting to deselect the CURRENT OPTION 
            {
                //Reset the end time to show no time
                lbl_endTime2.Text = "Enable option/set duration";
                //If the third time option has been selected, and the user deselects this second option then out of order
                if (dtp_option3.Checked == true)
                {
                    MessageBox.Show("Must select times in priority", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Deselect that option
                    dtp_option3.Checked = false;
                }
            }
        }
        //If the user tries to enable the third date/time option and the second option has not been selected, then error
        //(done in order of priority - where highest priority of time option is first)
        //This can be checked solely on the second option because the second option can only be selected if the first option is
        private void dtp_option3_MouseDown(object sender, MouseEventArgs e)
        {
            if (dtp_option2.Checked == false) //If other checkbox is not selected, then incorrect (in priority order)
            {
                MessageBox.Show("Must select times in priority", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Do not allow user to check this option (deselect)
                dtp_option3.Checked = false;
            }
            //Otherwise, if the option has been selected with this click,
            //Then set the endtime (if a duration has been set)
            if (dtp_option3.Checked)
            {
                if (txt_duration.Text != "Duration")
                {
                    lbl_endTime3.Text = dtp_option3.Value.AddHours(float.Parse(txt_duration.Text)).ToString();
                }
            }
            //Otherwise, user must be attmepting to deselect the CURRENT OPTION 
            else
            {
                lbl_endTime3.Text = "Enable option/set duration";
            }

        }

        private void dtp_option1_MouseDown(object sender, MouseEventArgs e)
        {
            if (dtp_option1.Checked == false) //If the user is attempting to deselect the first option
            {
                //If either option is selected, then reset both (because if second option is deselected, then the third must be as well
                if (dtp_option2.Checked == true || dtp_option3.Checked == true) 
                {
                    MessageBox.Show("Must select times in priority", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtp_option2.Checked = false;
                    dtp_option3.Checked = false;
                }
                txt_duration.Enabled = false; //Do not allow user to set duration if no options avaliable
                txt_duration.Text = "Duration";

                ResetAllEndTimes(); //As now no options are selected, reset the end times
            }
            else
            {
                //Otherwise, the first option is beign selected for the first time so let user set duration
                txt_duration.Enabled = true;
            }
        }

        private void ResetAllEndTimes() //Clear all end times
        {
            lbl_endTime1.Text = "Enable option/set duration";
            lbl_endTime2.Text = "Enable option/set duration";
            lbl_endTime3.Text = "Enable option/set duration";
        }


        private void cb_users_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (cb_users.CheckedItems.Count == 20 && e.CurrentValue == CheckState.Unchecked)
            {
                MessageBox.Show("Maximum of 20 friends can be invited.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.NewValue = e.CurrentValue; //Do not select
            }
        }
        //When the user enters the textbox, set to the text and when they leave, if it is empty revert it back
        private void txt_eventDescription_Click(object sender, EventArgs e)
        {
            if (txt_description.Text == "Short Description")
            {
                txt_description.Text = "";
            }
        }
        private void txt_eventDescription_Leave(object sender, EventArgs e)
        {
            if (txt_description.Text == "")
            {
                txt_description.Text = "Short Description";
            }
        }

        //When the user enters the textbox, set to the text and when they leave, if it is empty revert it back
        private void txt_eventName_Click(object sender, EventArgs e)
        {
            if (txt_eventName.Text == "Event Name")
            {
                txt_eventName.Text = "";
            }
        }
        private void txt_eventName_Leave(object sender, EventArgs e)
        {
            if (txt_eventName.Text == "")
            {
                txt_eventName.Text = "Event Name";
            }
        }

        //When the user enters the textbox, set to the text and when they leave, if it is empty revert it back
        private void txt_cost_Click(object sender, EventArgs e)
        {
            if (txt_cost.Text == "Cost")
            {
                txt_cost.Text = "";
            }
        }
        private void txt_cost_Leave(object sender, EventArgs e)
        {
            if (txt_cost.Text == "")
            {
                txt_cost.Text = "Cost";
            }
        }

        //When the user enters the textbox, set to the text and when they leave, if it is empty revert it back
        private void txt_duration_Click(object sender, EventArgs e)
        {
            if (txt_duration.Text == "Duration")
            {
                txt_duration.Text = "";
            }
        }
        private void txt_duration_Leave(object sender, EventArgs e)
        {
            if (txt_duration.Text == "")
            {
                txt_duration.Text = "Duration";
            }
        }

        //Whenever the duration is changed by the user, then auto update the end time
        private void txt_duration_TextChanged_1(object sender, EventArgs e)
        {
            //If the duration is being changed to something that is not default or empty
            if (txt_duration.Text != "Duration" && txt_duration.Text != "")
            {
                //Can assume as duration is only enabled if the first time option is enabled
                lbl_endTime1.Text = dtp_option1.Value.AddHours(float.Parse(txt_duration.Text)).ToString();
                if (dtp_option2.Checked) //If the second option exists (thus has end time), then update that end time
                {
                    lbl_endTime2.Text = dtp_option2.Value.AddHours(float.Parse(txt_duration.Text)).ToString();
                }
                if (dtp_option3.Checked)//If the third option exists (thus has end time), then update that end time
                {
                    lbl_endTime3.Text = dtp_option3.Value.AddHours(float.Parse(txt_duration.Text)).ToString();
                }
            }
            else //Otherwise, it must be changed to an empty condition, thus reset all of the end times
            {
                lbl_endTime1.Text = "Enable option/set duration";
                if (dtp_option2.Checked)
                {
                    lbl_endTime2.Text = "Enable option/set duration";
                }
                if (dtp_option3.Checked)
                {
                    lbl_endTime3.Text = "Enable option/set duration";
                }
            }
        }

        private void btn_createEvent_Click(object sender, EventArgs e) //Create the new event providing its valid
        {
            bool valid = CheckAllComplete(); //Check that all of the fields are valid and complete (not default)
           //If the event was valid, then turn the data inputted into the fields into strings that can be put into
           //the database and manipulated
            if (valid == true) 
            {
                CreateUserString(); //Concatenate users
                CreateLocationString(); //Concatenate location options with the host's own vote
                CreateStartTimeString(); //Concatenate date options with the host's own vote
                CreateEndTimeString(); //Concatenate end time options with the host's own vote
                AddEvent(); //Insert the event into database
                AddEventToInvitee();//Add this event to each invitee's lsit of events they are invited to
                ReturnToForm(); //Return to the myevents form (with this event added)
                //Confirmation
                MessageBox.Show($"Successfully sent invites for {txt_eventName.Text}.", "Invites Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReturnToForm()
        {
            Close();
            eventsForm.PopulateWithMyEvents(); //Update the datagridview with this new event
        }

        private bool CheckAllComplete()
        {
            string message = ""; //Store what message will be sent
            int check = 0; //Store if the current fields pass each check
            if (txt_eventName.Text != "" && txt_eventName.Text != "Event Name") //Firstly, check if not default
            {
                bool exists = CheckIfEventExists(); //If it isn't default, then check if an event is already caleld this
                if (exists == false)
                {
                    check++; //If it is unique, then passes check
                }
                else //Otherwise, reset check and tell user it failed
                {
                    check = 0;
                    message = "Event name already exists. Please create a new name.";
                }
            }
            if (txt_cost.Text != "" && txt_cost.Text != "Cost") //Check if not default
            {
                check++;
            }
            else
            {
                check = 0;
                message = "Cost cannot be empty or default.";
            }
            if (txt_duration.Text != "" && txt_duration.Text != "Duration")  //Check if not default
            {
                check++;
            }
            else
            {
                check = 0;
                message = "Duration cannot be empty or default.";
            }
            if (txt_description.Text != "" && txt_description.Text != "Duration")  //Check if not default
            {
                check++;
            }
            else
            {
                check = 0;
                message = "Description cannot be empty or default.";
            }
            if (cb_users.CheckedItems.Count > 0) //Check that user has at least one user selected to invite
            {
                check++;
            }
            else
            {
                check = 0;
                message = "Must have at least one friend attending (selected).";
            }
            //Depending on if any of these conditions are fulfilled
            //Ensure that the location names are all unique
            //Further, because if any locations are default then nothing will be added, ensure that at least the first text isn't default
            if (txt_location1.Text != "Location Priority 1" && ((txt_location1.Text != txt_location2.Text) && (txt_location2.Text != txt_location3.Text) && (txt_location1.Text != txt_location3.Text)) && (txt_location1.Text != "" && txt_location2.Text != "" && txt_location3.Text != ""))
            {
                check++;
            }
            else
            {
                check = 0;
                message = "Must have at least one location not default and cannot be the same location name.";
            }

            //Extract the data from the components
            DateTime option1 = DateTime.ParseExact(dtp_option1.Value.ToString(), "d/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime option2 = DateTime.ParseExact(dtp_option2.Value.ToString(), "d/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime option3 = DateTime.ParseExact(dtp_option3.Value.ToString(), "d/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            DateTime rsvp = DateTime.ParseExact(dtp_rsvp.Value.ToString(), "d/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

            //According to each case, ensure that RSVP is after the option/s that are selected (which is determined by if the time is checked)
            if ((rsvp < option1 && !dtp_option2.Checked && !dtp_option3.Checked) || (rsvp < option2 && rsvp < option1 && !dtp_option3.Checked) || (rsvp < option1 && rsvp < option2 && rsvp < option3))
            {
                check++;

            }
            else
            {
                check = 0;
                message = "RSVP time cannot be set after the event is scheduled.";
            }

            //If both option2 and option3 are disabled, then it won't have to be checked against option1 (nothing else it can match with)
            if (!dtp_option2.Checked && !dtp_option3.Checked)
            {
                check++;
            }
            //Otherwise, ensure options don't match according to how many are checked
            else if ((dtp_option1.Value.ToString() != dtp_option2.Value.ToString()) && !dtp_option3.Checked)
            {
                check++;
            }
            //Otherwise, ensure options don't match according to how many are checked
            else if ((dtp_option1.Value.ToString() != dtp_option2.Value.ToString()) && (dtp_option2.Value.ToString() != dtp_option3.Value.ToString()) && (dtp_option1.Value.ToString() != dtp_option3.Value.ToString()))
            {
                check++;
            }
            else
            {
                check = 0;
                message = "Must have one time and date selected and cannot be the same value.";
            }

            //If the form passes all of the checks
            if (check == 8)
            {
                return true; //Then let user create new event
            }
            else
            {
                //Otherwise, show user specific message
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CheckIfEventExists()
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get any events that match the event name
            sqlcommand2.CommandText = $"SELECT * FROM Events WHERE eventName='{txt_eventName.Text}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);

            //Close connection with cloud server
            con.Close();

            if (table2.Rows.Count > 0) //If an event does exist (result returned)
            {
                return true; //Then event already exists
            }
            else
            {
                return false; //Then no event exists
            }
        }

        private void AddEventToInvitee()
        {
            foreach (string invitee in cb_users.CheckedItems)
            {
                PopulateInvitee(invitee);
                //List more readable to work with when deleting elements
                List<string> invitationIDs = dgv_invitee.Rows[0].Cells["invitationIDs"].Value.ToString().Split(',').ToList();
                invitationIDs.Add(txt_eventName.Text);
                string updatedInvitationIDs = "";

                foreach (string ID in invitationIDs) //Recreate string to be inserted back into the table except without the user
                {
                    if (ID != "")
                    {
                        updatedInvitationIDs += ID + ",";
                    }
                }

                //Establish connection
                MySqlConnection con2 = new MySqlConnection(cs);
                //Open the connection to the database
                con2.Open();

                //Used to create command
                MySqlCommand sqlcommand = new MySqlCommand();
                sqlcommand.Connection = con2;
                sqlcommand.CommandType = CommandType.Text;
                //Select all of the rows where the usernamne (should only be one or none) matches the user attempting to log in (by using the username in txt_username.Text)
                sqlcommand.CommandText = $"UPDATE Users SET invitationIDs='{updatedInvitationIDs}' WHERE username ='{invitee}'";
                sqlcommand.ExecuteNonQuery();

                //Close connection with cloud server
                con2.Close();
            }
        }

        private void PopulateInvitee(string user) //Get information for the user that is invited
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get information
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username = '{user}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            dgv_invitee.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }

        //Concatenate the time options into a string with the priority attached to it
        string startTimeOptions = ""; 
        private void CreateStartTimeString() //Add time and its priority in [] (lowest will be chosen -> highest priority gets a 1 added)
        {
            startTimeOptions += dtp_option1.Value.ToString() + "[1],";
            if (dtp_option2.Checked)
            {
                startTimeOptions += dtp_option2.Value.ToString() + "[2],";
            }
            if (dtp_option3.Checked)
            {
                startTimeOptions += dtp_option3.Value.ToString() + "[3],";
            }
        }

        string endTimeOptions = "";
        private void CreateEndTimeString() //Concatenate the end times with their priorities
        {
            endTimeOptions += lbl_endTime1.Text + "[1],";
            if (dtp_option2.Checked)
            {
                endTimeOptions += lbl_endTime2.Text + "[2],";
            }
            if (dtp_option3.Checked)
            {
                endTimeOptions += lbl_endTime3.Text + "[3],";
            }
        }

        //Concatenate the location options into a string with the priority attached to it
        string locations = "";
        private void CreateLocationString() //Add location and the priority in [] (lowest will be chosen -> highest priority gets a 1 added)
        {
            locations += $"{txt_location1.Text}[1],";
            if (txt_location2.Text != "" && txt_location2.Text != "Location Priority 2")
            {
                locations += $"{txt_location2.Text}[2],";
            }
            if (txt_location3.Text != "" && txt_location3.Text != "Location Priority 3")
            {
                locations += $"{txt_location3.Text}[3],";
            }
        }

        string users = ""; //Create string of users that were invited (by adding all of the selected friends in the checkbox)
        private void CreateUserString()
        {
            for (int i = 0; i < cb_users.SelectedItems.Count; i++)
            {
                users += cb_users.SelectedItems[i] + ","; //Add a comma to separate each user
            }
        }

        private void AddEvent()
        {
            //Set the current RSVP value to a string to store
            string rsvp = dtp_rsvp.Value.ToString();
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Add all of the strings as a new event
            sqlcommand2.CommandText = $"INSERT INTO Events (owner,eventName,eventDescription,invitees,status,lastUpdated,eventLocation,eventTime,eventDuration,eventEnd,cost,rsvp) VALUES ('{username}', '{txt_eventName.Text}', '{txt_description.Text}', '{users}', 'Pending', '{DateTime.Now.ToString()}', '{locations}', '{startTimeOptions}', '{txt_duration.Text}', '{endTimeOptions}','{txt_cost.Text}','{rsvp}')";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        int decimalDigits = 0;
        bool decimalPoint = false;
        private void txt_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22) //Prevent user using CNTRL key so that they can't paste text with a "'" in it
            {
                e.Handled = true;
            }
            if (e.KeyChar == 39) //Prevent user entering ' (as the SQL command thinks its end of parameter)
            {
                e.Handled = true;
            }
            // Allow decimal (float) numbers and up to 2 decimal points after it
            //This is achieved by checking if a dot is being entered and if so, if the index of a '.' exists in the textbox
            //then handle the decimal point (prevent it from entering the textbox) as a decimal point already exists
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            //Changes decimal point to false only when decimal point is hit. This is used instead of an else below the above 'if' statement
            //because it which would trigger if anything except for a '.' was used
            if (e.KeyChar == '.')
            {
                decimalPoint = true;
            }

            // Verify that the pressed key isn't CTRL or any non-numeric digit

            //<= 1 rather than <= 2 because first time it runs, checks against 0 and second time will check against decimalDigits = 1
            //the || e.KeyChar here allows backspace to be used
            if (decimalDigits <= 1 || e.KeyChar == (char)Keys.Back)
            {
                //If the character is NOT a backspace (control character), digit or a '.', then handle the character (prevent it from entering the textbox) - this is NOT because of the ! before each condition
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
                else //If the character IS either a backspace, digit or '.'
                {
                    //If decimal point has been set to true (a decimal point has been entered in the control) but the entered digit is NOT the decimal point
                    //itself, it must be a decimal number so increment the number of decimal digits (this is used to check that <= 2 decimal places are entered
                    if (decimalPoint == true && e.KeyChar != '.')
                    {
                        decimalDigits++;
                    }
                }
            }
            else //If there are >= 1 decimal digit already (already reached 2 decimal places) or the key was not a backspace, then handle the character (prevent it from entering the textbox)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Back) //If the key pressed was the backspace
            {
                //Then if decimal point is true (a decimal point has been entered) and the textbox (not including the number which is being deleted indicated by length - 1) contains a decimal point
                if (decimalPoint == true && txt_cost.Text.Substring(0, txt_cost.Text.Length - 1).Contains(".") == true)
                {
                    //Then user must be backspacing the final number (which is a decimal place) so remove a decimal digit
                    decimalDigits -= 2;
                }
                //If the textbox is empty, handle the backspace
                else if (txt_cost.Text == "")
                {
                    e.Handled = true;
                }
                //Because otherwise take last character must have the decimal point in it
                else if (txt_cost.Text.Substring(0, txt_cost.Text.Length - 1).Contains(".") == false)
                {
                    //The decimal point must have been removed so set the text box as no longer having a decimal point, and now there are no deimal places
                    decimalPoint = false;
                    decimalDigits = 0;
                }
            }
        }

        int decimalDigits2 = 0;
        bool decimalPoint2 = false;
        private void txt_duration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22) //Prevent user using CNTRL key so that they can't paste text with a "'" in it
            {
                e.Handled = true;
            }
            if (e.KeyChar == 39) //Prevent user entering ' (as the SQL command thinks its end of parameter)
            {
                e.Handled = true;
            }
            // Allow decimal (float) numbers and up to 2 decimal points after it
            //This is achieved by checking if a dot is being entered and if so, if the index of a '.' exists in the textbox
            //then handle the decimal point (prevent it from entering the textbox) as a decimal point already exists
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            //Changes decimal point to false only when decimal point is hit. This is used instead of an else below the above 'if' statement
            //because it which would trigger if anything except for a '.' was used
            if (e.KeyChar == '.')
            {
                decimalPoint2 = true;
            }

            // Verify that the pressed key isn't CTRL or any non-numeric digit

            //<= 1 rather than <= 2 because first time it runs, checks against 0 and second time will check against decimalDigits = 1
            //the || e.KeyChar here allows backspace to be used
            if (decimalDigits2 <= 1 || e.KeyChar == (char)Keys.Back)
            {
                //If the character is NOT a backspace (control character), digit or a '.', then handle the character (prevent it from entering the textbox) - this is NOT because of the ! before each condition
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
                else //If the character IS either a backspace, digit or '.'
                {
                    //If decimal point has been set to true (a decimal point has been entered in the control) but the entered digit is NOT the decimal point
                    //itself, it must be a decimal number so increment the number of decimal digits (this is used to check that <= 2 decimal places are entered
                    if (decimalPoint2 == true && e.KeyChar != '.')
                    {
                        decimalDigits2++;
                    }
                }
            }
            else //If there are >= 1 decimal digit already (already reached 2 decimal places) or the key was not a backspace, then handle the character (prevent it from entering the textbox)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Back) //If the key pressed was the backspace
            {
                //Then if decimal point is true (a decimal point has been entered) and the textbox (not including the number which is being deleted indicated by length - 1) contains a decimal point
                if (decimalPoint2 == true && txt_cost.Text.Substring(0, txt_cost.Text.Length - 1).Contains(".") == true)
                {
                    //Then user must be backspacing the final number (which is a decimal place) so remove a decimal digit
                    decimalDigits2 -= 2;
                }
                //If the textbox is empty, handle the backspace
                else if (txt_cost.Text == "")
                {
                    e.Handled = true;
                }
                //Because otherwise take last character must have the decimal point in it
                else if (txt_cost.Text.Substring(0, txt_cost.Text.Length - 1).Contains(".") == false)
                {
                    //The decimal point must have been removed so set the text box as no longer having a decimal point, and now there are no deimal places
                    decimalPoint2 = false;
                    decimalDigits2 = 0;
                }
            }
        }
        //When the user changes the value of the option, if a duration is set (not default or empty)
        //then change the end time of the event accordingly
        private void dtp_option1_ValueChanged(object sender, EventArgs e)
        {
            if (txt_duration.Text != "Duration" && txt_duration.Text != "")
            {
                lbl_endTime1.Text = dtp_option1.Value.AddHours(float.Parse(txt_duration.Text)).ToString();
            }
        }
        //When the user changes the value of the option, if a duration is set (not default or empty)
        //then change the end time of the event accordingly
        private void dtp_option2_ValueChanged(object sender, EventArgs e)
        {
            if (txt_duration.Text != "Duration" && txt_duration.Text != "")
            {
                lbl_endTime2.Text = dtp_option2.Value.AddHours(float.Parse(txt_duration.Text)).ToString();
            }
        }
        //When the user changes the value of the option, if a duration is set (not default or empty)
        //then change the end time of the event accordingly
        private void dtp_option3_ValueChanged(object sender, EventArgs e)
        {
            if (txt_duration.Text != "Duration" && txt_duration.Text != "")
            {
                //Add duration to the option to get an end time
                lbl_endTime3.Text = dtp_option3.Value.AddHours(float.Parse(txt_duration.Text)).ToString();
            }
        }

        //When the user enters the textbox, set to the text and when they leave, if it is empty revert it back
        private void txt_location1_Click(object sender, EventArgs e)
        {
            if (txt_location1.Text == "Location Priority 1")
            {
                txt_location1.Text = "";
            }
        }
        private void txt_location1_Leave(object sender, EventArgs e)
        {
            if (txt_location1.Text == "")
            {
                txt_location1.Text = "Location Priority 1";
            }
        }

        //When the user enters the textbox, set to the text and when they leave, if it is empty revert it back
        private void txt_location2_Click(object sender, EventArgs e)
        {
            if (txt_location2.Text == "Location Priority 2")
            {
                txt_location2.Text = "";
            }
        }
        private void txt_location2_Leave(object sender, EventArgs e)
        {
            if (txt_location2.Text == "")
            {
                txt_location2.Text = "Location Priority 2";
            }
        }

        //When the user enters the textbox, set to the text and when they leave, if it is empty revert it back
        private void txt_location3_Click(object sender, EventArgs e)
        {
            if (txt_location3.Text == "Location Priority 3")
            {
                txt_location3.Text = "";
            }
        }

        private void txt_location3_Leave(object sender, EventArgs e)
        {
            if (txt_location3.Text == "")
            {
                txt_location3.Text = "Location Priority 3";
            }
        }

        private void txt_eventName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39) //Prevent user entering ' (as the SQL command thinks its end of parameter)
            {
                e.Handled = true;
            }
        }

        private void txt_description_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39) //Prevent user entering ' (as the SQL command thinks its end of parameter)
            {
                e.Handled = true;
            }
        }

        private void txt_location1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39) //Prevent user entering ' (as the SQL command thinks its end of parameter)
            {
                e.Handled = true;
            }

        }

        private void txt_location2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39) //Prevent user entering ' (as the SQL command thinks its end of parameter)
            {
                e.Handled = true;
            }
        }

        private void txt_location3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39) //Prevent user entering ' (as the SQL command thinks its end of parameter)
            {
                e.Handled = true;
            }
        }
    }

}
