using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Can connect to cloud database

namespace major_nav
{
    public partial class frm_invitationVote : Form
    {
        //Connection string to login the database
        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work";
        //Stores which user is logged in
        public static string username;
        //Stores which event is being managed (selected before being clicked)
        public static string eventName;

        private frm_invitation invitationForm; //Create a form reference so that the form can be reset once the person has officially joined the event

        public frm_invitationVote(Form callingForm)
        {
            InitializeComponent();
            invitationForm = callingForm as frm_invitation;

            SetupForm();

        }

        private void SetupForm()
        {
            PopulateEvent(); //Get information for the selected event
            PopulateUser(); //Get information for the user
            FillWithInfo(); //Fill the form with this information
            SetEndTimes(); //Display the end times for the event
        }


        private void PopulateEvent() //Get information for the event that is selected
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get information for event
            sqlcommand2.CommandText = $"SELECT * FROM Events WHERE eventName = '{eventName}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            dgv_eventData.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }

        private void PopulateUser()
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username = '{username}'";

            //Execute command to find rows which match username
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);

            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            dgv_userData.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }


        private void FillWithInfo() //Fill the form with information for the invite
        {
            txt_duration.Text = dgv_eventData.Rows[0].Cells["eventDuration"].Value.ToString(); //Display the duration of the event

            if (dgv_eventData.Rows[0].Cells["eventTime"].Value.ToString() != "") //If there are event time options (not empty)
            {
                //Get all the options for the day and time by splitting the string that contains them by a ','
                string[] dayTime = dgv_eventData.Rows[0].Cells["eventTime"].Value.ToString().Split(',');

                //Because events must be created with at least one option, assume first exists
                //Display the first option -> cut off at the [ so that the user can't see the number of votes allocated to it
                lbl_timeDate_option1.Text = dayTime[0].Substring(0, dayTime[0].IndexOf("[")); //cut string at [
                //Then, allow the user to choose the priority of this option (using the button)
                btn_timeDate_option1.Enabled = true;
                //Immediately, this is option 1 (just aesthetics -> user can then toggle for their desired preference)
                btn_timeDate_option1.Text = "1";

       
                try 
                {
                    //If an error is not thrown when that daytime option is selected (because no option exists so a substring can't be made)
                    //then set the textbox to that option and allow user to select their priority
                    lbl_timeDate_option2.Text = dayTime[1].Substring(0, dayTime[1].IndexOf("["));
                    btn_timeDate_option2.Enabled = true;
                    btn_timeDate_option2.Text = "2";
                    //Because now there are more possible priority options that the buttons can be toggled to, change number (else default 1)
                    maxTimeOption = 2;
                }
                //Otherwise, prevent error by having an empty catch (leaves button disabled and text saying NO OPTION SET) - indicating event doesn't have option
                catch
                {
                }
                try
                {
                    //If an error is not thrown when that daytime option is selected (because no option exists so a substring can't be made)
                    //then set the textbox to that option and allow user to select their priority
                    lbl_timeDate_option3.Text = dayTime[2].Substring(0, dayTime[2].IndexOf("["));
                    btn_timeDate_option3.Enabled = true;
                    btn_timeDate_option3.Text = "3";
                    //Because now there are more possible priority options that the buttons can be toggled to, change number (else default 1)
                    maxTimeOption = 3;
                }
                //Otherwise, prevent error by having an empty catch (leaves button disabled and text saying NO OPTION SET) - indicating event doesn't have option
                catch
                {
                }
              
            }

            //As follows from above
            if (dgv_eventData.Rows[0].Cells["eventLocation"].Value.ToString() != "") //If options for the event location exist
            {
                //Split the cell of data for the event locations at the ","
                string[] location = dgv_eventData.Rows[0].Cells["eventLocation"].Value.ToString().Split(',');

                //Able to assume that one option already exists, populate the first textbox with the option (chopping the vote off)
                lbl_location_option1.Text = location[0].Substring(0, location[0].IndexOf("[")); //cut string at [
                //Enable the button so user can make priority preference
                btn_location_option1.Enabled = true;
                //For aesthetics, first preference (user can toggle to change)
                btn_location_option1.Text = "1";
                try
                {
                    //If an error is not thrown when that daytime option is selected (because no option exists so a substring can't be made)
                    //then set the textbox to that option and allow user to select their priority
                    lbl_location_option2.Text = location[1].Substring(0, location[1].IndexOf("["));
                    btn_location_option2.Enabled = true;
                    btn_location_option2.Text = "2";
                    //Because now there are more possible priority options that the buttons can be toggled to, change number (else default 1)
                    maxLocationOption = 2;
                }
                //Otherwise, prevent error by having an empty catch (leaves button disabled and text saying NO OPTION SET) - indicating event doesn't have option
                catch
                {
                }
                try
                {
                    //If an error is not thrown when that daytime option is selected (because no option exists so a substring can't be made)
                    //then set the textbox to that option and allow user to select their priority
                    lbl_location_option3.Text = location[2].Substring(0, location[2].IndexOf("["));
                    btn_location_option3.Enabled = true;
                    btn_location_option3.Text = "3";
                    //Because now there are more possible priority options that the buttons can be toggled to, change number (else default 1)
                    maxLocationOption = 3;
                }
                //Otherwise, prevent error by having an empty catch (leaves button disabled and text saying NO OPTION SET) - indicating event doesn't have option
                catch
                {
                }
            }
        }


        private void SetEndTimes() //Display the end times for the event
        {

            double duration = Double.Parse(txt_duration.Text); //Get the duration set for the event
            if (lbl_timeDate_option1.Text != "NO OPTION SET") //Providing that there is a time option for the according textbox (option is set during fill info)
            {
                //Add the duration to this time option
                lbl_endTime1.Text = DateTime.ParseExact(lbl_timeDate_option1.Text, "d/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture).AddHours(duration).ToString();
            }
            if (lbl_timeDate_option2.Text != "NO OPTION SET")
            {
                lbl_endTime2.Text = DateTime.ParseExact(lbl_timeDate_option2.Text, "d/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture).AddHours(duration).ToString();
            }
            if (lbl_timeDate_option3.Text != "NO OPTION SET")
            {
                lbl_endTime3.Text = DateTime.ParseExact(lbl_timeDate_option3.Text, "d/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture).AddHours(duration).ToString();
            }
        }



        private void lbl_return_Click(object sender, EventArgs e) 
        {
            //Allow user to return to the accept invite form (which they can then return to list of invitations)
            Close();
        }



        private void btn_createEvent_Click(object sender, EventArgs e)
        {
            if ((btn_timeDate_option2.Text == "") || (btn_timeDate_option1.Text != btn_timeDate_option2.Text && btn_timeDate_option3.Text == "") || (btn_timeDate_option1.Text != btn_timeDate_option2.Text && btn_timeDate_option2.Text != btn_timeDate_option3.Text && btn_timeDate_option3.Text != btn_timeDate_option1.Text))
            {
                if ((btn_location_option2.Text == "") || (btn_location_option1.Text != btn_location_option2.Text && btn_location_option3.Text == "") || (btn_location_option1.Text != btn_location_option2.Text && btn_location_option2.Text != btn_location_option3.Text && btn_location_option3.Text != btn_location_option1.Text)) //if the second option
                {
                    ReUpdate(); //Get most relevant information for user and event (incase updated)
                    NewDateTimeVotes(); //Set the new votes for day/time options (with this user)
                    NewLocationVotes(); //Set the new votes for location options (with this user)
                    InsertVotes(); //Insert these new day/time and location votes into the actual database
                    AddUserToAttendees(); //Add user as attending the event now
                    MoveEventToAttending(); //Move the event from the user's list of invited events to the list of users attending events
                    RecordUsersVote();//Add the user's votes to the record of votes
                    invitationForm.ReturnToEvents(); //Trigger the public function in the other form (invitation form) to close
                    ReUpdate_Event(eventName); //Update the event as the users invited/attending have been changed
                    Close(); //Close this form too
                    //Confimration
                    MessageBox.Show($"Successfully accepted invitation and sent votes for {eventName}.", "Invites Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Cannot have two or more location options at the same priority.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Cannot have two or more time/date options at the same button priority.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReUpdate_Event(string eventName)
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Update the time stored in lastUpdated
            sqlcommand2.CommandText = $"UPDATE Events SET lastUpdated='{DateTime.Now}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }


        private void ReUpdate() //Get most relevant information for user and event (incase updated)
        {
            PopulateEvent();
            PopulateUser();
        }

        private void AddUserToAttendees() //Remove user from list of users invited and add to list of users attending
        {
            //Get list of current users invited
            //List more readable to work with when deleting elements
            List<string> invitees = dgv_eventData.Rows[0].Cells["invitees"].Value.ToString().Split(',').ToList();
            //Remove this user from the list of users invited
            invitees.Remove(username);
            string updatedInvitees = "";

            foreach (string user in invitees) //Recreate string to be inserted back into the table except without the user
            {
                if (user != "")
                {
                    updatedInvitees += user + ",";
                }
            }

            //Get the list of current users attending
            //List more readable to work with when deleting elements
            List<string> attendees = dgv_eventData.Rows[0].Cells["attendees"].Value.ToString().Split(',').ToList();
            //Add this user to the list of attendees
            attendees.Add(username);
            string updatedAttendees = "";

            foreach (string user in attendees) //Recreate string to be inserted back into the table with user
            {
                if (user != "")
                {
                    updatedAttendees += user + ",";
                }
            }

            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
           //Update with new attendees and invitees
            sqlcommand2.CommandText = $"UPDATE Events SET attendees='{updatedAttendees}', invitees='{updatedInvitees}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void MoveEventToAttending() //Move the event from the user's list of invited events to the list of users attending events
        {
            //Get list of events that the user is invited to
            //List more readable to work with when deleting elements
            List<string> invitationIDs = dgv_userData.Rows[0].Cells["invitationIDs"].Value.ToString().Split(',').ToList();
            //Remove this event from the list (remove from list of invited events)
            invitationIDs.Remove(eventName);
            string updatedInvitationIDs = "";

            foreach (string event1 in invitationIDs) //Recreate string to be inserted back into the table except without the event
            {
                if (event1 != "")
                {
                    updatedInvitationIDs += event1 + ",";
                }
            }

            //Get list of events that the user is currently attending
            //List more readable to work with when deleting elements
            List<string> eventIDs = dgv_userData.Rows[0].Cells["eventIDs"].Value.ToString().Split(',').ToList();
            //Add this event to that list
            eventIDs.Add(eventName);
            string updatedeventIDs = "";

            foreach (string event1 in eventIDs) //Recreate string to be inserted back into the table with this new event
            {
                if (event1 != "")
                {
                    updatedeventIDs += event1 + ",";
                }
            }

            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Update the user with the new events invited and attending (switched to attending)
            sqlcommand2.CommandText = $"UPDATE Users SET eventIDs='{updatedeventIDs}', invitationIDs='{updatedInvitationIDs}' WHERE username='{username}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }


        private void RecordUsersVote()
        {
            //List more readable to work with when deleting elements
            List<string> votes = dgv_eventData.Rows[0].Cells["recordVotes"].Value.ToString().Split(',').ToList();
            votes.Add($"[{username}]-[{btn_timeDate_option1.Text},{btn_timeDate_option2.Text},{btn_timeDate_option3.Text}]-[{btn_location_option1.Text},{btn_location_option2.Text},{btn_location_option3.Text}]");
            string updatedVotes = "";

            foreach (string user in votes) //Recreate string to be inserted back into the table except without the user
            {
                if (user != "")
                {
                    updatedVotes += user + "|";
                }
            }

            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Select all of the rows where the usernamne (should only be one or none) matches the user attempting to log in (by using the username in txt_username.Text)
            sqlcommand2.CommandText = $"UPDATE Events SET recordVotes='{updatedVotes}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        //Store the string of the new option priorities (to be inserted into the sql by InsertVotes()
        string location_newPriorities;
        private void NewLocationVotes() //Once the user has set their prorities, add this number to the current calculation stored
        {
            //Separate all of the locations (twice because one is for the votes and the other is for the actual options)
            string[] location = dgv_eventData.Rows[0].Cells["eventLocation"].Value.ToString().Split(',');
            string[] location2 = dgv_eventData.Rows[0].Cells["eventLocation"].Value.ToString().Split(',');

            //For each item in the first array, get only the option (cut out [])
            for (int i = 0; i < location.Length - 1; i++) 
            {
                location[i] = location[i].Substring(0, location[i].IndexOf("["));
            }

            //Making all of these into a list and then finding the INDEX of the location desired
            int location_idOfOption1 = location.ToList().IndexOf(lbl_location_option1.Text);

            //After cutting the location list (to get actual option) then get the value of the vote from the second array
            //Which was NOT cut at [
            //Get the VALUE of the priority currently by first finding starting position then length by subtracting position from second character
            string location_currentPriority_option1 = location2[location_idOfOption1].Substring(location2[location_idOfOption1].IndexOf("[") + 1, location2[location_idOfOption1].IndexOf("]") - location2[location_idOfOption1].IndexOf("[") - 1); 
            //Get the NEW VALUE of the specific option by adding this current priority to the value of the button
            //NOTE:  weird way of adding votes means that the option with the lowest number in the [[] has the greatest votes
            string location_newPriority_option1 = (Convert.ToInt32(location_currentPriority_option1) + Convert.ToInt32(btn_location_option1.Text)).ToString();
            //Re-concatenate the option with its new priority
            string location_redone_option1 = $"{lbl_location_option1.Text}[{location_newPriority_option1}],";

            //Because try and catch statement variables are local to the statement, define as empty if try/catch fails (so it can be used)
            string location_redone_option2 = "";
            try
            {
                //If it tries to find location of NO OPTION SET - no index will be found hence try will fail.
                //Otherwise, same process above is followed
                int location_idOfOption2 = location.ToList().IndexOf(lbl_location_option2.Text);
                string location_currentPriority_option2 = location2[location_idOfOption2].Substring(location2[location_idOfOption2].IndexOf("[") + 1, location2[location_idOfOption2].IndexOf("]") - location2[location_idOfOption2].IndexOf("[") - 1); //cut string by first finding starting position then length by subtracting position from second character
                string location_newPriority_option2 = (Convert.ToInt32(location_currentPriority_option2) + Convert.ToInt32(btn_location_option2.Text)).ToString();
                location_redone_option2 = $"{lbl_location_option2.Text}[{location_newPriority_option2}],";
            }
            catch
            {
            }
            //Because try and catch statement variables are local to the statement, define as empty if try/catch fails (so it can be used)
            string location_redone_option3 = "";
            try
            {
                //If it tries to find location of NO OPTION SET - no index will be found hence try will fail.
                //Otherwise, same process above is followed
                int location_idOfOption3 = location.ToList().IndexOf(lbl_location_option3.Text);
                string location_currentPriority_option3 = location2[location_idOfOption3].Substring(location2[location_idOfOption3].IndexOf("[") + 1, location2[location_idOfOption3].IndexOf("]") - location2[location_idOfOption3].IndexOf("[") - 1); //cut string by first finding starting position then length by subtracting position from second character
                string location_newPriority_option3 = (Convert.ToInt32(location_currentPriority_option3) + Convert.ToInt32(btn_location_option3.Text)).ToString();
                location_redone_option3 = $"{lbl_location_option3.Text}[{location_newPriority_option3}],";
            }
            catch
            {
            }
            //Set the string to be inserted back as the priortiies of the locations as having these updated vote scores
            location_newPriorities = location_redone_option1 + location_redone_option2 + location_redone_option3;
        }


        //Store the string of the new option priorities (to be inserted into the sql by InsertVotes()
        string dayTime_newPriorities;
        private void NewDateTimeVotes()  //Once the user has set their prorities, add this number to the current calculation stored
        {

            //Separate all of the time/dates (twice because one is for the votes and the other is for the actual options)
            string[] dayTime = dgv_eventData.Rows[0].Cells["eventTime"].Value.ToString().Split(',');
            string[] dayTime2 = dgv_eventData.Rows[0].Cells["eventTime"].Value.ToString().Split(',');

            //For each item in the first array, get only the option (cut out [])
            for (int i = 0; i < dayTime.Length - 1; i++)
            {
                dayTime[i] = dayTime[i].Substring(0, dayTime[i].IndexOf("["));
            }

            //Making all of these into a list and then finding the INDEX of the time/date desired
            int dayTime_idOfOption1 = dayTime.ToList().IndexOf(lbl_timeDate_option1.Text);

            //After cutting the location list (to get actual option) then get the value of the vote from the second array
            //Which was NOT cut at [
            //Get the VALUE of the priority currently by first finding starting position then length by subtracting position from second character
            string dayTime_currentPriority_option1 = dayTime2[dayTime_idOfOption1].Substring(dayTime2[dayTime_idOfOption1].IndexOf("[") + 1, dayTime2[dayTime_idOfOption1].IndexOf("]") - dayTime2[dayTime_idOfOption1].IndexOf("[") - 1); //cut string by first finding starting position then length by subtracting position from second character
           //Get the NEW VALUE of the specific option by adding this current priority to the value of the button
            //NOTE:  weird way of adding votes means that the option with the lowest number in the [[] has the greatest votes
            string dayTime_newPriority_option1 = (Convert.ToInt32(dayTime_currentPriority_option1) + Convert.ToInt32(btn_timeDate_option1.Text)).ToString();
            //Re-concatenate the option with its new priority
            string dayTime_redone_option1 = $"{lbl_timeDate_option1.Text}[{dayTime_newPriority_option1}],";

            //Because try and catch statement variables are local to the statement, define as empty if try/catch fails (so it can be used)
            string dayTime_redone_option2 = "";
            try
            {
                //If it tries to find time/date of NO OPTION SET - no index will be found hence try will fail.
                //Otherwise, same process above is followed
                int dayTime_idOfOption2 = dayTime.ToList().IndexOf(lbl_timeDate_option2.Text);
                string dayTime_currentPriority_option2 = dayTime2[dayTime_idOfOption2].Substring(dayTime2[dayTime_idOfOption2].IndexOf("[") + 1, dayTime2[dayTime_idOfOption2].IndexOf("]") - dayTime2[dayTime_idOfOption2].IndexOf("[") - 1); //cut string by first finding starting position then length by subtracting position from second character
                string dayTime_newPriority_option2 = (Convert.ToInt32(dayTime_currentPriority_option2) + Convert.ToInt32(btn_timeDate_option2.Text)).ToString();
                dayTime_redone_option2 = $"{lbl_timeDate_option2.Text}[{dayTime_newPriority_option2}],";
            }
            catch
            {
            }
            //Because try and catch statement variables are local to the statement, define as empty if try/catch fails (so it can be used)
            string dayTime_redone_option3 = "";
            try
            {
                //If it tries to find time/date of NO OPTION SET - no index will be found hence try will fail.
                //Otherwise, same process above is followed
                int dayTime_idOfOption3 = dayTime.ToList().IndexOf(lbl_timeDate_option3.Text);
                string dayTime_currentPriority_option3 = dayTime2[dayTime_idOfOption3].Substring(dayTime2[dayTime_idOfOption3].IndexOf("[") + 1, dayTime2[dayTime_idOfOption3].IndexOf("]") - dayTime2[dayTime_idOfOption3].IndexOf("[") - 1); //cut string by first finding starting position then length by subtracting position from second character
                string dayTime_newPriority_option3 = (Convert.ToInt32(dayTime_currentPriority_option3) + Convert.ToInt32(btn_timeDate_option3.Text)).ToString();
                dayTime_redone_option3 = $"{lbl_timeDate_option3.Text}[{dayTime_newPriority_option3}],";
            }
            catch
            {
            }
            //Set the string to be inserted back as the priortiies of the time/dates as having these updated vote scores
            dayTime_newPriorities = dayTime_redone_option1 + dayTime_redone_option2 + dayTime_redone_option3;
        }

        private void InsertVotes() //Insert the new daytime and location options
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Update the event times and locations votes for the event with the new strings
            sqlcommand2.CommandText = $"UPDATE Events SET eventTime='{dayTime_newPriorities}', eventLocation='{location_newPriorities}' WHERE eventName='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }


        //Allow user to toggle preferences using the buttons (depending on how many options the event has for time and location respectively)

        //Global so that the number of textbox options avaliable can be set by the FillWithInfo function
        int maxTimeOption = 1;
        int maxLocationOption = 1;

        //Make public from the 'click' variable so that the number the button is currently set to is stored
        int timeDate_option1Number = 1;
        private void btn_timeDate_option1_Click(object sender, EventArgs e) //Change priority of option beside the button
        {
            //Increment button to the max of the time/date options avaliable
            if (timeDate_option1Number < maxTimeOption)
            {
                timeDate_option1Number++;
                //Display this priority number
                btn_timeDate_option1.Text = timeDate_option1Number.ToString();
            }
            //Otherwise, reset the button's counter
            else
            {
                timeDate_option1Number = 1;
                //Display this priority number
                btn_timeDate_option1.Text = timeDate_option1Number.ToString();
            }
        }

        //Make public from the 'click' variable so that the number the button is currently set to is stored
        int timeDate_option2Number = 1;
        private void btn_timeDate_option2_Click(object sender, EventArgs e)
        {
            //Increment button to the max of the time/date options avaliable
            if (timeDate_option2Number < maxTimeOption)
            {
                timeDate_option2Number++;
                //Display this priority number
                btn_timeDate_option2.Text = timeDate_option2Number.ToString();
            }
            //Otherwise, reset the button's counter
            else
            {
                timeDate_option2Number = 1;
                //Display this priority number
                btn_timeDate_option2.Text = timeDate_option2Number.ToString();
            }
        }
        //Make public from the 'click' variable so that the number the button is currently set to is stored
        int timeDate_option3Number = 1;
        private void btn_timeDate_option3_Click(object sender, EventArgs e)
        {
            //Increment button to the max of the time/date options avaliable
            if (timeDate_option3Number < maxTimeOption)
            {
                timeDate_option3Number++;
                //Display this priority number
                btn_timeDate_option3.Text = timeDate_option3Number.ToString();
            }
            //Otherwise, reset the button's counter
            else
            {
                timeDate_option3Number = 1;
                //Display this priority number
                btn_timeDate_option3.Text = timeDate_option3Number.ToString();
            }
        }
        //Make public from the 'click' variable so that the number the button is currently set to is stored
        int location_option1Number = 1;
        private void btn_location_option1_Click(object sender, EventArgs e)
        {
            //Increment button to the max of the time/date options avaliable
            if (location_option1Number < maxLocationOption)
            {
                location_option1Number++;
                //Display this priority number
                btn_location_option1.Text = location_option1Number.ToString();
            }
            //Otherwise, reset the button's counter
            else
            {
                location_option1Number = 1;
                //Display this priority number
                btn_location_option1.Text = location_option1Number.ToString();
            }
        }
        //Make public from the 'click' variable so that the number the button is currently set to is stored
        int location_option2Number = 1;
        private void btn_location_option2_Click(object sender, EventArgs e)
        {
            //Increment button to the max of the location options avaliable
            if (location_option2Number < maxLocationOption)
            {
                location_option2Number++;
                //Display this priority number
                btn_location_option2.Text = location_option2Number.ToString();
            }
            //Otherwise, reset the button's counter
            else
            {
                location_option2Number = 1;
                //Display this priority number
                btn_location_option2.Text = location_option2Number.ToString();
            }
        }
        //Make public from the 'click' variable so that the number the button is currently set to is stored
        int location_option3Number = 1;
        private void btn_location_option3_Click(object sender, EventArgs e)
        {
            //Increment button to the max of the location options avaliable
            if (location_option3Number < maxLocationOption)
            {
                location_option3Number++;
                //Display this priority number
                btn_location_option3.Text = location_option3Number.ToString();
            }
            else
            {
                location_option3Number = 1;
                //Display this priority number
                btn_location_option3.Text = location_option3Number.ToString();
            }
        }
    }
}
