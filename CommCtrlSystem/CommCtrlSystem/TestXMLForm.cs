using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace CommCtrlSystem
{
    public partial class TestXMLForm : Form
    {
        public TestXMLForm()
        {
            InitializeComponent();
            loadSettings();
        }

        public void loadSettings()
        {
            try
            {
                Configure cfg = null;
                string cfgfile = System.IO.Path.Combine(Application.StartupPath, "cfg.json");
                if (File.Exists(cfgfile))
                {
                    cfg = JsonConvert.DeserializeObject<Configure>(File.ReadAllText(cfgfile));
                }

                if (cfg == null)
                {
                    return;
                }

                textUserName.Text = cfg.username;
                textPassword.Text = cfg.userpassword;
                textAnalysis.Text = cfg.analysis;
                textBoxDevName.Text = cfg.device_name;
                textBoxDevID.Text = cfg.device_id;
                textBoxLabName.Text = cfg.lab_name;
                textBoxSampleName.Text = cfg.sample_name;
                textBoxSampleID.Text = cfg.sample_id;
                textBoxOperName.Text = cfg.operator_name;
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                //MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void saveXMLFile(int roomNo)
        {
            DateTime now = DateTime.Now;
            int iNo = 1;

            string dir_path = "d:\\IN";

            Configure cfg = null;
            string cfgfile = System.IO.Path.Combine(Application.StartupPath, "cfg.json");
            if (File.Exists(cfgfile))
            {
                cfg = JsonConvert.DeserializeObject<Configure>(File.ReadAllText(cfgfile));
            }

            if (cfg != null && cfg.excel_dir != null)
            {
                dir_path = cfg.xml_dir;
            }

          
            if (!Directory.Exists(dir_path))
            {
                try
                {
                    Directory.CreateDirectory(dir_path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Create dir " + dir_path + " failure!");
                }
            }

            string filename = String.Format(dir_path + "\\dlznyq_coldfilter_{0}-{1}.xml", now.ToString("yyyy-MM-dd"), iNo);
            while (File.Exists(filename))
            {
                iNo++;
                filename = String.Format(dir_path + "\\dlznyq_coldfilter_{0}-{1}.xml", now.ToString("yyyy-MM-dd"), iNo);
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
                LimsDocEntity entity1_time = l.createEntity("RESULT", null);
                LimsDocEntity entity1_res = l.createEntity("RESULT", null);
                LimsDocEntity entity2_time = l.createEntity("RESULT", null);
                LimsDocEntity entity2_res = l.createEntity("RESULT", null);
                LimsDocEntity entity3_time = l.createEntity("RESULT", null);
                LimsDocEntity entity3_res = l.createEntity("RESULT", null);
                LimsDocEntity entity4_time = l.createEntity("RESULT", null);
                LimsDocEntity entity4_res = l.createEntity("RESULT", null);

                entity2.addFields("ANALYSIS", "in", textAnalysis.Text);

                entity.addFields("ID_NUMERIC", "in", textID.Text);


                entity1_time.addFields("NAME", "in", "初次冷浴温度1");
                entity1_time.addFields("TEXT", "in", textBox1.Text);
                entity2.addChild(entity1_time.getElement());

                entity1_res.addFields("NAME", "in", "初次观察温度1");
                entity1_res.addFields("TEXT", "in", textBox2.Text);
                entity2.addChild(entity1_res.getElement());

                entity2_time.addFields("NAME", "in", "冷浴温度1");
                entity2_time.addFields("TEXT", "in", textBox3.Text);
                entity2.addChild(entity2_time.getElement());

                entity2_res.addFields("NAME", "in", "冷滤点1");
                entity2_res.addFields("TEXT", "in", textBox4.Text);
                entity2.addChild(entity2_res.getElement());

                entity3_time.addFields("NAME", "in", "初次冷浴温度2");
                entity3_time.addFields("TEXT", "in", textBox5.Text);
                entity2.addChild(entity3_time.getElement());

                entity3_res.addFields("NAME", "in", "初次观察温度2");
                entity3_res.addFields("TEXT", "in", textBox6.Text);
                entity2.addChild(entity3_res.getElement());

                entity4_time.addFields("NAME", "in", "冷浴温度2");
                entity4_time.addFields("TEXT", "in", textBox7.Text);
                entity2.addChild(entity4_time.getElement());

                entity4_res.addFields("NAME", "in", "冷滤点2");
                entity4_res.addFields("TEXT", "in", textBox8.Text);
                entity2.addChild(entity4_res.getElement());

                entity.addChild(entity2.getElement());
                l.getBody().addEntity(entity.getElement());

                return l.createdoc(filename);
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                //MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;

        }

        private void saveSettings()
        {
            try
            {
                Configure cfg = null;
                string cfgfile = System.IO.Path.Combine(Application.StartupPath, "cfg.json");
                if (File.Exists(cfgfile))
                {
                    cfg = JsonConvert.DeserializeObject<Configure>(File.ReadAllText(cfgfile));
                }

                if (cfg == null)
                {
                    cfg = new Configure();
                }

                cfg.username = textUserName.Text;
                cfg.userpassword = textPassword.Text;
                cfg.analysis = textAnalysis.Text;

                cfg.device_name = textBoxDevName.Text;
                cfg.device_id = textBoxDevID.Text;
                cfg.lab_name = textBoxLabName.Text;
                cfg.sample_name = textBoxSampleName.Text;
                cfg.sample_id = textBoxSampleID.Text;
                cfg.operator_name = textBoxOperName.Text;

                File.WriteAllText(cfgfile, JsonConvert.SerializeObject(cfg));
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                //MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTestXML_Click(object sender, EventArgs e)
        {
            saveXMLFile(0);
            saveSettings();
            //this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void saveExcelFile(int roomNo)
        {
            DateTime now = DateTime.Now;
            int iNo = 1;
            string dir_path = "d:\\ExcelIN";

            Configure cfg = null;
            string cfgfile = System.IO.Path.Combine(Application.StartupPath, "cfg.json");
            if (File.Exists(cfgfile))
            {
                cfg = JsonConvert.DeserializeObject<Configure>(File.ReadAllText(cfgfile));
            }

            if (cfg != null && cfg.excel_dir != null)
            {
                dir_path = cfg.excel_dir;
            }

            if (!Directory.Exists(dir_path))
            {
                try
                {
                    Directory.CreateDirectory(dir_path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Create dir " + dir_path + " failure!");
                }
            }

            string filename = String.Format(dir_path + "\\dlznyq_coldfilter_{0}-{1}.xls", now.ToString("yyyy-MM-dd"), iNo);
            while (File.Exists(filename))
            {
                iNo++;
                filename = String.Format(dir_path + "\\dlznyq_coldfilter_{0}-{1}.xls", now.ToString("yyyy-MM-dd"), iNo);
            }
            createExcelFile(filename, roomNo);
        }

        private void createExcelFile(string FileName, int room)
        {
            //create  
            try
            {
                NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("Result");
                NPOI.SS.UserModel.IRow row0 = sheet.CreateRow(0);
                int i = 0;

                row0.CreateCell(i++).SetCellValue("日期:");
                row0.CreateCell(i++).SetCellValue("仪器名称:");
                row0.CreateCell(i++).SetCellValue("仪器编号:");
                row0.CreateCell(i++).SetCellValue("实验室名称:");
                row0.CreateCell(i++).SetCellValue("油样名称:");
                row0.CreateCell(i++).SetCellValue("油样号:");
                row0.CreateCell(i++).SetCellValue("实验员:");
                row0.CreateCell(i++).SetCellValue("分析方法:");
                row0.CreateCell(i++).SetCellValue("初次冷浴温度1:");
                row0.CreateCell(i++).SetCellValue("初次观察温度1:");
                row0.CreateCell(i++).SetCellValue("冷浴温度1:");
                row0.CreateCell(i++).SetCellValue("冷滤点1:");
                row0.CreateCell(i++).SetCellValue("初次冷浴温度2:");
                row0.CreateCell(i++).SetCellValue("初次观察温度2:");
                row0.CreateCell(i++).SetCellValue("冷浴温度2:");
                row0.CreateCell(i++).SetCellValue("冷滤点2:");


                NPOI.SS.UserModel.IRow row1 = sheet.CreateRow(1);
                i = 0;
                row1.CreateCell(i++).SetCellValue(DateTime.Now.ToString());
                row1.CreateCell(i++).SetCellValue(textBoxDevName.Text);
                row1.CreateCell(i++).SetCellValue(textBoxDevID.Text);
                row1.CreateCell(i++).SetCellValue(textBoxLabName.Text);
                row1.CreateCell(i++).SetCellValue(textBoxSampleName.Text);
                row1.CreateCell(i++).SetCellValue(textBoxSampleID.Text);
                row1.CreateCell(i++).SetCellValue(textBoxOperName.Text);
                row1.CreateCell(i++).SetCellValue(textAnalysis.Text);
                row1.CreateCell(i++).SetCellValue(textBox1.Text);
                row1.CreateCell(i++).SetCellValue(textBox2.Text);
                row1.CreateCell(i++).SetCellValue(textBox3.Text);
                row1.CreateCell(i++).SetCellValue(textBox4.Text);
                row1.CreateCell(i++).SetCellValue(textBox5.Text);
                row1.CreateCell(i++).SetCellValue(textBox6.Text);
                row1.CreateCell(i++).SetCellValue(textBox7.Text);
                row1.CreateCell(i++).SetCellValue(textBox8.Text);

                for (int j = 0; j < i; j++)
                {
                    sheet.AutoSizeColumn(j);
                }

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    book.Write(ms);
                    using (FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                    book = null;
                }
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                //MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            saveExcelFile(0);
        }
    }
}
