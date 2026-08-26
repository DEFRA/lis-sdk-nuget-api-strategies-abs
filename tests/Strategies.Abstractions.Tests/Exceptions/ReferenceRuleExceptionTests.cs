// <copyright file="ReferenceRuleExceptionTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;
using Shouldly;
using Xunit;

public class ReferenceRuleExceptionTests
{
    [Fact]
    public void Constructor_WithMessage_ShouldSetMessageProperty()
    {
        // Arrange
        const string message = "Referenced entity not found";

        // Act
        var exception = new ReferenceRuleException(message);

        // Assert
        exception.Message.ShouldBe(message);
    }
}
