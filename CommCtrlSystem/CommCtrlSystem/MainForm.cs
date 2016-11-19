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
            LogClass.GetInstance().WriteLogFile("MainForm Start-------------------------");
            InitializeComponent();
            //getConfig();
            //InitializeRegs();
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region 判断系统是否已启动

            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName("CommCtrlSystem");//获取指定的进程名   
            if (myProcesses.Length > 1)
            {
                DialogResult dr = MessageBox.Show("Another programs already exist, kill them all?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    foreach (System.Diagnostics.Process proces in myProcesses)
                    {
                        if (proces.Id != System.Diagnostics.Process.GetCurrentProcess().Id)
                        {
                            proces.Kill();
                        }
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
            #endregion


            LogClass.GetInstance().WriteLogFile("MainForm_Load");
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
            LogClass.GetInstance().WriteLogFile("ApplicationExit");
            inputCommPortSingleton.GetInstance().closeComm();
            wm.stopUpdateRegs();
            LogClass.GetInstance().WriteLogFile("ApplicationExit End-----------------------");
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime dt = DateTime.Now;
            //int t = tc.id;
            labelDate.Text = now.ToString("yyyy-MM-dd");
            labelTime.Text = dt.ToLongTimeString().ToString();

            if (inputCommPortSingleton.GetInstance().getCommStatus() == inputCommPortSingleton.COMMSTS_FAILURE)
            {
                labelWarning.Text = "通信故障";
            }
            else
            {
                labelWarning.Text = "";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnClosing(e);
            if (MessageBox.Show("您确定要退出?", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }

        }
    } 
}

