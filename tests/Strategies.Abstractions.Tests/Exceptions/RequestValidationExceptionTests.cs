// <copyright file="RequestValidationExceptionTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Exceptions;

using System.Linq;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Validation;
using Shouldly;
using Xunit;

public class RequestValidationExceptionTests
{
    [Fact]
    public void Constructor_WithMessage_ShouldSetMessageAndEmptyErrors()
    {
        // Arrange
        const string message = "Validation failed";

        // Act
        var exception = new RequestValidationException(message);

        // Assert
        exception.Message.ShouldBe(message);
        exception.Errors.ShouldBeEmpty();
    }

    [Fact]
    public void Constructor_WithMessageAndErrors_ShouldSetMessageAndErrors()
    {
        // Arrange
        const string message = "Validation failed.";
        var errors = new List<RequestValidationFailure>
        {
            new("Name", "Name is required") { Severity = RequestValidationFailureSeverity.Error },
            new("Age", "Age must be positive") { Severity = RequestValidationFailureSeverity.Warning },
        };

        // Act
        var exception = new RequestValidationException(message, errors);

        // Assert
        exception.Message.ShouldBe(message);
        exception.Errors.Count().ShouldBe(2);
    }

    [Fact]
    public void Constructor_WithMessageErrorsAndAppendDefaultMessageFalse_ShouldKeepOriginalMessage()
    {
        // Arrange
        const string message = "Validation failed.";
        var errors = new List<RequestValidationFailure>
        {
            new("Name", "Name is required"),
        };

        // Act
        var exception = new RequestValidationException(message, errors, appendDefaultMessage: false);

        // Assert
        exception.Message.ShouldBe(message);
        exception.Errors.Count().ShouldBe(1);
    }

    [Fact]
    public void Constructor_WithMessageErrorsAndAppendDefaultMessageTrue_ShouldAppendErrorsToMessage()
    {
        // Arrange
        const string message = "Validation failed.";
        var errors = new List<RequestValidationFailure>
        {
            new("Email", "Invalid email format"),
        };

        // Act
        var exception = new RequestValidationException(message, errors, appendDefaultMessage: true);

        // Assert
        exception.Message.ShouldStartWith("Validation failed.");
        exception.Message.ShouldContain("-- Email: Invalid email format Severity: Error");
        exception.Errors.Count().ShouldBe(1);
    }

    [Fact]
    public void Constructor_WithErrorsOnly_ShouldBuildMessageFromErrors()
    {
        // Arrange
        var errors = new List<RequestValidationFailure>
        {
            new("Id", "Id is required"),
        };

        // Act
        var exception = new RequestValidationException(errors);

        // Assert
        exception.Message.ShouldContain("Validation failed: ");
        exception.Message.ShouldContain("-- Id: Id is required Severity: Error");
        exception.Errors.Count().ShouldBe(1);
    }
}
