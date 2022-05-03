using FluentAssertions;
using FoodPlanner.Domain.Entities;
using FoodPlanner.Domain.Tests.TestData.Common;
using FoodPlanner.Domain.Tests.TestData.Category;
using System;
using System.Collections.Generic;
using Xunit;

namespace FoodPlanner.Domain.Tests.UnitTests
{
    [Trait("Unit tests", "Entities")]
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

        [Theory]
        [ProductsMinimumData]
        public void Succed_With_Setting_Products_For_Category(List<Product> products)
        {
            // Arrange
            Category category = new();

            // Act
            category.Products = products;

            // Assert
            category.Products.Should().NotBeNullOrEmpty().And.BeSameAs(products);
        }

        [Theory]
        [CorrectCategoryName]
        public void Succed_With_Setting_Correct_Name(string name)
        {
            // Arrange
            Category category = new();

            // Act
            category.Name = name;

            // Assert
            category.Should().NotBeNull();
            category.Name.Should().NotBeNullOrWhiteSpace().And.Be(name);
        }

        [Theory]
        [IncorrectName]
        public void Failed_With_Setting_Incorrect_Name(string name)
        {
            // Arrange
            Category category = new();

            // Act
            Action action = () => category.Name = name;

            // Assert
            category.Name.Should().Be(default);
            action.Should().Throw<ArgumentException>();
        }
    }
}