using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Management.Instrumentation;
using System.Collections.Specialized;
using System.Threading;

namespace HDDLED
{
    public partial class Form1 : Form
    {
        NotifyIcon HddLedIcon;
        Icon activeIcon;
        Icon idleIcon;
        Thread HddLedWorking;

        #region Form Hidden
        public Form1()
        {
            InitializeComponent();
            //loads icon fron files into object variables above
            activeIcon = new Icon("HDD_Busy.ico");
            idleIcon = new Icon("HDD_Idle.ico");

            //create notification icons and assign idle default icon and present graphically
            HddLedIcon = new NotifyIcon();
            HddLedIcon.Icon = idleIcon;
            HddLedIcon.Visible = true;
            
            //Create all context menu items (e.g. quit) and added them to hddLedIcon (notification)
            MenuItem exitMenuItem = new MenuItem("Exit");
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(exitMenuItem);
            HddLedIcon.ContextMenu = contextMenu;

            //Add quit button function on click to close the program
            exitMenuItem.Click += ExitMenuItem_Click;
        
            //
            //This hides the form (window state) and puts it in taskbar/system tray (ShowInTaskbar)
            //
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            //Start working thread that pulls HDD activity from the system
            HddLedWorking = new Thread(new ThreadStart(HddActivityThread));
            HddLedWorking.Start();
        }

        //Closes using "quit" on click event on context menu
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            HddLedIcon.Dispose();
            this.Close();
        }
        #endregion
        /// <summary>
        /// This is the thread responsible for pulling info off the system
        /// for the actual state of hdd activity
        /// and aplying to notification icon  (hddLedIcon)
        /// </summary>
        #region Threads
        public void HddActivityThread()
        {
            try
            {
                //main loop which allows for running of program infinitely
               while (true)
                {
                    Thread.Sleep(100);
                }
            }
            catch (ThreadAbortException tbe)
            {
            }
        }
        #endregion
    }
}
