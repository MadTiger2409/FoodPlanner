using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Unit> Units { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Meal> Meals { get; set; }
        DbSet<PlannedMeal> PlannedMeals { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}