using FoodPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodPlanner.Infrastructure.Persistence.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(x => x.Name)
				.IsRequired();

			builder.HasQueryFilter(x => !x.Deleted);
		}
	}
}
