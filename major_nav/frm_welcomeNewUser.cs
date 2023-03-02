using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; //Can open the help/user manual PDF


using MySql.Data.MySqlClient; //Can connect to cloud database


namespace major_nav
{
    public partial class frm_welcomeNewUser : Form
    {

        //Stores which user is currently logged in
        public static string user = "";
        //To connect to cloud database
        string cs = @"server=3.26.46.221;userid=app;password=hs)PPt)Bb4W);database=major_work";

        public frm_welcomeNewUser()
        {
            InitializeComponent();
        }

        private void btn_closeWelcome_Click(object sender, EventArgs e)
        {
            frm_nav.username = user;
            //Show the hub form now as user has successfully logged in
            frm_nav hub = new frm_nav();
            hub.Show();

            //Update the user in the database so that the welcome screen does not appear again 
            SetUserNotNewAnymore();

            //As the form has no borderstyle, create a custom close button. If the 'X' button is clicked, close the form.
            //Unlike the other forms which use .hide(), .close() is used because AddUser appears as a .ShowDialog
            Close();
        }

        private void SetUserNotNewAnymore()
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
            sqlcommand2.CommandText = $"UPDATE Users SET new='false' WHERE username='{user}'";

            sqlcommand2.ExecuteNonQuery();

            //Close connection with cloud server
            con.Close();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            //Open the pdf documentation file stored in the bin > Debug folder to provide the user with help
            Process.Start("userManual.pdf");
        }
    }
}




