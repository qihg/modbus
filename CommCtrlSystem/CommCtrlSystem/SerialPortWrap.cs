using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace CommCtrlSystem
{
    static class SerialPortWrap
    {
        static Object thisLock = new Object();
        static public string[] getAllSerialPort()
        {
            return SerialPort.GetPortNames();
        }

        static public List<string> getUnUsedSerialPort()
        {
            SerialPort _tempPort;
            String[] Portname = SerialPort.GetPortNames();
            List<string> unusedPort = new List<string>();
            //create a loop for each string in SerialPort.GetPortNames
            foreach (string str in Portname)
            {
                try
                {
                    _tempPort = new SerialPort(str);
                    _tempPort.Open();

                    //if the port exist and we can open it
                    if (_tempPort.IsOpen)
                    {
                        unusedPort.Add(str);
                        _tempPort.Close();
                    }
                }
                catch (Exception ex)
                {
                    LogClass.GetInstance().WriteExceptionLog(ex);
                    //MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //return the temp bool 
            return unusedPort;
        }
    }
}
