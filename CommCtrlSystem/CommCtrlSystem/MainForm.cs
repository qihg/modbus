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
        WindowHistoryReport whr;
        WindowTemperatureCorrection wtc;
        WindowPIDSetting wps;
        WindowManualSetting wms;
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
            whr = new WindowHistoryReport();
            wtc = new WindowTemperatureCorrection();
            wps = new WindowPIDSetting();
            wms = new WindowManualSetting();

            WindowManager.GetInstance().gb = groupBoxMain;
            WindowManager.GetInstance().wmain = wm;
            WindowManager.GetInstance().wbs = wbs;
            WindowManager.GetInstance().whr = whr;
            WindowManager.GetInstance().wtc = wtc;
            WindowManager.GetInstance().wps = wps;
            WindowManager.GetInstance().wms = wms;

            groupBoxMain.Controls.Clear();
            groupBoxMain.Controls.Add(wm);
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            inputCommPortSingleton.GetInstance().closeComm();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime dt = DateTime.Now;
            //int t = tc.id;
            labelDate.Text = now.ToString("yyyy-MM-dd");
            labelTime.Text = dt.ToLongTimeString().ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    } 
}

