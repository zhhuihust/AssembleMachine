using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace Lens_2018
{
    class TimeDelay
    {
        [DllImport("kernel32.dll")]
        public static extern uint GetTickCount();
        public static void delay(Int32 time)
        {
            uint start = GetTickCount();
            while ((GetTickCount() - start) < time)
            {
                Application.DoEvents();
            }
        }

        public static Stopwatch watch = new Stopwatch();

        public static void StartCount()
        {
            if (watch.ElapsedMilliseconds != 0)
            {
                watch.Reset();
                watch.Start();
            }
            else
            {
                watch.Start();
            }
        }

        public static double TimeCount()
        {
            double time1 = watch.ElapsedMilliseconds;
            double time = time1 / 1000;
            return time;
        }

        public static void StopCount()
        {
            watch.Stop();
            watch.Reset();
        }


    }
}
