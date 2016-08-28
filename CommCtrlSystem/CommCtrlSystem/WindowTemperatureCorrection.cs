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
    public partial class WindowTemperatureCorrection : UserControl
    {
        private Thread updateDataThread;
        private ModbusRegisters modbusRegs;
        private delegate void UpdateMainUIInvoke(ModbusRegisters modbusRegs);
        private TextBox[] tbBaseSetting;
        private const byte SLAVEID = 1;
        private const ushort STARTADDRESS = 0x33;
        private const ushort REGNUM = 18;

        public WindowTemperatureCorrection()
        {
            InitializeComponent();
            InitializeRegs();
        }

        void InitializeRegs()
        {
            tbBaseSetting = new TextBox[18];
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
            tbBaseSetting[10] = textBox11;
            tbBaseSetting[11] = textBox12;
            tbBaseSetting[12] = textBox13;
            tbBaseSetting[13] = textBox14;
            tbBaseSetting[14] = textBox15;
            tbBaseSetting[15] = textBox16;
            tbBaseSetting[16] = textBox17;
            tbBaseSetting[17] = textBox18;
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

        private void buttonMain_Click(object sender, EventArgs e)
        {
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wmain);
        }

        private void buttonWTRead_Click(object sender, EventArgs e)
        {
            updateDataThread = new Thread(new ThreadStart(DoUpdateRegs));
            updateDataThread.Start();
        }

        private void buttonWTWrite_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < modbusRegs.numRegisters; i++)
            {
                modbusRegs.stReg[i].setValue(ushort.Parse(tbBaseSetting[i].Text.ToString()));
            }
            inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
        }
    }
}
