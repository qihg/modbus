using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using Modbus.Device;
using Modbus.IO;
using Modbus.Utility;
using Modbus.Data;

namespace CommCtrlSystem
{
    public struct stRegister
    {
        public ushort value;
        public Dictionary<int, string> strValue;

        public int getIntValue()
        {
            int iValue = (int)value;
            if (value >= 0x8000)
            {
                iValue = 0x10000 - iValue;
            }
            return iValue;
        }

        public int getHighReg()
        {
            return (value >> 8) & 0xff;
        }

        public int getLowReg()
        {
            return value & 0xff;
        }

        public int addStringMap(int key, string message)
        {
            if (strValue == null)
            {
                strValue = new Dictionary<int, string>();
            }
            strValue.Add(key, message);
            return 1;
        }

        public string getString()
        {
            if (strValue == null)
            {
                return null;
            }
            if (strValue.ContainsKey(value))
            {
                return strValue[value];
            }
            else
            {
                return null;
            }
        }
    };

    public class ModbusRegisters
    {
        public stRegister[] regs;

        public ushort[] regvalues;
        public byte slaveid { get; set; }
        public ushort startAddress { get; set; }
        public ushort numRegisters { get; set; }
        private IModbusSerialMaster master;

        public ModbusRegisters(IModbusSerialMaster master, byte slaveid, ushort startAddress, ushort numRegisters)
        {
            this.master = master;
            this.slaveid = slaveid;
            this.startAddress = startAddress;
            this.numRegisters = numRegisters;
            this.regs = new stRegister[numRegisters];
        }

        public int readHoldingRegister()
        {
            regvalues = master.ReadHoldingRegisters(slaveid, startAddress, numRegisters);
            return 1;
        }

        public int writeHoldingRegister()
        {
            master.WriteMultipleRegisters(slaveid, startAddress, regvalues);
            return 1;
        }
    };
}
