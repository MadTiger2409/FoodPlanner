using FluentAssertions;
using FoodPlanner.Domain.Entities;
using FoodPlanner.Domain.UnitTests.Common;
using FoodPlanner.Domain.UnitTests.Common.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FoodPlanner.Domain.UnitTests.Tests
{
    public class MealTests
    {
        [Fact]
        public void Succed_With_Creating_Meal()
        {
            // Arrange
            Meal meal = null;

            // Act
            meal = new();

            // Assert
            meal.Should().NotBeNull();
            meal.Id.Should().Be(default);
            meal.Name.Should().Be(default);
            meal.Ingredients.Should().NotBeNull();
            meal.PlannedMeals.Should().NotBeNull();
        }

        [Theory]
        [PlannedMealsMinimumData]
        public void Succed_With_Setting_PlannedMeals_For_Meal(List<PlannedMeal> plannedMeals)
        {
            // Arrange
            Meal meal = new();

            // Act
            meal.PlannedMeals = plannedMeals;

            // Assert
            meal.PlannedMeals.Should().NotBeNullOrEmpty().And.BeSameAs(plannedMeals);
        }

        [Theory]
        [IngredientsMinimumData]
        public void Succed_With_Setting_Ingredients_For_Meal(List<Ingredient> ingredients)
        {
            // Arrange
            Meal meal = new();

            // Act
            meal.Ingredients = ingredients;

            // Assert
            meal.Ingredients.Should().NotBeNullOrEmpty().And.BeSameAs(ingredients);
        }

        [Theory]
        [CorrectMealName]
        public void Succed_With_Setting_Correct_Name(string name)
        {
            // Arrange
            Meal meal = new();

            // Act
            meal.Name = name;

            // Assert
            meal.Should().NotBeNull();
            meal.Name.Should().NotBeNullOrWhiteSpace().And.Be(name);
        }

        [Theory]
        [IncorrectName]
        public void Failed_With_Setting_Incorrect_Name(string name)
        {
            // Arrange
            Meal meal = new();

            // Act
            Action action = () => meal.Name = name;

            // Assert
            meal.Name.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }
    }
}