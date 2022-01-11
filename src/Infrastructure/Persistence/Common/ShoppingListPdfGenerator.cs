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

            PdfCellStyle headerStyle = new()
            {
                TextPen = PdfPens.Black,
                TextBrush = PdfBrushes.Black,
                BackgroundBrush = PdfBrushes.White,
                Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10),
            };

            PdfLightTable table = new()
            {
                DataSource = shoppingList,
                ColumnProportionalSizing = true,
            };

            table.Style.HeaderStyle = headerStyle;
            table.Style.ShowHeader = true;
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