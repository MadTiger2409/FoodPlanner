using FluentAssertions;
using FoodPlanner.Domain.Entities;
using FoodPlanner.Domain.UnitTests.Common.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FoodPlanner.Domain.UnitTests.Tests
{
    public class ProductTests
    {
        [Theory]
        [DataWithoutIngredients]
        public void Create_Product_Without_Ingredients(int id, string name)
        {
            // Arrange
            Product product;

            // Act
            product = new Product { Id = id, Name = name };

            // Assert
            product.Id.Should().BePositive().And.Be(id);
            product.Name.Should().NotBeNullOrWhiteSpace().And.Be(name);
            product.Ingredients.Should().NotBeNull();
        }
    }
}