using PdfUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace PdfApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //print1("电子票.pdf");
            try
            {

                Stopwatch watch = new Stopwatch();
                watch.Start();
                int i = 0;
                while (i < 1)
                {
                  
                    PrintUtil.PrintDefault("电子票.pdf");
                    i++;

                }
                watch.Stop();
                Console.WriteLine(watch.Elapsed);
                Console.ReadKey();


            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            Console.ReadKey();
        }

       
    }
}
