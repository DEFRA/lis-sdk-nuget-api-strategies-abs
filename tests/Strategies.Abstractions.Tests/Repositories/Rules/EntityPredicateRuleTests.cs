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
        rule.Predicate.ShouldBeSameAs(predicate);
        rule.Description.ShouldBe(description);
        rule.ErrorMessage.ShouldBeNull();
        rule.Predicate(new TestPredicateEntity { IsActive = true }).ShouldBeTrue();
        rule.Predicate(new TestPredicateEntity { IsActive = false }).ShouldBeFalse();
    }

    [Fact]
    public void Constructor_WithErrorMessage_ShouldSetProperties()
    {
        // Arrange
        Func<TestPredicateEntity, bool> predicate = e => e.Id > 0;
        const string description = "Entity ID must be positive";
        const string errorMessage = "Invalid ID";

        // Act
        var rule = new EntityPredicateRule<TestPredicateEntity>(predicate, description, errorMessage);

        // Assert
        rule.Predicate.ShouldBeSameAs(predicate);
        rule.Description.ShouldBe(description);
        rule.ErrorMessage.ShouldBe(errorMessage);
    }

    public class TestPredicateEntity
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }
    }
}
