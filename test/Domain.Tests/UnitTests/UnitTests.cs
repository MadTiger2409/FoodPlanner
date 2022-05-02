using FluentAssertions;
using FoodPlanner.Domain.Entities;
using FoodPlanner.Domain.Tests.TestData.Common;
using FoodPlanner.Domain.Tests.TestData.Unit;
using System;
using System.Collections.Generic;
using Xunit;

namespace FoodPlanner.Domain.Tests.UnitTests
{
    public class UnitTests
    {
        [Fact]
        public void Succed_With_Creating_Unit()
        {
            // Arrange
            Unit unit = null;

            // Act
            unit = new();

            // Assert
            unit.Should().NotBeNull();
            unit.Id.Should().Be(default);
            unit.Name.Should().Be(default);
            unit.Ingredients.Should().NotBeNull();
        }

        [Theory]
        [IngredientsMinimumData]
        public void Succed_With_Setting_Ingredients_For_Unit(List<Ingredient> ingredients)
        {
            // Arrange
            Unit unit = new();

            // Act
            unit.Ingredients = ingredients;

            // Assert
            unit.Ingredients.Should().NotBeNullOrEmpty().And.BeSameAs(ingredients);
        }

        [Theory]
        [CorrectUnitName]
        public void Succed_With_Setting_Correct_Name(string name)
        {
            // Arrange
            Unit unit = new();

            // Act
            unit.Name = name;

            // Assert
            unit.Should().NotBeNull();
            unit.Name.Should().NotBeNullOrWhiteSpace().And.Be(name);
        }

        [Theory]
        [IncorrectName]
        public void Failed_With_Setting_Incorrect_Name(string name)
        {
            // Arrange
            Unit unit = new();

            // Act
            Action action = () => unit.Name = name;

            // Assert
            unit.Name.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }
    }
}