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
    public partial class frm_settings : Form
    {
        public frm_settings()
        {
            InitializeComponent();
            SetupForm();
        }

        public static string username = ""; //Store which user is logged in
        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //String to connect and log in to cloud database
        private void SetupForm()
        {
            PopulateUser(); //Get data for user
            FillData(); //Fill the form with this info
        }

        private void FillData()
        {
            txt_username.Text = username; //Username passed when the user is initiially logged in
            txt_email.Text = dgv_userData.Rows[0].Cells["email"].Value.ToString(); //Display user's email
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
            //Get user information
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

        private void btn_deleteAccount_Click(object sender, EventArgs e)
        {
            //When a user wishes to delete account - remove username from any friends and any events
            RemoveUserFromEvents();
            RemoveUserFromFriends();
            DeleteAccount(); //Remove their account record
            MessageBox.Show("Account succcesfully removed. Logging out and restarting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart(); //Restart now that their account is removed
        }
        private void ReUpdate_User(string user) //Use to reupdate friends once the user has been removed from their friends list
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Update last updated
            sqlcommand2.CommandText = $"UPDATE Users SET lastUpdated='{DateTime.Now}' WHERE username ='{user}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void ReUpdate_Event(string eventName) //Use to reupdate event once user has been removed as an invitee/attendee
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Reupdate event last updated time
            sqlcommand2.CommandText = $"UPDATE Events SET lastUpdated='{DateTime.Now}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void RemoveUsersVotes()
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
                    if (currentUsersRecord == username) //Choose with IF = -> because we know the name will be somewhere, test and test2 would both be regonised with a .contains
                    {
                        //Then save the id
                        idForUsersVote = i;
                        //More efficient -> leave the loop
                        i = votes.Length;
                    }
                }
            }

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
                dayTime[i] = dayTime[i].Substring(0, dayTime[i].IndexOf("["));
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
                location[i] = location[i].Substring(0, location[i].IndexOf("["));
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
            voteRecord.Remove(currentUsersRecord); //Remove the current user from the '|' (which separates each user)
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
            MessageBox.Show($"Event successfully left.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //Get data for the event
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



        string eventName; //Global as need to populate dgv with information from this event
        private void RemoveUserFromEvents() //Remove user as attendee/invitee from any events
        {
            if (dgv_userData.Rows[0].Cells["invitationIDs"].Value.ToString() != "") //Providing the user is INVITED to any events (prevent errors)
            {
                //List more readable to work with when deleting elements
                List<string> ids = dgv_userData.Rows[0].Cells["invitationIDs"].Value.ToString().Split(',').ToList();

                foreach (string event1 in ids) //For each event they are invited to
                {
                    eventName = event1;
                    //Used to populate with this event's info
                    PopulateEvent();

                    //List more readable to work with when deleting elements
                    List<string> invitees = dgv_eventData.Rows[0].Cells["invitees"].Value.ToString().Split(',').ToList();
                    invitees.Remove(username); //Remove user as invitee
                    string updatedInvitees = "";

                    foreach (string user in invitees) //Recreate string to be inserted back into the table except without the user
                    {
                        if (user != "")
                        {
                            updatedInvitees += user + ",";
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
                    //Update invitee list without user
                    sqlcommand.CommandText = $"UPDATE Events SET invitees='{updatedInvitees}' WHERE eventName ='{eventName}'";
                    sqlcommand.ExecuteNonQuery();

                    //Close connection with cloud server
                    con2.Close();
                    ReUpdate_Event(eventName); //Indicate that event data has been changed (and for other users to update)
                }
            }
            if (dgv_userData.Rows[0].Cells["eventIDs"].Value.ToString() != "")
            {
                //List more readable to work with when deleting elements
                List<string> ids = dgv_userData.Rows[0].Cells["eventIDs"].Value.ToString().Split(',').ToList();

                foreach (string event1 in ids) //Recreate string to be inserted back into the table except without the user
                {
                    eventName = event1;
                    //Used to populate with this event's info
                    PopulateEvent();

                    //List more readable to work with when deleting elements
                    List<string> attendees = dgv_eventData.Rows[0].Cells["attendees"].Value.ToString().Split(',').ToList();
                    attendees.Remove(username); //Remove user from attending
                    string updatedAttendees = "";

                    foreach (string ID in attendees) //Recreate string to be inserted back into the table except without the user
                    {
                        if (ID != "")
                        {
                            updatedAttendees += ID + ",";
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
                    //Update attendees without user
                    sqlcommand.CommandText = $"UPDATE Events SET attendees='{updatedAttendees}' WHERE eventName ='{eventName}'";
                    sqlcommand.ExecuteNonQuery();

                    //Close connection with cloud server
                    con2.Close();
                    if (dgv_eventData.Rows[0].Cells["status"].Value.ToString() == "Pending")
                    {
                        RemoveUsersVotes(); //Because this event was not yet hosted, remove votes
                    }
                    ReUpdate_Event(eventName); //Indicate that event data has been changed (and for other users to update)
                }
            }
        }

        string friendName; //Global because used in other function to get the information for specific friend chosen
        private void RemoveUserFromFriends()
        {
            if (dgv_userData.Rows[0].Cells["friendInvitations"].Value.ToString() != "") //Only do if user has friend invitations (prevent error)
            {
                //List more readable to work with when deleting elements
                //Get all of the users who have sent a friend request to the current user
                List<string> friends = dgv_userData.Rows[0].Cells["friendInvitations"].Value.ToString().Split(',').ToList();

                foreach (string user in friends) //For each user who has requested the user, get their information then remove this user from their sent requests
                    //(because the account is now deleted)
                {
                    friendName = user;
                    //Used to get friend info in populatefriend
                    PopulateFriend();

                    //List more readable to work with when deleting elements
                    List<string> invitationIDs = dgv_friendData.Rows[0].Cells["sentRequests"].Value.ToString().Split(',').ToList();
                    invitationIDs.Remove(username); //Remove this user
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
                    //Update with new outgoing requests without user for friend
                    sqlcommand.CommandText = $"UPDATE Users SET sentRequests='{updatedInvitationIDs}' WHERE username ='{friendName}'";
                    sqlcommand.ExecuteNonQuery();

                    //Close connection with cloud server
                    con2.Close();

                    ReUpdate_User(friendName); //Indicate that the friend's account has been updated (friend removed)
                }
            }
            //SAME PROCESS AS ABOVE, EXCEPT REMOVING USER FROM FRIENDS' LISTS
            if (dgv_userData.Rows[0].Cells["friends"].Value.ToString() != "") //Only do if user has friends (prevent error)
            {
                //List more readable to work with when deleting elements
                List<string> friends = dgv_userData.Rows[0].Cells["friends"].Value.ToString().Split(',').ToList();

                foreach (string user in friends) //For each friend in the current user's list
                {
                    friendName = user; //Get their information (to get their list of friends from
                    PopulateFriend();

                    //List more readable to work with when deleting elements
                    List<string> friendsList = dgv_friendData.Rows[0].Cells["friends"].Value.ToString().Split(',').ToList();
                    friends.Remove(username); //Remove this user from that list
                    string updatedFriends = "";

                    foreach (string friend in friendsList) //Recreate string to be inserted back into the table except without the user
                    {
                        if (user != "")
                        {
                            updatedFriends += user + ",";
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
                    //Remove user from friends' lists
                    sqlcommand.CommandText = $"UPDATE Users SET friends='{updatedFriends}' WHERE username ='{friendName}'";
                    sqlcommand.ExecuteNonQuery();

                    //Close connection with cloud server
                    con2.Close();

                    ReUpdate_User(friendName); //Indicate that the friend's account has been updated (friend removed)
                }
            }
        }

        private void PopulateFriend() //Get information for selected friend
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username = '{friendName}'";
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

        private void DeleteAccount()
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Remove account record
            sqlcommand2.CommandText = $"DELETE FROM Users WHERE username='{username}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
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

        private void btn_generatePass_Click_1(object sender, EventArgs e)
        {
            txt_password.UseSystemPasswordChar = true; //Now password generated, hide
            GeneratePassword();
        }

        private void btn_passwordShow_MouseEnter(object sender, EventArgs e)
        {
            if (txt_password.Text != "Password")
            {
                txt_password.HideSelection = true; //For aeshtetics
                btn_passwordShow.Text = "HIDE"; //Indicate that the password can he hidden 
                txt_password.UseSystemPasswordChar = false; //Change the textbox to use plain text (show the password)

            }
        }

        private void btn_passwordShow_MouseLeave(object sender, EventArgs e)
        {

            if (txt_password.Text != "Password") //Only revert format if user has not entered new input
            {
                btn_passwordShow.Text = "SHOW"; //Indicate that the password can be shown
                txt_password.UseSystemPasswordChar = true; //Change the textbox to use password characters (censor the password)
            }

        }

        private void txt_password_Click(object sender, EventArgs e)
        {
            if (txt_password.Text == "Password") //Only revert format if user has not entered new input
            {
                txt_password.Text = "";
                txt_password.UseSystemPasswordChar = true; //If password is default, then hide password as user starts typing
            }
        }

        private void txt_password_Leave(object sender, EventArgs e)
        {
            if (txt_password.Text == "") //Only revert format if user has not entered new input
            {
                txt_password.Text = "Password"; //Return to password entry if no password has been entered
                txt_password.UseSystemPasswordChar = false; //If nothing entered then show password title
            }
        }

        private void btn_changePassword_Click(object sender, EventArgs e)
        {
            if (txt_password.Text.Length < 9)
            {
                MessageBox.Show("Password must be greater than 8 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show($"Are you sure you want to change your password to what you havve entered in the password textbox? This cannot be reversed.", "Confirmaton", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    //Establish connection
                    MySqlConnection con = new MySqlConnection(cs);
                    //Open the connection to the database
                    con.Open();

                    //Used to create command
                    MySqlCommand sqlcommand2 = new MySqlCommand();
                    sqlcommand2.Connection = con;
                    sqlcommand2.CommandType = CommandType.Text;
                    //Change password by updating the cell for that user
                    sqlcommand2.CommandText = $"UPDATE Users SET password='{txt_password.Text}' WHERE username='{username}'";
                    sqlcommand2.ExecuteNonQuery();

                    //Close connection with cloud server
                    con.Close();
                    MessageBox.Show("Password successfully changed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to remove your temporary password? This cannot be reversed.", "Confirmaton", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //Establish connection
                MySqlConnection con = new MySqlConnection(cs);
                //Open the connection to the database
                con.Open();

                //Used to create command
                MySqlCommand sqlcommand2 = new MySqlCommand();
                sqlcommand2.Connection = con;
                sqlcommand2.CommandType = CommandType.Text;
                //Remove temporary password by clearing the cell for the user
                sqlcommand2.CommandText = $"UPDATE Users SET securityCode='' WHERE username='{username}'";
                sqlcommand2.ExecuteNonQuery();

                //Close connection with cloud server
                con.Close();
                MessageBox.Show("Your security code has been removed. Request a new password if needed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            //When user TAB's into the control, ensure that password is concealed
            if (txt_password.Text != "Password")
            {
                txt_password.UseSystemPasswordChar = true;
                //Ensure if user copy and pastes, not ' or spaces
                txt_password.Text = txt_password.Text.Replace(" ", "");
                txt_password.Text = txt_password.Text.Replace("'", "");
            }
        }
    }
}
