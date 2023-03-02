using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization; //custom timedate
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Can connect to cloud database

namespace major_nav
{
    public partial class frm_friends : Form
    {
        public frm_friends()
        {
            InitializeComponent();

            ReUpdate(); //This populates/repopulates all of the datagridviews
        }

        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //String to connect and log in to cloud database
        public static string username = ""; //Store user logged in


        private void txt_friendName_Click(object sender, EventArgs e)
        {
            if (txt_friendName.Text == "Friend Username") //Only revert format if user has not entered new input
            {
                txt_friendName.Text = "";
            }
        }

        private void txt_friendName_Leave(object sender, EventArgs e)
        {
            if (txt_friendName.Text == "") //Only revert format if user has not entered new input
            {
                txt_friendName.Text = "Friend Username";
            }
        }

        private void ReUpdate() //Populate/repopulate all datagridviews
        {
            PopulateFriends(); //Populate list of user's friends
            PopulateRequests(); //Populate list of user's requests recieved
            PopulateSentRequests(); //Populate list of user's sent requests
        }

        private void PopulateFriends()
        {
            PopulateUser(); //Get most recent information
            lbl_lastUpdate.Text = DateTime.Now.ToString(); //Reupdate the last time that the dgv's were updated for user's info (e.g if friend was like update ur list they could read)
            List<string> friends = dgv_user.Rows[0].Cells["friends"].Value.ToString().Split(',').ToList(); //Get all of the names which are separated be a comma
            dgv_friends.Rows.Clear();

            for (int i = 0; i < friends.Count; i++) //For each friend, add a row and set the value to that frined name
            {
                if (friends[i] != "")
                {
                    dgv_friends.Rows.Add("");
                    dgv_friends.Rows[i].Cells[0].Value = friends[i];
                    dgv_friends.Rows[i].Height = 40; //For aesthetics, set the height of each row to 40px
                }
            }
        }

        private void PopulateSentRequests() //Populate list of user's sent requests
        {
            PopulateUser(); //Get most recent information
            lbl_lastUpdate.Text = DateTime.Now.ToString(); //Reupdate the last time that the dgv's were updated for user's info (e.g if friend was like update ur list they could read)
            List<string> friends = dgv_user.Rows[0].Cells["sentRequests"].Value.ToString().Split(',').ToList(); //Get all of the names which are separated be a comma
          
            dgv_sentRequests.Rows.Clear(); //Clear so that adding rows does not already add to a list
            for (int i = 0; i < friends.Count; i++) //For each friend, add a row and set the value to that frined name
            {
                if (friends[i] != "")
                {
                    dgv_sentRequests.Rows.Add("");
                    dgv_sentRequests.Rows[i].Cells[0].Value = friends[i];
                    dgv_sentRequests.Rows[i].Height = 40; //For aesthetics, set the height of each row to 40px
                }
            }
        }

        private void PopulateRequests()
        {
            PopulateUser(); //Get most recent information
            lbl_lastUpdate.Text = DateTime.Now.ToString(); //Reupdate the last time that the dgv's were updated for user's info (e.g if friend was like update ur list they could read)
            List<string> friends = dgv_user.Rows[0].Cells["friendInvitations"].Value.ToString().Split(',').ToList(); //Get all of the names which are separated be a comma

            dgv_friendInvites.Rows.Clear();
            for (int i = 0; i < friends.Count; i++) //For each friend, add a row and set the value to that frined name
            {
                if (friends[i] != "")
                {
                    dgv_friendInvites.Rows.Add("");
                    dgv_friendInvites.Rows[i].Cells[0].Value = friends[i];
                    dgv_friendInvites.Rows[i].Height = 40; //For aesthetics, set the height of each row to 40px
                }
            }
        }

        private void PopulateUser() //Get information for user
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

  

        string selectedFriendName = "";//Get name of user that is selected in the friends datagridview
        private void dgv_friends_CellContentClick(object sender, DataGridViewCellEventArgs e) //When one of the buttons are pressed in the user's list of friends
        {
            int selectedRowIndex = dgv_friends.SelectedCells[0].RowIndex;
            selectedFriendName = dgv_friends.Rows[selectedRowIndex].Cells[0].Value.ToString(); //Set the current friend to the selected name
            if (mostRecent) //Check mostRecent from the click event -> ensures that if isn't the most recent version, this event isn't called twice
            {
                if (e.ColumnIndex == dgv_friends.Columns[2].Index && e.RowIndex >= 0) //If user clicks REMOVE
                {
                    if (MessageBox.Show($"Are you sure you want to remove {selectedFriendName}? You will have te re-request them.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        RemoveFriend();
                        ReUpdate_User(selectedFriendName);
                        ReUpdate_User(username);
                        PopulateFriends();
                    }
                }
            }
        }

        private void RemoveFriend()
        {
            PopulateWithSelectedFriend(); //Get information for current friend
            RemoveFriendFromUser(); //Remove friend from user's friend list
            RemoveUserFromFriend(); //Remove user from friend's list
            MessageBox.Show($"{selectedFriendName} successfully removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PopulateWithSelectedFriend() //Get info for selected event
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get information for the friend that is currently selected
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username = '{selectedFriendName}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);

            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            dgv_friend.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }

        private void RemoveFriendFromUser() //Remove the friend from the user's friend list
        {
            //List more readable to work with when deleting elements
            List<string> friends = dgv_user.Rows[0].Cells["friends"].Value.ToString().Split(',').ToList(); //Get user's friends
            friends.Remove(selectedFriendName); //Remove friend
            string updatedFriends = "";


            foreach (string user in friends) //Recreate string to be inserted back into the table except without the friend
            {
                if (user != "")
                {
                    updatedFriends += user + ",";
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
            //Update friend's list without selected friend
            sqlcommand2.CommandText = $"UPDATE Users SET friends='{updatedFriends}' WHERE username='{username}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();

        }

        private void RemoveUserFromFriend() //Remove user from friend's list
        {
            //List more readable to work with when deleting elements
            List<string> friends = dgv_friend.Rows[0].Cells["friends"].Value.ToString().Split(',').ToList(); //Get selected friend's list
            friends.Remove(username); //Remove this user from it
            string updatedFriends = "";


            foreach (string user in friends) //Recreate string to be inserted back into the table except without the user
            {
                if (user != "")
                {
                    updatedFriends += user + ",";
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
            //Update friend's list except without user (remove user from list)
            sqlcommand2.CommandText = $"UPDATE Users SET friends='{updatedFriends}' WHERE username='{selectedFriendName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void btn_requestFriend_Click(object sender, EventArgs e) //When the user requests a friend
        {
            bool exists = CheckUserExists(); //Check if such user exists
            if (txt_friendName.Text == username) //Ensure they aren't adding themselves
            {
                MessageBox.Show("You cannot add yourself as a friend.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (exists == true) //If the user did exist
                {
                    string message = CheckIfFriendExists(); //Check if user has already added the friend
                    if (message == "")
                    {
                        PopulateWithFriendRequest(); //Get information for the requested friend
                        AddFriends(); //Add user to request's list and request to user's sent list
                        ReUpdate_User(txt_friendName.Text); //Change the friend's last updated time so that they must reupdate their dgv (show new user)
                        ReUpdate(); //Update all of the datagridviews
                        MessageBox.Show($"Request successfully sent to {txt_friendName.Text}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Show whichever error (user already existed)
                    }
                }
                else
                {
                    MessageBox.Show("User does not exist. Please check the username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void PopulateWithFriendRequest() //Get info for the friend that the user requested
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get information for requested friend
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username = '{txt_friendName.Text}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            dgv_friend.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }

        private string CheckIfFriendExists() //Check if the user has already added this friend
        {
            string message = "";
            string friendName = txt_friendName.Text;
            //If either of the lists contain the friend's username, then they already exist
            bool friendExists = dgv_user.Rows[0].Cells["friends"].Value.ToString().Split(',').ToList().Contains(friendName);
            bool sentExists = dgv_user.Rows[0].Cells["sentRequests"].Value.ToString().Split(',').ToList().Contains(friendName);
            bool received = dgv_user.Rows[0].Cells["friendInvitations"].Value.ToString().Split(',').ToList().Contains(friendName);
            if (friendExists == true)
            {
                message = "You are already friends with this user.";
            }
            else if (sentExists)
            {
                message = "You have already requested this user.";
            }
            else if (received)
            {
                message = "You already have a request from this user.";
            }
            return message; //Display message to user
        }

        private void AddFriends() //Add a friend that a user has requested
        {
            UserToFriendsList(); //Add the current user to the requested user's list of invitations
            FriendToSentList(); //Add friend to the user's list of outgoing requests
        }

        private void UserToFriendsList() //Add current user to the friend's list of friend requests
        {
            string friendName = txt_friendName.Text;

            //List more readable to work with when deleting elements
            List<string> friends = dgv_friend.Rows[0].Cells["friendInvitations"].Value.ToString().Split(',').ToList();
            friends.Add(username);    //Add user as having sent a request (that they can accept)
            string updatedFriends = "";


            foreach (string user in friends) //Recreate string to be inserted back into the table except without the user
            {
                if (user != "")
                {
                    updatedFriends += user + ",";
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
            //Add user as having sent a request (that they can accept)
            sqlcommand2.CommandText = $"UPDATE Users SET friendInvitations='{updatedFriends}' WHERE username='{friendName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void FriendToSentList() //Add name to record of outgoing requests (for user)
        {
            string friendName = txt_friendName.Text;

            //List more readable to work with when deleting elements
            List<string> friends = dgv_user.Rows[0].Cells["sentRequests"].Value.ToString().Split(',').ToList(); //Get the list of current outgoing friend requests
            friends.Add(friendName); //Add requested ser to the list
            string updatedFriends = "";

            foreach (string user in friends) //Recreate string to be inserted back into the table except with new user
            {
                if (user != "")
                {
                    updatedFriends += user + ",";
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
            //Add user as an outgoing request
            sqlcommand2.CommandText = $"UPDATE Users SET sentRequests='{updatedFriends}' WHERE username='{username}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }


        private bool CheckUserExists() //Check if the user that is attempting to be requested exists
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get record for any users who match
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username='{txt_friendName.Text}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);

            //Close connection with cloud server
            con.Close();

            //If any records are found (rows > 0)
            if (table2.Rows.Count > 0)
            {
                return true; //Then user found
            }
            else
            {
                return false; //User not found
            }
        }


        string selectedInviteName = ""; //Name for whichever user who has sent an invite is

        private void dgv_friendInvites_CellContentClick(object sender, DataGridViewCellEventArgs e) //If the ACCEPT or IGNORE request button is clicked
        {
            if (mostRecent) //If using the most recent version of table (this ensures if not most recent, not caleld twice)
            {
                if (e.ColumnIndex == dgv_friendInvites.Columns[2].Index && e.RowIndex >= 0) //ACCEPT button clicked
                {
                    int selectedRowIndex = dgv_friendInvites.SelectedCells[0].RowIndex;
                    selectedInviteName = dgv_friendInvites.Rows[selectedRowIndex].Cells[0].Value.ToString(); //Only set variable if not clicked the header
                    if (MessageBox.Show($"Are you sure you want to add {selectedInviteName} as your friend?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        MoveUsers(); //Put both user and this invited user in their friend list's respectively
                        ReUpdate_User(selectedInviteName); //Update both user's records as they have been changed
                        ReUpdate_User(username); //Update both user's records as they have been changed
                        ReUpdate(); //Refresh datagridviews
                    }
                }
                else if (e.ColumnIndex == dgv_friendInvites.Columns[3].Index && e.RowIndex >= 0) //ignore request
                {
                    int selectedRowIndex = dgv_friendInvites.SelectedCells[0].RowIndex;
                    selectedInviteName = dgv_friendInvites.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    if (MessageBox.Show($"Are you sure you want to ignore {selectedInviteName} as your friend? You will have to wait until they request you again.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        RemoveRequest(); //Remove the user's send request and the user's request from user's 
                        ReUpdate_User(selectedInviteName); //Update both user's records as they have been changed
                        ReUpdate_User(username); //Update both user's records as they have been changed
                        ReUpdate(); //Refresh datagridviews
                    }
                }
            }
        }

        private void RemoveRequest()
        {
            PopulateUser();//Get most recent information for user
            PopulateWithFriend(); //Get most recent information for friend
            RemoveInviteFromUser(); //Remove the specific user's request from the list of requests
            RemoveFromFriendsSent(); //Remove this user from the friend's list of outgoing requests (as denied)
            MessageBox.Show($"{selectedInviteName} has successfully been removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void PopulateWithFriend()
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get information for the friend theyve selected to ADD (as a friend)
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username = '{selectedInviteName}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            dgv_friend.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }

        private void RemoveInviteFromUser()
        {
            //List more readable to work with when deleting elements
            List<string> friends = dgv_user.Rows[0].Cells["friendInvitations"].Value.ToString().Split(',').ToList(); //Get users current list of requests
            friends.Remove(selectedInviteName); //Remove the current request
            string updatedFriends = "";

            foreach (string user in friends) //Recreate string to be inserted back into the table except without the requesgt
            {
                if (user != "")
                {
                    updatedFriends += user + ",";
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
            //Update without request
            sqlcommand2.CommandText = $"UPDATE Users SET friendInvitations='{updatedFriends}' WHERE username='{username}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void RemoveFromFriendsSent() //Remove from requester's list of outgoing requests
        {
            //List more readable to work with when deleting elements
            List<string> friends = dgv_friend.Rows[0].Cells["sentRequests"].Value.ToString().Split(',').ToList(); //Get current list
            friends.Remove(username); //Remove this user
            string updatedFriends = "";

            foreach (string user in friends) //Recreate string to be inserted back into the table except without the user
            {
                if (user != "")
                {
                    updatedFriends += user + ",";
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
            //Update without user
            sqlcommand2.CommandText = $"UPDATE Users SET sentRequests='{updatedFriends}' WHERE username='{selectedInviteName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void MoveUsers() //Move both friend and user into each other's friend list
        {
            PopulateUser(); //Get most recent information for friend and user
            PopulateWithFriend(); 
            MoveFriend(); //Move friend into user's friends list
            MoveUser(); //Move user into the friends list of the requester
        }


        private void MoveFriend() //Put requester in the user's friend list
        {
            //List more readable to work with when deleting elements
            List<string> friendInvites = dgv_user.Rows[0].Cells["friendInvitations"].Value.ToString().Split(',').ToList();
            friendInvites.Remove(selectedInviteName); //Remove friend from the user's list of invitations
            string updatedFriendInvites = "";

            foreach (string user in friendInvites) //Recreate string to be inserted back into the table except without the requester
            {
                if (user != "")
                {
                    updatedFriendInvites += user + ",";
                }
            }

            //List more readable to work with when deleting elements
            List<string> friends = dgv_user.Rows[0].Cells["friends"].Value.ToString().Split(',').ToList();
            friends.Add(selectedInviteName); //Add requester to the users FRIEND list
            string updatedFriends = "";

            foreach (string user in friends) //Recreate string to be inserted back into the table except without the user
            {
                if (user != "")
                {
                    updatedFriends += user + ",";
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
            //Update by moving requester from user's list of friend requests to an actual friend
            sqlcommand2.CommandText = $"UPDATE Users SET friendInvitations='{updatedFriendInvites}', friends='{updatedFriends}' WHERE username='{username}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void MoveUser() //Put user in from requester's list of outgoing requests into their friends list
        {
            //List more readable to work with when deleting elements
            List<string> friendInvites = dgv_friend.Rows[0].Cells["sentRequests"].Value.ToString().Split(',').ToList();
            friendInvites.Remove(username); //Remove user from requester's list of outgoing requests
            string updatedFriendInvites = "";

            foreach (string user in friendInvites) //Recreate string to be inserted back into the table except without the user
            {
                if (user != "")
                {
                    updatedFriendInvites += user + ",";
                }
            }

            //List more readable to work with when deleting elements
            List<string> friends = dgv_friend.Rows[0].Cells["friends"].Value.ToString().Split(',').ToList();
            friends.Add(username); //Add user to their friend list
            string updatedFriends = "";

            foreach (string user in friends) //Recreate string to be inserted back into the table with user
            {
                if (user != "")
                {
                    updatedFriends += user + ",";
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
            //Update with friend in friends list and out of outgoing request list
            sqlcommand2.CommandText = $"UPDATE Users SET sentRequests='{updatedFriendInvites}', friends='{updatedFriends}' WHERE username='{selectedInviteName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        bool mostRecent; //Global so that the contentclick function can check too
        private void dgv_friends_Click(object sender, EventArgs e)
        {
            mostRecent = CheckLastUpdated_User(username); //Whenever the user clicks friend's list, check for user's details
            if (!mostRecent) //If user has recieved new info, update the datagridview
            {
                MessageBox.Show("Your friends have been recently changed. Updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReUpdate();
            }
        }

        private bool CheckLastUpdated_User(string user)
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get user info
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username = '{user}'";
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
        private void ReUpdate_User(string user) //Reupdate the last time that the user was updated
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Reupdate the last time that the user was updated
            sqlcommand2.CommandText = $"UPDATE Users SET lastUpdated='{DateTime.Now}' WHERE username ='{user}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void dgv_friendInvites_Click(object sender, EventArgs e)
        {
            mostRecent = CheckLastUpdated_User(username); //Check if the user has been updated
            if (!mostRecent) //If not most recent version, reupdate dgv
            {
                MessageBox.Show("Your friends have been recently changed. Updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReUpdate();
            }
        }


        string selectedRequestName; //Name for the friend that is currently selected
        private void dgv_sentRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mostRecent)
            {
                if (e.ColumnIndex == dgv_friendInvites.Columns[2].Index && e.RowIndex >= 0) //If the user wants to retract their outgoing request to a user
                {
                    int selectedRowIndex = dgv_sentRequests.SelectedCells[0].RowIndex;
                    selectedRequestName = dgv_sentRequests.Rows[selectedRowIndex].Cells[0].Value.ToString(); //Set name to selected user

                    if (MessageBox.Show($"Are you sure you want to remove your friend request to {selectedRequestName}? You will have to re-request them.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        PopulateWithSelectedRequestFriend(); //Get data for the selected user
                        ReUpdate_User(selectedRequestName); //Indicate new data for the requested friend
                        ReUpdate_User(username); //Indicate new data for user
                        RemoveSentRequestOfFriend(); //Remove the sent request for that user
                        RemoveRequestFromFriend(); //Remove the request to that user (from this user)
                        ReUpdate(); //Update datagridview
                        MessageBox.Show("Removed friend request.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void PopulateWithSelectedRequestFriend() //Get information for the user whose request is currently selected
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get user whose request is currently selected
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username = '{selectedRequestName}'";
            //Execute command and get data
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(sqlcommand2);
            //Create table that recieves data from command
            DataTable table2 = new DataTable();
            //Fill this datatable with return from data adapter
            dataAdapter2.Fill(table2);
            dgv_requestData.DataSource = table2;

            //Close connection with cloud server
            con.Close();
        }

        private void dgv_sentRequests_Click(object sender, EventArgs e)
        {
            mostRecent = CheckLastUpdated_User(username); //Check if the user's information has been updated
            if (!mostRecent) //If not most recent information then refresh
            {
                MessageBox.Show("Your friends have been recently changed. Updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReUpdate();
            }
        }


        private void RemoveSentRequestOfFriend()//Remove the outgoing request to the selected user
        {
            //List more readable to work with when deleting elements
            List<string> friends = dgv_user.Rows[0].Cells["sentRequests"].Value.ToString().Split(',').ToList();
            friends.Remove(selectedRequestName); //Remove the currently selected user
            string updatedFriends = "";

            foreach (string user in friends) //Recreate string to be inserted back into the table except without the user
            {
                if (user != "")
                {
                    updatedFriends += user + ",";
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
            //Update having removed the user
            sqlcommand2.CommandText = $"UPDATE Users SET sentRequests='{updatedFriends}' WHERE username='{username}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }


        private void RemoveRequestFromFriend() //Remove the request recieved by the user
        {
            //List more readable to work with when deleting elements
            List<string> friends = dgv_requestData.Rows[0].Cells["friendInvitations"].Value.ToString().Split(',').ToList();
            friends.Remove(username); //Remove this user's friend request
            string updatedFriends = "";

            foreach (string user in friends) //Recreate string to be inserted back into the table except without the user
            {
                if (user != "")
                {
                    updatedFriends += user + ",";
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
            //Update removing the user's friend request
            sqlcommand2.CommandText = $"UPDATE Users SET friendInvitations='{updatedFriends}' WHERE username='{selectedRequestName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void txt_friendName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39) //Prevent user entering ' (as the SQL command thinks its end of parameter)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Space) //Prevent user entering space (data validation)
            {
                e.Handled = true;
            }
        }
    }
}
