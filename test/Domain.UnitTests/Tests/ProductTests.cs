using FluentAssertions;
using FoodPlanner.Domain.Entities;
using FoodPlanner.Domain.UnitTests.Common;
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
        [CorrectDataWithoutIngredients]
        public void Succed_To_Create_Product_Without_Ingredients(int id, string name)
        {
            // Arrange
            Product product = null;

            // Act
            product = new Product { Id = id, Name = name };

            // Assert
            product.Should().NotBeNull();
            product.Id.Should().Be(id);
            product.Name.Should().Be(name);
            product.Ingredients.Should().NotBeNull();
        }

        [Theory]
        [PositiveId]
        public void Succed_To_Create_Product_With_Positive_Id(int id)
        {
            // Arrange
            Product product = null;

            // Act
            product = new Product { Id = id, Name = "Milk" };

            // Assert
            product.Should().NotBeNull();
            product.Id.Should().BePositive().And.Be(id);
        }

        [Theory]
        [NotPositiveId]
        public void Failed_To_Create_Product_With_Not_Positive_Id(int id)
        {
            // Arrange
            Product product = null;

            // Act
            Action action = () => product = new Product { Id = id, Name = "Milk" };

            // Assert
            product.Should().BeNull();
            action.Should().Throw<ArgumentException>();
        }
    }
}