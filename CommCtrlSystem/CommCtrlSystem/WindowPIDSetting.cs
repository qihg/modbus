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
    public partial class WindowPIDSetting : UserControl
    {
        private Thread updateDataThread;
        private Thread writeDataThread;
        private ModbusRegisters modbusRegs;
        private delegate void UpdateMainUIInvoke(ModbusRegisters modbusRegs);
        private delegate void WriteDataOKInvoke();
        private TextBox[] tbPidSetting;
        private const byte SLAVEID = 1;
        private const ushort STARTADDRESS = 0x1B;
        private const ushort REGNUM = 24;

        public WindowPIDSetting()
        {
            InitializeComponent();
            InitializeRegs();
        }

        void InitializeRegs()
        {
            tbPidSetting = new TextBox[24];
            modbusRegs = new ModbusRegisters(SLAVEID, STARTADDRESS, REGNUM);
            tbPidSetting[0] = textBox1;
            tbPidSetting[1] = textBox2;
            tbPidSetting[2] = textBox3;
            tbPidSetting[3] = textBox4;
            tbPidSetting[4] = textBox5;
            tbPidSetting[5] = textBox6;
            tbPidSetting[6] = textBox7;
            tbPidSetting[7] = textBox8;
            tbPidSetting[8] = textBox9;
            tbPidSetting[9] = textBox10;
            tbPidSetting[10] = textBox11;
            tbPidSetting[11] = textBox12;
            tbPidSetting[12] = textBox13;
            tbPidSetting[13] = textBox14;
            tbPidSetting[14] = textBox15;
            tbPidSetting[15] = textBox16;
            tbPidSetting[16] = textBox17;
            tbPidSetting[17] = textBox18;
            tbPidSetting[18] = textBox19;
            tbPidSetting[19] = textBox20;
            tbPidSetting[20] = textBox21;
            tbPidSetting[21] = textBox22;
            tbPidSetting[22] = textBox23;
            tbPidSetting[23] = textBox24;

            for (int i = 0; i < 24; i++)
            {
                tbPidSetting[i].KeyPress += new KeyPressEventHandler(new CheckUserInput().CheckIsNumber);
            }
        }

        public void DoUpdateRegs()
        {
            inputCommPortSingleton.GetInstance().readRegister(ref modbusRegs);
            UpdateMainUIInvoke umi = new UpdateMainUIInvoke(UpdateUIData);
            if (this.IsHandleCreated)
            {
                BeginInvoke(umi, modbusRegs);
            }

        }

        public void UpdateUIData(ModbusRegisters reg)
        {
            for (int i = 0; i < reg.numRegisters; i++)
            {
                tbPidSetting[i].Text = reg.stReg[i].getShortValue().ToString();
            }

            buttonPIDRead.Enabled = true;
            buttonPIDWrite.Enabled = true;
            buttonMain.Enabled = true;
        }

        private void buttonMain_Click(object sender, EventArgs e)
        {
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wmain);
        }

        private void buttonPIDRead_Click(object sender, EventArgs e)
        {
            //updateDataThread = new Thread(new ThreadStart(DoUpdateRegs));
            //updateDataThread.Start();
            buttonPIDRead.Enabled = false;
            buttonPIDWrite.Enabled = false;
            buttonMain.Enabled = false;
            updateDataThread = new Thread(new ThreadStart(DoUpdateRegs));
            updateDataThread.Start();
        }

        public void WriteDataOK()
        {
            buttonPIDRead.Enabled = true;
            buttonPIDWrite.Enabled = true;
            buttonMain.Enabled = true;
        }

        private void WriteThread()
        {
            try
            {
                for (int i = 0; i < modbusRegs.numRegisters; i++)
                {
                    modbusRegs.stReg[i].setValue(ushort.Parse(tbPidSetting[i].Text.ToString()));
                }
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
                WriteDataOKInvoke umi = new WriteDataOKInvoke(WriteDataOK);
                if (this.IsHandleCreated)
                {
                    BeginInvoke(umi);
                }
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
          
        private void buttonPIDWrite_Click(object sender, EventArgs e)
        {
            buttonPIDRead.Enabled = false;
            buttonPIDWrite.Enabled = false;
            buttonMain.Enabled = false;
            writeDataThread = new Thread(new ThreadStart(WriteThread));
            writeDataThread.Start();
        }

        public void update()
        {
            inputCommPortSingleton.GetInstance().initComm();
            inputCommPortSingleton.GetInstance().openComm();
            buttonPIDRead.Enabled = false;
            buttonPIDWrite.Enabled = false;
            buttonMain.Enabled = false;
            updateDataThread = new Thread(new ThreadStart(DoUpdateRegs));
            updateDataThread.Start();
        }
    }
}
