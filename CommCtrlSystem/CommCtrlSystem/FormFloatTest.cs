using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommCtrlSystem
{
    public partial class FormFloatTest : Form
    {
        //List<RegTextBox> lRegTextBox;
        //ModbusRegisters modbusRegs;
        public FormFloatTest()
        {
            InitializeComponent();
            //byte slaveid = 1;
            //ushort startaddr = 0;
            //ushort numregs = 10;

            //modbusRegs = new ModbusRegisters(slaveid, startaddr, numregs);
            //inputCommPortSingleton.GetInstance().readRegister(ref modbusRegs);

            //lRegTextBox = new List<RegTextBox>();
            //foreach (Control control in this.Controls)//遍历本窗体中所有的ComboBox控件 
            //{
             //   if (control.GetType().ToString() == "CommCtrlSystem.RegTextBox")
             //   {
             //       (control as CommCtrlSystem.RegTextBox).setReg(ref modbusRegs);
                    //(control as CommCtrlSystem.RegTextBox).KeyPress += new KeyPressEventHandler(new CheckUserInput().CheckIsNumber);
             //       lRegTextBox.Add(control as CommCtrlSystem.RegTextBox);
             //   }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // use user conctrl
            //inputCommPortSingleton.GetInstance().readRegister(ref modbusRegs);

            //for (int i = 0; i < lRegTextBox.Count; i++)
            //{
            //    lRegTextBox[i].UpdateData();
            //}

            // use api            
            
            inputCommPortSingleton.GetInstance().initComm();
            if (!inputCommPortSingleton.GetInstance().openComm())
            {
                return;
            }
            byte slaveid = byte.Parse(textBox1.Text);
            ushort startaddr = ushort.Parse(textBox2.Text);
            ushort numregs = 2;

            ModbusRegisters modbusRegs = new ModbusRegisters(slaveid, startaddr, numregs);
            inputCommPortSingleton.GetInstance().readRegister(ref modbusRegs);

            int b0 = int.Parse(textBoxByte0.Text);
            int b1 = int.Parse(textBoxByte1.Text);
            int b2 = int.Parse(textBoxByte2.Text);
            int b3 = int.Parse(textBoxByte3.Text);

            byte[] bytes = new byte[4];
            bytes[b0] = (byte)modbusRegs.stReg[0].getHighReg();
            bytes[b1] = (byte)modbusRegs.stReg[0].getLowReg();
            bytes[b2] = (byte)modbusRegs.stReg[1].getHighReg();
            bytes[b3] = (byte)modbusRegs.stReg[1].getLowReg();
 
            float f = BitConverter.ToSingle(bytes, 0);
            textBox3.Text = f.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inputCommPortSingleton.GetInstance().initComm();
            if (!inputCommPortSingleton.GetInstance().openComm())
            {
                return;
            }

            //inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);

            // use api
            byte slaveid = byte.Parse(textBox1.Text);
            ushort startaddr = ushort.Parse(textBox2.Text);
            float f = float.Parse(textBox3.Text);
            byte[] bytes = BitConverter.GetBytes(f);
            ushort numregs = 10;

            using (ModbusRegisters modbusRegs = new ModbusRegisters(slaveid, startaddr, numregs))
            {
                int b0 = int.Parse(textBoxByte0.Text);
                int b1 = int.Parse(textBoxByte1.Text);
                int b2 = int.Parse(textBoxByte2.Text);
                int b3 = int.Parse(textBoxByte3.Text);

                modbusRegs.stReg[0].setHighReg(bytes[b0]);
                modbusRegs.stReg[0].setLowReg(bytes[b1]);
                modbusRegs.stReg[1].setHighReg(bytes[b2]);
                modbusRegs.stReg[1].setLowReg(bytes[b3]);
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }
    }
}
