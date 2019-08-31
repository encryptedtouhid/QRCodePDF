using iTextSharp.text;
using iTextSharp.text.pdf;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_Code_gen
{
    class Program
    {
        
        

        static void Main(string[] args)
        {
            List<Bitmap> bitlist = new List<Bitmap>();

            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            doc.PageCount = 1;
            doc.NewPage();
            //Create PDF Table  
            
            //Create a PDF file in specific path  
            PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\touhi\Pictures\Uplay\newpdf.pdf", FileMode.Create));

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            PdfPCell cell_2 = new PdfPCell();
            cell_2.AddElement(new Paragraph("Sr.No.", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, GrayColor.GRAY)));
            table.AddCell(cell_2);

          

            //Open the PDF document  
            doc.Open();
           
            //Add Content to PDF  
            doc.Add(table);
            // Closing the document  
            doc.Close();



            for (int i = 1; i <= 10; i++)
            {
                string p = i.ToString();
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(p, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(400);
                MemoryStream ms = new MemoryStream();

                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                bitlist[i] = qrCodeImage;
                img.Save(@"C:\Users\touhi\Pictures\Uplay\"+i+".Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            Console.ReadLine();
        }
    }
}
