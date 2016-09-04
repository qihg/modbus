using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Printing;
using Modbus.Device;
using Modbus.IO;
using Modbus.Utility;
using Modbus.Data;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;

namespace CommCtrlSystem
{
    public partial class WindowMain : UserControl
    {
        public Thread updateDataThread;
        public bool m_updateDataFlg = false;
        ModbusRegisters modbusRegs;
        public delegate void UpdateMainUIInvoke(ModbusRegisters modbusRegs);
        private static readonly object locker = new object();

        private const byte SLAVEID = 1;
        private const ushort STARTADDRESS = 0;
        private const ushort REGNUM = 19;

        // Register define
        private const int TEMP_OIL0 = 0;
        private const int TEMP_OIL1 = 1;
        private const int TEMP_BATH0 = 2;
        private const int TEMP_BATH1 = 3;
        private const int COLDFILTERPOINT0 = 4;
        private const int COLDFILTERPOINT1 = 5;
        private const int PID_RESULT0 = 6;
        private const int PID_RESULT1 = 7;

        private const int STATE_WORK = 8;
        private const int RUNTIME_M = 9;
        private const int RUNTIME_S = 10;
        private const int TIME_SUCK = 11;
        private const int TIME_DROP = 12;
        private const int ALARM = 13;
        private const int STATE_SUCKTUBE = 14;
        private const int CHECKFINISH = 15;
        private const int UP_FLAG = 16;
        private const int DOWN_FLAG = 17;
        private const int ALLSTATE = 18;

        private TextBox[] tbmain;

        WindowRealtimeData wrd1;
        WindowRealtimeData wrd2;
        
        public WindowMain()
        {
            InitializeComponent();
            InitializeRegs();
            AccessHelper.initAccessHelper("CCSData.accdb");
            getConfig();

            wrd1 = new WindowRealtimeData();
            wrd2 = new WindowRealtimeData();


            WindowManager.GetInstance().wrd1 = wrd1;
            WindowManager.GetInstance().wrd2 = wrd2;

        }

        void InitializeRegs()
        {
            modbusRegs = new ModbusRegisters(SLAVEID, STARTADDRESS, REGNUM);
            modbusRegs.stReg[CHECKFINISH].addStringMap(0, "");
            modbusRegs.stReg[CHECKFINISH].addStringMap(1, "冷滤点完成");
            modbusRegs.stReg[CHECKFINISH].addStringMap(2, "<51℃，未阻塞");
            modbusRegs.stReg[CHECKFINISH].addStringMap(3, "首次吸引超过60秒，放弃");
            modbusRegs.stReg[CHECKFINISH].addStringMap(4, "用户温度下限未阻塞");

            modbusRegs.stReg[STATE_WORK].addStringMap(0, "停止");
            modbusRegs.stReg[STATE_WORK].addStringMap(1, "加热");
            modbusRegs.stReg[STATE_WORK].addStringMap(2, "制冷");
            modbusRegs.stReg[STATE_WORK].addStringMap(3, "完成");
            modbusRegs.stReg[STATE_WORK].addStringMap(4, "故障");

            modbusRegs.stReg[ALARM].addStringMap(0, "无故障");
            modbusRegs.stReg[ALARM].addStringMap(1, "加热器故障");
            modbusRegs.stReg[ALARM].addStringMap(2, "制冷故障");
            modbusRegs.stReg[ALARM].addStringMap(3, "光电检测故障");
            modbusRegs.stReg[ALARM].addStringMap(4, "电磁阀故障");
            modbusRegs.stReg[ALARM].addStringMap(5, "超温故障");
            modbusRegs.stReg[ALARM].addStringMap(6, "制冷超时故障");
            modbusRegs.stReg[ALARM].addStringMap(7, "加热超时故障");
            modbusRegs.stReg[ALARM].addStringMap(8, "温度传感器故障");

            modbusRegs.stReg[STATE_SUCKTUBE].addStringMap(0, "无动作");
            modbusRegs.stReg[STATE_SUCKTUBE].addStringMap(1, "吸引");
            modbusRegs.stReg[STATE_SUCKTUBE].addStringMap(2, "释放");

            modbusRegs.stReg[UP_FLAG].addStringMap(0, "OFF");
            modbusRegs.stReg[UP_FLAG].addStringMap(1, "ON");

            modbusRegs.stReg[DOWN_FLAG].addStringMap(0, "OFF");
            modbusRegs.stReg[DOWN_FLAG].addStringMap(1, "ON");

            modbusRegs.stReg[ALLSTATE].addStringMap(0, "停止");
            modbusRegs.stReg[ALLSTATE].addStringMap(1, "启动");
        }

        private void WindowMain_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PaperSize p = null;
            foreach (PaperSize ps in printDocument1.PrinterSettings.PaperSizes)
            {
                if (ps.PaperName.Equals("A4"))
                    p = ps;
            }

            this.printDocument1.DefaultPageSettings.PaperSize = p;
            this.printDocument1.PrintPage += new PrintPageEventHandler(this.MyPrintDocument_PrintPage);

            printPreviewDialog1.Document = printDocument1;
            DialogResult result = printPreviewDialog1.ShowDialog();
            if (result == DialogResult.OK)
                this.printDocument1.Print();
        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            /*如果需要改变自己 可以在new Font(new FontFamily("黑体"),11）中的“黑体”改成自己要的字体就行了，黑体 后面的数字代表字体的大小
             System.Drawing.Brushes.Blue , 170, 10 中的 System.Drawing.Brushes.Blue 为颜色，后面的为输出的位置 */
            e.Graphics.DrawString("滤点分析仪结果报告", new Font(new FontFamily("黑体"), 11), System.Drawing.Brushes.Black, 170, 10);

            e.Graphics.DrawLine(Pens.Black, 8, 30, 480, 30);
            e.Graphics.DrawString("日期", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 9, 35);
            e.Graphics.DrawString("测定结果", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 160, 35);
            e.Graphics.DrawString("试样编号", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 260, 35);
            e.Graphics.DrawString("操作员", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 330, 35);
            e.Graphics.DrawString("运行时间", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 400, 35);
            e.Graphics.DrawLine(Pens.Black, 8, 50, 480, 50);
            //产品信息
            e.Graphics.DrawString(DateTime.Now.ToString(), new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 9, 55);
            e.Graphics.DrawString(textBoxRes1.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 160, 55);
            e.Graphics.DrawString(textBoxNo1.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 260, 55);
            e.Graphics.DrawString(textBoxOp1.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 330, 55);
            e.Graphics.DrawString(textBoxTime1.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 400, 55);

            e.Graphics.DrawString(DateTime.Now.ToString(), new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 9, 75);
            e.Graphics.DrawString(textBoxRes2.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 160, 75);
            e.Graphics.DrawString(textBoxNo2.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 260, 75);
            e.Graphics.DrawString(textBoxOp2.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 330, 75);
            e.Graphics.DrawString(textBoxTime2.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 400, 75);

            e.Graphics.DrawLine(Pens.Black, 8, 200, 480, 200);
        }
        private void btnSysCfg_Click(object sender, EventArgs e)
        {
            FormSysCfg fsc = new FormSysCfg();
            fsc.ShowDialog();
            getConfig();
        }

        private void getConfig()
        {
            try
            {
                Configure cfg = null;
                if (File.Exists(@"cfg.json"))
                {
                    cfg = JsonConvert.DeserializeObject<Configure>(File.ReadAllText(@"cfg.json"));
                    if (cfg != null)
                    {
                        textBoxCom1.Text = cfg.InputSerialPortName;
                        textBoxCom2.Text = cfg.OutputSerialPortName;
                        textBoxServerIP.Text = cfg.ServerIp;
                        textBoxServerPort.Text = cfg.ServerPort.ToString();
                        if (cfg.bGetDataOnload)
                        {
                            startUpdateRegs();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void DoUpdateRegs()
        {
            Thread.Sleep(1000);
            inputCommPortSingleton.GetInstance().initComm();
            inputCommPortSingleton.GetInstance().openComm();
            Random random = new Random();
            while (m_updateDataFlg)
            {
                try
                {
                    inputCommPortSingleton.GetInstance().readRegister(ref modbusRegs);
                    UpdateMainUIInvoke umi = new UpdateMainUIInvoke(UpdateUIData);
                    BeginInvoke(umi, modbusRegs);
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString(), "Error - No Ports available", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

            }
            inputCommPortSingleton.GetInstance().closeComm();
        }

        public void UpdateUIData(ModbusRegisters reg)
        {
            textBoxRes1.Text = reg.stReg[CHECKFINISH].getHighRegString();
            textBoxRes2.Text = reg.stReg[CHECKFINISH].getLowRegString();

            textBox2.Text = reg.stReg[TEMP_OIL0].getShortValue().ToString();
            textBox9.Text = reg.stReg[TEMP_OIL1].getShortValue().ToString();

            textBox3.Text = reg.stReg[TEMP_BATH0].getShortValue().ToString();
            textBox10.Text = reg.stReg[TEMP_BATH1].getShortValue().ToString();

            textBox3.Text = reg.stReg[TEMP_BATH0].getShortValue().ToString();
            textBox10.Text = reg.stReg[TEMP_BATH1].getShortValue().ToString();

            textBox4.Text = reg.stReg[ALLSTATE].getHighRegString();
            textBox11.Text = reg.stReg[ALLSTATE].getLowRegString();

            int run_time_h0 = reg.stReg[RUNTIME_M].getHighReg() / 60;
            int run_time_h1 = reg.stReg[RUNTIME_M].getLowReg() / 60;
            int run_time_m0 = reg.stReg[RUNTIME_M].getHighReg() % 60;
            int run_time_m1 = reg.stReg[RUNTIME_M].getLowReg() % 60;
            int run_time_s0 = reg.stReg[RUNTIME_S].getHighReg();
            int run_time_s1 = reg.stReg[RUNTIME_S].getLowReg();
            textBoxTime1.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", run_time_h0, run_time_m0, run_time_s0);
            textBoxTime2.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", run_time_h1, run_time_m1, run_time_s1);

            WindowManager.GetInstance().wrd1.updateData(0, reg);
            WindowManager.GetInstance().wrd2.updateData(1, reg);

            //Random random = new Random();
            //WindowManager.GetInstance().wrd1.addPoint0(random.Next(0, 10), random.Next(30, 50));
            //WindowManager.GetInstance().wrd2.addPoint0(random.Next(90, 100), random.Next(10, 40));

            if (reg.stReg[CHECKFINISH].getHighReg() != 0 && reg.stReg[CHECKFINISH].getLowReg() != 0)
            {
                byte[] imageLeft = WindowManager.GetInstance().wrd1.getImageData();
                byte[] imageRight = WindowManager.GetInstance().wrd2.getImageData();

                //Left room
                string sql1 = "insert into ModbusResultTable(room, TestDate, TestTime, TestResult, TestNo, Operator, [TestImage]) values('left','" + DateTime.Now + "', '"+ textBoxTime1.Text + "', '" + textBoxRes1.Text + "', '" + textBoxNo1.Text + "', '" + textBoxOp1.Text + "', @imageLeft)";

                OleDbParameter[] pars = new OleDbParameter[1];

                OleDbParameter p = new OleDbParameter("@imageLeft", OleDbType.VarBinary, imageLeft.Length);
                p.Value = imageLeft;

                pars[0] = p;
                int i = AccessHelper.ExecuteNonQuery(AccessHelper.ConnString, sql1, pars);

                //Right room
                string sql2 = "insert into ModbusResultTable(room, TestDate, TestTime, TestResult, TestNo, Operator, [TestImage]) values('right','" + DateTime.Now + "', '" + textBoxTime2.Text + "','" + textBoxRes2.Text + "', '" + textBoxNo2.Text + "', '" + textBoxOp2.Text + "', @imageRight)";
                OleDbParameter[] pars2 = new OleDbParameter[1];

                OleDbParameter p2 = new OleDbParameter("@imageRight", OleDbType.VarBinary, imageRight.Length);
                p2.Value = imageRight;

                pars2[0] = p2;
                i = AccessHelper.ExecuteNonQuery(AccessHelper.ConnString, sql2, pars2);
                stopUpdateRegs();
            }
        }

        public void startUpdateRegs()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            lock (locker)
            {
                if (!m_updateDataFlg)
                {
                    m_updateDataFlg = true;
                    updateDataThread = new Thread(new ThreadStart(DoUpdateRegs));
                    updateDataThread.Start();
                }
            }
        }

        public void stopUpdateRegs()
        {
            lock (locker)
            {
                if (m_updateDataFlg)
                {
                    m_updateDataFlg = false;
                    updateDataThread.Join();
                }
            }
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //mRealtimeFlg = 1;
            startUpdateRegs();
            //btnStart.Enabled = false;
            //btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopUpdateRegs();
            //btnStart.Enabled = true;
        }

        private bool checkAuth()
        {
            if (!WindowManager.GetInstance().checkAuth())
            {
                AuthForm authForm = new AuthForm();
                if (authForm.ShowDialog(this) == DialogResult.No)
                {
                    return false;
                }
                else
                {
                    if (!WindowManager.GetInstance().checkAuth())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnBaseSetting_Click(object sender, EventArgs e)
        {
            if (!checkAuth())
            {
                return;
            }

            GroupBox tgb =  WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wbs);
        }

        private void btnHistReport_Click(object sender, EventArgs e)
        {
            //if (!checkAuth())
            //{
            //    return;
            //}
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            WindowManager.GetInstance().whr.RefreshData();
            tgb.Controls.Add(WindowManager.GetInstance().whr);
        }

        private void btnTempCorret_Click(object sender, EventArgs e)
        {
            if (!checkAuth())
            {
                return;
            }
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wtc);
        }

        private void btnPIDSetting_Click(object sender, EventArgs e)
        {
            if (!checkAuth())
            {
                return;
            }
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wps);
        }

        private void btnManualTest_Click(object sender, EventArgs e)
        {
            if (!checkAuth())
            {
                return;
            }
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wms);
        }

        private void btnRTData1_Click(object sender, EventArgs e)
        {
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wrd1);
        }

        private void btnRTData2_Click(object sender, EventArgs e)
        {
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wrd2);
        }

        /// <summary>  
        /// If the supplied excel File does not exist then Create it  
        /// </summary>  
        /// <param name="FileName"></param>  
        private void CreateExcelFile(string FileName)
        {
            //create  
            try
            {
                object Nothing = System.Reflection.Missing.Value;
                var app = new Excel.Application();
                app.Visible = false;
                Excel.Workbook workBook = app.Workbooks.Add(Nothing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Sheets[1];
                worksheet.Name = "Work";

                const int l_date = 1;
                const int l_no = 4;
                const int l_res = 2;
                const int l_runtime = 3;
                const int l_oper = 5;

                worksheet.Cells[1, l_no] = "试样编号";
                worksheet.Cells[1, l_date] = "日期时间";
                worksheet.Cells[1, l_res] = "测定结果";
                //worksheet.Cells[1, 4] = "试样名称";
                worksheet.Cells[1, l_runtime] = "运行时间";
                worksheet.Cells[1, l_oper] = "操作员";



                worksheet.Cells[2, l_no] = textBoxNo1.Text;
                worksheet.Cells[2, l_date] = DateTime.Now.ToString();
                worksheet.Cells[2, l_res] = textBoxRes1.Text;
                worksheet.Cells[2, l_runtime] = textBoxTime1.Text;
                worksheet.Cells[2, l_oper] = textBoxOp1.Text;

                worksheet.Cells[3, l_no] = textBoxNo2.Text;
                worksheet.Cells[3, l_date] = DateTime.Now.ToString();
                worksheet.Cells[3, l_res] = textBoxRes2.Text;
                worksheet.Cells[3, l_runtime] = textBoxTime2.Text;
                worksheet.Cells[3, l_oper] = textBoxOp2.Text;

                worksheet.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
                workBook.Close(false, Type.Missing, Type.Missing);
                app.Quit();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>  
        /// open an excel file,then write the content to file  
        /// </summary>  
        /// <param name="FileName">file name</param>  
        /// <param name="findString">first cloumn</param>  
        /// <param name="replaceString">second cloumn</param>  
        private void WriteToExcel(string excelName, string filename, string findString, string replaceString)
        {
            //open  
            object Nothing = System.Reflection.Missing.Value;
            var app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook mybook = app.Workbooks.Open(excelName, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);
            Excel.Worksheet mysheet = (Excel.Worksheet)mybook.Worksheets[1];
            mysheet.Activate();
            //get activate sheet max row count  
            int maxrow = mysheet.UsedRange.Rows.Count + 1;
            mysheet.Cells[maxrow, 1] = filename;
            mysheet.Cells[maxrow, 2] = findString;
            mysheet.Cells[maxrow, 3] = replaceString;
            mybook.Save();
            mybook.Close(false, Type.Missing, Type.Missing);
            mybook = null;
            //quit excel app  
            app.Quit();
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {

            //string localFilePath, fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "Excel文件（*.xls）|*.xls|Excel文件（*.xlsx）|*.xlsx";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                //获取文件路径，不带文件名 
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 

                //给文件名前加上时间 
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt; 

                //在文件名里加字符 
                //saveFileDialog1.FileName.Insert(1,"dameng"); 

                //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件 

                ////fs输出带文字或图片的文件，就看需求了 
                CreateExcelFile(localFilePath);
            }
        }

    }
}
