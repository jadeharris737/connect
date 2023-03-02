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
    public partial class frm_equalVotes: Form
    {
        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //String to connect and log in to cloud database
        //This public variables are set when the user logins in and store which user is currently logged in
        public static string username = "";
        //This public variables stores which event is selected to be hosted
        public static string eventName = "";

        public frm_equalVotes()
        {
            InitializeComponent();
            PrepareInterface(); //Populate the form with the users information
        }

        private void PrepareInterface()
        {
            PopulateEvent(); 
            PopulateUser();
            FillWithInfo(); //Fill the labels with the according information
            SetEndTimes(); //Display what the end times for each option will be
            EnableChoices(); //Enable the radio buttons for the labels that have an option
        }

        private void PopulateEvent()
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Populate with the information for the selected event for use
            sqlcommand2.CommandText = $"SELECT * FROM Events WHERE eventName = '{eventName}'";

            //Execute command to find rows which match username
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
            //Populate datagrid with information about user for use
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


        //Contain the number of time options and number of location options
        int timeChoices = 1;
        int locationChoices = 1;
        private void EnableChoices() //Enable the radio buttons for the labels that have an option
        {
            if (lbl_timeDate_option1.Text != "NO OPTION SET") //If the label has the text NO OPTION SET (filled at FillWithInfo) then there must not be any option, thus user cannot choose (disable)
            {
                rb_time1.Enabled = true;
                timeChoices = 2;
            }
            if(lbl_timeDate_option2.Text != "NO OPTION SET")
            {
                rb_time2.Enabled = true;
                timeChoices = 3;
            }
            if (lbl_timeDate_option3.Text != "NO OPTION SET")
            {
                rb_time3.Enabled = true;
                timeChoices = 4;
            }
            if (lbl_location_option1.Text != "NO OPTION SET")
            {
                rb_location1.Enabled = true;
                locationChoices = 2;
            }
            if (lbl_location_option2.Text != "NO OPTION SET")
            {
                rb_location2.Enabled = true;
                locationChoices = 3;
            }
            if (lbl_location_option3.Text != "NO OPTION SET")
            {
                rb_location3.Enabled = true;
                locationChoices = 4;
            }

            if (dayTimeLength ==2) //If there is only one option for the date/time, then instantly have it set as selected (as user can't choose any others)
            {
                rb_time1.Checked = true;
            }
            if (locationLength == 2) //If there is only one option for the location, then instantly have it set as selected (as user can't choose any others)
            {
                rb_location1.Checked = true;
            }

        }


        private void SetEndTimes() //Set the label displaying the end times to each event by adding the duration of the event to the start time contained in the according label
        {
            double duration = Double.Parse(txt_duration.Text);
            if (lbl_timeDate_option1.Text != "NO OPTION SET") //Only if there is an option set in that according label
            {
                //Use of ParseExact to allow the format of DateTime.Now to convert the specific format of the string into the specific date time format
                //Add duration of the event in hours
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

        //Store for use in the EnableChoices() function which manages if there is only one option for date/time (in which case that one option should be instantly selected
        int dayTimeLength = 0;
        int locationLength = 0;
        private void FillWithInfo() //Fill the labels with each option
        {
            txt_duration.Text = dgv_eventData.Rows[0].Cells["eventDuration"].Value.ToString(); //Display the duration of the event for user convenience

            string eventTimes = dgv_eventData.Rows[0].Cells["eventTime"].Value.ToString(); //All of the event starting times contained for the event
            if (eventTimes != "") //If there are event times
            {
                string[] dayTime = eventTimes.Split(','); //Get each event time which is split by a comma
                dayTimeLength = dayTime.Length; //Set the global length variable 

                lbl_timeDate_option1.Text = dayTime[0]; //Set each label to the according option 
                if (dayTimeLength == 3)
                {
                    lbl_timeDate_option2.Text = dayTime[1];
                }
                if (dayTimeLength == 4)
                {
                    lbl_timeDate_option3.Text = dayTime[2];
                }
              
            }

            string locations = dgv_eventData.Rows[0].Cells["eventLocation"].Value.ToString(); //All of the event starting times contained for the event
            if (locations != "") //If there are locations
            {
                string[] location = dgv_eventData.Rows[0].Cells["eventLocation"].Value.ToString().Split(','); //Access each location by splitting it by a comma
                locationLength = location.Length; //Set the global number of variables

                lbl_location_option1.Text = location[0]; //Populate each label with each according option
                if (locationLength == 3)
                {
                    lbl_location_option2.Text = location[1];
                }
                if (locationLength == 4)
                {
                    lbl_location_option3.Text = location[2];
                }
            }
        }


        private void btn_createEvent_Click(object sender, EventArgs e)
        {
            //Ensure that one of the radio buttons from both of the groups of options - location and time - is selected.
            if ((rb_location1.Checked || rb_location2.Checked || rb_location3.Checked) && (rb_time1.Checked || rb_time2.Checked || rb_time3.Checked)) 
            {
                ReUpdate_Event(eventName); //Ensure that if user goes to adjust something about event - their datagridview will update
                UpdateEventWithDecisions();
                Close();
            }
            else
            {
                MessageBox.Show($"Please select one option that recieved equal votes for both time and location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UpdateEventWithDecisions() //Update the event in the mysql server with the details of the event (whichever vote user chose)
        {
            string chosenTime = "";  //Set time and location according to whichever option was beside the selected radio button
            string chosenLocation = "";
            if (rb_time1.Checked)
            {
                chosenTime = lbl_timeDate_option1.Text;
            }
            if (rb_time2.Checked)
            {
                chosenTime = lbl_timeDate_option2.Text;
            }
            if (rb_time3.Checked)
            {
                chosenTime = lbl_timeDate_option3.Text;
            }

            if (rb_location1.Checked)
            {
                chosenLocation = lbl_location_option1.Text;
            }
            if (rb_location2.Checked)
            {
                chosenLocation = lbl_location_option2.Text;
            }
            if (rb_location3.Checked)
            {
                chosenLocation = lbl_location_option3.Text;
            }


            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Update the event with this time and location
            sqlcommand2.CommandText = $"UPDATE Events SET eventTime='{chosenTime}',eventLocation='{chosenLocation}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }



    
        private void ReUpdate_Event(string eventName) //Reset the last time that the event was updated
        {
            //Establish connection
            MySqlConnection con = new MySqlConnection(cs);
            //Open the connection to the database
            con.Open();

            //Used to create command
            MySqlCommand sqlcommand2 = new MySqlCommand();
            sqlcommand2.Connection = con;
            sqlcommand2.CommandType = CommandType.Text;
            //Reupdate lastUpdated time for the event
            sqlcommand2.CommandText = $"UPDATE Events SET lastUpdated='{DateTime.Now}' WHERE eventName ='{eventName}'";
            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void btn_randomise_Click(object sender, EventArgs e) //Choose a random radio button to be checked if the user wishes to radomise
        {
            Random random = new Random(); //Instantiate new random object
            int select_time = random.Next(1, timeChoices); //Choose a number between the 1 and the number of options for the time, then select according radio button
            if (select_time == 1)
            {
                rb_time1.Checked = true;
            }
            else if (select_time == 2)
            {
                rb_time2.Checked = true;
            }
            else
            {
                rb_time3.Checked = true;
            }
            int select_location = random.Next(1, locationChoices); //Choose a number between the 1 and the number of options for the location, then select according radio button
            if (select_location == 1)
            {
                rb_location1.Checked = true;
            }
            else if (select_location == 2)
            {
                rb_location2.Checked = true;
            }
            else
            {
                rb_location3.Checked = true;
            }
        }
    }
}
