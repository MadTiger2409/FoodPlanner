using FoodPlanner.Application.Common.ProjectionModels;
using FoodPlanner.Infrastructure.Persistence.Common.Interfaces;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using System;
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

            var grid = new PdfGrid
            {
                DataSource = shoppingList
            };

            grid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));

            var stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;

            document.Close(true);

            return new FileResult(stream, "application/pdf", "shoppingList.pdf");
        }
    }
}