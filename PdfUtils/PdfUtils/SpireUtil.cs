using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace PdfUtils
{
    class SpireUtil
    {
        /// <summary>
        /// 用Spire库打印Pdf
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="setPortraitable">设置可纵向打印</param>
        public static void PrintWithSpire(string filePath, bool setPortraitable = false)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(filePath);
            //Use the default printer to print all the pages
            //doc.PrintDocument.DefaultPageSettings.PaperSize = new PaperSize("defaultsize", 560, 960);
            //doc.PrintDocument.DefaultPageSettings.Margins = new Margins(20, 20, 30, 30);
            //var margins = new Margins(100, 1, 20, 1);
            //doc.PrintDocument.DefaultPageSettings.Margins = margins;
            //doc.PrintDocument.PrinterSettings.DefaultPageSettings.Margins = margins;
            if (setPortraitable)
            {
                var newPdf = GeneratePortraitableFile(filePath);
                PrintWithSpire(newPdf);
                if (File.Exists(newPdf))
                {
                    File.Delete(newPdf);
                }
                return;
            }
            doc.PrintDocument.Print();
        }
        /// <summary>
        /// 有些pdf，Spire无法纵向打印
        /// 现在是通过生成一个有页边距的新pdf文件来克服该问题
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private static string GeneratePortraitableFile(string filepath)
        {

            //加载PDF文档
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(filepath);

            //创建一个新的PdfDocument实例
            PdfDocument newPdf = new PdfDocument();

            //遍历所有PDF 页面     
            foreach (PdfPageBase page in pdf.Pages)
            {
                //设置新页面大小为A2, 设置新的页边距
                // PdfPageBase newPage = newPdf.Pages.Add(PdfPageSize.A4, new PdfMargins(1, 100));
                PdfPageBase newPage = newPdf.Pages.Add(PdfPageSize.A4, new PdfMargins(1, 50));
                //将原PDF内容写入新页面              
                page.CreateTemplate().Draw(newPage, new PointF(0, 0));

            }

            //保存PDF
            var newFilePath = Path.Combine(Environment.CurrentDirectory, Guid.NewGuid().ToString() + ".pdf");
            newPdf.SaveToFile(newFilePath, FileFormat.PDF);
            return newFilePath;
        }
    }
}
