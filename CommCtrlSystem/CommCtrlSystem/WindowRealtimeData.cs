using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommCtrlSystem
{
    public partial class WindowRealtimeData : UserControl
    {
        public WindowRealtimeData()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wmain);
        }
    }
}
