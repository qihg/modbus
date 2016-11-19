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
using Modbus.Device;
using Modbus.IO;
using Modbus.Utility;
using Modbus.Data;
using System.Text.RegularExpressions;
using System.Threading;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;

namespace PLCModbusSystem
{
    public partial class Form1 : Form
    {
        public Thread updateDataThread;
        public bool m_updateDataFlg = false;
        ModbusRegisters modbusRegs;
        public delegate void UpdateMainUIInvoke(ModbusRegisters modbusRegs);
        private static readonly object locker = new object();

        private List<RegTextBox> lRegTextBox;
        private const byte SLAVEID = 1;
        private const ushort STARTADDRESS = 0;
        private const ushort REGNUM = 18;
        private ushort last_startaddr = 0;
        private string last_floatformat = "";

        private const int INPUT_METHOD_SERIAL = 0;
        private const int INPUT_METHOD_IP = 1;
        private int input_method = INPUT_METHOD_SERIAL;
        private labelcfg lcfg = null;
        private int rtycnt = 3;
        public Form1()
        {
            InitializeComponent();
            labelWarning.Text = "";
            InitializeSystemSetting();
            InitializeRegs();
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        void addRegTextBoxControl(ref List<RegTextBox> list, ref ModbusRegisters modbusRegs, Control.ControlCollection controls, RegTextBox.FloatFMT fmt)
        {
            foreach (Control control in controls)//遍历本窗体中所有的ComboBox控件 
            {
                if (control.GetType().ToString() == "System.Windows.Forms.GroupBox")
                {
                    addRegTextBoxControl(ref list, ref modbusRegs, (control as GroupBox).Controls, fmt);
                } 
                else if (control.GetType().ToString() == "PLCModbusSystem.RegTextBox")
                {
                    (control as PLCModbusSystem.RegTextBox).setReg(ref modbusRegs);
                    (control as PLCModbusSystem.RegTextBox).floatFmt = fmt;
                    //(control as CommCtrlSystem.RegTextBox).KeyPress += new KeyPressEventHandler(new CheckUserInput().CheckIsNumber);
                    lRegTextBox.Add(control as PLCModbusSystem.RegTextBox);
                }
            }
        }

        void updateRegAddrLabel(ushort startaddr)
        {
            label23.Text = "(" + string.Format("{0:0000}", startaddr) + ")";
            label24.Text = "(" + string.Format("{0:0000}", startaddr + 2) + ")";
            label25.Text = "(" + string.Format("{0:0000}", startaddr + 10) + ")";
            label26.Text = "(" + string.Format("{0:0000}", startaddr + 4) + ")";
            label27.Text = "(" + string.Format("{0:0000}", startaddr + 12) + ")";
            label28.Text = "(" + string.Format("{0:0000}", startaddr + 6) + ")";
            label29.Text = "(" + string.Format("{0:0000}", startaddr + 14) + ")";
            label30.Text = "(" + string.Format("{0:0000}", startaddr + 8) + ")";
            label31.Text = "(" + string.Format("{0:0000}", startaddr + 16) + ")";
        }

        void InitializeRegs()
        {
            lRegTextBox = new List<RegTextBox>();
            modbusRegs = new ModbusRegisters(SLAVEID, last_startaddr, REGNUM);
            RegTextBox.FloatFMT fmt = RegTextBox.FloatFMT.FMT_DCBA;

            if (last_floatformat == "AB CD")
            {
                fmt = RegTextBox.FloatFMT.FMT_ABCD;
            }
            else if (last_floatformat == "BA DC")
            {
                fmt = RegTextBox.FloatFMT.FMT_BADC;
            }
            else if (last_floatformat == "CD AB")
            {
                fmt = RegTextBox.FloatFMT.FMT_CDAB;
            }
            else
            {
                fmt = fmt = RegTextBox.FloatFMT.FMT_DCBA;
            }
            addRegTextBoxControl(ref lRegTextBox, ref modbusRegs, this.Controls, fmt);

            updateRegAddrLabel(last_startaddr);
            //foreach (Control control in this.Controls)//遍历本窗体中所有的ComboBox控件 
            //{
            //    if (control.GetType().ToString() == "System.Windows.Forms.GroupBox")
            //    {

           //     }
           //     string tmpstr = control.GetType().ToString();
           //     if (tmpstr == "PLCModbusSystem.RegTextBox")
           //     {
           //         (control as PLCModbusSystem.RegTextBox).setReg(ref modbusRegs);
                    //(control as CommCtrlSystem.RegTextBox).KeyPress += new KeyPressEventHandler(new CheckUserInput().CheckIsNumber);
           //         lRegTextBox.Add(control as PLCModbusSystem.RegTextBox);
           //     }
          //  }
        }

        private void load_labcfg()
        {  
            string cfgfile = System.IO.Path.Combine(Application.StartupPath, "labcfg.json");
            if (File.Exists(cfgfile))
            {
                lcfg = JsonConvert.DeserializeObject<labelcfg>(File.ReadAllText(cfgfile));
            } else {
                return;
            }

            if (lcfg.label_res != null)
            {
                label_res.Text = lcfg.label_res;
            }

            if (lcfg.label_1 != null)
            {
                label_1.Text = lcfg.label_1;
            }

            if (lcfg.label_2 != null)
            {
                label_2.Text = lcfg.label_2;
            }

            if (lcfg.label_3 != null)
            {
                label_3.Text = lcfg.label_3;
            }

            if (lcfg.label_4 != null)
            {
                label_4.Text = lcfg.label_4;
            }

            if (lcfg.label_5 != null)
            {
                label_5.Text = lcfg.label_5;
            }

            if (lcfg.label_6 != null)
            {
                label_6.Text = lcfg.label_6;
            }

            if (lcfg.label_7 != null)
            {
                label_7.Text = lcfg.label_7;
            }

            if (lcfg.label_8 != null)
            {
                label_8.Text = lcfg.label_8;
            }
        }

        private void InitializeSystemSetting()
        {
            try
            {
                load_labcfg();
                Configure cfg = null;
                string cfgfile = System.IO.Path.Combine(Application.StartupPath, "cfg.json");
                if (File.Exists(cfgfile))
                {
                    cfg = JsonConvert.DeserializeObject<Configure>(File.ReadAllText(cfgfile));
                }

                string[] portList = System.IO.Ports.SerialPort.GetPortNames();

                for (int i = 0; i < portList.Length; ++i)
                {
                    string name = portList[i];
                    comboBoxSerialPort.Items.Add(name);
                    if (cfg != null && name.ToLower() == cfg.InputSerialPortName.ToLower())
                    {
                        comboBoxSerialPort.SelectedIndex = i;
                    }
                }

                if (cfg == null)
                {
                    return;
                }

                if (cfg.bSerial_sel)
                {
                    radioButtonSerial.Checked = true;
                    input_method = INPUT_METHOD_SERIAL;
                }
                else if (cfg.bNetwork_sel)
                {
                    radioButtonNetwork.Checked = true;
                    input_method = INPUT_METHOD_IP;
                }
                else
                {
                    radioButtonSerial.Checked = true;
                    input_method = INPUT_METHOD_SERIAL;
                }

                if (radioButtonSerial.Checked)
                {
                    comboBoxSerialPort.Enabled = true;
                    comboBoxBaud.Enabled = true;
                    textBoxIPAddr.Enabled = false;
                    textBoxPort.Enabled = false;
                }
                else if (radioButtonNetwork.Checked)
                {
                    comboBoxSerialPort.Enabled = false;
                    comboBoxBaud.Enabled = false;
                    textBoxIPAddr.Enabled = true;
                    textBoxPort.Enabled = true;
                }


                if (inputCommPortSingleton.GetInstance().checkSerialPort(cfg.InputSerialPortName))
                {
                    comboBoxSerialPort.Text = cfg.InputSerialPortName;
                }
                else
                {
                    comboBoxSerialPort.Text = "";
                }

                if (cfg.bOutputExcel)
                {
                    checkBoxExcel.Checked = true;
                }
                else
                {
                    checkBoxExcel.Checked = false;
                }

                if (cfg.bOutputLims)
                {
                    checkBoxLims.Checked = true;
                }
                else
                {
                    checkBoxLims.Checked = false;
                }

                if (comboBoxBaud.Items.Contains(cfg.InputSerialPortBaud))
                {
                    comboBoxBaud.Text = cfg.InputSerialPortBaud;
                }

                textBoxUserName.Text = cfg.username;
                textBoxPassword.Text = cfg.userpassword;
                textBoxAnalysis.Text = cfg.analysis;

                textBoxDevID.Text = cfg.dev_id;
                textBoxDevName.Text = cfg.dev_name;
                textBoxLabName.Text = cfg.lab_name;
                textBoxOilID.Text = cfg.oil_id;
                textBoxOilName.Text = cfg.oil_name;
                maskedTextBoxStartAddr.Text = cfg.startAddr.ToString();
                comboBoxFormat.Text = cfg.floatFormat;
                last_startaddr = cfg.startAddr;
                last_floatformat = cfg.floatFormat;

                textBoxIPAddr.Text = cfg.ipaddr;
                textBoxPort.Text = cfg.port;

                if (input_method == INPUT_METHOD_SERIAL)
                {
                    if (false == inputCommPortSingleton.GetInstance().initComm() || false == inputCommPortSingleton.GetInstance().openComm())
                    {
                        labelWarning.Text = "串口初始化失败";
                    }
                    else
                    {
                        startUpdateRegs();
                    }
                }
                else
                {
                    if (false == modbusNetworkSingleton.GetInstance().initModbusPoll(cfg.ipaddr, int.Parse(cfg.port), cfg.protocol))
                    {
                        labelWarning.Text = "以太网初始化失败";
                    }
                    else
                    {
                        startUpdateRegs();
                    }
                }
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                //MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            //LogClass.GetInstance().WriteLogFile("ApplicationExit");
            if (input_method == INPUT_METHOD_SERIAL)
            {
                inputCommPortSingleton.GetInstance().closeComm();
            }
            else
            {
                modbusNetworkSingleton.GetInstance().closeComm();
            }
            
            stopUpdateRegs();
            //LogClass.GetInstance().WriteLogFile("ApplicationExit End-----------------------");
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                Configure cfg = new Configure();
                cfg.InputSerialPortName = comboBoxSerialPort.Text;
                if (checkBoxExcel.Checked)
                {
                    cfg.bOutputExcel = true;
                }
                else
                {
                    cfg.bOutputExcel = false;
                }

                if (checkBoxLims.Checked)
                {
                    cfg.bOutputLims = true;
                }
                else
                {
                    cfg.bOutputLims = false;
                }

                cfg.InputSerialPortBaud = comboBoxBaud.Text.ToString();
                cfg.InputSerialPortDataBit = "8 Data Bits";
                cfg.InputSerialPortParity = "None Parity";
                cfg.InputSerialPortStopBit = "1 Stop Bit";;

                cfg.username = textBoxUserName.Text.Trim();
                cfg.userpassword = textBoxPassword.Text.Trim();
                cfg.analysis = textBoxAnalysis.Text.Trim();
                cfg.dev_id = textBoxDevID.Text.Trim();
                cfg.dev_name = textBoxDevName.Text.Trim();
                cfg.lab_name = textBoxLabName.Text.Trim();
                cfg.oil_id = textBoxOilID.Text.Trim();
                cfg.oil_name = textBoxOilName.Text.Trim();

                cfg.startAddr = ushort.Parse(maskedTextBoxStartAddr.Text.Trim());
                cfg.floatFormat = comboBoxFormat.Text.Trim();

                if (radioButtonSerial.Checked)
                {
                    cfg.bSerial_sel = true;
                }
                else
                {
                    cfg.bSerial_sel = false;
                }

                if (radioButtonNetwork.Checked)
                {
                    cfg.bNetwork_sel = true;
                }
                else
                {
                    cfg.bNetwork_sel = false;
                }

                cfg.protocol = comboBoxProtocol.Text.Trim();
                cfg.ipaddr = textBoxIPAddr.Text.Trim();
                cfg.port = textBoxPort.Text.Trim();
                string cfgfile = System.IO.Path.Combine(Application.StartupPath, "cfg.json");
                File.WriteAllText(cfgfile, JsonConvert.SerializeObject(cfg));

                //if (false == inputCommPortSingleton.GetInstance().initComm() || false == inputCommPortSingleton.GetInstance().openComm())
                //{
                //    labelWarning.Text = "串口初始化失败";
                //}
                //else
                //{
                    stopUpdateRegs();
                    if (last_startaddr != cfg.startAddr || last_floatformat != cfg.floatFormat)
                    {
                        last_startaddr = cfg.startAddr;
                        last_floatformat = cfg.floatFormat;

                        RegTextBox.FloatFMT fmt = RegTextBox.FloatFMT.FMT_DCBA;

                        if (last_floatformat == "AB CD")
                        {
                            fmt = RegTextBox.FloatFMT.FMT_ABCD;
                        }
                        else if (last_floatformat == "BA DC")
                        {
                            fmt = RegTextBox.FloatFMT.FMT_BADC;
                        }
                        else if (last_floatformat == "CD AB")
                        {
                            fmt = RegTextBox.FloatFMT.FMT_CDAB;
                        }
                        else
                        {
                            fmt = fmt = RegTextBox.FloatFMT.FMT_DCBA;
                        }

                        lRegTextBox.Clear();

                        modbusRegs.startAddress = last_startaddr;
                        addRegTextBoxControl(ref lRegTextBox, ref modbusRegs, this.Controls, fmt);
                        updateRegAddrLabel(last_startaddr);
                    }

                    if (input_method == INPUT_METHOD_SERIAL)
                    {
                        if (false == inputCommPortSingleton.GetInstance().initComm() || false == inputCommPortSingleton.GetInstance().openComm())
                        {
                            labelWarning.Text = "串口初始化失败";
                        }
                        else
                        {
                            startUpdateRegs();
                        }
                    }
                    else
                    {
                        if (false == modbusNetworkSingleton.GetInstance().initModbusPoll(cfg.ipaddr, int.Parse(cfg.port), cfg.protocol))
                        {
                            labelWarning.Text = "以太网初始化失败";
                        }
                        else
                        {
                            startUpdateRegs();
                        }
                    }
                //}
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                //MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DoUpdateRegs()
        {
            while (m_updateDataFlg)
            {
                try
                {
                    if (input_method == INPUT_METHOD_SERIAL)
                    {
                        int ret = inputCommPortSingleton.GetInstance().readRegister(ref modbusRegs);
                        if (ret != inputCommPortSingleton.RET_OK)
                        {
                            if (ret == inputCommPortSingleton.RET_TIMEOUT)
                            {
                                continue;
                            }
                            else
                            {
                                // set label communication error
                            }
                            break;
                        }
                    }
                    else
                    {
                        //modbusNetworkSingleton.GetInstance().writeMultiRegisters(modbusRegs);
                        int ret = modbusNetworkSingleton.GetInstance().readRegister(ref modbusRegs);
                        if (ret != modbusNetworkSingleton.RET_OK)
                        {
                            if (ret == modbusNetworkSingleton.RET_TIMEOUT)
                            {
                                continue;
                            }
                            else
                            {
                                // set label communication error
                            }
                            break;
                        }
                    }
                    UpdateMainUIInvoke umi = new UpdateMainUIInvoke(UpdateUIData);

                    while (!this.IsHandleCreated)
                    {
                        Thread.Sleep(100);
                    }
                    BeginInvoke(umi, modbusRegs);

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    LogClass.GetInstance().WriteExceptionLog(ex);
                    //MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            while (m_updateDataFlg)
            {
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    LogClass.GetInstance().WriteExceptionLog(ex);
                }
            }
            if (input_method == INPUT_METHOD_SERIAL)
            {
                inputCommPortSingleton.GetInstance().closeComm();
            }
            else
            {
                modbusNetworkSingleton.GetInstance().closeComm();
            }
        }

        public void UpdateUIData(ModbusRegisters reg)
        {
            for (int i = 0; i < lRegTextBox.Count; i++)
            {
                lRegTextBox[i].UpdateData();
            }

            byte[] bytes = new byte[4];
            if (comboBoxFormat.Text == "AB CD")
            {
                bytes[0] = (byte)modbusRegs.stReg[1].getLowReg();
                bytes[1] = (byte)modbusRegs.stReg[1].getHighReg();
                bytes[2] = (byte)modbusRegs.stReg[0].getLowReg();
                bytes[3] = (byte)modbusRegs.stReg[0].getHighReg();
            }
            else if (comboBoxFormat.Text == "CD AB")
            {
                bytes[0] = (byte)modbusRegs.stReg[0].getLowReg();
                bytes[1] = (byte)modbusRegs.stReg[0].getHighReg();
                bytes[2] = (byte)modbusRegs.stReg[1].getLowReg();
                bytes[3] = (byte)modbusRegs.stReg[1].getHighReg();
            }
            else if (comboBoxFormat.Text == "BA DC")
            {
                bytes[0] = (byte)modbusRegs.stReg[1].getHighReg();
                bytes[1] = (byte)modbusRegs.stReg[1].getLowReg();
                bytes[2] = (byte)modbusRegs.stReg[0].getHighReg();
                bytes[3] = (byte)modbusRegs.stReg[0].getLowReg();
            }
            else if (comboBoxFormat.Text == "DC BA")
            {
                bytes[0] = (byte)modbusRegs.stReg[0].getHighReg();
                bytes[1] = (byte)modbusRegs.stReg[0].getLowReg();
                bytes[2] = (byte)modbusRegs.stReg[1].getHighReg();
                bytes[3] = (byte)modbusRegs.stReg[1].getLowReg();
            }
            else
            {
                return;
            }
            float q = BitConverter.ToSingle(bytes, 0);

            if (q > 0)
            {
                SaveFile();
            }

            regTextBoxResult.Text = "0";
            if (input_method == INPUT_METHOD_SERIAL)
            {
                inputCommPortSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
            else
            {
                modbusNetworkSingleton.GetInstance().writeMultiRegisters(modbusRegs);
            }
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
                    //LogClass.GetInstance().WriteLogFile("Join");
                    updateDataThread.Join();
                    //LogClass.GetInstance().WriteLogFile("Joined");
                }
            }
        }

        private void CreateExcelFile(string FileName)
        {
            //create  
            try
            {
                NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("Result");
                NPOI.SS.UserModel.IRow row0 = sheet.CreateRow(0);
                int i = 0;
                if (lcfg == null)
                {
                    row0.CreateCell(i++).SetCellValue("日期:");
                    row0.CreateCell(i++).SetCellValue("仪器名称:");
                    row0.CreateCell(i++).SetCellValue("仪器编号:");
                    row0.CreateCell(i++).SetCellValue("实验室名称:");
                    row0.CreateCell(i++).SetCellValue("油样名称:");
                    row0.CreateCell(i++).SetCellValue("油样号:");
                    row0.CreateCell(i++).SetCellValue("实验员:");
                    row0.CreateCell(i++).SetCellValue("分析方法:");
                    row0.CreateCell(i++).SetCellValue("一号弹:测试时间:");
                    row0.CreateCell(i++).SetCellValue("最大压力:");
                    row0.CreateCell(i++).SetCellValue("二号弹:测试时间:");
                    row0.CreateCell(i++).SetCellValue("最大压力:");
                    row0.CreateCell(i++).SetCellValue("三号弹:测试时间:");
                    row0.CreateCell(i++).SetCellValue("最大压力:");
                    row0.CreateCell(i++).SetCellValue("四号弹:测试时间:");
                    row0.CreateCell(i++).SetCellValue("最大压力:");
                }
                else
                {
                    row0.CreateCell(i++).SetCellValue("日期:");
                    row0.CreateCell(i++).SetCellValue("仪器名称:");
                    row0.CreateCell(i++).SetCellValue("仪器编号:");
                    row0.CreateCell(i++).SetCellValue("实验室名称:");
                    row0.CreateCell(i++).SetCellValue("油样名称:");
                    row0.CreateCell(i++).SetCellValue("油样号:");
                    row0.CreateCell(i++).SetCellValue("实验员:");
                    row0.CreateCell(i++).SetCellValue("分析方法:");
                    row0.CreateCell(i++).SetCellValue(lcfg.label_1_out);
                    row0.CreateCell(i++).SetCellValue(lcfg.label_2_out);
                    row0.CreateCell(i++).SetCellValue(lcfg.label_3_out);
                    row0.CreateCell(i++).SetCellValue(lcfg.label_4_out);
                    row0.CreateCell(i++).SetCellValue(lcfg.label_5_out);
                    row0.CreateCell(i++).SetCellValue(lcfg.label_6_out);
                    row0.CreateCell(i++).SetCellValue(lcfg.label_7_out);
                    row0.CreateCell(i++).SetCellValue(lcfg.label_8_out);
                }

                NPOI.SS.UserModel.IRow row1 = sheet.CreateRow(1);
                i = 0;
                row1.CreateCell(i++).SetCellValue(DateTime.Now.ToString());
                row1.CreateCell(i++).SetCellValue(textBoxDevName.Text);
                row1.CreateCell(i++).SetCellValue(textBoxDevID.Text);
                row1.CreateCell(i++).SetCellValue(textBoxLabName.Text);
                row1.CreateCell(i++).SetCellValue(textBoxOilName.Text);
                row1.CreateCell(i++).SetCellValue(textBoxOilID.Text);
                row1.CreateCell(i++).SetCellValue(textBoxUserName.Text);
                row1.CreateCell(i++).SetCellValue(textBoxAnalysis.Text);
                row1.CreateCell(i++).SetCellValue(regTextBox1.Text);
                row1.CreateCell(i++).SetCellValue(regTextBox2.Text);
                row1.CreateCell(i++).SetCellValue(regTextBox3.Text);
                row1.CreateCell(i++).SetCellValue(regTextBox4.Text);
                row1.CreateCell(i++).SetCellValue(regTextBox5.Text);
                row1.CreateCell(i++).SetCellValue(regTextBox6.Text);
                row1.CreateCell(i++).SetCellValue(regTextBox7.Text);
                row1.CreateCell(i++).SetCellValue(regTextBox8.Text);

                for (int j = 0; j < i; j++)
                {
                    sheet.AutoSizeColumn(j);
                }

                //worksheet.Cells[1, 1] = "仪器名称:";
                //worksheet.Cells[2, 1] = "仪器编号:";
                //worksheet.Cells[3, 1] = "实验室名称:";
                //worksheet.Cells[4, 1] = "油样名称:";
                //worksheet.Cells[5, 1] = "油样号:";
                //worksheet.Cells[6, 1] = "实验员:";
                //worksheet.Cells[7, 1] = "分析方法:";
                //worksheet.Cells[8, 1] = "日期:";

                //worksheet.Cells[1, 2] = textBoxDevName.Text;
                //worksheet.Cells[2, 2] = textBoxDevID.Text;
                //worksheet.Cells[3, 2] = textBoxLabName.Text;
                //worksheet.Cells[4, 2] = textBoxOilName.Text;
                //worksheet.Cells[5, 2] = textBoxOilID.Text;
                //worksheet.Cells[6, 2] = textBoxUserName.Text;
                //worksheet.Cells[7, 2] = textBoxAnalysis.Text;
                //worksheet.Cells[8, 2] = DateTime.Now.ToString();

                //worksheet.Cells[9, 1] = "一号弹:";
                //worksheet.Cells[10, 1] = "二号弹:";
                //worksheet.Cells[11, 1] = "三号弹:";
                //worksheet.Cells[12, 1] = "四号弹:";

                //worksheet.Cells[9, 2] = "测试时间:";
                //worksheet.Cells[10, 2] = "测试时间:";
                //worksheet.Cells[11, 2] = "测试时间:";
                //worksheet.Cells[12, 2] = "测试时间:";

                //worksheet.Cells[9, 3] = regTextBox1.Text;
                //worksheet.Cells[10, 3] = regTextBox3.Text;
                //worksheet.Cells[11, 3] = regTextBox5.Text;
                //worksheet.Cells[12, 3] = regTextBox7.Text;

                //worksheet.Cells[9, 4] = "最大压力:";
                //worksheet.Cells[10, 4] = "最大压力:";
                //worksheet.Cells[11, 4] = "最大压力:";
                //worksheet.Cells[12, 4] = "最大压力:";


                //worksheet.Cells[9, 5] = regTextBox2.Text;
                //worksheet.Cells[10, 5] = regTextBox4.Text;
                //worksheet.Cells[11, 5] = regTextBox6.Text;
                //worksheet.Cells[12, 5] = regTextBox8.Text;

                //((Excel.Range)worksheet.Columns["A:E", System.Type.Missing]).AutoFit();
                //worksheet.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
                //workBook.Close(false, Type.Missing, Type.Missing);
                //app.Quit();

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    book.Write(ms);
                    using (FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                    book = null;
                }
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void SaveFile()
        {
            if (checkBoxExcel.Checked)
            {
                saveExcelFile();
            }

            if (checkBoxLims.Checked)
            {
                saveXMLFile();
            }
        }
        private void buttonTestOutput_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        public void saveExcelFile()
        {
            DateTime now = DateTime.Now;
            int iNo = 1;
           
            string dir_path = "d:\\ExcelIN";
            try
            {
                if (!Directory.Exists(dir_path))
                {
                    Directory.CreateDirectory(dir_path);
                }
            }
            catch (Exception ex)
            {
                //if (ex.Equals()
                MessageBox.Show("Folder " + dir_path + " create error.");
            }

            string filename = String.Format("d:\\ExcelIN\\dlznyq_coldfilter_{0}-{1}.xls", now.ToString("yyyy-MM-dd"), iNo);
            while (File.Exists(filename))
            {
                iNo++;
                filename = String.Format("d:\\ExcelIN\\dlznyq_coldfilter_{0}-{1}.xls", now.ToString("yyyy-MM-dd"), iNo);
            }
            CreateExcelFile(filename);
            

        }

        public bool createXmlFile(string filename)
        {
            try
            {
                Configure cfg = null;
                string cfgfile = System.IO.Path.Combine(Application.StartupPath, "cfg.json");
                if (File.Exists(cfgfile))
                {
                    cfg = JsonConvert.DeserializeObject<Configure>(File.ReadAllText(cfgfile));
                    if (cfg != null)
                    {
                        LimsDoc l;
                        l = new LimsDoc(cfg.username, cfg.userpassword, "system");

                        LimsDocEntity entity = l.createEntity("SAMPLE", "RESULT_ENTRY");
                        LimsDocEntity entity2 = l.createEntity("TEST", null);
                        LimsDocEntity entity1_time = l.createEntity("RESULT", null);
                        LimsDocEntity entity1_res = l.createEntity("RESULT", null);
                        LimsDocEntity entity2_time = l.createEntity("RESULT", null);
                        LimsDocEntity entity2_res = l.createEntity("RESULT", null);
                        LimsDocEntity entity3_time = l.createEntity("RESULT", null);
                        LimsDocEntity entity3_res = l.createEntity("RESULT", null);
                        LimsDocEntity entity4_time = l.createEntity("RESULT", null);
                        LimsDocEntity entity4_res = l.createEntity("RESULT", null);

                        entity2.addFields("ANALYSIS", "in", textBoxAnalysis.Text);

                        entity.addFields("ID_NUMERIC", "in", textBoxOilID.Text);

                        if (lcfg == null)
                        {
                            entity1_time.addFields("NAME", "in", "一号弹测试时间");
                            entity1_time.addFields("TEXT", "in", regTextBox1.Text);
                            entity2.addChild(entity1_time.getElement());

                            entity1_res.addFields("NAME", "in", "一号弹最大压力");
                            entity1_res.addFields("TEXT", "in", regTextBox2.Text);
                            entity2.addChild(entity1_res.getElement());

                            entity2_time.addFields("NAME", "in", "二号弹测试时间");
                            entity2_time.addFields("TEXT", "in", regTextBox3.Text);
                            entity2.addChild(entity2_time.getElement());

                            entity2_res.addFields("NAME", "in", "二号弹最大压力");
                            entity2_res.addFields("TEXT", "in", regTextBox4.Text);
                            entity2.addChild(entity2_res.getElement());

                            entity3_time.addFields("NAME", "in", "三号弹测试时间");
                            entity3_time.addFields("TEXT", "in", regTextBox5.Text);
                            entity2.addChild(entity3_time.getElement());

                            entity3_res.addFields("NAME", "in", "三号弹最大压力");
                            entity3_res.addFields("TEXT", "in", regTextBox6.Text);
                            entity2.addChild(entity3_res.getElement());

                            entity4_time.addFields("NAME", "in", "四号弹测试时间");
                            entity4_time.addFields("TEXT", "in", regTextBox7.Text);
                            entity2.addChild(entity4_time.getElement());

                            entity4_res.addFields("NAME", "in", "四号弹最大压力");
                            entity4_res.addFields("TEXT", "in", regTextBox8.Text);
                            entity2.addChild(entity4_res.getElement());
                        }
                        else
                        {
                            entity1_time.addFields("NAME", "in", lcfg.label_1_out);
                            entity1_time.addFields("TEXT", "in", regTextBox1.Text);
                            entity2.addChild(entity1_time.getElement());

                            entity1_res.addFields("NAME", "in", lcfg.label_2_out);
                            entity1_res.addFields("TEXT", "in", regTextBox2.Text);
                            entity2.addChild(entity1_res.getElement());

                            entity2_time.addFields("NAME", "in", lcfg.label_3_out);
                            entity2_time.addFields("TEXT", "in", regTextBox3.Text);
                            entity2.addChild(entity2_time.getElement());

                            entity2_res.addFields("NAME", "in", lcfg.label_4_out);
                            entity2_res.addFields("TEXT", "in", regTextBox4.Text);
                            entity2.addChild(entity2_res.getElement());

                            entity3_time.addFields("NAME", "in", lcfg.label_5_out);
                            entity3_time.addFields("TEXT", "in", regTextBox5.Text);
                            entity2.addChild(entity3_time.getElement());

                            entity3_res.addFields("NAME", "in", lcfg.label_6_out);
                            entity3_res.addFields("TEXT", "in", regTextBox6.Text);
                            entity2.addChild(entity3_res.getElement());

                            entity4_time.addFields("NAME", "in", lcfg.label_7_out);
                            entity4_time.addFields("TEXT", "in", regTextBox7.Text);
                            entity2.addChild(entity4_time.getElement());

                            entity4_res.addFields("NAME", "in", lcfg.label_8_out);
                            entity4_res.addFields("TEXT", "in", regTextBox8.Text);
                            entity2.addChild(entity4_res.getElement());
                        }

                        entity.addChild(entity2.getElement());

                        l.getBody().addEntity(entity.getElement());

                        return l.createdoc(filename);
                    }
                }
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                //MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;

        }
        public void saveXMLFile()
        {
            DateTime now = DateTime.Now;
            int iNo = 1;

            string dir_path = "c:\\IN";
            if (!Directory.Exists(dir_path))
            {
                Directory.CreateDirectory(dir_path);
            }

            string filename = String.Format("c:\\IN\\dlznyq_coldfilter_{0}-{1}.xml", now.ToString("yyyy-MM-dd"), iNo);
            while (File.Exists(filename))
            {
                iNo++;
                filename = String.Format("c:\\IN\\dlznyq_coldfilter_{0}-{1}.xml", now.ToString("yyyy-MM-dd"), iNo);
            }
            createXmlFile(filename);
        }

        private void maskedTextBoxStartAddr_Leave(object sender, EventArgs e)
        {
            //modbusRegs.startAddress = ushort.Parse(maskedTextBoxStartAddr.Text);            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButtonSerial.Checked)
            {
                if (inputCommPortSingleton.GetInstance().getCommStatus() == inputCommPortSingleton.COMMSTS_FAILURE)
                {
                    labelWarning.Text = "通信故障";
                }
                else if (inputCommPortSingleton.GetInstance().getCommStatus() == inputCommPortSingleton.COMMSTS_PORTNOTOPEN)
                {
                    labelWarning.Text = "串口打开失败";
                }
                else if (inputCommPortSingleton.GetInstance().getCommStatus() == inputCommPortSingleton.COMMSTS_NORMAL)
                {
                    labelWarning.Text = "";
                }
                else
                {
                    //labelWarning.Text = "未知错误";
                }
            }
            else if (radioButtonNetwork.Checked)
            {
                if (modbusNetworkSingleton.GetInstance().getCommStatus() == modbusNetworkSingleton.COMMSTS_FAILURE)
                {
                    if (rtycnt > 0)
                    {
                        rtycnt--;
                        buttonSaveSettings_Click(null, null);
                    }
                    else
                    {
                        labelWarning.Text = "以太网通信故障";
                    }
                }
                else if (modbusNetworkSingleton.GetInstance().getCommStatus() == modbusNetworkSingleton.COMMSTS_PORTNOTOPEN)
                {
                    labelWarning.Text = "以太网打开失败";
                }
                else if (modbusNetworkSingleton.GetInstance().getCommStatus() == modbusNetworkSingleton.COMMSTS_NORMAL)
                {
                    rtycnt = 3;
                    labelWarning.Text = "";
                }
                else
                {
                    //labelWarning.Text = "未知错误";
                }
            }
        }

        private void radioButtonSerial_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSerial.Checked)
            {
                comboBoxSerialPort.Enabled = true;
                comboBoxBaud.Enabled = true;
                comboBoxProtocol.Enabled = false;
                textBoxIPAddr.Enabled = false;
                textBoxPort.Enabled = false;
                input_method = INPUT_METHOD_SERIAL;
            }
        }

        private void radioButtonNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNetwork.Checked)
            {
                comboBoxSerialPort.Enabled = false;
                comboBoxBaud.Enabled = false;
                comboBoxProtocol.Enabled = true;
                textBoxIPAddr.Enabled = true;
                textBoxPort.Enabled = true;
                input_method = INPUT_METHOD_IP;
            }
        }

        private bool fillByteArray(ref byte[] src, ref byte[] dst, int maxcplen, int dstofs, byte maskedbyte)
        {
            for (int i = 0; i < maxcplen; i++)
            {
                Buffer.SetByte(dst, i + dstofs, maskedbyte);
            }

            if (src.Length > maxcplen)
            {
                Buffer.BlockCopy(src, 0, dst, dstofs, maxcplen);
            }
            else
            {
                Buffer.BlockCopy(src, 0, dst, dstofs, src.Length);
            }
            return true;
        }

        private byte[] getAsciiData(string[] strings)
        {
            int len = strings.Length;
            const int BLOCK_LEN = 16;
            //const int NUM_OF_BLOCK = 6;
            byte[] data = new byte[BLOCK_LEN * len];

            for (int i = 0; i < len; i++)
            {
                byte[] tmpstr = System.Text.Encoding.UTF8.GetBytes(strings[i]);
                fillByteArray(ref tmpstr, ref data, BLOCK_LEN, i * BLOCK_LEN, 0x00);
            }

            return data;
        }

        string[] getString(ModbusRegisters asciiModbusRegs, int blocklen)
        {
            int numstr = asciiModbusRegs.numRegisters * 2 / blocklen;
            string[] str = new string[numstr];
            for (int i = 0; i < numstr; i++)
            {
                byte[] tmpstr = new byte[blocklen];
                Buffer.BlockCopy(asciiModbusRegs.values, i * blocklen, tmpstr, 0, blocklen);
                str[i] = System.Text.Encoding.UTF8.GetString(tmpstr);
            }
               
            return str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] str = new string[3];
            str[0] = "仪器名称";
            str[1] = "仪器编号";
            str[2] = "实验室名称";
            byte[] b = getAsciiData(str);

            ushort startAddress = 6898;
            ushort[] data = new ushort[b.Length / sizeof(short)];
            Buffer.BlockCopy(b, 0, data, 0, data.Length * sizeof(short));

            ModbusRegisters asciiModbusRegs = new ModbusRegisters(1, startAddress, (ushort)data.Length);
            ModbusRegisters asciiModbusRegsRead = new ModbusRegisters(1, startAddress, (ushort)data.Length);
            for (int i = 0; i < asciiModbusRegs.numRegisters; i++)
            {
                asciiModbusRegs.stReg[i].value = data[i];
            }
            if (radioButtonSerial.Checked)
            {
                int ret = inputCommPortSingleton.GetInstance().writeMultiRegisters(asciiModbusRegs);
            }
            else
            {
                //modbusNetworkSingleton.GetInstance().writeMultiRegisters(modbusRegs);
                int ret = modbusNetworkSingleton.GetInstance().writeMultiRegisters(asciiModbusRegs);
            }
            
            modbusNetworkSingleton.GetInstance().readRegister(ref asciiModbusRegsRead);
            string[] stt = getString(asciiModbusRegsRead, 16);
            textBoxDevName.Text = stt[0];
            textBoxDevID.Text = stt[1];
            textBoxLabName.Text = stt[2];
        }
    }
}
