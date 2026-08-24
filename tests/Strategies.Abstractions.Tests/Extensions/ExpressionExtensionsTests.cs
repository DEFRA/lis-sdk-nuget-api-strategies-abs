// <copyright file="ExpressionExtensionsTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Extensions;

using System.Linq.Expressions;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Extensions;
using Shouldly;
using Xunit;

public class ExpressionExtensionsTests
{
    [Fact]
    public void AndAlso_WhenLeftIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        Expression<Func<int, bool>> left = null!;
        Expression<Func<int, bool>> right = x => x > 0;

        // Act & Assert
        Should.Throw<ArgumentNullException>(() => left.AndAlso(right));
    }

    [Fact]
    public void AndAlso_WhenRightIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        Expression<Func<int, bool>> left = x => x > 0;
        Expression<Func<int, bool>> right = null!;

        // Act & Assert
        Should.Throw<ArgumentNullException>(() => left.AndAlso(right));
    }

    [Theory]
    [InlineData(5, true)]
    [InlineData(15, false)]
    [InlineData(-5, false)]
    public void AndAlso_CombinesTwoExpressionsCorrectly(int input, bool expected)
    {
        // Arrange
        Expression<Func<int, bool>> isPositive = x => x > 0;
        Expression<Func<int, bool>> isLessThanTen = y => y < 10;

        // Act
        var combined = isPositive.AndAlso(isLessThanTen);
        var func = combined.Compile();

        // Assert
        func(input).ShouldBe(expected);
    }
}
