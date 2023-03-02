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
    public partial class frm_font : Form
    {
        public frm_font()
        {
            InitializeComponent();
        }

        private void btn_closeWelcome_Click(object sender, EventArgs e)
        {
            frm_login loginForm = new frm_login();
            loginForm.Show();
            Close();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            //Open the pdf documentation file stored in the bin > Debug folder to provide the user with help
            Process.Start("userManual.pdf");
        }
    }
}
