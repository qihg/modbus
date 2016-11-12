﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PLCModbusSystem
{
    class IPAddrTextBox : TextBox
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassName = "SysIPAddress32";
                return cp;
            }
        }
    }
}
