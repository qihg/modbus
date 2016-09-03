using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace CommCtrlSystem
{
    class CheckUserInput
    {
        public void TextCheck(object sender, EventArgs e)
        {
            Control control = sender as Control;

            if (int.Parse(control.Text) > 100)
            {
                control.Text = "0";
            }
        }
    }
}
