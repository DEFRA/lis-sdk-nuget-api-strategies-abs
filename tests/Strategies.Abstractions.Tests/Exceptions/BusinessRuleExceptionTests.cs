// <copyright file="BusinessRuleExceptionTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;
using Shouldly;
using Xunit;

public class BusinessRuleExceptionTests
{
    [Fact]
    public void Constructor_WithMessage_ShouldSetMessageProperty()
    {
        // Arrange
        const string message = "Business rule violated";

        // Act
        var exception = new BusinessRuleException(message);

        // Assert
        exception.Message.ShouldBe(message);
    }
}
