// <copyright file="RequestValidationResultTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Validation;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Validation;
using Shouldly;
using Xunit;

public class RequestValidationResultTests
{
    [Fact]
    public void Constructor_WithFailures_ShouldFilterNullsAndSetErrors()
    {
        // Arrange
        var failure1 = new RequestValidationFailure("Prop1", "Error 1");
        var failure2 = new RequestValidationFailure("Prop2", "Error 2");
        var failures = new[] { failure1, null!, failure2 };

        // Act
        var result = new RequestValidationResult(failures);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(2);
        result.Errors.ShouldContain(failure1);
        result.Errors.ShouldContain(failure2);
    }

    [Fact]
    public void Constructor_WithEmptyFailures_ShouldBeValid()
    {
        // Act
        var result = new RequestValidationResult(Array.Empty<RequestValidationFailure>());

        // Assert
        result.IsValid.ShouldBeTrue();
        result.Errors.ShouldBeEmpty();
    }

    [Fact]
    public void Constructor_WithOtherResults_ShouldCombineErrorsAndDistinctRuleSets()
    {
        // Arrange
        var f1 = new RequestValidationFailure("Name", "Name is required");
        var f2 = new RequestValidationFailure("Age", "Age is invalid");

        var result1 = new RequestValidationResult(new[] { f1 })
        {
            RuleSetsExecuted = new[] { "RuleSet1", "RuleSet2" },
        };

        var result2 = new RequestValidationResult(new[] { f2 })
        {
            RuleSetsExecuted = new[] { "RuleSet2", "RuleSet3" },
        };

        var result3 = new RequestValidationResult(Array.Empty<RequestValidationFailure>())
        {
            RuleSetsExecuted = null!,
        };

        // Act - testing with array
        var combinedFromArray = new RequestValidationResult(new[] { result1, result2, result3 });

        // Act - testing with List (non-array enumerable)
        var combinedFromList = new RequestValidationResult(new List<RequestValidationResult> { result1, result2, result3 });

        // Assert
        combinedFromArray.Errors.Count.ShouldBe(2);
        combinedFromArray.Errors.ShouldContain(f1);
        combinedFromArray.Errors.ShouldContain(f2);
        combinedFromArray.RuleSetsExecuted.Length.ShouldBe(3);
        combinedFromArray.RuleSetsExecuted.ShouldContain("RuleSet1");
        combinedFromArray.RuleSetsExecuted.ShouldContain("RuleSet2");
        combinedFromArray.RuleSetsExecuted.ShouldContain("RuleSet3");

        combinedFromList.Errors.Count.ShouldBe(2);
        combinedFromList.RuleSetsExecuted.Length.ShouldBe(3);
    }

    [Fact]
    public void Errors_Setter_WhenNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var result = new RequestValidationResult(Array.Empty<RequestValidationFailure>());

        // Act & Assert
        Should.Throw<ArgumentNullException>(() => result.Errors = null!);
    }

    [Fact]
    public void Errors_Setter_ShouldFilterNullFailures()
    {
        // Arrange
        var result = new RequestValidationResult(Array.Empty<RequestValidationFailure>());
        var f1 = new RequestValidationFailure("Prop", "Error");

        // Act
        result.Errors = new List<RequestValidationFailure> { f1, null! };

        // Assert
        result.Errors.Count.ShouldBe(1);
        result.Errors.ShouldContain(f1);
    }

    [Fact]
    public void ToString_ShouldReturnNewlinedErrorMessages()
    {
        // Arrange
        var f1 = new RequestValidationFailure("Prop1", "Error 1");
        var f2 = new RequestValidationFailure("Prop2", "Error 2");
        var result = new RequestValidationResult(new[] { f1, f2 });

        // Act
        var stringRepresentation = result.ToString();

        // Assert
        stringRepresentation.ShouldBe($"Error 1{Environment.NewLine}Error 2");
    }

    [Fact]
    public void ToDictionary_ShouldGroupByPropertyName()
    {
        // Arrange
        var f1 = new RequestValidationFailure("Name", "Name is required");
        var f2 = new RequestValidationFailure("Name", "Name is too short");
        var f3 = new RequestValidationFailure("Age", "Age must be positive");
        var result = new RequestValidationResult(new[] { f1, f2, f3 });

        // Act
        var dict = result.ToDictionary();

        // Assert
        dict.Count.ShouldBe(2);
        dict.ContainsKey("Name").ShouldBeTrue();
        dict["Name"].ShouldBe(new[] { "Name is required", "Name is too short" });
        dict.ContainsKey("Age").ShouldBeTrue();
        dict["Age"].ShouldBe(new[] { "Age must be positive" });
    }
}
