using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CommCtrlSystem
{
    public partial class TestXMLForm : Form
    {
        public TestXMLForm()
        {
            InitializeComponent();
        }

        public void saveXMLFile(int roomNo)
        {
            DateTime now = DateTime.Now;
            int iNo = 1;

            string dir_path = "c:\\IN";
            if (!Directory.Exists(dir_path))
            {
                Directory.CreateDirectory(dir_path);
            }

            string filename = String.Format("c:\\IN\\dlznyq_coldfilter_{0}-{1}.xml", now.ToString("yyyy-MM-dd"), iNo);
            while (File.Exists(filename))
            {
                iNo++;
                filename = String.Format("c:\\IN\\dlznyq_coldfilter_{0}-{1}.xml", now.ToString("yyyy-MM-dd"), iNo);
            }
            createXmlFile(filename, roomNo);
        }

        public bool createXmlFile(string filename, int roomNo)
        {
            try
            {
                LimsDoc l;
                l = new LimsDoc(textUserName.Text, textPassword.Text, "system");

                LimsDocEntity entity = l.createEntity("SAMPLE", "RESULT_ENTRY");
                LimsDocEntity entity2 = l.createEntity("TEST", null);
                LimsDocEntity entity3 = l.createEntity("RESULT", null);

                entity2.addFields("ANALYSIS", "in", textAnalysis.Text);
                entity.addFields("ID_NUMERIC", "in", textID.Text);
                entity3.addFields("NAME", "in", "结果");
                entity3.addFields("TEXT", "in", textResult.Text);
                entity2.addChild(entity3.getElement());
                entity.addChild(entity2.getElement());

                l.getBody().addEntity(entity.getElement());

                return l.createdoc(filename);
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;

        }
        private void btnTestXML_Click(object sender, EventArgs e)
        {
            saveXMLFile(0);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
