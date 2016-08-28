using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommCtrlSystem
{
    public partial class WindowManualSetting : UserControl
    {
        public WindowManualSetting()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wmain);
        }

        private void buttonAdjust1_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x45, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void buttonAdjust2_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x46, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void buttonRefrigeration1_34_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x47, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void buttonRefrigeration1_51_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x48, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void buttonRefrigeration1_67_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x49, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void button1Thawing1_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x4a, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void buttonRefrigeration2_34_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x4b, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void buttonRefrigeration2_51_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x4c, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void buttonRefrigeration2_67_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x4d, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void button1Thawing2_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x4e, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void buttonDrying1_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x4f, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void buttonDrying2_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x50, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void buttonClean1_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x51, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void buttonClean2_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x52, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }

        private void button1Stop_Click(object sender, EventArgs e)
        {
            using (ModbusRegisters modbusRegs = new ModbusRegisters(1, 0x53, 1))
            {
                modbusRegs.stReg[0].value = 0x02;
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
        }
    }
}
