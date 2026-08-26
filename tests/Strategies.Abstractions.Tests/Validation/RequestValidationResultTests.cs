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
        result.ShouldSatisfyAllConditions(
            x => x.IsValid.ShouldBeFalse(),
            x => x.Errors.Count.ShouldBe(2),
            x => x.Errors.ShouldContain(failure1),
            x => x.Errors.ShouldContain(failure2));
    }

    [Fact]
    public void Constructor_WithEmptyFailures_ShouldBeValid()
    {
        // Act
        var result = new RequestValidationResult(Array.Empty<RequestValidationFailure>());

        // Assert
        result.ShouldSatisfyAllConditions(
            x => x.IsValid.ShouldBeTrue(),
            x => x.Errors.ShouldBeEmpty());
    }

    [Fact]
    public void Constructor_WithOtherResults_ShouldCombineErrorsAndDistinctRuleSets()
    {
        // Arrange
        var f1 = new RequestValidationFailure("Name", "Name is required");
        var f2 = new RequestValidationFailure("Age", "Age is invalid");

        var result1 = new RequestValidationResult([f1]) { RuleSetsExecuted = ["RuleSet1", "RuleSet2"], };
        var result2 = new RequestValidationResult([f2]) { RuleSetsExecuted = ["RuleSet2", "RuleSet3"], };
        var result3 = new RequestValidationResult(Array.Empty<RequestValidationFailure>())
        {
            RuleSetsExecuted = null!,
        };

        // Act
        var combinedFromArray = new RequestValidationResult([result1, result2, result3]);

        var combinedFromList =
            new RequestValidationResult(new List<RequestValidationResult> { result1, result2, result3 });

        // Assert
        combinedFromArray.ShouldSatisfyAllConditions(
            x => x.Errors.Count.ShouldBe(2),
            x => x.Errors.ShouldContain(f1),
            x => x.Errors.ShouldContain(f2),
            x => x.RuleSetsExecuted.Length.ShouldBe(3),
            x => x.RuleSetsExecuted.ShouldContain("RuleSet1"),
            x => x.RuleSetsExecuted.ShouldContain("RuleSet2"),
            x => x.RuleSetsExecuted.ShouldContain("RuleSet3"));

        combinedFromList.ShouldSatisfyAllConditions(
            x => x.Errors.Count.ShouldBe(2),
            x => x.RuleSetsExecuted.Length.ShouldBe(3),
            x => x.RuleSetsExecuted.ShouldContain("RuleSet1"),
            x => x.RuleSetsExecuted.ShouldContain("RuleSet2"),
            x => x.RuleSetsExecuted.ShouldContain("RuleSet3"));
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
        result.Errors = [f1, null!];

        // Assert
        result.ShouldSatisfyAllConditions(
            x => x.Errors.Count.ShouldBe(1),
            x => x.Errors.ShouldContain(f1));
    }

    [Fact]
    public void ToString_ShouldReturnNewlinedErrorMessages()
    {
        // Arrange
        var f1 = new RequestValidationFailure("Prop1", "Error 1");
        var f2 = new RequestValidationFailure("Prop2", "Error 2");
        var result = new RequestValidationResult([f1, f2]);

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
        var result = new RequestValidationResult([f1, f2, f3]);

        // Act
        var dict = result.ToDictionary();

        // Assert
        dict.ShouldSatisfyAllConditions(
            x => x.Count.ShouldBe(2),
            x => x.ContainsKey("Name").ShouldBeTrue(),
            x => x["Name"].ShouldBe(["Name is required", "Name is too short"]),
            x => x.ContainsKey("Age").ShouldBeTrue(),
            x => x["Age"].ShouldBe(["Age must be positive"]));
    }
}
