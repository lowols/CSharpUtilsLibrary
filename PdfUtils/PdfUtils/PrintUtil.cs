using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PdfUtils
{
   public class PrintUtil
    {
        /// <summary>
        /// 可以正常打印本地pdf
        /// </summary>
        /// <param name="args"></param>
       public static void PrintDefault(string filepath)
        {
            Process proc = new Process();
            proc.EnableRaisingEvents = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = filepath;//@"C:\Users\wang\Desktop\abc.pdf";//打印文件路径（本地完整路径包括文件名和后缀名）
            proc.StartInfo.Verb = "print";// "print";
            //proc.StartInfo.Arguments = "/Direction: 90";
            proc.Start();

            //proc.Exited += new EventHandler((x, y) =>
            //{
            //    //Thread.Sleep(1000);
            //    var i = 1;
            //    if (!string.IsNullOrEmpty(filepath) && File.Exists(filepath))
            //    {
            //        File.Delete(filepath);
            //    }
            //});

        }
    }
}
