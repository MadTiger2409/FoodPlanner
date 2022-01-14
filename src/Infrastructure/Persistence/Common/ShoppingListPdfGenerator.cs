using FoodPlanner.Application.Common.ProjectionModels;
using FoodPlanner.Infrastructure.Persistence.Common.Interfaces;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System.Collections.Generic;
using System.IO;

namespace FoodPlanner.Infrastructure.Persistence.Common
{
    public class ShoppingListPdfGenerator : IShoppingListPdfGenerator
    {
        public FileResult GetPdf(List<ShoppingListModel> shoppingList)
        {
            var document = new PdfDocument();
            var page = document.Pages.Add();

            MemoryStream fontStream = new(Properties.Resources.Arial);

            PdfTrueTypeFont altFont = new(fontStream, 10);
            PdfTrueTypeFont headerFont = new(fontStream, 12, PdfFontStyle.Bold);

            PdfCellStyle altStyle = new(altFont, PdfBrushes.Black, PdfPens.Black);
            PdfCellStyle headerStyle = new(headerFont, PdfBrushes.Black, PdfPens.Black);

            PdfLightTable table = new()
            {
                DataSource = shoppingList,
                ColumnProportionalSizing = true,
            };

            table.Style.DefaultStyle = altStyle;
            table.Style.HeaderStyle = headerStyle;

            table.Style.ShowHeader = true;
            table.Style.RepeatHeader = false;
            table.Style.CellPadding = 3f;

            table.Draw(page, new PointF(10, 10));

            var stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;

            document.Close(true);

            return new FileResult(stream, "application/pdf", "shoppingList.pdf");
        }
    }
}