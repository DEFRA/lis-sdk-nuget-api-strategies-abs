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
        failure.ShouldSatisfyAllConditions(
            x => x.PropertyName.ShouldBe("Email"),
            x => x.ErrorMessage.ShouldBe("Invalid email"),
            x => x.AttemptedValue.ShouldBe("test@"),
            x => x.Severity.ShouldBe(RequestValidationFailureSeverity.Error),
            x => x.CustomState.ShouldBeNull(),
            x => x.ErrorCode.ShouldBeNull(),
            x => x.FormattedMessagePlaceholderValues.ShouldBeNull());
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
        failure.ShouldSatisfyAllConditions(
            x => x.Severity.ShouldBe(RequestValidationFailureSeverity.Warning),
            x => x.PropertyName.ShouldBe("UpdatedName"),
            x => x.ErrorMessage.ShouldBe("Updated error"),
            x => x.AttemptedValue.ShouldBe("abc"),
            x => x.CustomState.ShouldBeSameAs(customState),
            x => x.ErrorCode.ShouldBe("ERR001"),
            x => x.FormattedMessagePlaceholderValues.ShouldBeSameAs(placeholders));
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
