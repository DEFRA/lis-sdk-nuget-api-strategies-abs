// <copyright file="StrategyPreConditionExceptionTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Exceptions.Base;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public class StrategyPreConditionExceptionTests
{
    [Fact]
    public void Constructor_WithMessage_ShouldSetMessageProperty()
    {
        // Arrange
        const string message = "Strategy pre-condition error";

        // Act
        var exception = new TestStrategyPreConditionException(message);

        // Assert
        exception.ShouldSatisfyAllConditions(
            x => x.Message.ShouldBe(message),
            x => x.InnerException.ShouldBeNull());
    }

    [Fact]
    public void Constructor_WithMessageAndInnerException_ShouldSetProperties()
    {
        // Arrange
        const string message = "Strategy pre-condition error with inner";
        var innerException = new InvalidOperationException("Inner error");

        // Act
        var exception = new TestStrategyPreConditionException(message, innerException);

        // Assert
        exception.ShouldSatisfyAllConditions(
            x => x.Message.ShouldBe(message),
            x => x.InnerException.ShouldBeSameAs(innerException));
    }

    private sealed class TestStrategyPreConditionException : StrategyPreConditionException
    {
        public TestStrategyPreConditionException(string message)
            : base(message)
        {
        }

        public TestStrategyPreConditionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
