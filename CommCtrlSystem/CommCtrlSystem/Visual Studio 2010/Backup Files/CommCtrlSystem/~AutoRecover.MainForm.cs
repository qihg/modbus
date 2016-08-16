using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.Serialization.


namespace CommCtrlSystem
{
    public partial class MainForm : Form
    {
        ModbusRegisters stsRegs;
        public MainForm()
        {
            InitializeComponent();
            SerialPortWrap spw = new SerialPortWrap();
            SerialPort sp = spw.getSerialPort("com1");
            if (sp == null)
            {
                textBox1.Text = "NULL";
                sp = new SerialPort();
                sp.PortName = "com1";
                sp.Open();
            }
            else
            {
                textBox1.Text = "Opened";
                //sp.Open();
            }

            

            SerialPort sp2 = spw.getSerialPort("com1");
            if (sp2 == null)
            {
                textBox2.Text = "NULL";
            }
            else
            {
                textBox2.Text = "Opened";
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime dt = DateTime.Now;
            //int t = tc.id;
            labelDate.Text = now.ToString("yyyy-MM-dd");
            labelTime.Text = dt.ToLongTimeString().ToString();
        }
    }
}
