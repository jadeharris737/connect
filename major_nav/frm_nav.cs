using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //use native libraries (dynamic link library) thus allowing user to move forms
using FontAwesome.Sharp; //Import icons
using System.Diagnostics; //Can open the help/user manual PDF
using MySql.Data.MySqlClient;

namespace major_nav
{
    public partial class frm_nav : Form
    {

        //This public variables is set when the user logins in and store which user is currently logged in
        public static string username = "";
        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work"; //String to connect and log in to cloud database

        //Create variables to store objects
        private IconButton currentButton;
        private Panel leftBorderButton;
        private Form currentChildForm;

        public frm_nav()
        {
            InitializeComponent();
            SetupNavBar();
            SetUsernameInAllForms(); //Ensure all forms know which user is logged in
        }

        private void SetupNavBar()
        {
            //Create a left border on all of the buttons (which will display to indicate the user has selected)
            leftBorderButton = new Panel(); 
            leftBorderButton.Size = new Size(7, 45);
            pnl_menu.Controls.Add(leftBorderButton);

            //Customise form aesthetics
            Text = string.Empty;
            ControlBox = false;
            DoubleBuffered = true;

            ActivateButton(btn_hub, RGBColours.colour1); //Activate the hub button (as this is where the user lands)
            lbl_titleOfChildForm.Text = "Home";
        }

        private void SetUsernameInAllForms() //Set the user logged in for all forms
        {
            frm_events.username = username;
            frm_newEvent.username = username; 
            frm_eventsInvited.username = username;
            frm_friends.username = username;
            frm_myEvents.username = username;
            frm_newEvent.username = username;
            frm_settings.username = username;
            frm_invitationVote.username = username;
        }

        private struct RGBColours //Contain each RGB colour for use in the nav bar to represent the specific form
        {
            public static Color colour1 = Color.FromArgb(254, 76, 155);
            public static Color colour2 = Color.FromArgb(253, 138, 114);
            public static Color colour3 = Color.FromArgb(255, 198, 0);
            public static Color colour4 = Color.FromArgb(0, 204, 102);
            public static Color colour5 = Color.FromArgb(24, 161, 251);
            public static Color colour6 = Color.FromArgb(95, 77, 221);
        }

        private void ActivateButton(object senderButton, Color colour) //Highlight the active button (show that it is selected)
        {
            if (senderButton != null) //Cauton button is not null
            {
                DisableButton(); //Deactivate previous button
                //Button customisation
                currentButton = (IconButton)senderButton; //Convert object to an iconbutton type
                currentButton.BackColor = Color.White; //Change background colour
                currentButton.ForeColor = colour; //Change text colour
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.IconColor = colour;
                currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentButton.ImageAlign = ContentAlignment.MiddleRight;
                //left border button -> move 
                leftBorderButton.BackColor = colour; //Give colour to the left border on the button instantiated before
                leftBorderButton.Location = new Point(0, currentButton.Location.Y); //Move the left border button and display it as 'selected'
                leftBorderButton.Visible = true;
                leftBorderButton.BringToFront();
                //Make the icon in the header according to what form is open
                pb_currentChildFormIcon.IconChar = currentButton.IconChar;
            }
        }

        private void DisableButton() //Disable the current button (deselect once another button has been selected)
        {
            if (currentButton != null) //If the selected button is not null, then return the button to its original properties/customisation
            {
                currentButton.BackColor = Color.White;
                currentButton.ForeColor = SystemColors.ControlDarkDark;
                currentButton.TextAlign = ContentAlignment.MiddleLeft;
                currentButton.IconColor = SystemColors.ControlDarkDark;
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm) //Open the secondary form inside main form and show title of current form
        {
            if (currentChildForm != null)
            {
                //Can open only one form at a time so close any other child forms if the current form is not null
                currentChildForm.Close();
            }
            currentChildForm = childForm; //Set this new form as the current form
            childForm.TopLevel = false; //Set aesthetics of form (make not top level so that it is embeded)
            childForm.FormBorderStyle = FormBorderStyle.None; //Remove border for aesthetics
            childForm.Dock = DockStyle.Fill;
            pnl_desktop.Controls.Add(childForm);
            pnl_desktop.Tag = childForm; //Associate form data with the panel (so that controls are recognised)
            childForm.BringToFront();
            childForm.Show();
        }


        private void btn_hub_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColours.colour1); //Send specific colour to highlight/show selected as
            try //Close a form if one already exists. Try/Catch needed if the user immedaitely clicks on the hub button on loading
            {
                currentChildForm.Close();
            }
            catch
            {
            }
            lbl_titleOfChildForm.Text = "Home"; //Display 'home' in the topbar
        }

        private void btn_events_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColours.colour2); //Send specific colour
            OpenChildForm(new frm_events(this)); //Open the form with reference to this nav form for if the user clicks the new event form (uses this to reselect myEvents)
            lbl_titleOfChildForm.Text = "Events";
        }

        public void btn_myEvents_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColours.colour3); //Send specific colour
            OpenChildForm(new frm_myEvents()); //Open the form
            lbl_titleOfChildForm.Text = "My Events";
        }

        private void btn_friends_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColours.colour4); //Send specific colour
            OpenChildForm(new frm_eventsInvited(this));//Open the form with reference to this nav form for if the user clicks the new event form (uses this to reselect myEvents)
            lbl_titleOfChildForm.Text = "My Invitations";
        }

        private void btn_budget_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColours.colour5); //Send specific colour
            OpenChildForm(new frm_friends());  //Open the form
            lbl_titleOfChildForm.Text = "My Friends";
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColours.colour6); //Send specific colour
            OpenChildForm(new frm_settings());  //Open the form
            lbl_titleOfChildForm.Text = "Settings";
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            //Open the pdf documentation file stored in the bin > Debug folder to provide the user with help
            Process.Start("userManual.pdf");
        }

        //Allow form to be dragged
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] //Import external User32 windows DLL: causes mouse to let go of any other forms
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")] //Import external User32 windows DLL: sends message to window/windows
        private extern static void SendMessage(IntPtr Window, int WindowsMessage, int AdditionalParameter1, int AdditionalParameter2);



        private void pnl_titleBar_MouseDown(object sender, MouseEventArgs e) //Allow user to use titlebar to move the form
        {
            ReleaseCapture(); //Provide drag functionality when there is no border on the form
            SendMessage(Handle, 0x112, 0xf012, 0); //Send message to the windows to drag by passing the window that the control is attached to
            //Handle refers to window (the application) selected
            //0x112 is message when user choses command from windows menu
            //0xf012 refers to use of window menu/topbar specifically
            //0 means no other parameter
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            RecordUserLoggedOut(); //If the user has logged out of the program, update their status in the mysql database (as user can only be logged in on one machine)
            Application.Exit();
        }

        private void RecordUserLoggedOut()
        {
            //Establish connection
            MySqlConnection con2 = new MySqlConnection(cs);
            //Open the connection to the database
            con2.Open();

            //Used to create command
            MySqlCommand sqlcommand = new MySqlCommand();
            sqlcommand.Connection = con2;
            sqlcommand.CommandType = CommandType.Text;
            //Log user out in database (as user can only be logged in on one machine)
            sqlcommand.CommandText = $"UPDATE Users SET loggedIn='false' WHERE username ='{username}'";
            sqlcommand.ExecuteNonQuery();

            //Close connection with cloud server
            con2.Close();
        }       

        private void btn_minimised_Click(object sender, EventArgs e)
        {
            //Minimise window
            WindowState = FormWindowState.Minimized;
        }

        private void btn_logOut_Click(object sender, EventArgs e)
        {
            RecordUserLoggedOut(); //If the user has logged out of the program, update their status in the mysql database (as user can only be logged in on one machine)
            Application.Restart(); //Restart so that user can log in
        }

        private void frm_nav_Shown(object sender, EventArgs e)
        {
            lbl_username.Text = username; //Display user who is logged in
        }

        private void frm_nav_FormClosing(object sender, FormClosingEventArgs e)
        {
            RecordUserLoggedOut(); //If the user has logged out of the program, update their status in the mysql database (as user can only be logged in on one machine)
            //This is specifically for if the user shuts down using windows escape key or anything- not normal exit buttons
        }
        private void btn_home_Click(object sender, EventArgs e) //When user clicks the home icon in the top right hand corner, return to the home form
        {
            btn_hub_Click(btn_hub, e); //Emulate user selecting button
        }
    }
}
