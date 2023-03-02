using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization; //for date time
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Can connect to cloud database

namespace major_nav
{

    public partial class frm_events : Form
    {

        private frm_nav nav; //Create a form reference so that the myEvents form can be opened
        public frm_events(Form callingForm)
        {
            InitializeComponent();
            nav = callingForm as frm_nav;

            dgv_events.RowTemplate.Height = 40; //For aesthetics, set each row to 40px high
            Refresh();
        }

        //This public variables is set when the user logins in and store which user is currently logged in
        public static string username = "";
        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //String to connect and log in to cloud database


        private void Refresh()
        {
            PopulateUser(); //Update the information for the user
            PopulateWithMyEvents(); //Update the user's events datagridview
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
            //Get user information
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
        private void PopulateWithMyEvents()
        {
            lbl_lastUpdate.Text = DateTime.Now.ToString(); //Use to keep track of when the datagridview was last updated
            List<string> events = new List<string>();
            //Only populate if the user is invited to events (prevent error)
            if (dgv_currentUserInfo.Rows[0].Cells["eventIDs"].Value.ToString() != "")
            {
                events = dgv_currentUserInfo.Rows[0].Cells["eventIDs"].Value.ToString().Split(',').ToList(); //Make a list of each event separated by comma
            }

            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;

            //Select all of these events by finding any instances where the eventName column matches any of the IDs
            //(shows all events user invited to)
            string getEvents = "SELECT eventName,owner,status FROM Events WHERE eventName IN (";

            foreach (var event1 in events)
            {
                if (event1 != "")
                {
                    getEvents += $"'{event1}',";
                }
            }
            getEvents += $"'')";
            sqlcommand2.CommandText = getEvents; //Use this string as query

            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            //Place this data in datagrid view for use
            dgv_events.DataSource = table2; //Put into datagridview displayed for user
            //Close connection with cloud server
            con.Close();

        }

        private void btn_newEvent_Click_1(object sender, EventArgs e) //Redirect user to the myEvents form so that they can create an event if they wish
        {
            nav.btn_myEvents_Click(nav.btn_myEvents, e); //Mimic press of myEvents navigation button to 'redirect'
        }



        string selectedEvent = ""; //Make global as this variable is set in the CLICK event (as opposed to this cellcontentclick)
        private void dgv_events_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check if most recent is true (from the global variable that is called if the datagridview is even clicked)
            //This ensures that if a user clicks dgv but its not most recent version, this event won't also occur
            if (mostRecent)
            {
                //If the user clicks the LEAVE button
                if (e.ColumnIndex == dgv_events.Columns[1].Index && e.RowIndex >= 0)
                {
                    if (MessageBox.Show($"Are you sure you want to leave {selectedEvent}? This cannot be reversed.", "Confirmaton", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        LeaveEvent(); //Remove user from event
                        ReUpdate_Event(selectedEvent); //Reupdate event as the user has now left
                        Refresh();
                    }
                }
                //If the user clicks the VIEW button for an event that is hosted, then let them view INFORMATION/details form that event
                else if (e.ColumnIndex == 0 && e.RowIndex >= 0 && dgv_events.Rows[selectedRowIndex].Cells[4].Value.ToString() == "Hosted")
                {
                    frm_viewing.eventName = selectedEvent;
                    frm_viewing viewingForm = new frm_viewing();
                    viewingForm.ShowDialog();
                }
                //Otherwise, they must be clicking on the VIEW button for an event that is not yet hosted
                else
                {
                    MessageBox.Show($"Please wait until the event is hosted by {dgv_events.Rows[selectedRowIndex].Cells[3].Value.ToString()}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LeaveEvent()
        {
            PopulateSelectedEventDetails(); //Get the details of the currently selected event
            if (dgv_events.Rows[selectedRowIndex].Cells[4].Value.ToString() == "Pending")
            {
                RemoveUsersVotesRecord(); //Remove the votes that the user made (as the event has not yet been hosted)
            }
            //otherwise, just remove user from event and event from user
            RemoveUserFromEvent_Hosted();
            RemoveEventFromUser_Hosted();
        }

        private void RemoveUsersVotesRecord()
        {
            //NOTE: Users votes are recorded in format [USERNAME]-[1,2,3]-[1,2,3]|
            //Where the first [1,2,3] records the votes that the user made for time/date
            //The second [1,2,3] stores order for location votes
            //| separates users

            //List more readable to work with when deleting elements
            //The record votes for each user are separated with '|'
            string[] votes = dgv_currentEventSelection.Rows[0].Cells["recordVotes"].Value.ToString().Split('|');
            //Find the record for the current user's
            string currentUsersRecord = "";
            //Use to remove user later
            string currentUser = "";
            //Contain the ID that the user's vote is stored as
            int idForUsersVote = 0;

            //Search through all of the votes (for all of the users - separated at the |)
            //If the users USERNAME matches the username checked, then set that as the id for the user's vote 
            for (int i = 0; i < votes.Length; i++)
            {
                if (votes[i] != "") //providing that not checking the empty user (as there is an extra ,)
                {
                    //Referring to format above, this separates the string for the USERNAME, TIME/DATE VOTES and LOCATION VOTES
                    //Then only deals with the USERNAME part (through the use of the [0] ID
                    string currentUsersVote = votes[i].Split('-')[0];
                    //Check if the username equals by taking a substring IN BETWEEN BUT NOT INCLUDING the [] characters
                    currentUsersRecord = currentUsersVote.Substring(1, currentUsersVote.IndexOf("]") - 1);
                    if (currentUsersRecord == username) //Choose with IF = -> because we know the name will be somewhere, test and test2 would both be regonised with a .contains
                    {
                        //Then save the id
                        idForUsersVote = i;
                        //More efficient -> leave the loop
                        i = votes.Length;
                    }
                }
            }

            currentUser = votes[idForUsersVote];

            //Separate this specific user's votes -> this is achieved by using their ID specifically then separating into USERNAME, TIME VOTES and LOCATION VOTES
            string[] usersVotes = votes[idForUsersVote].Split('-');

            //SUBTRACTING USERS VOTES FROM THE PRIORITY OF EVENT TIMES
            //NOTE: Length to check the number of options has + 1 because of the extra ',' which makes the list have +1 extra item

            //Get the number of votes currently stored for the event times
            string[] dayTimeCurrentVotes = dgv_currentEventSelection.Rows[0].Cells["eventTime"].Value.ToString().Split(',');

            //This achieved by taking the 2nd part of the users string ([1] index) and only the data from in between NOT INCLUDING the [ ]
            string timeDateVotes = usersVotes[1].Substring(1, usersVotes[1].IndexOf("]") - 1);
            //Within this [ ], each vote the user made is separated by a ,
            string[] eachTimeDateVote = timeDateVotes.Split(',');

            //Get the CURRENT VOTE priority for option (regardless of user)
            int timeDate_option1 = Convert.ToInt32(dayTimeCurrentVotes[0].Substring(dayTimeCurrentVotes[0].IndexOf("[") + 1, dayTimeCurrentVotes[0].IndexOf("]") - dayTimeCurrentVotes[0].IndexOf("[") - 1));
            //Get the vote the user made
            int timeDate_vote1 = Convert.ToInt32(eachTimeDateVote[0]);
            //Subtract vote user made from the current vote
            string newTimeDate_1 = (timeDate_option1 - timeDate_vote1).ToString();

            string newTimeDate_2 = "";
            if (dayTimeCurrentVotes.Length >= 3) //Only execute if another option existed for the time/date -> do exact same as above (subtract users vote from current stored priority vote)
            {
                int timeDate_option2 = Convert.ToInt32(dayTimeCurrentVotes[1].Substring(dayTimeCurrentVotes[1].IndexOf("[") + 1, dayTimeCurrentVotes[1].IndexOf("]") - dayTimeCurrentVotes[1].IndexOf("[") - 1));
                int timeDate_vote2 = Convert.ToInt32(eachTimeDateVote[1]);
                newTimeDate_2 = (timeDate_option2 - timeDate_vote2).ToString();

            }
            string newTimeDate_3 = "";
            if (dayTimeCurrentVotes.Length == 4) //Only execute if another option existed for the time/date -> do exact same as above (subtract users vote from current stored priority vote)
            {
                int timeDate_option2 = Convert.ToInt32(dayTimeCurrentVotes[1].Substring(dayTimeCurrentVotes[1].IndexOf("[") + 1, dayTimeCurrentVotes[1].IndexOf("]") - dayTimeCurrentVotes[1].IndexOf("[") - 1));
                int timeDate_vote2 = Convert.ToInt32(eachTimeDateVote[1]);
                newTimeDate_2 = (timeDate_option2 - timeDate_vote2).ToString();

                int timeDate_option3 = Convert.ToInt32(dayTimeCurrentVotes[2].Substring(dayTimeCurrentVotes[2].IndexOf("[") + 1, dayTimeCurrentVotes[2].IndexOf("]") - dayTimeCurrentVotes[2].IndexOf("[") - 1));
                int timeDate_vote3 = Convert.ToInt32(eachTimeDateVote[2]);
                newTimeDate_3 = (timeDate_option3 - timeDate_vote3).ToString();
            }

            //SUBTRACTING USERS VOTES FROM THE PRIORITY OF LOCATIONS
            //This achieved by taking the 3nd part of the users string ([2] index) and only the data from in between NOT INCLUDING the [ ]
            string locationVotes = usersVotes[2].Substring(1, usersVotes[2].IndexOf("]") - 1);
            //Within this [ ], each vote the user made for location is separated by a ,
            string[] eachLocationVote = locationVotes.Split(',');

            //Get the number of votes currently stored for the locations
            string[] locationsCurrentVotes = dgv_currentEventSelection.Rows[0].Cells["eventLocation"].Value.ToString().Split(',');

            //Get the CURRENT VOTE priority for option (regardless of user)
            int location_vote1 = Convert.ToInt32(eachLocationVote[0]);
            //Get the vote the user made
            int location_option1 = Convert.ToInt32(locationsCurrentVotes[0].Substring(locationsCurrentVotes[0].IndexOf("[") + 1, locationsCurrentVotes[0].IndexOf("]") - locationsCurrentVotes[0].IndexOf("[") - 1));
            //Subtract vote user made from the current vote
            string newlocation_1 = (location_option1 - location_vote1).ToString();

            string newlocation_2 = "";
            if (locationsCurrentVotes.Length >= 3) //Only execute if another option existed for the time/date -> do exact same as above (subtract users vote from current stored priority vote)
            {
                int location_option2 = Convert.ToInt32(locationsCurrentVotes[1].Substring(locationsCurrentVotes[1].IndexOf("[") + 1, locationsCurrentVotes[1].IndexOf("]") - locationsCurrentVotes[1].IndexOf("[") - 1));
                int location_vote2 = Convert.ToInt32(eachLocationVote[1]);
                newlocation_2 = (location_option2 - location_vote2).ToString();
            }

            string newlocation_3 = "";
            if (locationsCurrentVotes.Length == 4) //Only execute if another option existed for the time/date -> do exact same as above (subtract users vote from current stored priority vote)
            {
                int location_vote3 = Convert.ToInt32(eachLocationVote[2]);
                int location_option3 = Convert.ToInt32(locationsCurrentVotes[2].Substring(locationsCurrentVotes[2].IndexOf("[") + 1, locationsCurrentVotes[2].IndexOf("]") - locationsCurrentVotes[2].IndexOf("[") - 1));
                newlocation_3 = (location_option3 - location_vote3).ToString();
            }

            //RE-CONCATENATE THE STRINGS CONTAINING THE OPTIONS AND THEIR VOTES FOR LOCATION AND TIME EXCEPT WITH THEIR NEW PRIORITY 
            //This means, must have OPTION[number of votes] format

            //Get the currently stored event times again
            string[] dayTime = dgv_currentEventSelection.Rows[0].Cells["eventTime"].Value.ToString().Split(',');

            for (int i = 0; i < dayTime.Length - 1; i++) //Get only the name of the option that users are voting for (before the [ which contains the vote itself))
            {
                if (dayTime[i] != "")
                {
                    dayTime[i] = dayTime[i].Substring(0, dayTime[i].IndexOf("["));
                }
            }

            //Get the option name and then the corresponding new priority, and put in string format OPTION[new priority]
            string dayTime_option1_name = dayTime[0];
            string dayTime_redone_option1 = $"{dayTime_option1_name}[{newTimeDate_1}],";

            //Follows previous process, get the option name and then the corresponding new priority, and put in string format OPTION[new priority]
            string dayTime_redone_option2 = ""; //Because 'if' uses local variables
            if (newTimeDate_2 != "")
            {
                string dayTime_option2_name = dayTime[1];
                dayTime_redone_option2 = $"{dayTime_option2_name}[{newTimeDate_2}],";
            }

            //Follows previous process, get the option name and then the corresponding new priority, and put in string format OPTION[new priority]
            string dayTime_redone_option3 = ""; //Because 'if' uses local variables
            if (newTimeDate_3 != "")
            {
                string dayTime_option3_name = dayTime[2];
                dayTime_redone_option3 = $"{dayTime_option3_name}[{newTimeDate_3}],";
            }

            //Concatenate all of these options together (no need for comma in between as string already includes). This has updated the priorities of the options.
            string dayTime_newPriorities = dayTime_redone_option1 + dayTime_redone_option2 + dayTime_redone_option3;



            //FOR LOCATION

            string[] location = dgv_currentEventSelection.Rows[0].Cells["eventLocation"].Value.ToString().Split(',');

            for (int i = 0; i < location.Length - 1; i++) //Get only the name of the option that users are voting for (before the [ which contains the vote itself))
            {
                if (location[i] != "")
                {
                    location[i] = location[i].Substring(0, location[i].IndexOf("["));
                }
            }

            //Get the option name and then the corresponding new priority, and put in string format OPTION[new priority]
            string location_option1_name = location[0];
            string location_redone_option1 = $"{location_option1_name}[{newlocation_1}],";

            //Follows previous process, get the option name and then the corresponding new priority, and put in string format OPTION[new priority]
            string location_redone_option2 = ""; //Because 'if' uses local variables
            if (newlocation_2 != "")
            {
                string location_option2_name = location[1];
                location_redone_option2 = $"{location_option2_name}[{newlocation_2}],";
            }

            //Follows previous process, get the option name and then the corresponding new priority, and put in string format OPTION[new priority]
            string location_redone_option3 = "";  //Because 'if' uses local variables
            if (newlocation_3 != "")
            {
                string location_option3_name = location[2];
                location_redone_option3 = $"{location_option3_name}[{newlocation_3}],";
            }

            //Concatenate all of these options together (no need for comma in between as string already includes). This has updated the priorities of the options.
            string location_newPriorities = location_redone_option1 + location_redone_option2 + location_redone_option3;

            //REMOVE THIS SPECIFIC USERS RECORD NOW FROM THE RECORD OF ALL USER'S VOTES (as user no longer attending)
            List<string> voteRecord = dgv_currentEventSelection.Rows[0].Cells["recordVotes"].Value.ToString().Split('|').ToList();
            voteRecord.Remove(currentUser); //Remove the current user from the '|' (which separates each user)
            string updatedVoteRecord = "";

            foreach (string vote in voteRecord) //Recreate string to be inserted back into the table except without the user
            {
                if (vote != "")
                {
                    updatedVoteRecord += vote + ",";
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
            //Update the table with the same options but new priorities and remove the users own vote
            sqlcommand2.CommandText = $"UPDATE Events SET recordVotes='{updatedVoteRecord}',eventLocation='{location_newPriorities}',eventTime='{dayTime_newPriorities}' WHERE eventName= '{selectedEvent}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void PopulateSelectedEventDetails()
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get information for the event that is currently selected
            sqlcommand2.CommandText = $"SELECT * FROM Events WHERE eventName= '{selectedEvent}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            dgv_currentEventSelection.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }

        private void RemoveUserFromEvent_Hosted() //Remove user from list of attendees (only if event already hosted)
        {
            //List more readable to work with when deleting elements
            List<string> attendees = dgv_currentEventSelection.Rows[0].Cells["attendees"].Value.ToString().Split(',').ToList();
            attendees.Remove(username); //Remove the user from the lsit of attendees
            string updatedAttendees = "";


            foreach (string user in attendees) //Recreate string to be inserted back into the table except without the user
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
            //Update with new list of attendees without user
            sqlcommand2.CommandText = $"UPDATE Events SET attendees='{updatedAttendees}' WHERE eventName = '{selectedEvent}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void RemoveEventFromUser_Hosted() //Remove event from user's list of events which are already hosted
        {
            //List more readable to work with when deleting elements
            List<string> events = dgv_currentUserInfo.Rows[0].Cells["eventIDs"].Value.ToString().Split(',').ToList();
            events.Remove(selectedEvent); //Remove event from the users list of events which are already hosted
            string updatedEvents = "";


            foreach (string event1 in events) //Recreate string to be inserted back into the table except without the event
            {
                if (event1 != "")
                {
                    updatedEvents += event1 + ",";
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
            //Update user's list without this event
            sqlcommand2.CommandText = $"UPDATE Users SET eventIDs='{updatedEvents}' WHERE username = '{username}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        bool mostRecent; //Checked in contentClick event (so that if it is updated, other actions are prevented)
        int selectedRowIndex;
        private void dgv_events_Click(object sender, EventArgs e)
        {
            if (dgv_events.Rows.Count > 0) //If an event does exist
            {
                selectedRowIndex = dgv_events.SelectedCells[0].RowIndex;
                selectedEvent = dgv_events.Rows[selectedRowIndex].Cells["eventName"].Value.ToString();
                mostRecent = CheckLastUpdated_Event(selectedEvent); //Check if the event has been updated since the dgv was populated
                if (!mostRecent) //If the user isn't using the mostRecent datagridview, then update
                {
                    MessageBox.Show("Your events have been recently changed. Updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PopulateWithMyEvents();
                }
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            PopulateWithMyEvents(); //When the user wants to refresh the ddatagridview, they can click the reset button
        }

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
            //Get information for the event
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
            //Update the time stored in lastUpdated
            sqlcommand2.CommandText = $"UPDATE Events SET lastUpdated='{DateTime.Now}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void dgv_events_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0) //Only if the cell to be formatted is in the first column (these buttons are the ones impacted)
            {
                int rowIndex = e.RowIndex; //Use index to check the status for that event (stored in different cell)
                if (dgv_events.Rows[rowIndex].Cells[4].Value.ToString() == "Pending") //If the event is hosted
                {
                    //Establish connection
                    MySqlConnection con2 = new MySqlConnection(cs);
                    //Open the connection to the database
                    con2.Open();

                    //Used to create command
                    MySqlCommand sqlcommand2 = new MySqlCommand();
                    sqlcommand2.Connection = con2;
                    sqlcommand2.CommandType = CommandType.Text;
                    //Get the RSVP information for the event from the SQL server (as not contained in the dgv).
                    //NOTE: this cannot be done by using the hidden dgv as that is only populated with the currently
                    //selected event whereas this should apply at the form opening
                    sqlcommand2.CommandText = $"SELECT * FROM Events WHERE eventName ='{dgv_events.Rows[rowIndex].Cells[2].Value.ToString()}'";
                    //Execute command and get data
                    MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);

                    //Create table that recieves data from command
                    DataTable table2 = new DataTable();
                    //Fill this datatable with return from data adapter
                    dataAdapter2.Fill(table2);

                    //For the user's information, tell them its RSVP
                    e.Value = $"Hosted: {table2.Rows[0]["rsvp"].ToString()}";
                }
                else if (dgv_events.Rows[rowIndex].Cells[4].Value.ToString() == "Hosted")
                {
                    e.Value = "View Details"; //Otherwise, if the event is already hosted, let the user view details.
                }
            }
        }
    }
}
