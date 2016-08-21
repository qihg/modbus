using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Printing;
using Modbus.Device;
using Modbus.IO;
using Modbus.Utility;
using Modbus.Data;
using System.Text.RegularExpressions;
using System.Threading;



namespace CommCtrlSystem
{
    public partial class MainForm : Form
    {
        WindowMain wm;
        WindowBaseSetting wbs;
        public MainForm()
        {
            InitializeComponent();
            //getConfig();
            //InitializeRegs();
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            wm = new WindowMain();
            wbs = new WindowBaseSetting();
            WindowManager.GetInstance().gb = groupBoxMain;
            WindowManager.GetInstance().wmain = wm;
            WindowManager.GetInstance().wbs = wbs;

            groupBoxMain.Controls.Clear();
            groupBoxMain.Controls.Add(wm);
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (wm.updateDataThread != null)
            {
                wm.m_updateDataFlg = false;
                wm.updateDataThread.Join();
            }
            inputCommPortSingleton.GetInstance().closeComm();
        }
    } 
}

