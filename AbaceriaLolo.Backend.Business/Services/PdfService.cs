using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace AbaceriaLolo.Backend.Infrastructure.Services
{
    public class PdfService : IPdfService
    {
        public async Task<byte[]> GenerateInventoryPdfAsync(IEnumerable<InventorySectionModel> inventorySections)
        {
            using (var ms = new MemoryStream())
            {
                var writer = new PdfWriter(ms);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                document.Add(new Paragraph("INVENTARIO"));

                foreach (var section in inventorySections)
                {
                    document.Add(new Paragraph($"{section.SectionName}"));

                    // Crear la tabla con dos columnas
                    var table = new Table(UnitValue.CreatePercentArray(new float[] { 70, 30 })).UseAllAvailableWidth();
                    table.AddHeaderCell("Productos");
                    table.AddHeaderCell("Cantidad MÍNIMA");

                    foreach (var product in section.InventoryProducts)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(product.ProductName)));
                        table.AddCell(new Cell().Add(new Paragraph(product.Quantity.ToString())));
                    }

                    document.Add(table);
                }

                document.Close();
                return ms.ToArray();
            }
        }
    }
}
