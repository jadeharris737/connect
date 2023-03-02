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
using System.Drawing.Printing; //Can print invitation

namespace major_nav
{
    public partial class frm_viewing : Form
    {
        public frm_viewing()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            PopulateEvent();
            FillWithInfo();
        }

        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //String to connect and log in to cloud database
        //This public variable holds which event was selected in the original datagridivew
        public static string eventName = "";

        private void FillWithInfo()
        {
            //Populate the textboxes (disabled) to display the data for the event
            txt_eventName.Text = dgv_eventData.Rows[0].Cells["eventName"].Value.ToString();
            txt_owner.Text = dgv_eventData.Rows[0].Cells["owner"].Value.ToString();
            //Show number of invitees by splitting them at the comma, but -1 as one is an empty invitee (extra comma)
            int peopleInvited = dgv_eventData.Rows[0].Cells["attendees"].Value.ToString().Split(',').Count() - 1;
            txt_noInvited.Text = peopleInvited.ToString();
            txt_cost.Text = dgv_eventData.Rows[0].Cells["cost"].Value.ToString();
            txt_duration.Text = dgv_eventData.Rows[0].Cells["eventDuration"].Value.ToString();
            txt_description.Text = dgv_eventData.Rows[0].Cells["eventDescription"].Value.ToString();
            txt_time.Text = dgv_eventData.Rows[0].Cells["eventTime"].Value.ToString().Replace(",","");
            txt_location.Text = dgv_eventData.Rows[0].Cells["eventLocation"].Value.ToString().Replace(",","");

            //Calculate the end time by adding the duration to the event time which was selected (only hosted events can show details)
            DateTime eventDateTime = Convert.ToDateTime(dgv_eventData.Rows[0].Cells["eventTime"].Value.ToString());
            float duration = float.Parse(txt_duration.Text);
            lbl_endTime.Text = eventDateTime.AddHours(duration).ToString();
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
            //Get data for event
            sqlcommand2.CommandText = $"SELECT * FROM Events WHERE eventName = '{eventName}'";

            //Execute command and recieve data
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
            Close(); //Allow user to return back to the event datagridview
        }

        private void btn_print_Click(object sender, EventArgs e) //Allow user to print the event details
        {
            PrintDocument pd = new PrintDocument(); //Create printable document
            pd.PrintPage += new PrintPageEventHandler(PrintImage); //Print the bounds recieved by the PrintImage part
            ppd_printPreview.Document = pd; //Show the user the bitmap image created 
            ppd_printPreview.Show(); //Allow them to preview image
            pd.Print();
        }
        private void PrintImage(object o, PrintPageEventArgs e)
        {
            //Set bounds as the form
            int x = SystemInformation.WorkingArea.X;
            int y = SystemInformation.WorkingArea.Y;
            int width = Width;
            int height = Height;

            Rectangle bounds = new Rectangle(x, y, width, height);
            Bitmap img = new Bitmap(width, height);

            //Create a bitmap image of the form within the bounds for the width and height
            DrawToBitmap(img, bounds);
            //Draw an image of this bitmap around the point 100,100 which the user can print
            Point p = new Point(100, 100);
            e.Graphics.DrawImage(img, p);
        }
    }
}
