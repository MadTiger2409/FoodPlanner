using FluentAssertions;
using FoodPlanner.Domain.Entities;
using Xunit;

namespace FoodPlanner.Domain.UnitTests.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void Success_With_Creating_Category()
        {
            // Arrange
            Category category = null;

            // Act
            category = new();

            // Assert
            category.Should().NotBeNull();
            category.Id.Should().Be(default);
            category.Name.Should().Be(default);
            category.Products.Should().NotBeNull();
        }
    }
}
