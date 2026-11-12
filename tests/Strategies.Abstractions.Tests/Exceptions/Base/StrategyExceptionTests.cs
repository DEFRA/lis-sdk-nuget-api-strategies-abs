// <copyright file="StrategyExceptionTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Exceptions.Base;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public class StrategyExceptionTests
{
    [Fact]
    public void Constructor_WithMessage_ShouldSetMessageProperty()
    {
        // Arrange
        const string message = "Strategy error";

        // Act
        var exception = new TestStrategyException(message);

        // Assert
        exception.ShouldSatisfyAllConditions(
            x => x.Message.ShouldBe(message),
            x => x.InnerException.ShouldBeNull());
    }

    [Fact]
    public void Constructor_WithMessageAndInnerException_ShouldSetProperties()
    {
        // Arrange
        const string message = "Strategy error with inner";
        var innerException = new InvalidOperationException("Inner error");

        // Act
        var exception = new TestStrategyException(message, innerException);

        // Assert
        exception.ShouldSatisfyAllConditions(
            x => x.Message.ShouldBe(message),
            x => x.InnerException.ShouldBeSameAs(innerException));
    }

    private sealed class TestStrategyException : StrategyException
    {
        public TestStrategyException(string message)
            : base(message)
        {
        }

        public TestStrategyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
