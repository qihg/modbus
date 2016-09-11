using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommCtrlSystem
{
    public class Configure
    {
        public string InputSerialPortName { get; set; }
        public string InputSerialPortBaud { get; set; }
        public string InputSerialPortDataBit { get; set; }
        public string InputSerialPortParity { get; set; }
        public string InputSerialPortStopBit { get; set; }

        public string InputModbusType { get; set; }

        public string OutoutMethod { get; set; }

        public string OutputSerialPortName { get; set; }
        public string OutputSerialPortBaud { get; set; }
        public string OutputSerialPortDataBit { get; set; }
        public string OutputSerialPortParity { get; set; }
        public string OutputSerialPortStopBit { get; set; }
        public string OutputModbusType { get; set; }

        public bool bGetDataOnload { get; set; }

        public string ServerIp { get; set; }
        public string ServerPort { get; set; }

        public string username { get; set; }
        public string userpassword { get; set; }
        public string analysis { get; set; }
    }
}
