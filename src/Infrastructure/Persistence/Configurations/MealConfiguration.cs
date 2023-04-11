using FoodPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodPlanner.Infrastructure.Persistence.Configurations
{
	public class MealConfiguration : IEntityTypeConfiguration<Meal>
	{
		public void Configure(EntityTypeBuilder<Meal> builder)
		{
			builder.Property(x => x.Name)
				.IsRequired();

			builder.HasQueryFilter(x => !x.Deleted);
		}
	}
}
