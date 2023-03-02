using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization; //For datetime
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Can connect to cloud database

namespace major_nav
{
    public partial class frm_invitation : Form
    {
        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //String to connect and log in to cloud database

        //This public variable is set when the user logins in and stores which user is currently logged in
        public static string username = "test";
        //Stores which event was selected in the eventInvited
        public static string eventName = "";
        //Stores whether the user used the VIEW button (thus wants to view event) or used the ACCEPT button (wants to accept invitation and send options)
        public static string openedBy = "";

        private frm_eventsInvited eventsInvitedForm; //Create a form reference so that the close function from forget password can be called
        public frm_invitation(Form callingForm)
        {
            InitializeComponent();
            //Allow Refresh() function fo the eventsInvited form to be accessed so that the form can be refreshed
            eventsInvitedForm = callingForm as frm_eventsInvited;

            SetInterface();
        }

        private void SetInterface()
        {
            PopulateEvent(); //Populate information for the selected event (using event name passed to form when user chooses to open it)
            FillWithInfo(); //Display this information in the form's 'invitation'

            if (openedBy == "View") //If the user opened this form with the VIEW button for the invitation (as opposed to ACCEPT) then do not redirect to the vote form
            {
                btn_sendVote.Text = "DONE"; //Thus, change the label on the button
            }
        }

        public void ReturnToEvents() //Public as this funciton is called once the user has sent their votes
        {
            eventsInvitedForm.Refresh2(); //Update the datagridview (remove this event as invitation has now been accepted)
            Close(); //Close this form
        }

        private void FillWithInfo() //Use the datagridview to fill the invitation with details
        {
            txt_eventName.Text = dgv_eventData.Rows[0].Cells["eventName"].Value.ToString();
            txt_owner.Text = dgv_eventData.Rows[0].Cells["owner"].Value.ToString();
            int peopleAttending = dgv_eventData.Rows[0].Cells["attendees"].Value.ToString().Split(',').Count() - 1; //Attendees separated by comma 
            txt_noInvited.Text = peopleAttending.ToString();
            txt_cost.Text = dgv_eventData.Rows[0].Cells["cost"].Value.ToString();
            txt_duration.Text = dgv_eventData.Rows[0].Cells["eventDuration"].Value.ToString();
            txt_description.Text = dgv_eventData.Rows[0].Cells["eventDescription"].Value.ToString();
        }

        private void PopulateEvent() //Populate datagridview with information for event which is displayed in invitation
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Get information for events
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

        private void lbl_return_Click(object sender, EventArgs e)
        {
            Close(); //Allow user to return to eventsInvited form 
        }

        private void btn_createEvent_Click(object sender, EventArgs e)
        {
            if (openedBy == "Accept") //If the user opened this form with the intention to accept (and thus send their votes)
            {
                frm_invitationVote invitationForm = new frm_invitationVote(this); //Open the form to allow them to send their votes
                invitationForm.ShowDialog();
            }
            else //Otherwise, they opened this form only to view the data of the invitation so clicking this button is like a 'done' button
            {
                Close();
            }
        }

    }
}
