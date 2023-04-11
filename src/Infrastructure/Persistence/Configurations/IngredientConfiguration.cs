using FoodPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodPlanner.Infrastructure.Persistence.Configurations
{
	public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
	{
		public void Configure(EntityTypeBuilder<Ingredient> builder)
		{
			builder.Property(x => x.Amount)
				.IsRequired();

			builder.HasQueryFilter(x => !x.Deleted);
		}
	}
}
