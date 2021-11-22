using FluentAssertions;
using FoodPlanner.Domain.Entities;
using FoodPlanner.Domain.UnitTests.Common;
using FoodPlanner.Domain.UnitTests.Common.PlannedMeal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FoodPlanner.Domain.UnitTests.Tests
{
    public class PlannedMealTests
    {
        [Fact]
        public void Succed_With_Creating_PlannedMeal()
        {
            // Arrange
            PlannedMeal plannedMeal = null;

            // Act
            plannedMeal = new();

            // Assert
            plannedMeal.Should().NotBeNull();
            plannedMeal.Id.Should().Be(default);
            plannedMeal.MealId.Should().Be(default);
            plannedMeal.ScheduledFor.Should().Be(default);
            plannedMeal.OrdinalNumber.Should().Be(default);
        }

        [Theory]
        [PositiveId]
        public void Succed_With_Setting_Positive_Id(int id)
        {
            // Arrange
            PlannedMeal plannedMeal = new();

            // Act
            plannedMeal.Id = id;

            // Assert
            plannedMeal.Should().NotBeNull();
            plannedMeal.Id.Should().BePositive().And.Be(id);
        }

        [Theory]
        [NotPositiveId]
        public void Failed_With_Setting_Not_Positive_Id(int id)
        {
            // Arrange
            PlannedMeal plannedMeal = new();

            // Act
            Action action = () => plannedMeal.Id = id;

            // Assert
            plannedMeal.Id.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [PositiveId]
        public void Succed_With_Setting_Positive_MealId(int id)
        {
            // Arrange
            PlannedMeal plannedMeal = new();

            // Act
            plannedMeal.MealId = id;

            // Assert
            plannedMeal.Should().NotBeNull();
            plannedMeal.MealId.Should().BePositive().And.Be(id);
        }

        [Theory]
        [NotPositiveId]
        public void Failed_With_Setting_Not_Positive_MealId(int id)
        {
            // Arrange
            PlannedMeal plannedMeal = new();

            // Act
            Action action = () => plannedMeal.MealId = id;

            // Assert
            plannedMeal.MealId.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [PositiveId]
        public void Succed_With_Setting_Positive_OrdinalNumber(int ordinalNumber)
        {
            // Arrange
            PlannedMeal plannedMeal = new();

            // Act
            plannedMeal.OrdinalNumber = ordinalNumber;

            // Assert
            plannedMeal.Should().NotBeNull();
            plannedMeal.OrdinalNumber.Should().BePositive().And.Be(ordinalNumber);
        }

        [Theory]
        [NotPositiveId]
        public void Failed_With_Setting_Not_Positive_OrdinalNumber(int ordinalNumber)
        {
            // Arrange
            PlannedMeal plannedMeal = new();

            // Act
            Action action = () => plannedMeal.OrdinalNumber = ordinalNumber;

            // Assert
            plannedMeal.OrdinalNumber.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [CorrectScheduledForDate]
        public void Succed_With_Setting_Correct_ScheduledFor_Date(DateTime sheduledFor)
        {
            // Arrange
            PlannedMeal plannedMeal = new();

            // Act
            plannedMeal.ScheduledFor = sheduledFor;

            // Assert
            plannedMeal.Should().NotBeNull();
            plannedMeal.ScheduledFor.Should().NotBe(default).And.Be(sheduledFor);
        }
    }
}