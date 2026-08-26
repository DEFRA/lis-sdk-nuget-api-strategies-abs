// <copyright file="EntityPredicateRuleTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Repositories.Rules;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories.Rules;
using Shouldly;
using Xunit;

public class EntityPredicateRuleTests
{
    [Fact]
    public void Constructor_WithoutErrorMessage_ShouldSetProperties()
    {
        // Arrange
        Func<TestPredicateEntity, bool> predicate = e => e.IsActive;

        const string description = "Entity must be active";

        // Act
        var rule = new EntityPredicateRule<TestPredicateEntity>(predicate, description);

        // Assert
        rule.ShouldSatisfyAllConditions(
            x => x.Predicate.ShouldBeSameAs(predicate),
            x => x.Description.ShouldBe(description),
            x => x.ErrorMessage.ShouldBeNull(),
            x => x.Predicate(new TestPredicateEntity { IsActive = true }).ShouldBeTrue(),
            x => x.Predicate(new TestPredicateEntity { IsActive = false }).ShouldBeFalse());
    }

    [Fact]
    public void Constructor_WithErrorMessage_ShouldSetProperties()
    {
        // Arrange
        Func<TestPredicateEntity, bool> predicate = _ => TestPredicateEntity.Id > 0;

        const string description = "Entity ID must be positive";
        const string errorMessage = "Invalid ID";

        // Act
        var rule = new EntityPredicateRule<TestPredicateEntity>(predicate, description, errorMessage);

        // Assert
        rule.ShouldSatisfyAllConditions(
            x => x.Predicate.ShouldBeSameAs(predicate),
            x => x.Description.ShouldBe(description),
            x => x.ErrorMessage.ShouldBe(errorMessage));
    }

    private class TestPredicateEntity
    {
        public static int Id => 0;

        public bool IsActive { get; init; }
    }
}
