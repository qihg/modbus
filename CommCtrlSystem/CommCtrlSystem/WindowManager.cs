using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommCtrlSystem
{
    class WindowManager
    {
        private static WindowManager globalInstance;
        private static readonly object locker = new object();
        private WindowManager()
        {
        }

        public static WindowManager GetInstance()
        {
            if (globalInstance == null)
            {
                lock (locker)
                {
                    if (globalInstance == null)
                    {
                        globalInstance = new WindowManager();
                    }
                }
            }
            return globalInstance;
        }

        public GroupBox gb {set; get;}
        public WindowMain wmain { set; get; }
        public WindowBaseSetting wbs { set; get; }
        public WindowHistoryReport whr { set; get; }
        public WindowTemperatureCorrection wtc { set; get; }
        public WindowPIDSetting wps { set; get; }
        public WindowManualSetting wms { set; get; }
        public WindowRealtimeData wrd1 { set; get; }
        public WindowRealtimeData wrd2 { set; get; }
    }
}
