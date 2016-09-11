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

        public void CheckIsNumber(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)'-')
            {
                e.Handled = true;
                MessageBox.Show("请输入数字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
            }
        }

        public void CheckIsUInt(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.Text != "")
            {
                long input = long.Parse(control.Text);
                if (long.Parse(control.Text) > 65535)
                {
                    control.Text = "";
                    MessageBox.Show("最大值为65535，请重新输入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
