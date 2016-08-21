using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace CommCtrlSystem
{
    public struct stRegister
    {
        public ushort value;
        public Dictionary<int, string> strValue;

        public int getShortValue()
        {
            int iValue = (int)value;
            if (value >= 0x8000)
            {
                iValue = 0x10000 - iValue;
            }
            return iValue;
        }

        public int getUShortValue()
        {
            return value;
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
        public stRegister[] stReg;

        public ushort[] values;
        public byte slaveid { get; set; }
        public ushort startAddress { get; set; }
        public ushort numRegisters { get; set; }

        public ModbusRegisters(byte slaveid, ushort startAddress, ushort numRegisters)
        {
            this.slaveid = slaveid;
            this.startAddress = startAddress;
            this.numRegisters = numRegisters;
            this.stReg = new stRegister[numRegisters];
        }
    };
}
