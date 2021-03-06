﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modbus.Device;
using Modbus.IO;
using Modbus.Utility;
using Modbus.Data;
using System.IO.Ports;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CommCtrlSystem
{
    public class inputCommPortSingleton
    {
        private static inputCommPortSingleton inputCommPort;
        private static readonly object locker = new object();
        SerialPort port;
        string InputModbusType;
        IModbusSerialMaster master;
        private static int rtycnt = 0;

        private const int MAX_RETYR_COUNT = 3;
        public const int RET_OK = 0;
        public const int RET_TIMEOUT = -1;
        public const int RET_COMMERROR = -2;
        public const int RET_FAILURE = -3;
        public const int RET_INITFAILURE = -4;

        public const int COMMSTS_UNKONOWN = 0;
        public const int COMMSTS_NORMAL = 1;
        public const int COMMSTS_FAILURE = 2;
        public const int COMMSTS_PORTNOTOPEN = 3;
        private int commsts = COMMSTS_UNKONOWN;
        private inputCommPortSingleton()
        {
        }

        public static inputCommPortSingleton GetInstance()
        {
            if (inputCommPort == null)
            {
                lock (locker)
                {
                    if (inputCommPort == null)
                    {
                        inputCommPort = new inputCommPortSingleton();
                    }
                }
            }
            return inputCommPort;
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

        public int getCommStatus()
        {
            return commsts;
        }

        public bool checkSerialPort(string portname)
        {
            string[] portList = System.IO.Ports.SerialPort.GetPortNames();

            for (int i = 0; i < portList.Length; ++i)
            {
                string name = portList[i];
                if (name.ToLower() == portname.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        public bool initComm()
        {
            lock (locker)
            {
                if (port == null)
                {
                    Configure cfg = null;
                    
                    //MessageBox.Show(Environment.CurrentDirectory, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show(Directory.GetCurrentDirectory(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string cfgfile = System.IO.Path.Combine(Application.StartupPath, "cfg.json");
                    if (File.Exists(cfgfile))
                    {
                        cfg = JsonConvert.DeserializeObject<Configure>(File.ReadAllText(cfgfile));

                        if (!checkSerialPort(cfg.InputSerialPortName))
                        {
                            return false;
                        }

                        port = new SerialPort(cfg.InputSerialPortName);

                        port.BaudRate = (int)GetNumber(cfg.InputSerialPortBaud);
                        port.DataBits = (int)GetNumber(cfg.InputSerialPortDataBit);
                        if (cfg.InputSerialPortParity == "None Parity")
                        {
                            port.Parity = Parity.None;
                        }
                        else if (cfg.InputSerialPortParity == "Odd Parity")
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

                        port.ReadTimeout = 500;
                        port.WriteTimeout = 500;

                        InputModbusType = cfg.InputModbusType;
                    }
                    else
                    {
                        MessageBox.Show("Cannot find cfg.json!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        public bool openComm()
        {
            LogClass.GetInstance().WriteLogFile("OpenComm Called " + port.PortName);
            lock (locker)
            {
                if (port != null && !port.IsOpen)
                {
                    try
                    {
                        port.Open();
                        LogClass.GetInstance().WriteLogFile("port opened");
                        // create modbus master
                        if (InputModbusType == "RTU")
                        {
                            master = ModbusSerialMaster.CreateRtu(port);
                        }
                        else
                        {
                            master = ModbusSerialMaster.CreateAscii(port);
                        }

                        return true;
                    }
                    catch (Exception ex)
                    {
                        LogClass.GetInstance().WriteExceptionLog(ex);
                        //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        public void closeComm()
        {
            LogClass.GetInstance().WriteLogFile("closeComm Called");
            lock (locker)
            {
                if (port != null && port.IsOpen)
                {
                    port.Close();
                    LogClass.GetInstance().WriteLogFile("port Close");
                }
            }
        }

        public int readRegister(ref ModbusRegisters regs)
        {
            if (master == null)
            {
                commsts = COMMSTS_UNKONOWN;
                return RET_INITFAILURE;
            }

            lock (locker)
            {
                if (port.IsOpen == false)
                {
                    commsts = COMMSTS_PORTNOTOPEN;
                    return RET_INITFAILURE;
                }

                try
                {
                    regs.values = master.ReadHoldingRegisters(regs.slaveid, regs.startAddress, regs.numRegisters);
                    for (int i = 0; i < regs.numRegisters; i++)
                    {
                        regs.stReg[i].value = regs.values[i];
                    }
                }
                catch (TimeoutException ex)
                {
                    LogClass.GetInstance().WriteLogFile("ReadHoldingRegisters Timeout:" + port.ReadTimeout.ToString());
                    //MessageBox.Show("Serial Port Read Timeout:" + port.ReadTimeout.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (rtycnt++ < MAX_RETYR_COUNT)
                    {
                        return RET_TIMEOUT;
                    } else {
                        commsts = COMMSTS_FAILURE;
                        return RET_COMMERROR;
                    }
                }
                catch (Exception ex)
                {
                    LogClass.GetInstance().WriteExceptionLog(ex);
                    //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    commsts = COMMSTS_FAILURE;
                    return RET_FAILURE;
                }
            }
            rtycnt = 0;
            commsts = COMMSTS_NORMAL;
            return RET_OK;
        }

        public int writeMultiRegisters(ModbusRegisters regs)
        {
            if (master == null)
            {
                commsts = COMMSTS_UNKONOWN;
                return RET_INITFAILURE;
            }

            if (port.IsOpen == false)
            {
                commsts = COMMSTS_PORTNOTOPEN;
                return RET_INITFAILURE;
            }

            lock (locker)
            {
                try
                {
                    for (int i = 0; i < regs.numRegisters; i++)
                    {
                        regs.values[i] = regs.stReg[i].value;
                    }

                    master.WriteMultipleRegisters(regs.slaveid, regs.startAddress, regs.values);
                }
                catch (TimeoutException ex)
                {
                    LogClass.GetInstance().WriteLogFile("WriteMultipleRegisters Timeout:" + port.WriteTimeout.ToString());
                    //MessageBox.Show("Serial Port Write Timeout:" + port.WriteTimeout.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (rtycnt++ < MAX_RETYR_COUNT)
                    {
                        return RET_TIMEOUT;
                    }
                    else
                    {
                        commsts = COMMSTS_FAILURE;
                        return RET_COMMERROR;
                    }
                }
                catch (Exception ex)
                {
                    LogClass.GetInstance().WriteExceptionLog(ex);
                    //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    commsts = COMMSTS_FAILURE;
                    return RET_FAILURE;
                }
            }
            rtycnt = 0;
            commsts = COMMSTS_NORMAL;
            return RET_OK;
        }

        public int writeSingleRegister(ModbusRegisters regs, ushort value)
        {
            try
            {

                if (master == null)
                {
                    commsts = COMMSTS_UNKONOWN;
                    return RET_INITFAILURE;
                }

                if (port.IsOpen == false)
                {
                    commsts = COMMSTS_PORTNOTOPEN;
                    return RET_INITFAILURE;
                }

                lock (locker)
                {
                    master.WriteSingleRegister(regs.slaveid, regs.startAddress, value);
                }
            }
            catch (TimeoutException ex)
            {
                LogClass.GetInstance().WriteLogFile("writeSingleRegister Timeout:" + port.WriteTimeout.ToString());
                //MessageBox.Show("Serial Port Write Timeout:" + port.WriteTimeout.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (rtycnt++ < MAX_RETYR_COUNT)
                {
                    return RET_TIMEOUT;
                }
                else
                {
                    commsts = COMMSTS_FAILURE;
                    return RET_COMMERROR;
                }
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                commsts = COMMSTS_FAILURE;
                return RET_FAILURE;
            }

            rtycnt = 0;
            commsts = COMMSTS_NORMAL;
            return RET_OK;
        }

    }
}

