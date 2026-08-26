// <copyright file="ExistenceRuleExceptionTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;
using Shouldly;
using Xunit;

public class ExistenceRuleExceptionTests
{
    [Fact]
    public void Constructor_WithMessage_ShouldSetMessageProperty()
    {
        // Arrange
        const string message = "Entity does not exist";

        // Act
        var exception = new ExistenceRuleException(message);

        // Assert
        exception.Message.ShouldBe(message);
    }
}
