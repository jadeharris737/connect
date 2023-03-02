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
using System.Globalization;

namespace major_nav
{
    public partial class frm_myEvents : Form
    {
        public frm_myEvents()
        {
            InitializeComponent();
            SetupForm();
        }

        //String to connect to the database
        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work";
        //Store which user is logged in
        public static string username;


        private void SetupForm()
        {
            //Make all of the rows in the datagridview 40px high
            dgv_events.RowTemplate.Height = 40;
            Refresh(); //Get information
        }


        private void Refresh() //Refresh the information
        {
            PopulateUser(); //Get information for user
            PopulateWithMyEvents(); //Get information for event
        }

        private void PopulateUser()
        {
            //Establish connection
            MySqlConnection con2 = new MySqlConnection(cs);
            //Open the connection to the database
            con2.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con2;
            sqlcommand2.CommandType = CommandType.Text;
            //Get all information for user
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username ='{username}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            //Place this data in datagrid view for use
            dgv_currentUserInfo.DataSource = table2;

            //Close connection with cloud server
            con2.Close();

        }

        public void PopulateWithMyEvents() //Get information for the event
        {

            lbl_lastUpdate.Text = DateTime.Now.ToString();
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get event information
            sqlcommand2.CommandText = $"SELECT eventName,status,eventTime,rsvp FROM Events WHERE owner = '{username}'"; //All of user's owned
            //Execute command and get information
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            //Place this data in datagrid view for use
            dgv_events.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }


        private void btn_newEvent_Click_1(object sender, EventArgs e) //When the user wants to create a new event, open the create event form
        {
            frm_newEvent newEventForm = new frm_newEvent(this);
            newEventForm.ShowDialog();
        }

        string selectedEvent = ""; //Publicly store which event is currently selected (changed by click event)
        private void dgv_events_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get the row that content is currently in
            int selectedRowIndex = e.RowIndex;
            if (mostRecent) //Check if the event has been recently updated (hence public selected event variable)
            {
                // Ignore clicks that are not in header. If they click the CANCEL button
                if (e.ColumnIndex == dgv_events.Columns[2].Index && e.RowIndex >= 0)
                {
                    //Get confirmation
                    if (MessageBox.Show($"Are you sure you want to cancel {selectedEvent}? This cannot be reversed.", "Confirmaton", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        CancelEvent(); //Cancel event
                        Refresh(); //Refresh the datagridview of the users list of events without this event
                        ////Indicate that the event has been updated (so other user's datagridview will update)
                        //ReUpdate_Event(selectedEvent);
                        //Confirmation
                        MessageBox.Show($"{selectedEvent} successfully cancelled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (e.ColumnIndex == dgv_events.Columns[1].Index && e.RowIndex >= 0) //Otherwise, if they click the FINISH/HOST button
                {
                    if (dgv_events.Rows[selectedRowIndex].Cells[4].Value.ToString() == "Pending") //If the status column of the event says 'PENDING' (hence event has only been invited -> so the user must want to host it)
                    {
                        //Get confirmation
                        if (MessageBox.Show($"Are you sure you want to host {selectedEvent}? Attendees will be notified and you will have to cancel the event completely to change its details (time/location preference).", "Confirmaton", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            //Get information for that exact selected event (as opposed to the list of events that the user owns)
                            PopulateSelectedEvent();
                            //Host event
                            HostEvent();
                            //Refresh the datagridview of the users' events
                            Refresh();
                            //Indicate that the event has been updated (so other user's datagridview will update)
                            ReUpdate_Event(selectedEvent);
                            MessageBox.Show($"{selectedEvent} successfully hosted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else //Otherwise, this column must say HOSTED (in which case the user would be wanting to COMPLETE/FINISH the event)
                    {
                        //Confirmation
                        if (MessageBox.Show($"Are you sure {selectedEvent} is completed? This event will be removed.", "Confirmaton", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            CancelEvent(); //Remove the event
                            Refresh(); //Refresh the datagridview of the users' events without this event
                            //Indicate that the event has been updated (so other user's datagridview will update)
                            ReUpdate_Event(selectedEvent);
                            MessageBox.Show($"{selectedEvent} successfully complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                else if (e.ColumnIndex == dgv_events.Columns[0].Index && e.RowIndex >= 0) //Otherwise, user must have clicked the MANAGE button
                {
                    //Send the currently selected event name to the managing form (in order to show the details)
                    frm_managing.eventName = selectedEvent;
                    //Send the current user
                    frm_managing.username = username;
                    //Open the form
                    frm_managing managingForm = new frm_managing();
                    managingForm.ShowDialog();
                }
            }
        }

        private void PopulateSelectedEvent() //Get information for the selected
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand = new MySqlCommand();
            sqlcommand.Connection = con;
            sqlcommand.CommandType = CommandType.Text;
            //Select all of the rows where the usernamne (should only be one or none) matches the user attempting to log in (by using the username in txt_username.Text)
            sqlcommand.CommandText = $"SELECT * FROM Events WHERE eventName ='{selectedEvent}'";
            //Execute command to find rows which match username
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlcommand);

            //Create table that recieves data from command
            DataTable table = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter.Fill(table);
            //Place this data in datagrid view for use
            dgv_currentEventSelection.DataSource = table;

            //Close connection with cloud server
            con.Close();
        }

        private void HostEvent() //Host the event by choosing the location and event times based on priority
        {
            //Choose the options according to the votes
            SetAccordingToVotes();
            //Set the event as hosted and move the invitees to as attendees
            SetHostStatusAndClearInvitees();
            //Move the event to all of the users' list of events they are attending (from their list of invitations)
            AddToHostsEvents();

        }

        //Add this event to the host's list of events attending
        //NOTE: this is because the event is already added to user's list (when they cast their votes)
        private void AddToHostsEvents() 
        {
            //Get the current list of eventIDs
            //List more readable to work with when deleting elements
            List<string> eventIDs = dgv_currentUserInfo.Rows[0].Cells["eventIDs"].Value.ToString().Split(',').ToList();
            //Add this event
            eventIDs.Add(selectedEvent);
            string updatedEventIDs = "";

            foreach (string ID in eventIDs) //Recreate string to be inserted back into the table
            {
                if (ID != "")
                {
                    updatedEventIDs += ID + ",";
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
            //Add this event to the host's list of events invited to
            sqlcommand.CommandText = $"UPDATE Users SET eventIDs='{updatedEventIDs}' WHERE username ='{username}'";
            sqlcommand.ExecuteNonQuery();

            //Close connection with cloud server
            con2.Close();
        }

        //Set the location and time/date options according to the votes
        //NOTE: the lowest number in the [] indicates the highest vote
        private void SetAccordingToVotes()
        {
            //Record if there are any matchups (two options that get the same vote)
            bool equalVotes = false;

            //Separate the current votes for daytime to get their votes
            string[] dayTimeCurrentVotes = dgv_currentEventSelection.Rows[0].Cells["eventTime"].Value.ToString().Split(',');
            //List of all of the indexes that have the option with the highest number of votes
            List<int> lowestIndexes_dayTime = new List<int>(3);

            //Set the first lowest value for the votes by getting the value inside the [ ] for the first option
            int lowestValue_dayTime = Convert.ToInt32(dayTimeCurrentVotes[0].Substring(dayTimeCurrentVotes[0].IndexOf("[") + 1, dayTimeCurrentVotes[0].IndexOf("]") - dayTimeCurrentVotes[0].IndexOf("[") - 1));
            lowestIndexes_dayTime.Add(0); //Add to the lowest indexes '0' -> indicating that by default the first option has the highest priority (thus would be set)

            //However, because there can be numerous options, do for the length of time options
            for (int i = 1; i < dayTimeCurrentVotes.Length; i++)
            {
                string value = dayTimeCurrentVotes[i]; //Iterating through each time option (starting at 1 because 0/the first item was already done)
                if (value != "") //Providing not empty
                {
                    //Get the priority value of the current option 
                    string value2 = value.Substring(dayTimeCurrentVotes[i].IndexOf("[") + 1, dayTimeCurrentVotes[i].IndexOf("]") - dayTimeCurrentVotes[i].IndexOf("[") - 1);
                    //Get it as an integer
                    int value3 = Convert.ToInt32(value2);
                    //If this option priority is LESS THAN the current lowest value, then this option must be lower (higher priority)
                    //Thus clear the current list of votes and just add this index
                    if (lowestValue_dayTime > value3)
                    {
                        //Set as now lowest value
                        lowestValue_dayTime = value3;
                        lowestIndexes_dayTime.Clear();
                        lowestIndexes_dayTime.Add(i);
                    }
                    //Otherwise, if they are equal/even (recieved same number of votes)
                    if (lowestValue_dayTime == value3)
                    {
                        //Set as now lowest value
                        lowestValue_dayTime = value3;
                        //Record this index as well
                        lowestIndexes_dayTime.Add(i);
                    }
                }
            }

            //Now, re-get the current time options but not to cut out their event time priorities, just for the actual options themselves
            string[] dayTime = dgv_currentEventSelection.Rows[0].Cells["eventTime"].Value.ToString().Split(',');
            //For each item in this list, cut out the vote [ ] and add it to the list
            for (int i = 0; i < dayTime.Length - 1; i++)
            {
                dayTime[i] = dayTime[i].Substring(0, dayTime[i].IndexOf("["));
            }
            //String for the options that get the highest vote
            string dayTime_highestVoted = "";

            //For each index of the options that got the lowest vote, add the ACTUAL OPTION VALUE (gotten from the list
            //which removed the [ ]) and set that as the event location now
            foreach (var index in lowestIndexes_dayTime)
            {
                dayTime_highestVoted += $"{dayTime[index]},";
            }
            
            //Repeat above for the location options
            //Separate the current votes for location to get their votes
            string[] locationCurrentVotes = dgv_currentEventSelection.Rows[0].Cells["eventLocation"].Value.ToString().Split(',');
            //List of all of the indexes that have the option with the highest number of votes
            List<int> lowestIndexes_location = new List<int>(3);

            //Set the first lowest value for the votes by getting the value inside the [ ] for the first option
            int lowestValue_location = Convert.ToInt32(locationCurrentVotes[0].Substring(locationCurrentVotes[0].IndexOf("[") + 1, locationCurrentVotes[0].IndexOf("]") - locationCurrentVotes[0].IndexOf("[") - 1));
            lowestIndexes_location.Add(0); //Add to the lowest indexes '0' -> indicating that by default the first option has the highest priority (thus would be set)
           
            //However, because there can be numerous options, do for the length of time options
            for (int i = 1; i < locationCurrentVotes.Length; i++)
            {
                string value = locationCurrentVotes[i];//Iterating through each time option (starting at 1 because 0/the first item was already done)
                if (value != "") //Providing not empty
                {
                    //Get the priority value of the current option 
                    string value2 = value.Substring(locationCurrentVotes[i].IndexOf("[") + 1, locationCurrentVotes[i].IndexOf("]") - locationCurrentVotes[i].IndexOf("[") - 1);
                    //Get it as an integer
                    int value3 = Convert.ToInt32(value2);
                    //If this option priority is LESS THAN the current lowest value, then this option must be lower (higher priority)
                    //Thus clear the current list of votes and just add this index
                    if (lowestValue_location > value3)
                    {
                        //Set as now lowest value
                        lowestValue_location = value3;
                        lowestIndexes_location.Clear();
                        lowestIndexes_location.Add(i);
                    }
                    //Otherwise, if they are equal/even (recieved same number of votes)
                    if (lowestValue_location == value3)
                    {
                        //Set as now lowest value
                        lowestValue_location = value3;
                        lowestIndexes_location.Add(i);
                    }
                }
            }

            //Now, re-get the current time options but not to cut out their location priorities, just for the actual options themselves
            string[] location = dgv_currentEventSelection.Rows[0].Cells["eventLocation"].Value.ToString().Split(',');
            //For each item in this list, cut out the vote [ ] and add it to the list
            for (int i = 0; i < location.Length - 1; i++) 
            {
                location[i] = location[i].Substring(0, location[i].IndexOf("["));
            }
            //String for the options that get the highest vote
            string location_highestVoted = "";
            //For each index of the options that got the lowest vote, add the ACTUAL OPTION VALUE (gotten from the list
            //which removed the [ ]) and set that as the event location now
            foreach (var index in lowestIndexes_location)
            {
                location_highestVoted += $"{location[index]},";
            }

            //If there are more than one daytime option, then numerous must be equal. Thus set to true
            if (lowestIndexes_dayTime.Count > 1)
            {
                equalVotes = true;
            }

            if (lowestIndexes_location.Count > 1)
            {
                equalVotes = true;
            }

            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //SET the location and daytime options that recieved the highest/equal votes
            sqlcommand2.CommandText = $"UPDATE Events SET eventLocation='{location_highestVoted}',eventTime='{dayTime_highestVoted}' WHERE eventName='{selectedEvent}'";
            //Execute command to find rows which match username
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();

            if (equalVotes) //If votes recieved equal numbers
            {
                frm_equalVotes.eventName = selectedEvent; //Then open the equal votes form (get user to select either option from the two that got equal votes)
                frm_equalVotes equalVotesForm = new frm_equalVotes();
                equalVotesForm.ShowDialog();
            }
        }

        //Set the event's status to hosted and clear all invitees (because all of those attending have already been
        //set to attending when they accepted the InvitationVote
        private void SetHostStatusAndClearInvitees()
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Indicate that the event has been hosted
            sqlcommand2.CommandText = $"UPDATE Events SET status='Hosted' WHERE eventName='{selectedEvent}'";
            //Execute command
            sqlcommand2.ExecuteNonQuery();

            try
            {
                //Get all of the user's currently invited
                List<string> invited = dgv_currentEventSelection.Rows[0].Cells["invitees"].Value.ToString().Split(',').ToList();
                //For each user, remove this event from the list of events that they are invited to
                foreach (var user in invited)
                {
                    invitedUser = user;
                    UpdateInvitees();
                }
            }
            catch
            {

            }

            //CLEAR INVITEES (now hosted)
            sqlcommand2.CommandText = $"UPDATE Events SET invitees='' WHERE eventName='{selectedEvent}'";
            //Execute command
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        //Public variables which contain which invited/attending user needs the event removed from the respective list
        string invitedUser;
        string attendingUser;

        private void CancelEvent()
        {
            try
            {
                //Get all of the user's currently invited
                List<string> invited = dgv_currentEventSelection.Rows[0].Cells["invitees"].Value.ToString().Split(',').ToList();
                //For each user, remove this event from the list of events that they are invited to
                foreach (var user in invited)
                {
                    invitedUser = user;
                    UpdateInvitees();
                }
            }
            catch
            {
            }

            try
            {
                //Get all of the user's currently attending
                List<string> attending = dgv_currentEventSelection.Rows[0].Cells["attendees"].Value.ToString().Split(',').ToList();
                //For each user, remove this event from the list of events that they are attending
                foreach (var user in attending)
                {
                    attendingUser = user;
                    UpdateAttendees();
                }
            }
            catch 
            {
            }

            RemoveEventFromHost();

            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Remove the event completely
            sqlcommand2.CommandText = $"DELETE FROM Events WHERE eventName='{selectedEvent}'";
            //Execute command to find rows which match username
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void RemoveEventFromHost()
        {
            //List more readable to work with when deleting elements
            List<string> eventIDs = dgv_currentUserInfo.Rows[0].Cells["eventIDs"].Value.ToString().Split(',').ToList();
            //Remove event
            eventIDs.Remove(selectedEvent);
            string updatedEventIDs = "";

            foreach (string ID in eventIDs) //Recreate string to be inserted back into the table
            {
                if (ID != "")
                {
                    updatedEventIDs += ID + ",";
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
            //Update the attending user's list without this event
            sqlcommand.CommandText = $"UPDATE Users SET invitationIDs='{updatedEventIDs}' WHERE username ='{username}'";
            sqlcommand.ExecuteNonQuery();

            //Close connection with cloud server
            con2.Close();
        }

        private void UpdateAttendees() //Remove event from the user's list of events they are attending
        {
            //Get information for friend
            PopulateFriend(attendingUser);
            //List more readable to work with when deleting elements
            List<string> eventIDs = dgv_friend.Rows[0].Cells["eventIDs"].Value.ToString().Split(',').ToList();
            //Remove event
            eventIDs.Remove(selectedEvent);
            string updatedEventIDs = "";

            foreach (string ID in eventIDs) //Recreate string to be inserted back into the table
            {
                if (ID != "")
                {
                    updatedEventIDs += ID + ",";
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
            //Update the attending user's list without this event
            sqlcommand.CommandText = $"UPDATE Users SET invitationIDs='{updatedEventIDs}' WHERE username ='{attendingUser}'";
            sqlcommand.ExecuteNonQuery();

            //Close connection with cloud server
            con2.Close();
        }


        private void UpdateInvitees() //Remove event from the user's list of events they are invited to
        {
            //Get information for friend
            PopulateFriend(invitedUser);
            //List more readable to work with when deleting elements
            List<string> invitationIDs = dgv_friend.Rows[0].Cells["invitationIDs"].Value.ToString().Split(',').ToList();
            //Remove this event from current list
            invitationIDs.Remove(selectedEvent);
            string updatedInvitationIDs = "";

            foreach (string ID in invitationIDs) //Recreate string to be inserted back into the table
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
            //Update the invited user's list without this event
            sqlcommand.CommandText = $"UPDATE Users SET invitationIDs='{updatedInvitationIDs}' WHERE username ='{invitedUser}'";
            sqlcommand.ExecuteNonQuery();

            //Close connection with cloud server
            con2.Close();
        }

        private void PopulateFriend(string friend)
        {
            //Establish connection
            MySqlConnection con2 = new MySqlConnection(cs);
            //Open the connection to the database
            con2.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con2;
            sqlcommand2.CommandType = CommandType.Text;
            //Get all information for user
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username ='{friend}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            //Place this data in datagrid view for use
            dgv_friend.DataSource = table2;

            //Close connection with cloud server
            con2.Close();
        }

        private void button4_Click(object sender, EventArgs e) //Reset button
        {
            PopulateWithMyEvents(); //Repopulate the datagridview
        }

        private void dgv_events_Click(object sender, EventArgs e)
        {
            //If the user has clicked a row of the datagridview (not the header)
            if (dgv_events.Rows.Count > 0)
            {
                //Get the current selected row
                int selectedRowIndex = dgv_events.SelectedCells[0].RowIndex;
                //Set the selected event to this eventname
                selectedEvent = dgv_events.Rows[selectedRowIndex].Cells["eventName"].Value.ToString();
                //Check if the most recent version of the event is being used
                mostRecent = CheckLastUpdated_Event(selectedEvent);
                if (!mostRecent) //If not, then update
                {
                    MessageBox.Show("Your events have been recently changed. Updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Refresh();
                }
            }
        }

        bool mostRecent = true;

        private bool CheckLastUpdated_Event(string eventName)
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            sqlcommand2.CommandText = $"SELECT * FROM Events WHERE eventName = '{eventName}'";

            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);

            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);

            //Close connection with cloud server
            con.Close();

            string time = table2.Rows[0]["lastUpdated"].ToString();
            //Convert into time that can be checked
            DateTime lastUpdated = DateTime.ParseExact(time, "d/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            string current = lbl_lastUpdate.Text;
            //Convert into time that can be checked
            DateTime clientsLastUpdated = DateTime.ParseExact(current, "d/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            //If the user was updated after the last time that their friends datagridview was last updated, then will need to reupdate 
            if (lastUpdated > clientsLastUpdated) //> means more recently
            {
                return false; //Thus, user not using most recent version
            }
            else
            {
                return true; //Thus, user not using most recent version
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
            //Select all of the rows where the usernamne (should only be one or none) matches the user attempting to log in (by using the username in txt_username.Text)
            sqlcommand2.CommandText = $"UPDATE Events SET lastUpdated='{DateTime.Now}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void dgv_events_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) //Get button to say either FINISH/HOST (based on the row)
        {
            if (e.ColumnIndex == 1) //If the cell is in the 1st column (which is the finish/host button)
            {
                //Get the row index of the button currently being formatted
                int rowIndex = e.RowIndex;
                //If it is 'pending', then event must not be hosted yet (thus button says host)
                if (dgv_events.Rows[rowIndex].Cells[4].Value.ToString() == "Pending")
                {
                    //Set the event time to empty because an event time has not yet been chosen (still in voting stage)
                    dgv_events.Rows[rowIndex].Cells[5].Value = "";
                    e.Value = "Host";
                }
                //Else, if the event is 'hosted'
                else if (dgv_events.Rows[rowIndex].Cells[4].Value.ToString() == "Hosted")
                {
                    //Set the RSVP date to empty (as date obviosuly already chosen)
                    dgv_events.Rows[rowIndex].Cells[6].Value = "";
                    //Then, event must already be hosted so only FINISH option
                    e.Value = "Finish";
                }
            }
        }
    }
}
