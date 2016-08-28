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

        public void setValue(ushort value)
        {
            this.value = value;
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

        public void setHighReg(byte value)
        {
            ushort hval = (ushort)value;
            ushort tmpval = (ushort)(this.value & 0x00ff);
            this.value = (ushort)(tmpval | (hval << 8));
        }

        public void setLowReg(byte value)
        {
            ushort hval = (ushort)value;
            ushort tmpval = (ushort)(this.value & 0xff00);
            this.value = (ushort)(tmpval | hval);
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

        public string getHighRegString()
        {
            if (strValue == null)
            {
                return null;
            }
             if (strValue.ContainsKey(getHighReg()))
            {
                int t = getHighReg();
                string s = strValue[getHighReg()];
                return strValue[getHighReg()];
            }
            else
            {
                return null;
            }
        }

        public string getLowRegString()
        {
            if (strValue == null)
            {
                return null;
            }
            if (strValue.ContainsKey(getLowReg()))
            {
                int t = getLowReg();
                string s = strValue[getLowReg()];
                return strValue[getLowReg()];
            }
            else
            {
                return null;
            }
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

    public class ModbusRegisters : System.IDisposable
    {
        public stRegister[] stReg;

        public ushort[] values;
        public byte slaveid { get; set; }
        public ushort startAddress { get; set; }
        public ushort numRegisters { get; set; }
            //供程序员显式调用的Dispose方法
        public void Dispose()
        {
            //调用带参数的Dispose方法，释放托管和非托管资源
            Dispose(true);
            //手动调用了Dispose释放资源，那么析构函数就是不必要的了，这里阻止GC调用析构函数
            System.GC.SuppressFinalize(this);
        }

        //protected的Dispose方法，保证不会被外部调用。
        //传入bool值disposing以确定是否释放托管资源
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                ///TODO:在这里加入清理"托管资源"的代码，应该是xxx.Dispose();
            }
            ///TODO:在这里加入清理"非托管资源"的代码
        }

        //供GC调用的析构函数
        ~ModbusRegisters()
        {
            Dispose(false);//释放非托管资源
        }

        public ModbusRegisters(byte slaveid, ushort startAddress, ushort numRegisters)
        {
            this.slaveid = slaveid;
            this.startAddress = startAddress;
            this.numRegisters = numRegisters;
            this.stReg = new stRegister[numRegisters];
            this.values = new ushort[numRegisters];
        }
    };
}
