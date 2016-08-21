using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
    public partial class WindowMain : UserControl
    {
        public Thread updateDataThread;
        public bool m_updateDataFlg = false;
        ModbusRegisters modbusRegs;
        public delegate void UpdateMainUIInvoke(ModbusRegisters modbusRegs);
        private static readonly object locker = new object();

        public const byte SLAVEID = 1;
        public const ushort STARTADDRESS = 0;
        public const ushort REGNUM = 19;
        private TextBox[] tbmain;

        public WindowMain()
        {
            InitializeComponent();
            InitializeRegs();
        }

        void InitializeRegs()
        {
            tbmain = new TextBox[10];
            modbusRegs = new ModbusRegisters(SLAVEID, STARTADDRESS, REGNUM);
            tbmain[0] = textBox2;
        }

        private void WindowMain_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PaperSize p = null;
            foreach (PaperSize ps in printDocument1.PrinterSettings.PaperSizes)
            {
                if (ps.PaperName.Equals("A4"))
                    p = ps;
            }

            this.printDocument1.DefaultPageSettings.PaperSize = p;
            this.printDocument1.PrintPage += new PrintPageEventHandler(this.MyPrintDocument_PrintPage);
            //将写好的格式给打印预览控件以便预览
            printPreviewDialog1.Document = printDocument1;
            //显示打印预览
            DialogResult result = printPreviewDialog1.ShowDialog();
            if (result == DialogResult.OK)
                this.printDocument1.Print();
        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            /*如果需要改变自己 可以在new Font(new FontFamily("黑体"),11）中的“黑体”改成自己要的字体就行了，黑体 后面的数字代表字体的大小
             System.Drawing.Brushes.Blue , 170, 10 中的 System.Drawing.Brushes.Blue 为颜色，后面的为输出的位置 */
            e.Graphics.DrawString("滤点分析仪结果报告", new Font(new FontFamily("黑体"), 11), System.Drawing.Brushes.Black, 170, 10);

            e.Graphics.DrawLine(Pens.Black, 8, 30, 480, 30);
            e.Graphics.DrawString("时间", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 9, 35);
            e.Graphics.DrawString("测定结果", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 160, 35);
            e.Graphics.DrawString("试样编号", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 260, 35);
            e.Graphics.DrawString("操作员", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 330, 35);
            e.Graphics.DrawLine(Pens.Black, 8, 50, 480, 50);
            //产品信息
            e.Graphics.DrawString(DateTime.Now.ToString(), new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 9, 55);
            //e.Graphics.DrawString(tc.res0, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 160, 55);
            //e.Graphics.DrawString(tc.no0, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 260, 55);
            //e.Graphics.DrawString(tc.oper0, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 330, 55);

            e.Graphics.DrawString(DateTime.Now.ToString(), new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 9, 75);
            //e.Graphics.DrawString(tc.res1, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 160, 75);
            //e.Graphics.DrawString(tc.no1, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 260, 75);
            //e.Graphics.DrawString(tc.oper1, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 330, 75);

            e.Graphics.DrawLine(Pens.Black, 8, 200, 480, 200);
        }
        private void btnSysCfg_Click(object sender, EventArgs e)
        {
            FormSysCfg fsc = new FormSysCfg();
            fsc.ShowDialog();
            getConfig();
        }

        private void getConfig()
        {
            try
            {
                Configure cfg = null;
                if (File.Exists(@"cfg.json"))
                {
                    cfg = JsonConvert.DeserializeObject<Configure>(File.ReadAllText(@"cfg.json"));
                    if (cfg != null)
                    {
                        //textBoxCom1.Text = cfg.InputSerialPortName;
                        //textBoxCom2.Text = cfg.OutputSerialPortName;
                        //textBoxServerIP.Text = cfg.ServerIp;
                        //textBoxServerPort.Text = cfg.ServerPort.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void DoUpdateRegs()
        {
            inputCommPortSingleton.GetInstance().initComm();
            inputCommPortSingleton.GetInstance().openComm();
            while (m_updateDataFlg)
            {
                inputCommPortSingleton.GetInstance().readRegister(ref modbusRegs);
                UpdateMainUIInvoke umi = new UpdateMainUIInvoke(UpdateUIData);
                BeginInvoke(umi, modbusRegs);
                Thread.Sleep(1000);
            }
            inputCommPortSingleton.GetInstance().closeComm();
        }

        public void UpdateUIData(ModbusRegisters reg)
        {
            tbmain[0].Text = reg.stReg[0].getShortValue().ToString();
        }

        public void startUpdateRegs()
        {
            lock (locker)
            {
                if (!m_updateDataFlg)
                {
                    m_updateDataFlg = true;
                    updateDataThread = new Thread(new ThreadStart(DoUpdateRegs));
                    updateDataThread.Start();
                }
            }
        }

        public void stopUpdateRegs()
        {
            lock (locker)
            {
                if (m_updateDataFlg)
                {
                    m_updateDataFlg = false;
                    updateDataThread.Join();
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //mRealtimeFlg = 1;
            startUpdateRegs();
            //btnStart.Enabled = false;
            //btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopUpdateRegs();
            //btnStart.Enabled = true;
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime dt = DateTime.Now;
            //int t = tc.id;
            labelDate.Text = now.ToString("yyyy-MM-dd");
            labelTime.Text = dt.ToLongTimeString().ToString();
        }

        private void btnBaseSetting_Click(object sender, EventArgs e)
        {
            GroupBox tgb =  WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wbs);
        }
    }
}
