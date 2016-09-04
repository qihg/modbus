using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace CommCtrlSystem
{
    public partial class FormSysCfg : Form
    {
        public FormSysCfg()
        {
            InitializeComponent();
            InitializeSystemSetting();
        }

        private void loadDefaultSettings()
        {
            comboBoxConnectMode.SelectedIndex = 0;
            comboBoxBaud1.SelectedIndex = 7;
            comboBoxBaud2.SelectedIndex = 7;
            comboBoxConnectMode.SelectedIndex = 0;
            comboBoxDataBits1.SelectedIndex = 1;
            comboBoxDataBits2.SelectedIndex = 1;
            comboBoxParity1.SelectedIndex = 2;
            comboBoxParity2.SelectedIndex = 2;
            comboBoxStopBits1.SelectedIndex = 0;
            comboBoxStopBits2.SelectedIndex = 0;
            maskedTextBoxServerPort.KeyPress += new KeyPressEventHandler(new CheckUserInput().CheckIsNumber);
            maskedTextBoxServerPort.TextChanged += new EventHandler(new CheckUserInput().CheckIsUInt);
        }

        private void InitializeSystemSetting()
        {
            loadDefaultSettings();
            try
            {
                Configure cfg = null;
                if (File.Exists(@"cfg.json"))
                {
                    cfg = JsonConvert.DeserializeObject<Configure>(File.ReadAllText(@"cfg.json"));
                }

                string[] portList = System.IO.Ports.SerialPort.GetPortNames();

                for (int i = 0; i < portList.Length; ++i)
                {
                    string name = portList[i];
                    comboBoxCom1.Items.Add(name);
                    comboBoxCom2.Items.Add(name);
                    if (cfg != null && name.ToLower() == cfg.InputSerialPortName.ToLower())
                    {
                        comboBoxCom1.SelectedIndex = i;
                    }

                    if (cfg != null && name.ToLower() == cfg.OutputSerialPortName.ToLower())
                    {
                        comboBoxCom2.SelectedIndex = i;
                    }
                }

                if (cfg == null)
                {
                    return;
                }

                if (cfg.InputModbusType == "RTU")
                {
                    radioButtonRTU1.Checked = true;
                    radioButtonASCII1.Checked = false;
                }
                else
                {
                    radioButtonRTU1.Checked = false;
                    radioButtonASCII1.Checked = true;
                }

                if (cfg.OutputModbusType == "RTU")
                {
                    radioButtonRTU2.Checked = true;
                    radioButtonASCII2.Checked = false;
                }
                else
                {
                    radioButtonRTU2.Checked = false;
                    radioButtonASCII2.Checked = true;
                    radioButtonASCII2.Checked = true;
                }

                if (comboBoxBaud1.Items.Contains(cfg.InputSerialPortBaud))
                {
                    comboBoxBaud1.Text = cfg.InputSerialPortBaud;
                }

                if (comboBoxDataBits1.Items.Contains(cfg.InputSerialPortDataBit))
                {
                    comboBoxDataBits1.Text = cfg.InputSerialPortDataBit;
                }

                if (comboBoxParity1.Items.Contains(cfg.InputSerialPortParity))
                {
                    comboBoxParity1.Text = cfg.InputSerialPortParity;
                }

                if (comboBoxStopBits1.Items.Contains(cfg.InputSerialPortStopBit))
                {
                    comboBoxStopBits1.Text = cfg.InputSerialPortStopBit;
                }

                if (comboBoxBaud2.Items.Contains(cfg.OutputSerialPortBaud))
                {
                    comboBoxBaud2.Text = cfg.OutputSerialPortBaud;
                }

                if (comboBoxDataBits2.Items.Contains(cfg.OutputSerialPortDataBit))
                {
                    comboBoxDataBits2.Text = cfg.OutputSerialPortDataBit;
                }

                if (comboBoxParity2.Items.Contains(cfg.OutputSerialPortParity))
                {
                    comboBoxParity2.Text = cfg.OutputSerialPortParity;
                }

                if (comboBoxStopBits2.Items.Contains(cfg.OutputSerialPortStopBit))
                {
                    comboBoxStopBits2.Text = cfg.OutputSerialPortStopBit;
                }

                checkBoxAutoStartOnLoad.Checked = cfg.bGetDataOnload;
                textBoxIpAddr.Text = cfg.ServerIp;
                maskedTextBoxServerPort.Text = cfg.ServerPort;

                if (comboBoxConnectMode.Items.Contains(cfg.OutoutMethod))
                {
                    comboBoxConnectMode.Text = cfg.OutoutMethod;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Configure cfg = new Configure();
                cfg.InputSerialPortName = comboBoxCom1.Text;
                if (radioButtonRTU1.Checked)
                {
                    cfg.InputModbusType = "RTU";
                }
                else
                {
                    cfg.InputModbusType = "ASCII";
                }

                if (radioButtonRTU2.Checked)
                {
                    cfg.OutputModbusType = "RTU";
                }
                else
                {
                    cfg.OutputModbusType = "ASCII";
                }
                cfg.InputSerialPortBaud = comboBoxBaud1.Text.ToString();
                cfg.InputSerialPortDataBit = comboBoxDataBits1.Text.ToString();
                cfg.InputSerialPortParity = comboBoxParity1.Text.ToString();
                cfg.InputSerialPortStopBit = comboBoxStopBits1.Text.ToString();

                cfg.OutputSerialPortName = comboBoxCom2.Text;
                cfg.OutputSerialPortBaud = comboBoxBaud2.Text.ToString();
                cfg.OutputSerialPortDataBit = comboBoxDataBits2.Text.ToString();
                cfg.OutputSerialPortParity = comboBoxParity2.Text.ToString();
                cfg.OutputSerialPortStopBit = comboBoxStopBits2.Text.ToString();
                cfg.bGetDataOnload = checkBoxAutoStartOnLoad.Checked;

                cfg.ServerIp = textBoxIpAddr.Text.Trim();
                cfg.ServerPort = maskedTextBoxServerPort.Text.Trim();
                cfg.OutoutMethod = comboBoxConnectMode.Text.ToString();
                File.WriteAllText(@"cfg.json", JsonConvert.SerializeObject(cfg));
                this.Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxConnectMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxConnectMode.SelectedItem.ToString() == "TCP/IP")
            {
                comboBoxCom2.Enabled = false;
                comboBoxBaud2.Enabled = false;
                comboBoxDataBits2.Enabled = false;
                comboBoxParity2.Enabled = false;
                comboBoxStopBits2.Enabled = false;
                radioButtonASCII2.Enabled = false;
                radioButtonRTU2.Enabled = false;
                textBoxIpAddr.Enabled = true;
                maskedTextBoxServerPort.Enabled = true;
            }
            else
            {
                comboBoxCom2.Enabled = true;
                comboBoxBaud2.Enabled = true;
                comboBoxDataBits2.Enabled = true;
                comboBoxParity2.Enabled = true;
                comboBoxStopBits2.Enabled = true;
                radioButtonASCII2.Enabled = true;
                radioButtonRTU2.Enabled = true;
                textBoxIpAddr.Enabled = false;
                maskedTextBoxServerPort.Enabled = false;
            }
            
        }

    }
}
