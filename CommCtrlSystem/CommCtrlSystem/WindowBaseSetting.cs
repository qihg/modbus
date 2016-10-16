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
        private Thread writeDataThread;
        private ModbusRegisters modbusRegs;
        private delegate void UpdateMainUIInvoke(ModbusRegisters modbusRegs);
        private delegate void WriteDataOKInvoke();
        private List<RegTextBox> lRegTextBox;
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
            lRegTextBox = new List<RegTextBox>();
            modbusRegs = new ModbusRegisters(SLAVEID, STARTADDRESS, REGNUM);

            foreach (Control control in this.Controls)//遍历本窗体中所有的ComboBox控件 
            {
                if (control.GetType().ToString() == "CommCtrlSystem.RegTextBox")
                {
                    (control as CommCtrlSystem.RegTextBox).setReg(ref modbusRegs);
                    //(control as CommCtrlSystem.RegTextBox).KeyPress += new KeyPressEventHandler(new CheckUserInput().CheckIsNumber);
                    lRegTextBox.Add(control as CommCtrlSystem.RegTextBox);
                }
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
            try
            {
                inputCommPortSingleton.GetInstance().readRegister(ref modbusRegs);
                UpdateMainUIInvoke umi = new UpdateMainUIInvoke(UpdateUIData);
                if (this.IsHandleCreated)
                {
                    BeginInvoke(umi, modbusRegs);
                }
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void UpdateUIData(ModbusRegisters reg)
        {
            for (int i = 0; i < lRegTextBox.Count; i++)
            {
                lRegTextBox[i].UpdateData();
            }

            buttonRead.Enabled = true;
            buttonWrite.Enabled = true;
            buttonMain.Enabled = true;
            //regTextBox1.UpdateData();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            buttonRead.Enabled = false;
            buttonWrite.Enabled = false;
            buttonMain.Enabled = false;
            updateDataThread = new Thread(new ThreadStart(DoUpdateRegs));
            updateDataThread.Start();
        }

        public void WriteDataOK()
        {
            buttonRead.Enabled = true;
            buttonWrite.Enabled = true;
            buttonMain.Enabled = true;
        }

        private void WriteThread()
        {
            try
            {
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

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            //modbusRegs.stReg[0].setValue(ushort.Parse(tbBaseSetting[0].Text.ToString()));
            //modbusRegs.stReg[1].setValue(ushort.Parse(tbBaseSetting[1].Text.ToString()));
            buttonRead.Enabled = false;
            buttonWrite.Enabled = false;
            buttonMain.Enabled = false;
            writeDataThread = new Thread(new ThreadStart(WriteThread));
            writeDataThread.Start();
        }

        public void update()
        {
            inputCommPortSingleton.GetInstance().initComm();
            if (!inputCommPortSingleton.GetInstance().openComm())
            {
                return;
            }

            buttonRead.Enabled = false;
            buttonWrite.Enabled = false;
            buttonMain.Enabled = false;
            updateDataThread = new Thread(new ThreadStart(DoUpdateRegs));
            updateDataThread.Start();

        }

    }
}
