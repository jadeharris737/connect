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
using System.Globalization; //For datetime format conversion

namespace major_nav
{
    public partial class frm_inviteFriend : Form
    {
        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //String to connect and log in to cloud database
        //This public variable is set when the user logins in and stores which user is currently logged in
        public static string username = "";
        //Store which event the user has selected/is managing from myEvents
        public static string eventName = "";

        private frm_managing managingForm; //Create a form reference so that the friends datagridview can be updated on the myEvents from

        public frm_inviteFriend(Form callingForm)
        {
            InitializeComponent();
            managingForm = callingForm as frm_managing;
            Refresh(); //Update information
        }

        private void Refresh()
        {
            PopulateUser();
            FillFriends();
        }


        private void FillFriends() //Fill the form with the users friends
        {
            lbl_lastUpdate.Text = DateTime.Now.ToString(); //Use to keep track of when the datagridview showing the user's friends was last updated
            //List more readable to work with lists when deleting elements
            //Split into user's friends at the comma
            try
            {
                List<string> friends = dgv_userData.Rows[0].Cells["friends"].Value.ToString().Split(',').ToList();
                try
                {
                    //Ensure that the datagridview is cleared (before more users are added to it) but try statement as can only be done if rows exist (thus first time would throw error)
                    dgv_userData.Rows.Clear();
                }
                catch
                {
                }

                foreach (string user in friends) //Add each friend to the datagridview (so user can select)
                {
                    if (user != "")
                    {
                        dgv_friends.Rows.Add($"{user}");
                    }
                }
            }
            catch
            {
            }
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


        private void lbl_return_Click(object sender, EventArgs e)
        {
            Close(); //Return back to the managing form
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
            //Get most recent information for user
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

        string selectedFriend;
        private void dgv_invitees_Click(object sender, EventArgs e)
        {
            //If the user has been updated since the datagridview was popualated (friends not changed)
            bool mostRecent = CheckLastUpdated_User(username);
            if (mostRecent)
            {
                if (dgv_friends.Rows.Count > 0) //If a friend does exist that the user has selected
                {
                    int selectedRowIndex = dgv_friends.SelectedCells[0].RowIndex;
                    selectedFriend = dgv_friends.Rows[selectedRowIndex].Cells[0].Value.ToString(); //Then set their name to be used
                }
            }
            else //friends have since been changed
            {
                Refresh(); //Re-update datagridview
                MessageBox.Show("Your friends have been recently changed. Updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sendInvite_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgv_friends.SelectedCells[0].RowIndex;
            selectedFriend = dgv_friends.Rows[selectedRowIndex].Cells[0].Value.ToString(); //Set to whichever friend is currently selected (this is user wanting to be invited)
            PopulateEvent(); //Reupdate event in case new users left event
            //Ensure user's cannot be added twice
            if (dgv_eventData.Rows[0].Cells["invitees"].Value.ToString().Contains(selectedFriend) || dgv_eventData.Rows[0].Cells["attendees"].Value.ToString().Contains(selectedFriend))
            {
                MessageBox.Show("Friend already invited/attending", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dgv_eventData.Rows[0].Cells["status"].Value.ToString() == "Hosted") //If the event is already hosted, then they are immediately considered attending
                {
                    PopulateFriend();
                    AddEventToFriend_Hosted();
                    AddFriendToEvent_Hosted();
                    MessageBox.Show("Friend successfully added as attendee.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    managingForm.Refresh();
                    Close(); //Exit invite friend
                }
                else //Otherwise, they can contribute vote (recieve invitation)
                {
                    PopulateFriend();
                    AddEventToFriend_Invite();
                    AddFriendToEvent_Invite();
                    MessageBox.Show("Friend successfully invited.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    managingForm.Refresh();
                    Close();  //Exit invite friend
                }
            }
        }

        private void PopulateFriend() //Populate with information of friend currently selected
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get data for friend that is currently selected 
            sqlcommand2.CommandText = $"SELECT * FROM Users WHERE username = '{selectedFriend}'";
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

        private void AddEventToFriend_Invite() //Add the event to the friend's list of invitations
        {
            //List more readable to work with when deleting elements
            List<string> eventIDs = dgv_friendData.Rows[0].Cells["invitationIDs"].Value.ToString().Split(',').ToList();
            //Add this event name to the users list of events that they are invited to
            eventIDs.Add(eventName);
            string updatedEventIDs = "";

            foreach (string event1 in eventIDs) //Recreate string to be inserted back into the table except without this event
            {
                if (event1 != "")
                {
                    updatedEventIDs += event1 + ",";
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
            //Add the event to the friend's invitation
            sqlcommand2.CommandText = $"UPDATE Users SET invitationIDs='{updatedEventIDs}' WHERE username='{selectedFriend}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }


        private void AddFriendToEvent_Invite() //Add the friend to the list of users invited
        {
            //List more readable to work with when deleting elements
            List<string> invitees = dgv_eventData.Rows[0].Cells["invitees"].Value.ToString().Split(',').ToList();
            //Add friend to list
            invitees.Add(selectedFriend);
            string updatedinvitees = "";

            foreach (string user in invitees) //Recreate string to be inserted back into the table
            {
                if (user != "")
                {
                    updatedinvitees += user + ",";
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
            //Update with new invitee
            sqlcommand2.CommandText = $"UPDATE Events SET invitees='{updatedinvitees}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }


        private void AddEventToFriend_Hosted() //if the event is already hsoted, then add the event to the friend's list of already hosted events they are attending
        {
            //List more readable to work with when deleting elements
            List<string> eventIDs = dgv_friendData.Rows[0].Cells["eventIDs"].Value.ToString().Split(',').ToList();
            eventIDs.Add(eventName);
            string updatedEventIDs = "";

            foreach (string event1 in eventIDs) //Recreate string to be inserted back into the table except without the user
            {
                if (event1 != "")
                {
                    updatedEventIDs += event1 + ",";
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
            //Insert list with this event added
            sqlcommand2.CommandText = $"UPDATE Users SET eventIDs='{updatedEventIDs}' WHERE username='{selectedFriend}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }


        private void AddFriendToEvent_Hosted() //Add the new friend to the list of attendees
        {
            //List more readable to work with when deleting elements
            List<string> attendees = dgv_eventData.Rows[0].Cells["attendees"].Value.ToString().Split(',').ToList();
            attendees.Add(selectedFriend);
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
            //Update with new list of attendees with new user
            sqlcommand2.CommandText = $"UPDATE Events SET attendees='{updatedAttendees}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void PopulateEvent() //Populate with information for the event
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
    }
}
