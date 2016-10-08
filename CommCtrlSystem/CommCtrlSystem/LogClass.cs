using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CommCtrlSystem
{
    class LogClass
    {
        private static LogClass log;
        private static readonly object locker = new object();

        private LogClass()
        {
        }

        public static LogClass GetInstance()
        {
            if (log == null)
            {
                lock (locker)
                {
                    if (log == null)
                    {
                        log = new LogClass();
                    }
                }
            }
            return log;
        }
        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="LogAddress">日志文件地址</param>
        public void WriteExceptionLog(Exception ex, string LogAddress = "")
        {
            lock (locker)
            {
                //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
                if (LogAddress == "")
                {
                    LogAddress = Environment.CurrentDirectory + '\\' +
                        DateTime.Now.Year + '-' +
                        DateTime.Now.Month + '-' +
                        DateTime.Now.Day + "_Log.log";
                }

                //把异常信息输出到文件
                StreamWriter fs = new StreamWriter(LogAddress, true);
                fs.WriteLine("当前时间：" + DateTime.Now.ToString());
                fs.WriteLine("异常信息：" + ex.Message);
                fs.WriteLine("异常对象：" + ex.Source);
                fs.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
                fs.WriteLine("触发方法：" + ex.TargetSite);
                fs.WriteLine();
                fs.Close();
            }
        }


         /**//// <summary> 
         /// 写入日志文件 
         /// </summary> 
         /// <param name="input"></param> 
        public void WriteLogFile(string input)
        {
            lock (locker)
            {
                /**/
                ///指定日志文件的目录 
                string fname = System.IO.Path.Combine(Application.StartupPath, "LogFile.txt");
                /**/
                ///定义文件信息对象 

                FileInfo finfo = new FileInfo(fname);

                if (!finfo.Exists)
                {
                    FileStream fs;
                    fs = File.Create(fname);
                    fs.Close();
                    finfo = new FileInfo(fname);
                }

                /**/
                ///判断文件是否存在以及是否大于2K 
                if (finfo.Length > 1024 * 1024 * 10)
                {
                    /**/
                    ///文件超过10MB则重命名 
                    File.Move(fname, Directory.GetCurrentDirectory() + DateTime.Now.TimeOfDay + "\\LogFile.txt");
                    /**/
                    ///删除该文件 
                    //finfo.Delete(); 
                }
                //finfo.AppendText(); 
                /**/
                ///创建只写文件流 

                using (FileStream fs = finfo.OpenWrite())
                {
                    /**/
                    ///根据上面创建的文件流创建写数据流 
                    StreamWriter w = new StreamWriter(fs);

                    /**/
                    ///设置写数据流的起始位置为文件流的末尾 
                    w.BaseStream.Seek(0, SeekOrigin.End);

                    /**/
                    ///写入“Log Entry : ” 
                    w.Write("\n\rLog Entry : ");

                    /**/
                    ///写入当前系统时间并换行 
                    w.Write("{0} {1} \n\r", DateTime.Now.ToLongTimeString(),
                        DateTime.Now.ToLongDateString());

                    /**/
                    ///写入日志内容并换行 
                    w.Write(input + "\n\r");

                    /**/
                    ///写入------------------------------------“并换行 
                    w.Write("------------------------------------\n\r");

                    /**/
                    ///清空缓冲区内容，并把缓冲区内容写入基础流 
                    w.Flush();

                    /**/
                    ///关闭写数据流 
                    w.Close();
                }
            }
        }
    }
}
