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

namespace CommCtrlSystem
{
    public partial class MainForm : Form
    {
        ModbusRegisters stsRegs;
        SerialPort inport;
        SerialPort outPort;
        int mRealtimeFlg = 0;
        ModbusRegisters regMainStatusRegs;
        public MainForm()
        {
            InitializeComponent();
            getConfig();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime dt = DateTime.Now;
            //int t = tc.id;
            labelDate.Text = now.ToString("yyyy-MM-dd");
            labelTime.Text = dt.ToLongTimeString().ToString();

            if (mRealtimeFlg == 1)
            {

            }
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
                        textBoxCom1.Text = cfg.InputSerialPortName;
                        textBoxCom2.Text = cfg.OutputSerialPortName;
                        textBoxServerIP.Text = cfg.ServerIp;
                        textBoxServerPort.Text = cfg.ServerPort.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", 500, 300);
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

        public static decimal GetNumber(string str)
        {
            decimal result = 0;
            if (str != null && str != string.Empty)
            {
                // 正则表达式剔除非数字字符（不包含小数点.）
                str = Regex.Replace(str, @"[^\d.\d]", "");
                // 如果是数字，则转换为decimal类型
                if (Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
                {
                    result = decimal.Parse(str);
                }
            }
            return result;
        }

        void realtimeReadStatus()
        {

            Configure cfg = null;
            if (File.Exists(@"cfg.json"))
            {
                cfg = JsonConvert.DeserializeObject<Configure>(File.ReadAllText(@"cfg.json"));
            }

            using (SerialPort port = new SerialPort(cfg.InputSerialPortName))
            {
                // configure serial port
                IModbusSerialMaster master;
                port.BaudRate = (int)GetNumber(cfg.InputSerialPortBaud);
                port.DataBits = (int)GetNumber(cfg.InputSerialPortDataBit);
                if (cfg.InputSerialPortParity == "None Parity")
                {
                    port.Parity = Parity.None;
                } else if (cfg.InputSerialPortParity == "Odd Parity")
                {
                    port.Parity = Parity.Odd;
                }
                else
                {
                    port.Parity = Parity.Even;
                }

                if (cfg.InputSerialPortStopBit == "1 Stop Bit")
                {
                    port.StopBits = StopBits.One;
                }
                else
                {
                    port.StopBits = StopBits.Two;
                }

                port.Open();

                // create modbus master
                if (cfg.InputModbusType == "RTU")
                {
                    master = ModbusSerialMaster.CreateRtu(port);
                }
                else
                {
                    master = ModbusSerialMaster.CreateAscii(port);
                }

                regMainStatusRegs = new ModbusRegisters(master, 1, 0, 19);
                regMainStatusRegs.readHoldingRegister();
            }
            //regMainStatusRegs = new ModbusRegisters();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            realtimeReadStatus();
        }
    } 
}

