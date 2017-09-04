using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PdfUtils
{
    class SumatraUtil
    {
        public static void PrintWithSumatra(string filePath)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Path.Combine(Environment.CurrentDirectory,@"Tools/SumatraPDF.exe");
            proc.StartInfo.Arguments = string.Format(@" -print-to-default {0}", filePath);
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            //proc.Exited += new EventHandler((x, y) => {
            //    //Thread.Sleep(1000);
            //    var i = 1;
            //    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            //    {
            //        File.Delete(filePath);
            //    }
            //});
            //for (int i = 0; i < 5; i++)
            //{
            //    if (!proc.HasExited)
            //    {
            //        proc.Refresh();
            //        Thread.Sleep(2000);
            //    }
            //    else
            //        break;
            //}
            //if (!proc.HasExited)
            //{
            //    proc.CloseMainWindow();
            //}
        }
      
    }
}
