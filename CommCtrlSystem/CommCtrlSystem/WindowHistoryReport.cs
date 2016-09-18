using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;

namespace CommCtrlSystem
{
    public partial class WindowHistoryReport : UserControl
    {
        DateTime start_datetime;
        DateTime end_datetime;
        bool bSelectDateFlg = false;
        bool bDataLoaded = false;
        List<int> dellist_left, dellist_right;

        string resToPrint;
        string noToPrint;
        string operatorToPrint;
        string timeToPrint;

        private int rowIndex = 0;
        public WindowHistoryReport()
        {
            InitializeComponent();
            dellist_left = new List<int>();
            dellist_right = new List<int>();
        }

        private void buttonMain_Click(object sender, EventArgs e)
        {
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wmain);
        }

        private void WindowHistoryReport_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            DataSet ds = new DataSet();
            //dt = accdb.SelectToDataTable("select * from MyTable");

            if (bSelectDateFlg)
            {
                string sql = "select ID, TestTime, TestResult, TestNo, Operator from ModbusResultTable where [room] = 'left' and [TestDate] between @start_datetime and @end_datetime";
                OleDbParameter[] pars = new OleDbParameter[2];

                OleDbParameter ps = new OleDbParameter("@start_datetime", OleDbType.Date);
                ps.Value = start_datetime;
                pars[0] = ps;

                OleDbParameter pe = new OleDbParameter("@end_datetime", OleDbType.Date);
                pe.Value = end_datetime;

                pars[1] = pe;
                ds = AccessHelper.ExecuteDataSet(AccessHelper.ConnString, sql, pars);
            }
            else
            {
                ds = AccessHelper.ExecuteDataSet(AccessHelper.ConnString, "select ID, TestTime, TestResult, TestNo, Operator from ModbusResultTable where [room] = 'left'", null);
            }

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            dataGridView1.AllowUserToAddRows = false;//datagridview
            //dataGridView1.Columns[0].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataSet ds2 = new DataSet();
            //dt = accdb.SelectToDataTable("select * from MyTable");

            if (bSelectDateFlg)
            {
                string sql = "select ID, TestTime, TestResult, TestNo, Operator from ModbusResultTable where [room] = 'right' and [TestDate] between @start_datetime and @end_datetime";
                OleDbParameter[] pars = new OleDbParameter[2];

                OleDbParameter ps = new OleDbParameter("@start_datetime", OleDbType.Date);
                ps.Value = start_datetime;
                pars[0] = ps;

                OleDbParameter pe = new OleDbParameter("@end_datetime", OleDbType.Date);
                pe.Value = end_datetime;

                pars[1] = pe;
                ds2 = AccessHelper.ExecuteDataSet(AccessHelper.ConnString, sql, pars);
            }
            else
            {
                ds2 = AccessHelper.ExecuteDataSet(AccessHelper.ConnString, "select ID, TestTime, TestResult, TestNo, Operator from ModbusResultTable where [room] = 'right'", null);
            }
            dataGridView2.DataSource = ds2.Tables[0].DefaultView;
            dataGridView2.AllowUserToAddRows = false;//datagridview
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dellist_left.Clear();
            dellist_right.Clear();
            bDataLoaded = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            object objCellValue = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            OleDbDataReader r = AccessHelper.ExecuteReader(AccessHelper.ConnString, "select * from ModbusResultTable where [ID] = " + objCellValue.ToString(), null);
            byte[] buff = null;
            if (r.Read())
            {
                buff = (byte[])r["TestImage"];
            }

            PictureViewForm pvf = new PictureViewForm();
            pvf.setPictureData(buff);
            pvf.Show();
        }

        private void buttonSave1_Click(object sender, EventArgs e)
        {
            if (dellist_left.Count > 0)
            {
                for (int i = 0; i < dellist_left.Count; i++)
                {
                    string sql = "delete from ModbusResultTable where [ID] = " + dellist_left[i];
                    AccessHelper.ExecuteNonQuery(AccessHelper.ConnString, sql, null);
                }
                RefreshData();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
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
            e.Graphics.DrawString(resToPrint, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 160, 55);
            e.Graphics.DrawString(noToPrint, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 260, 55);
            e.Graphics.DrawString(operatorToPrint, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 330, 55);
            e.Graphics.DrawString(timeToPrint, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 400, 55);

            e.Graphics.DrawLine(Pens.Black, 8, 200, 480, 200);
        }

        private void buttonSave2_Click(object sender, EventArgs e)
        {
            if (dellist_right.Count > 0)
            {
                for (int i = 0; i < dellist_right.Count; i++)
                {
                    string sql = "delete from ModbusResultTable where [ID] = " + dellist_right[i];
                    AccessHelper.ExecuteNonQuery(AccessHelper.ConnString, sql, null);
                }
                RefreshData();
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            object objCellValue = this.dataGridView2.Rows[e.RowIndex].Cells[0].Value;
            OleDbDataReader r = AccessHelper.ExecuteReader(AccessHelper.ConnString, "select * from ModbusResultTable where [ID] = " + objCellValue.ToString(), null);
            byte[] buff = null;
            if (r.Read())
            {
                buff = (byte[])r["TestImage"];
            }

            PictureViewForm pvf = new PictureViewForm();
            pvf.setPictureData(buff);
            pvf.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            bSelectDateFlg = true;
            DateTime result = dateTimePicker1.Value;
	        start_datetime = result.Date;
            end_datetime = result.Date.AddDays(1);
            RefreshData();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
            {
                object objCellValue = this.dataGridView1.Rows[this.rowIndex].Cells[0].Value;
                dellist_left.Add((int)objCellValue);
                this.dataGridView1.Rows.RemoveAt(this.rowIndex);
            }
        }

        private void deleteRowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView2.Rows[this.rowIndex].IsNewRow)
            {
                object objCellValue = this.dataGridView2.Rows[this.rowIndex].Cells[0].Value;
                dellist_right.Add((int)objCellValue);
                this.dataGridView2.Rows.RemoveAt(this.rowIndex);
            }
        }

        private void dataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView2.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView2.CurrentCell = this.dataGridView2.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip2.Show(this.dataGridView2, e.Location);
                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //ID, TestTime, TestResult, TestNo, Operator
            resToPrint = this.dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            noToPrint = this.dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            operatorToPrint = this.dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            timeToPrint = this.dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            resToPrint = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            noToPrint = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            operatorToPrint = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            timeToPrint = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
