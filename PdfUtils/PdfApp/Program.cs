using PdfUtils;
using System;
using System.Collections.Generic;
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
               
                int i = 0;
                while (i < 1)
                {
                    //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DownLoadFiles", DateTime.Now.ToString("yyyyMMdd")); //UploadConfigContext.UploadPath;
                    //HttpWebResponse res = HttpUtil.GetResponseByUrl("http://192.168.6.93/fp/d?d=599ec452a3201c000717f5dc");
                    //string filepath = FileUtil.SaveFile(path, res);
                    //Task.Factory.StartNew(() => FileUtil.ClearDirByDate(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DownLoadFiles"), new TimeSpan(3, 0, 0, 0)));
                    //PrintUtil.PrintDefault(filepath);
                    //i++;


                    HttpWebResponse res = HttpUtil.GetResponseByUrl("http://localhost:32574/599ec452a3201c000717f5dc.pdf");
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DownLoadFiles", DateTime.Now.ToString("yyyyMMdd"));
                    string filepath = FileUtil.SaveFile(path, res);
                    if (string.IsNullOrEmpty(filepath))
                    {
                        throw new Exception("保存版式文件时异常");
                    }


                    //PrintUtil.PrintDefault(filepath);
                    Task.Factory.StartNew(() => FileUtil.ClearDirByDate(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DownLoadFiles"), new TimeSpan(3, 0, 0, 0)));
                    i++;
                }

            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            Console.ReadKey();
        }

       
    }
}
