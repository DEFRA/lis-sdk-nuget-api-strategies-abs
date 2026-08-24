// <copyright file="SoapSchemaExceptionTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;
using Shouldly;
using Xunit;

public class SoapSchemaExceptionTests
{
    [Fact]
    public void Constructor_WithMessage_ShouldSetMessageProperty()
    {
        // Arrange
        const string message = "SOAP schema error";

        // Act
        var exception = new SoapSchemaException(message);

        // Assert
        exception.Message.ShouldBe(message);
        exception.InnerException.ShouldBeNull();
    }

    [Fact]
    public void Constructor_WithMessageAndInnerException_ShouldSetProperties()
    {
        // Arrange
        const string message = "SOAP schema error with inner";
        var innerException = new FormatException("Schema format error");

        // Act
        var exception = new SoapSchemaException(message, innerException);

        // Assert
        exception.Message.ShouldBe(message);
        exception.InnerException.ShouldBeSameAs(innerException);
    }
}
