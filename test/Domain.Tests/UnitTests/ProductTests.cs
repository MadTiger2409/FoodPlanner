using FluentAssertions;
using FoodPlanner.Domain.Entities;
using FoodPlanner.Domain.Tests.TestData.Common;
using FoodPlanner.Domain.Tests.TestData.Product;
using System;
using System.Collections.Generic;
using Xunit;

namespace FoodPlanner.Domain.Tests.UnitTests
{
    [Trait("Unit tests", "Entities")]
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
            product.CategoryId.Should().Be(null);
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
            product.Ingredients.Should().NotBeNullOrEmpty().And.BeSameAs(ingredients);
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