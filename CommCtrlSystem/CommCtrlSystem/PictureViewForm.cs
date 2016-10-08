using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace CommCtrlSystem
{
    public partial class PictureViewForm : Form
    {
        public PictureViewForm()
        {
            InitializeComponent();
        }

        public void setPictureData(byte[] imgdata)
        {
            pictureBox1.Image = Image.FromStream(new MemoryStream(imgdata));
        }

        private void PictureViewForm_Load(object sender, EventArgs e)
        {
        }
    }
}
