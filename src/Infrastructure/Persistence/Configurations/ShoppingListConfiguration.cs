using FoodPlanner.Application.Common.ProjectionModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodPlanner.Infrastructure.Persistence.Configurations
{
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingListModel>
    {
        public void Configure(EntityTypeBuilder<ShoppingListModel> builder)
        {
            builder.HasNoKey().ToView("shopping_list_view");
        }
    }
}
