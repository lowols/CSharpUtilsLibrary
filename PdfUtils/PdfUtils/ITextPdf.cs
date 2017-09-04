using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PdfUtils
{
    class ITextPdf
    {
        public void PrintPdf()
        {
            //Document iText_xls_2_pdf = new Document(PageSize.A4.Rotate());
            //PdfWriter writer = PdfWriter.GetInstance(iText_xls_2_pdf, response.getOutputStream());
            //iText_xls_2_pdf.Open();

            //PdfAction action = new PdfAction(PdfAction.PRINTDIALOG);
            //writer.SetOpenAction(action);
            //iText_xls_2_pdf.Close();
            using (MemoryStream stream = new MemoryStream())
            {
                Document iText_xls_2_pdf = new Document(PageSize.A4.Rotate());
                PdfWriter writer = PdfWriter.GetInstance(iText_xls_2_pdf, stream);
                iText_xls_2_pdf.Open();

                PdfAction action = new PdfAction(PdfAction.PRINTDIALOG);
                writer.SetOpenAction(action);
                iText_xls_2_pdf.Close();
            }
        }
       
    }
}
