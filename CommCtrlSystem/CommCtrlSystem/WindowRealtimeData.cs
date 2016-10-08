using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Imaging;
using System.IO;

namespace CommCtrlSystem
{
    public partial class WindowRealtimeData : UserControl
    {
        private Random random = new Random();

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

        private DateTime minValue;
        private DateTime maxValue;

        public WindowRealtimeData()
        {
            InitializeComponent();
            minValue = DateTime.Now;
            maxValue = minValue.AddMinutes(30);

            realtimeChart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            realtimeChart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();

            realtimeChart1.ChartAreas[0].AxisY.Minimum = 0;
            realtimeChart1.ChartAreas[0].AxisY.Maximum = 100;
            // Reset number of series in the chart.
            realtimeChart1.Series.Clear();

            // create a line chart series
            Series newSeries = new Series("试样温度");
            newSeries.ChartType = SeriesChartType.Line;
            newSeries.BorderWidth = 4;
            newSeries.Color = Color.Red;
            newSeries.XValueType = ChartValueType.Time;
            realtimeChart1.Series.Add(newSeries);

            Series newSeries2 = new Series("冷浴温度");
            newSeries2.ChartType = SeriesChartType.Line;
            newSeries2.BorderWidth = 4;
            newSeries2.Color = Color.Blue;
            newSeries2.XValueType = ChartValueType.Time;
            realtimeChart1.Series.Add(newSeries2);
        }

        private void buttonMain_Click(object sender, EventArgs e)
        {
            GroupBox tgb = WindowManager.GetInstance().gb;
            tgb.Controls.Clear();
            tgb.Controls.Add(WindowManager.GetInstance().wmain);
        }

        // dataflg : 0 - left room, 1 - right room  
        public void updateData(int dataflg, ModbusRegisters reg)
        {
            int run_time_h0 = reg.stReg[RUNTIME_M].getHighReg() / 60;
            int run_time_h1 = reg.stReg[RUNTIME_M].getLowReg() / 60;
            int run_time_m0 = reg.stReg[RUNTIME_M].getHighReg() % 60;
            int run_time_m1 = reg.stReg[RUNTIME_M].getLowReg() % 60;
            int run_time_s0 = reg.stReg[RUNTIME_S].getHighReg();
            int run_time_s1 = reg.stReg[RUNTIME_S].getLowReg();

            if (dataflg == 0) // left room
            {
                textBox1.Text = reg.stReg[TEMP_OIL0].getShortValue().ToString();
                textBox2.Text = reg.stReg[PID_RESULT0].getShortValue().ToString();

                textBox3.Text = reg.stReg[TIME_SUCK].getHighReg().ToString();
                textBox4.Text = reg.stReg[STATE_SUCKTUBE].getHighRegString();

                textBox5.Text = reg.stReg[TEMP_BATH0].getShortValue().ToString();
                textBox6.Text = reg.stReg[STATE_WORK].getHighRegString();

                textBox7.Text = reg.stReg[TIME_DROP].getHighReg().ToString();
                textBox8.Text = reg.stReg[UP_FLAG].getHighRegString();
                
                textBox9.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", run_time_h0, run_time_m0, run_time_s0);
                textBox10.Text = reg.stReg[ALLSTATE].getHighRegString();

                textBox11.Text = reg.stReg[ALARM].getHighRegString();
                textBox12.Text = reg.stReg[DOWN_FLAG].getHighRegString();

                addPoint(reg.stReg[TEMP_OIL0].getShortValue(), reg.stReg[TEMP_BATH0].getShortValue());
            }
            else // right room
            {
                textBox1.Text = reg.stReg[TEMP_OIL1].getShortValue().ToString();
                textBox2.Text = reg.stReg[PID_RESULT1].getShortValue().ToString();

                textBox3.Text = reg.stReg[TIME_SUCK].getLowReg().ToString();
                textBox4.Text = reg.stReg[STATE_SUCKTUBE].getLowRegString();

                textBox5.Text = reg.stReg[TEMP_BATH1].getShortValue().ToString();
                textBox6.Text = reg.stReg[STATE_WORK].getLowRegString();

                textBox7.Text = reg.stReg[TIME_DROP].getLowReg().ToString();
                textBox8.Text = reg.stReg[UP_FLAG].getLowRegString();

                textBox9.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", run_time_h1, run_time_m1, run_time_s1);
                textBox10.Text = reg.stReg[ALLSTATE].getLowRegString();

                textBox11.Text = reg.stReg[ALARM].getLowRegString();
                textBox12.Text = reg.stReg[DOWN_FLAG].getLowRegString();

                addPoint(reg.stReg[TEMP_OIL1].getShortValue(), reg.stReg[TEMP_BATH1].getShortValue());
            }
        }

        public void addPoint(int value1, int value2)
        {        
            try
            {
                realtimeChart1.Series[0].Points.AddXY(DateTime.Now.ToOADate(), value1);
                realtimeChart1.Series[1].Points.AddXY(DateTime.Now.ToOADate(), value2);

                if (DateTime.Now.ToOADate() > maxValue.ToOADate())
                {
                    realtimeChart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.ToOADate();
                }

                if (value1 > realtimeChart1.ChartAreas[0].AxisY.Maximum)
                {
                    realtimeChart1.ChartAreas[0].AxisY.Maximum = value1 + 10;
                }

                if (value2 > realtimeChart1.ChartAreas[0].AxisY.Maximum)
                {
                    realtimeChart1.ChartAreas[0].AxisY.Maximum = value2 + 10;
                }

                if (value1 < realtimeChart1.ChartAreas[0].AxisY.Minimum)
                {
                    realtimeChart1.ChartAreas[0].AxisY.Minimum = value1 - 10;
                }

                if (value2 < realtimeChart1.ChartAreas[0].AxisY.Minimum)
                {
                    realtimeChart1.ChartAreas[0].AxisY.Minimum = value2 - 10;
                }
                // Adjust Y & X axis scale
                realtimeChart1.ResetAutoValues();

                realtimeChart1.Invalidate();
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public byte[] getImageData()
        {
            MemoryStream memStream = new MemoryStream();
            realtimeChart1.SaveImage(memStream, ImageFormat.Png);
            memStream.Seek(0, SeekOrigin.Begin);
            byte[] btImage = new byte[memStream.Length];
            memStream.Read(btImage, 0, btImage.Length);
            memStream.Close();
            return btImage;
        }
    }
}
