using FoodPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodPlanner.Infrastructure.Persistence.Configurations
{
	public class PlannedMealConfiguration : IEntityTypeConfiguration<PlannedMeal>
	{
		public void Configure(EntityTypeBuilder<PlannedMeal> builder)
		{
			builder.Property(x => x.OrdinalNumber)
				.IsRequired();

			builder.Property(x => x.ScheduledFor)
				.IsRequired();

			builder.HasQueryFilter(x => !x.Deleted);
		}
	}
}
