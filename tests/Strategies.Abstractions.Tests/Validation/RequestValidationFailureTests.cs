// <copyright file="RequestValidationFailureTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Validation;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Validation;
using Shouldly;
using Xunit;

public class RequestValidationFailureTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Act
        var failure = new RequestValidationFailure("Email", "Invalid email", "test@");

        // Assert
        failure.PropertyName.ShouldBe("Email");
        failure.ErrorMessage.ShouldBe("Invalid email");
        failure.AttemptedValue.ShouldBe("test@");
        failure.Severity.ShouldBe(RequestValidationFailureSeverity.Error);
        failure.CustomState.ShouldBeNull();
        failure.ErrorCode.ShouldBeNull();
        failure.FormattedMessagePlaceholderValues.ShouldBeNull();
    }

    [Fact]
    public void Properties_ShouldGetAndSetCorrectly()
    {
        // Arrange
        var placeholders = new Dictionary<string, object> { { "Min", 5 } };
        var customState = new { Field = "Test" };

        // Act
        var failure = new RequestValidationFailure("Name", "Name is too short")
        {
            Severity = RequestValidationFailureSeverity.Warning,
            PropertyName = "UpdatedName",
            ErrorMessage = "Updated error",
            AttemptedValue = "abc",
            CustomState = customState,
            ErrorCode = "ERR001",
            FormattedMessagePlaceholderValues = placeholders,
        };

        // Assert
        failure.Severity.ShouldBe(RequestValidationFailureSeverity.Warning);
        failure.PropertyName.ShouldBe("UpdatedName");
        failure.ErrorMessage.ShouldBe("Updated error");
        failure.AttemptedValue.ShouldBe("abc");
        failure.CustomState.ShouldBeSameAs(customState);
        failure.ErrorCode.ShouldBe("ERR001");
        failure.FormattedMessagePlaceholderValues.ShouldBeSameAs(placeholders);
    }

    [Fact]
    public void ToString_ShouldReturnErrorMessage()
    {
        // Arrange
        const string errorMessage = "Field is required";
        var failure = new RequestValidationFailure("Field", errorMessage);

        // Act
        var result = failure.ToString();

        // Assert
        result.ShouldBe(errorMessage);
    }
}
