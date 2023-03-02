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

namespace major_nav
{
    public partial class frm_loadScreen : Form
    {
        public frm_loadScreen()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = true; //Enable the timer to begin ticking
            progBar_loading.Increment(4); //Increment the progress bar for each tick of the timer
            if (progBar_loading.Value == 100) //Continue this for each tick of the timer until it is full. Then application has 'loaded'
            {
                timer.Enabled = false; //Stop timer ticking
                frm_font form = new frm_font(); //Open up the font form to ensure that the user has installed the required font
                form.Show(); 
                Hide(); //Hide this form. This cannot be closed because the application runs off it (thus it stops the entire application).
            }
        }

        //Allow form to be dragged
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] //Import external User32 windows DLL: causes mouse to let go of any other forms
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")] //Import external User32 windows DLL: sends message to window/windows
        private extern static void SendMessage(IntPtr Window, int WindowsMessage, int AdditionalParameter1, int AdditionalParameter2); 

        private void frm_loadScreen_MouseDown(object sender, MouseEventArgs e) 
        {
            ReleaseCapture(); //Provide drag functionality when there is no border on the form
            SendMessage(Handle, 0x112, 0xf012, 0); //Send message to the windows to drag by passing the window that the control is attached to
            //Handle refers to window (the application) selected
            //0x112 is message when user choses command from windows menu
            //0xf012 refers to use of window menu/topbar specifically
            //0 means no other parameter
        }

    }
}
