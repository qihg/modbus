using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLCModbusSystem
{
    public class Configure
    {
        public string InputSerialPortName { get; set; }
        public string InputSerialPortBaud { get; set; }
        public string InputSerialPortDataBit { get; set; }
        public string InputSerialPortParity { get; set; }
        public string InputSerialPortStopBit { get; set; }

        public ushort startAddr { get; set; }
        public string floatFormat { get; set; }

        public bool bOutputLims { get; set; }
        public bool bOutputExcel { get; set; }

        public string dev_name { get; set; }
        public string dev_id { get; set; }
        public string lab_name { get; set; }
        public string oil_name { get; set; }
        public string oil_id { get; set; }
        public string username { get; set; }
        public string userpassword { get; set; }
        public string analysis { get; set; }

        public bool bSerial_sel { get; set; }
        public bool bNetwork_sel { get; set; }
        public string protocol { get; set; }
        public string ipaddr { get; set; }
        public string port { get; set; }
    }
}
