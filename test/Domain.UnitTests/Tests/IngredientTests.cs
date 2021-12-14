using FluentAssertions;
using FoodPlanner.Domain.Entities;
using FoodPlanner.Domain.UnitTests.Common;
using FoodPlanner.Domain.UnitTests.Common.Ingredient;
using System;
using Xunit;

namespace FoodPlanner.Domain.UnitTests.Tests
{
    public class IngredientTests
    {
        [Fact]
        public void Succed_With_Creating_Ingredient()
        {
            // Arrange
            Ingredient ingredient = null;

            // Act
            ingredient = new();

            // Assert
            ingredient.Should().NotBeNull();
            ingredient.Id.Should().Be(default);
            ingredient.MealId.Should().Be(default);
            ingredient.ProductId.Should().Be(default);
            ingredient.UnitId.Should().Be(default);
        }

        [Theory]
        [CorrectAmountData]
        public void Succed_With_Setting_Correct_Amount_Value(float amount)
        {
            // Arrange
            Ingredient ingredient = new();

            // Act
            ingredient.Amount = amount;

            // Assert
            ingredient.Should().NotBeNull();
            ingredient.Amount.Should().NotBe(default).And.BePositive().And.Be(amount);
        }

        [Theory]
        [InCorrectAmountData]
        public void Failed_With_Setting_Incorrect_Amount_Values(float amount)
        {
            // Arrange
            Ingredient ingredient = new();

            // Act
            Action action = () => ingredient.Amount = amount;

            // Assert
            ingredient.Amount.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }
    }
}