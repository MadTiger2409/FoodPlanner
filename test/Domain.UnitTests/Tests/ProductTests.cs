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
        [Fact]
        public void Succed_With_Creating_Product()
        {
            // Arrange
            Product product = null;

            // Act
            product = new();

            // Assert
            product.Should().NotBeNull();
            product.Id.Should().Be(default);
            product.Name.Should().Be(default);
            product.Ingredients.Should().NotBeNull();
        }

        [Theory]
        [IngredientsMinimumData]
        public void Succed_With_Setting_Ingredients_For_Product(List<Ingredient> ingredients)
        {
            // Arrange
            Product product = new();

            // Act
            product.Ingredients = ingredients;

            // Assert
            product.Ingredients.Should().NotBeNullOrEmpty();
            product.Ingredients.Should().BeSameAs(ingredients);
        }

        [Theory]
        [PositiveId]
        public void Succed_With_Setting_Positive_Id(int id)
        {
            // Arrange
            Product product = new();

            // Act
            product.Id = id;

            // Assert
            product.Should().NotBeNull();
            product.Id.Should().BePositive().And.Be(id);
        }

        [Theory]
        [NotPositiveId]
        public void Failed_With_Setting_Not_Positive_Id(int id)
        {
            // Arrange
            Product product = new();

            // Act
            Action action = () => product.Id = id;

            // Assert
            product.Id.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [CorrectProductName]
        public void Succed_With_Setting_Correct_Name(string name)
        {
            // Arrange
            Product product = new();

            // Act
            product.Name = name;

            // Assert
            product.Should().NotBeNull();
            product.Name.Should().NotBeNullOrWhiteSpace().And.Be(name);
        }

        [Theory]
        [IncorrectName]
        public void Failed_With_Setting_Incorrect_Name(string name)
        {
            // Arrange
            Product product = new();

            // Act
            Action action = () => product.Name = name;

            // Assert
            product.Name.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }
    }
}