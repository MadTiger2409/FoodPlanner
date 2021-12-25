using FluentAssertions;
using FoodPlanner.Domain.Entities;
using FoodPlanner.Domain.UnitTests.Common;
using FoodPlanner.Domain.UnitTests.Common.PlannedMeal;
using System;
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
        public void Succed_With_Setting_Positive_OrdinalNumber(int ordinalNumber)
        {
            // Arrange
            PlannedMeal plannedMeal = new();

            // Act
            plannedMeal.OrdinalNumber = (uint)ordinalNumber;

            // Assert
            plannedMeal.Should().NotBeNull();
            plannedMeal.OrdinalNumber.Should().BePositive().And.Be((uint)ordinalNumber);
        }

        [Fact]
        public void Failed_With_Setting_Not_Positive_OrdinalNumber()
        {
            // Arrange
            uint ordinalNumber = 0;
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