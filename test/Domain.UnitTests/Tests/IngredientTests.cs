using FluentAssertions;
using FoodPlanner.Domain.Entities;
using FoodPlanner.Domain.UnitTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FoodPlanner.Domain.UnitTests.Tests
{
    public class IngredientTests
    {
        [Fact]
        public void Succed_With_Creating_Unit()
        {
            // Arrange
            Ingredient ingredient = null;

            // Act
            ingredient = new Ingredient();

            // Assert
            ingredient.Should().NotBeNull();
            ingredient.Id.Should().Be(default);
            ingredient.MealId.Should().Be(default);
            ingredient.ProductId.Should().Be(default);
            ingredient.UnitId.Should().Be(default);
        }

        [Theory]
        [PositiveId]
        public void Succed_With_Setting_Positive_Id(int id)
        {
            // Arrange
            Ingredient ingredient = new Ingredient();

            // Act
            ingredient.Id = id;

            // Assert
            ingredient.Should().NotBeNull();
            ingredient.Id.Should().BePositive().And.Be(id);
        }

        [Theory]
        [NotPositiveId]
        public void Failed_With_Setting_Not_Positive_Id(int id)
        {
            // Arrange
            Ingredient ingredient = new Ingredient();

            // Act
            Action action = () => ingredient.Id = id;

            // Assert
            ingredient.Id.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [PositiveId]
        public void Succed_With_Setting_Positive_ProductId(int id)
        {
            // Arrange
            Ingredient ingredient = new Ingredient();

            // Act
            ingredient.ProductId = id;

            // Assert
            ingredient.Should().NotBeNull();
            ingredient.ProductId.Should().BePositive().And.Be(id);
        }

        [Theory]
        [NotPositiveId]
        public void Failed_With_Setting_Not_Positive_ProductId(int id)
        {
            // Arrange
            Ingredient ingredient = new Ingredient();

            // Act
            Action action = () => ingredient.ProductId = id;

            // Assert
            ingredient.ProductId.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [PositiveId]
        public void Succed_With_Setting_Positive_UnitId(int id)
        {
            // Arrange
            Ingredient ingredient = new Ingredient();

            // Act
            ingredient.UnitId = id;

            // Assert
            ingredient.Should().NotBeNull();
            ingredient.UnitId.Should().BePositive().And.Be(id);
        }

        [Theory]
        [NotPositiveId]
        public void Failed_With_Setting_Not_Positive_UnitId(int id)
        {
            // Arrange
            Ingredient ingredient = new Ingredient();

            // Act
            Action action = () => ingredient.UnitId = id;

            // Assert
            ingredient.UnitId.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }
    }
}