using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Common.ProjectionModels;
using FoodPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FoodPlanner.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<PlannedMeal> PlannedMeals { get; set; }
        public DbSet<ShoppingListModel> ShoppingLists { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}