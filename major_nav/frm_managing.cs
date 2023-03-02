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
    public partial class frm_managing : Form
    {
        public frm_managing()
        {
            InitializeComponent();

            SetupForm();
        }

        private void SetupForm()
        {
            PopulateEvent(); //Get info for this event
            PopulateUser(); //Get info for the user
            FillWithInfo(); //Fill the form with that info
        }

        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //Connection string to login the database
        //Stores which user is logged in
        public static string username = "";
        //Stores which event is being managed (selected  before clicked)
        public static string eventName = "";
        private void FillWithInfo()
        {
            txt_eventName.Text = dgv_eventData.Rows[0].Cells["eventName"].Value.ToString();
            txt_owner.Text = dgv_eventData.Rows[0].Cells["owner"].Value.ToString();
            int peopleInvited = dgv_eventData.Rows[0].Cells["attendees"].Value.ToString().Split(',').Count() - 1;
            txt_noInvited.Text = peopleInvited.ToString(); //Set the number of people to the number of attendees
            txt_cost.Text = dgv_eventData.Rows[0].Cells["cost"].Value.ToString();
            txt_duration.Text = dgv_eventData.Rows[0].Cells["eventDuration"].Value.ToString();
            txt_description.Text = dgv_eventData.Rows[0].Cells["eventDescription"].Value.ToString();
            txt_rsvp.Text = dgv_eventData.Rows[0].Cells["rsvp"].Value.ToString();
            PopulateFriends();

        }

        public void Refresh()
        {
            PopulateEvent();
            FillWithInfo();
        }

        private void PopulateFriends()
        {
            lbl_lastUpdate.Text = DateTime.Now.ToString(); //Track when last updated
            List<string> attendees = new List<string>(); //Public because 'if' variables are stored locally
            //List more readable to work with when deleting elements
            if (dgv_eventData.Rows[0].Cells["attendees"].Value.ToString() != "")
            {
                attendees = dgv_eventData.Rows[0].Cells["attendees"].Value.ToString().Split(',').ToList(); //Only if attendees exist
            }
            try
            {
                dgv_invitees.Rows.Clear(); //If there are rows to clear, and attendees exist
            }
            catch
            {
            }

            foreach (string user in attendees) //Add each attendee to the datagridview
            {
                if (user != "")
                {
                    dgv_invitees.Rows.Add($"{user}[ATTENDING]"); //If user is not empty user, add to list
                }
            }

            List<string> invitees = new List<string>(); //Public because 'if' variables are stored locally
            //List more readable to work with when deleting elements
            if (dgv_eventData.Rows[0].Cells["invitees"].Value.ToString() != "") //If there are people invited
            {
                invitees = dgv_eventData.Rows[0].Cells["invitees"].Value.ToString().Split(',').ToList();

            }

            foreach (string user in invitees) //Add each invitee to the datagridview
            {
                if (user != "")
                {
                    dgv_invitees.Rows.Add($"{user}[INVITED]"); //If user is not empty user, add to list
                }
            }

            List<string> timeDates = dgv_eventData.Rows[0].Cells["eventTime"].Value.ToString().Split(',').ToList();
            try
            {
                dgv_timeDates.Rows.Clear(); //If options already exist, then clear
            }
            catch
            {
            }

            foreach (string option in timeDates) //Add each option for the time and date of the event to the datagridview
            {
                if (option != "") //If an option exists
                {
                    if (option.Contains('[')) //If it contains a [ (because the event is not yet hosted - so it contains the number of votes)
                    {
                        dgv_timeDates.Rows.Add($"{option.Substring(0, option.IndexOf('['))}"); //Then just grab the actual option -> not the number of votes
                    }
                    else //Event already hosted
                    {
                        dgv_timeDates.Rows.Add(option); //Add option to view
                    }
                }
            }

            List<string> location = dgv_eventData.Rows[0].Cells["eventLocation"].Value.ToString().Split(',').ToList();
            try
            {
                dgv_locations.Rows.Clear(); //If options already exist, then clear
            }
            catch
            {
            }

            foreach (string option in location) //Add each option for the time and date of the event to the datagridview
            {
                if (option != "") // If an option exists
                {
                    if (option.Contains('['))//If it contains a [ (because the event is not yet hosted - so it contains the number of votes)
                    {
                        dgv_locations.Rows.Add($"{option.Substring(0, option.IndexOf('['))}"); //Then just grab the actual option -> not the number of votes
                    }
                    else //Event already hosted
                    {
                        dgv_locations.Rows.Add(option); //Add option to view
                    }
                }
            }
        }


        private void PopulateEvent() //Get information for event 
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

        private void PopulateUser() //Get information for user
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get record for user
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username = '{username}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            dgv_userData.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }



        string selectedFriend; //Store which name the user is selected
        string selectedFriendName; //Get their username without the [ATTENDING] or [INVITED] attached (which are just to inform user)
        private void btn_uninvite_Click(object sender, EventArgs e)
        {
            bool mostRecent = CheckLastUpdated_Event(eventName); //Check if the event (users invited/attending) has been updated
            if (mostRecent)
            {
                int selectedRowIndex = dgv_invitees.SelectedCells[0].RowIndex;
                selectedFriend = dgv_invitees.Rows[selectedRowIndex].Cells[0].Value.ToString();
                selectedFriendName = selectedFriend.Substring(0, selectedFriend.IndexOf('[')); //Just get the name part without the [ATTENDING] or [INVITED] attached (which are just to inform user)

                PopulateFriend(); //Get information for this friend


                if (selectedFriend.Substring(selectedFriend.IndexOf('[') + 1, selectedFriend.IndexOf(']') - selectedFriend.IndexOf('[') - 1) == "INVITED") //If the user was INVITED (attached had invited)
                {
                    UpdateInvited(); //Then remove from the users that are invited
                }
                else
                {
                    UpdateAttending(); //Then remove from the users that are attending
                }
                ReUpdate_Event(eventName); //Update the event as the users invited/attending have been changed
                Refresh(); //Update all the datagridviews (remove user graphically)
                MessageBox.Show($"User successfully uninvited.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Users attending/invited has been changed. Updating.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refresh(); //Update all the datagridviews (remove user graphically)
            }
        }

        private void UpdateAttending() //Remove (attending) user
        {
            //FROM FRIENDS' LIST, REMOVE THIS EVENT FROM THEIR LIST OF EVENTS
            //List more readable to work with when deleting elements
            List<string> eventIDs = dgv_friendData.Rows[0].Cells["eventIDs"].Value.ToString().Split(',').ToList(); //Get list of all of their events
            eventIDs.Remove(eventName); //Remove this event
            string updatedEventIDs = "";

            foreach (string ID in eventIDs) //Recreate string to be inserted back into the table except without this event
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
            //Update with removed event
            sqlcommand.CommandText = $"UPDATE Users SET eventIDs='{updatedEventIDs}' WHERE username ='{selectedFriendName}'";
            sqlcommand.ExecuteNonQuery();

            //Close connection with cloud server
            con2.Close();


            //List more readable to work with when deleting elements
            List<string> attendees = dgv_eventData.Rows[0].Cells["attendees"].Value.ToString().Split(',').ToList();
            attendees.Remove(selectedFriendName); //Remove this friend as an attendee to the event
            string updatedattendees = "";

            foreach (string user in attendees) //Recreate string to be inserted back into the table except without the user
            {
                if (user != "")
                {
                    updatedattendees += user + ",";
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
            //List of attendees without removed attendee
            sqlcommand2.CommandText = $"UPDATE Events SET attendees='{updatedattendees}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();

            //If event hasn't yet been hosted but user is attending, then they must have already cast their votes
            //So these need to be reset
            if (dgv_eventData.Rows[0].Cells["status"].Value.ToString() == "Pending")
            {
                RemoveUsersVotesRecord();
            }
        }

        private void UpdateInvited() //Remove (invited) user
        {
            //List more readable to work with when deleting elements
            List<string> invitationIDs = dgv_friendData.Rows[0].Cells["invitationIDs"].Value.ToString().Split(',').ToList(); //Get list of all events theyre currently invited to
            invitationIDs.Remove(eventName); //Remove this event
            string updatedInvitationIDs = "";

            foreach (string ID in invitationIDs) //Recreate string to be inserted back into the table except without the event
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
            //Update without this event
            sqlcommand.CommandText = $"UPDATE Users SET invitationIDs='{updatedInvitationIDs}' WHERE username ='{selectedFriendName}'";
            sqlcommand.ExecuteNonQuery();

            //Close connection with cloud server
            con2.Close();


            //List more readable to work with when deleting elements
            List<string> invitees = dgv_eventData.Rows[0].Cells["invitees"].Value.ToString().Split(',').ToList(); //Get current list of invited users
            invitees.Remove(selectedFriendName); //Remove friend from
            string updatedInvitees = "";

            foreach (string user in invitees) //Recreate string to be inserted back into the table except without the user
            {
                if (user != "")
                {
                    updatedInvitees += user + ",";
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
            //Update without this user
            sqlcommand2.CommandText = $"UPDATE Events SET invitees='{updatedInvitees}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void RemoveUsersVotesRecord()
        {
            //NOTE: Users votes are recorded in format [USERNAME]-[1,2,3]-[1,2,3]|
            //Where the first [1,2,3] records the votes that the user made for time/date
            //The second [1,2,3] stores order for location votes
            //| separates users

            //List more readable to work with when deleting elements
            //The record votes for each user are separated with '|'
            string[] votes = dgv_eventData.Rows[0].Cells["recordVotes"].Value.ToString().Split('|');
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
                    string currentUserVote = votes[i].Split('-')[0];
                    //Check if the username equals by taking a substring IN BETWEEN BUT NOT INCLUDING the [] characters
                    currentUsersRecord = currentUserVote.Substring(1, currentUserVote.IndexOf("]") - 1);
                    if (currentUsersRecord == selectedFriendName) //Choose with IF = -> because we know the name will be somewhere, test and test2 would both be regonised with a .contains
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
            string[] dayTimeCurrentVotes = dgv_eventData.Rows[0].Cells["eventTime"].Value.ToString().Split(',');

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
            string[] locationsCurrentVotes = dgv_eventData.Rows[0].Cells["eventLocation"].Value.ToString().Split(',');

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
            string[] dayTime = dgv_eventData.Rows[0].Cells["eventTime"].Value.ToString().Split(',');

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

            string[] location = dgv_eventData.Rows[0].Cells["eventLocation"].Value.ToString().Split(',');

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
            List<string> voteRecord = dgv_eventData.Rows[0].Cells["recordVotes"].Value.ToString().Split('|').ToList();
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
            sqlcommand2.CommandText = $"UPDATE Events SET recordVotes='{updatedVoteRecord}',eventLocation='{location_newPriorities}',eventTime='{dayTime_newPriorities}' WHERE eventName= '{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void PopulateFriend() //Get information for currently selected user
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get record for friend
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username = '{selectedFriendName}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            dgv_friendData.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }

        private void btn_removeOption_timeDate_Click(object sender, EventArgs e) //Remove the time/date option
        {
            int selectedRowIndex = dgv_timeDates.SelectedCells[0].RowIndex;
            string selectedTimeDate = dgv_timeDates.Rows[selectedRowIndex].Cells[0].Value.ToString(); //Get the currently selected timeDate option

            if (dgv_timeDates.Rows.Count > 1) //Providing a time/date or an option for it still exists 
            {
                //List more readable to work with when deleting elements
                List<string> timeDates = dgv_eventData.Rows[0].Cells["eventTime"].Value.ToString().Split(',').ToList();

                int indexOfTime = 0;
                //Separate all of the time/dates (twice because one is for the votes and the other is for the actual options)
                string[] dayTime = dgv_eventData.Rows[0].Cells["eventTime"].Value.ToString().Split(',');

                //For each item in the first array, get only the option (cut out [])
                for (int i = 0; i < dayTime.Length - 1; i++)
                {
                    //Find the ID that matches with the time/date (which can then be used to remove the version from the list with the [ ] preference)
                    if (dayTime[i].Substring(0, dayTime[i].IndexOf("[")) == selectedTimeDate)
                    {
                        indexOfTime = i;
                    }
                }
                //Remove the selected timedate (but have to get ID first because have to delete the vote associated with it too)
                timeDates.Remove(timeDates[indexOfTime]);
                string updatedTimeDates = "";

                foreach (string option in timeDates) //Recreate string to be inserted back into the table except without the option
                {
                    if (option != "")
                    {
                        updatedTimeDates += option + ",";
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
                //Update time and date options except without the event
                sqlcommand.CommandText = $"UPDATE Events SET eventTime='{updatedTimeDates}' WHERE eventName ='{eventName}'";
                sqlcommand.ExecuteNonQuery();

                //Close connection with cloud server
                con2.Close();

                ReUpdate_Event(eventName); //Update the event (as new information added)
                Refresh(); //Refresh the datagridviews
                MessageBox.Show($"Time date option successfully removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Must have a time/date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_removeOption_location_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgv_locations.SelectedCells[0].RowIndex;
            string selectedLocation = dgv_locations.Rows[selectedRowIndex].Cells[0].Value.ToString();  //Get the currently selected location option

            if (dgv_locations.Rows.Count > 1)  //Ensure at least one option exists
            {
                //List more readable to work with when deleting elements
                List<string> locations = dgv_eventData.Rows[0].Cells["eventLocation"].Value.ToString().Split(',').ToList();

                int indexOfLocation = 0;
                //Separate all of the time/dates (twice because one is for the votes and the other is for the actual options)
                string[] location = dgv_eventData.Rows[0].Cells["eventLocation"].Value.ToString().Split(',');

                //For each item in the first array, get only the option (cut out [])
                for (int i = 0; i < location.Length - 1; i++)
                {
                    //Find the ID that matches with the time/date (which can then be used to remove the version from the list with the [ ] preference)
                    if (location[i].Substring(0, location[i].IndexOf("[")) == selectedLocation)
                    {
                        indexOfLocation = i;
                    }
                }

                locations.Remove(locations[indexOfLocation]); //Remove the selected location with the entire []
                string updatedlocations = "";

                foreach (string option in locations)  //Recreate string to be inserted back into the table except without the option
                {
                    if (option != "")
                    {
                        updatedlocations += option + ",";
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
                //Update time and date options except without the event
                sqlcommand.CommandText = $"UPDATE Events SET eventLocation='{updatedlocations}' WHERE eventName ='{eventName}'";
                sqlcommand.ExecuteNonQuery();

                //Close connection with cloud server
                con2.Close();

                ReUpdate_Event(eventName);  //Update the event (as new information added)
                Refresh();  //Refresh the datagridviews
                MessageBox.Show($"Location option successfully removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Must have a location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Refresh(); //Refresh datagridviews
        }

        private void btn_newInvitee_Click(object sender, EventArgs e) //When want to add a new user
        {
            frm_inviteFriend.username = username; //Send this user as the username
            frm_inviteFriend.eventName = eventName; //Semd this eventname
            frm_inviteFriend inviteFriend = new frm_inviteFriend(this); //Open form
            inviteFriend.ShowDialog();
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            Close(); //When the user is complete, return them to the myEvents form
        }
    }
}
