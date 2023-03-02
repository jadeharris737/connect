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
    public partial class frm_eventsInvited : Form
    {

        private frm_nav nav; //Create a form reference so that the myEvents can be called when user wants to create new event

        public frm_eventsInvited(Form callingForm)
        {
            InitializeComponent();
            nav = callingForm as frm_nav;

            //DisableDataGridViewSorting();

            dgv_events.RowTemplate.Height = 40;
            Refresh2();
        }

        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //String to connect and log in to cloud database
        //This public variable is set when the user logins in and stores which user is currently logged in
        public static string username = "";


        public void Refresh2() //Refresh the information for the events
        {
            PopulateUser();
            PopulateWithMyEvents();
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
            //Get information for the user
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
            //Set last time the datagridview was updated
            lbl_lastUpdate.Text = DateTime.Now.ToString();

            //Create a list of all of the IDs for the events that the current user is invited to
            List<string> events = new List<string>();
            if (dgv_currentUserInfo.Rows[0].Cells["invitationIDs"].Value.ToString() != "")
            {
                //Get each ID by splitting at comma
                events = dgv_currentUserInfo.Rows[0].Cells["invitationIDs"].Value.ToString().Split(',').ToList();
            }

            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;

            //Now select all of these events by finding any instances where the eventName column matches any of the IDs and when that record has the status Pending
            //(because this is only displaying events the user is INVITED to -> not attending)
            string getEvents = "SELECT eventName,owner,rsvp FROM Events WHERE eventName IN (";
            foreach (var event1 in events)
            {
                if (event1 != "")
                {
                    getEvents += $"'{event1}',";
                }
            }
            getEvents += $"'') AND (status='Pending')";
            sqlcommand2.CommandText = getEvents; //Query this string

            //Execute command and get data
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



        private void btn_newEvent_Click_1(object sender, EventArgs e)
        {
            nav.btn_myEvents_Click(nav.btn_myEvents, e); //If the user tries to make a new event, redirect to the myEvent form (through nav, to highlight button and change child form displayed)
        }


        //Use in other functions
        int selectedRowIndex = 0;
        string selectedEvent;
        private void dgv_events_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mostRecent) //Providing the datagridview is the most recent version (so that the contentClick and click events don't both fire)
            {
                //If the user clicks the ACCEPT button (content in the column) 
                if (e.ColumnIndex == dgv_events.Columns[1].Index && e.RowIndex >= 0)
                {
                    //Set variables to fill the invitation form then open
                    frm_invitation.eventName = selectedEvent;
                    frm_invitation.openedBy = "Accept";
                    frm_invitationVote.eventName = selectedEvent;
                    frm_invitation invitation = new frm_invitation(this);
                    invitation.ShowDialog();
                } //If the user clicks the VIEW button (content in the column) 
                else if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    //Set variables to fill the invitation(also used for viewing information) form then open
                    frm_invitation.eventName = selectedEvent;
                    frm_invitationVote.eventName = selectedEvent;
                    frm_invitation.openedBy = "View";
                    frm_invitation invitation = new frm_invitation(this);
                    invitation.ShowDialog();
                }
                //If the user clicks the DECLINE button (content in the column) 
                if (e.ColumnIndex == dgv_events.Columns[2].Index && e.RowIndex >= 0)
                {
                    //Confirmation
                    if (MessageBox.Show($"Are you sure you want to decline invite to {dgv_events.Rows[selectedRowIndex].Cells["eventName"].Value.ToString()}? This cannot be reversed.", "Confirmaton", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        DeclineInvite();
                        ReUpdate_Event(selectedEvent);
                        Refresh2();
                    }
                }
            }
        }


        private void DeclineInvite()
        {
            UpdateEventInvitees(); //Remove user from the event's invitees (as they declined)
            UpdateUserInvitationIDs(); //Remove event from user's events that they are invited to (as they declined)

        }

        private void UpdateEventInvitees() //Remove user from the event
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



            //List more readable to work with when deleting elements
            List<string> invitees = dgv_currentEventSelection.Rows[0].Cells["invitees"].Value.ToString().Split(',').ToList();
            invitees.Remove(username); //Remove the user from the list of invitees
            string updatedInvitees = "";


            foreach (string user in invitees) //Recreate string to be inserted back into the table except without the user
            {
                if (user != "")
                {
                    updatedInvitees += user + ",";
                }
            }

            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Update with new list of invitees without user
            sqlcommand2.CommandText = $"UPDATE Events SET invitees='{updatedInvitees}' WHERE eventName ='{selectedEvent}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }



        private void UpdateUserInvitationIDs() //Remove the event from the user's list of invitationID's
        {
            //List more readable to work with when deleting elements
            List<string> invitationIDs = dgv_currentUserInfo.Rows[0].Cells["invitationIDs"].Value.ToString().Split(',').ToList();
            invitationIDs.Remove(selectedEvent); //Remove this event (the event that is selected)
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
            //Update user's list of event's invited to without this event
            sqlcommand.CommandText = $"UPDATE Users SET invitationIDs='{updatedInvitationIDs}' WHERE username ='{username}'";
            sqlcommand.ExecuteNonQuery();

            //Close connection with cloud server
            con2.Close();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Refresh(); //If user wishes to automatically refresh the datagridview
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
            //Update the time stored in lastUpdated
            sqlcommand2.CommandText = $"UPDATE Events SET lastUpdated='{DateTime.Now}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        bool mostRecent;
        private void dgv_events_Click(object sender, EventArgs e) //Check whether event has been updated recently
        {
            if (dgv_events.Rows.Count > 0) //Only if users has been invited to any event
            {
                selectedRowIndex = dgv_events.SelectedCells[0].RowIndex;
                selectedEvent = dgv_events.Rows[selectedRowIndex].Cells["eventName"].Value.ToString();
                mostRecent = CheckLastUpdated_Event(selectedEvent); //Check if the selected date has been recently updated
                if (!mostRecent) //If it has been recently updated
                {
                    MessageBox.Show("Your events have been recently changed. Updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Refresh2(); //Then cancel action and reupdate the datagridview
                }
            }
        }

    }
}
