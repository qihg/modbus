using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modbus.Device;
using Modbus.IO;
using Modbus.Utility;
using Modbus.Data;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace PLCModbusSystem
{
    class modbusNetworkSingleton
    {   
        const int PROTOCOL_TCPIP = 0;
        const int PROTOCOL_UDPIP = 1;
        const int PROTOCOL_RTU_TCPIP = 2;
        const int PROTOCOL_RTU_UDPIP = 3;

        private static modbusNetworkSingleton modbusPoll;
        private static readonly object locker = new object();
        TcpClient tcpClient;
        UdpClient udpClient;
        string ipaddr;
        int protocol;
        int port;

        ModbusMaster master;

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
        private modbusNetworkSingleton()
        {
        }

        public static modbusNetworkSingleton GetInstance()
        {
            if (modbusPoll == null)
            {
                lock (locker)
                {
                    if (modbusPoll == null)
                    {
                        modbusPoll = new modbusNetworkSingleton();
                    }
                }
            }
            return modbusPoll;
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

        public bool initModbusPoll(string ip, int port, string protocol)
        {
            lock (locker)
            {
                if (tcpClient != null)
                {
                    return false;
                }
                if (protocol == "TCP/IP")
                {
                    tcpClient = new TcpClient(ip, port);
                    master = ModbusIpMaster.CreateIp(tcpClient);
                    master.Transport.Retries = 5;
                    tcpClient.SendTimeout = 1000;
                    tcpClient.ReceiveTimeout = 1000;
                    this.protocol = PROTOCOL_TCPIP;
                }
                //else if (protocol == "UDP/IP")
                //{
                //    udpClient = new UdpClient(ip, port);
                //    this.protocol = PROTOCOL_UDPIP;
                //}
                else if (protocol == "RTU Over TCP/IP")
                {
                    tcpClient = new TcpClient(ip, port);
                    this.protocol =PROTOCOL_RTU_TCPIP;
                    master = ModbusSerialMaster.CreateRtu(tcpClient);
                    master.Transport.Retries = 5;
                    tcpClient.SendTimeout = 1000;
                    tcpClient.ReceiveTimeout = 1000;
                }
                //else if (protocol == "RTU Over UDP/IP")
                //{
                //    udpClient = new UdpClient(ip, port);
                //    this.protocol = PROTOCOL_RTU_UDPIP;
                //}
                //else
                //{
                //    this.protocol = -1;
                //}   

            }

            return true;
        }

        public bool openComm()
        {
            //LogClass.GetInstance().WriteLogFile("OpenComm Called " + port.PortName);
            lock (locker)
            {

            }

            return true;
        }

        public void closeComm()
        {
            //LogClass.GetInstance().WriteLogFile("closeComm Called");
            lock (locker)
            {
                if (master != null)
                {
                    master.Dispose();
                    master = null;
                }

                if (tcpClient != null)
                {
                    tcpClient.Close();
                    tcpClient = null;
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
                if (tcpClient == null)
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
                    //LogClass.GetInstance().WriteLogFile("ReadHoldingRegisters Timeout:" + port.ReadTimeout.ToString());
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

            if (tcpClient == null)
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
                    //LogClass.GetInstance().WriteLogFile("WriteMultipleRegisters Timeout:" + port.WriteTimeout.ToString());
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

                if (tcpClient == null)
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
                //LogClass.GetInstance().WriteLogFile("writeSingleRegister Timeout:" + port.WriteTimeout.ToString());
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
