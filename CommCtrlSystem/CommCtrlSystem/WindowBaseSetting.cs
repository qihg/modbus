using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CommCtrlSystem
{
    public partial class WindowBaseSetting : UserControl
    {
        private Thread updateDataThread;
        private ModbusRegisters modbusRegs;
        private delegate void UpdateMainUIInvoke(ModbusRegisters modbusRegs);
        private TextBox[] tbBaseSetting;
        private const byte SLAVEID = 1;
        private const ushort STARTADDRESS = 0x13;
        private const ushort REGNUM = 8;

        public WindowBaseSetting()
        {
            InitializeComponent();
            InitializeRegs();
        }

        void InitializeRegs()
        {
            tbBaseSetting = new TextBox[10];
            modbusRegs = new ModbusRegisters(SLAVEID, STARTADDRESS, REGNUM);
            tbBaseSetting[0] = textBox1;
            tbBaseSetting[1] = textBox2;
            tbBaseSetting[2] = textBox3;
            tbBaseSetting[3] = textBox4;
            tbBaseSetting[4] = textBox5;
            tbBaseSetting[5] = textBox6;
            tbBaseSetting[6] = textBox7;
            tbBaseSetting[7] = textBox8;
            tbBaseSetting[8] = textBox9;
            tbBaseSetting[9] = textBox10;

            for (int i = 0; i < 10; i++)
            {
                tbBaseSetting[i].KeyPress += new KeyPressEventHandler(new CheckUserInput().CheckIsNumber);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wmain);
        }

        public void DoUpdateRegs()
        {
            inputCommPortSingleton.GetInstance().readRegister(ref modbusRegs);
            UpdateMainUIInvoke umi = new UpdateMainUIInvoke(UpdateUIData);
            BeginInvoke(umi, modbusRegs);

        }

        public void UpdateUIData(ModbusRegisters reg)
        {
            for (int i = 0; i < reg.numRegisters; i++)
            {
                tbBaseSetting[i].Text = reg.stReg[i].getShortValue().ToString();
            }
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            updateDataThread = new Thread(new ThreadStart(DoUpdateRegs));
            updateDataThread.Start();
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            modbusRegs.stReg[0].setValue(ushort.Parse(tbBaseSetting[0].Text.ToString()));
            modbusRegs.stReg[1].setValue(ushort.Parse(tbBaseSetting[1].Text.ToString()));
            inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
        }
    }
}
