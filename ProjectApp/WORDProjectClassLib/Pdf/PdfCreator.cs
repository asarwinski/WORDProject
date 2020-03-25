using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WORDProjectClassLib.Models;

namespace WORDProjectClassLib.Pdf
{
    public static class PdfCreator
    {
        public static void Create(List<Exam> exams, string path)
        {
            var writer = new PdfWriter(path);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);
            document.SetMargins(20, 20, 20, 20);

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            var bytes = (byte[])converter.ConvertTo(Properties.Resources.wordLogo, typeof(byte[]));
            Paragraph p = new Paragraph();
            Image logo = new Image(ImageDataFactory.Create(bytes));
            p.Add(logo);
            p.Add(new Tab());
            p.AddTabStops(new TabStop(1000, TabAlignment.RIGHT));
            p.Add(DateTime.Now.ToString("MM/dd/yyyy"));

            document.Add(p);

            var table = new Table(new float[] { 2, 2, 1, 2, 2, 1 });
            table.SetWidth(UnitValue.CreatePercentValue(100));

            table.AddHeaderCell(new Cell().Add(new Paragraph("Zdający")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Egzaminator")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Kategoria")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Data")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Czas Trwania")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Wynik")));

            foreach (var exam in exams)
            {
                table.AddCell(new Cell().Add(new Paragraph(exam.Examinee.FullName)));
                table.AddCell(new Cell().Add(new Paragraph(exam.Examiner.FullName)));
                table.AddCell(new Cell().Add(new Paragraph(exam.Category)));
                table.AddCell(new Cell().Add(new Paragraph(exam.Date.ToString("yyyy-MM-dd"))));
                table.AddCell(new Cell().Add(new Paragraph(exam.Duration.ToString("t"))));
                table.AddCell(new Cell().Add(new Paragraph((bool)exam.Result ? "Pozytywny" : "Negatywny")));
            }

            document.Add(table);
            document.Close();
        }
    }
}
