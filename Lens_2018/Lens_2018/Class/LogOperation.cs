using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lens_2018
{
    class LogOperation
    {
        public static string OperationFilePath = Directory.GetCurrentDirectory() + "\\Log" + "\\" + dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + ".txt";
        public static DateTime dt
        {
            get { return DateTime.Now; }
        }

        public static void SaveLogMsg(string str)
        {
            using (StreamWriter FileWriter = new StreamWriter(OperationFilePath, true))
            {
                FileWriter.WriteLine("[" + dt.ToString("yy-MM-dd HH:mm:ss") + "]  " + str);
            }
        }

    }
}
