using FluentAssertions;
using FoodPlanner.Domain.Entities;
using FoodPlanner.Domain.UnitTests.Common;
using FoodPlanner.Domain.UnitTests.Common.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FoodPlanner.Domain.UnitTests.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Succed_With_Creating_Unit()
        {
            // Arrange
            Unit unit = null;

            // Act
            unit = new Unit();

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
            Unit unit = new Unit();

            // Act
            unit.Ingredients = ingredients;

            // Assert
            unit.Ingredients.Should().NotBeNullOrEmpty();
            unit.Ingredients.Should().BeSameAs(ingredients);
        }

        [Theory]
        [PositiveId]
        public void Succed_With_Setting_Positive_Id(int id)
        {
            // Arrange
            Unit unit = new Unit();

            // Act
            unit.Id = id;

            // Assert
            unit.Should().NotBeNull();
            unit.Id.Should().BePositive().And.Be(id);
        }

        [Theory]
        [NotPositiveId]
        public void Failed_With_Setting_Not_Positive_Id(int id)
        {
            // Arrange
            Unit unit = new Unit();

            // Act
            Action action = () => unit.Id = id;

            // Assert
            unit.Id.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [CorrectUnitName]
        public void Succed_With_Setting_Correct_Name(string name)
        {
            // Arrange
            Unit unit = new Unit();

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
            Unit unit = new Unit();

            // Act
            Action action = () => unit.Name = name;

            // Assert
            unit.Name.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }
    }
}