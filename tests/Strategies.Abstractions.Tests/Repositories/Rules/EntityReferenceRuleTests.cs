// <copyright file="EntityReferenceRuleTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Repositories.Rules;

using System.Linq.Expressions;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories.Rules;
using NSubstitute;
using Shouldly;
using Xunit;

public class EntityReferenceRuleTests
{
    [Fact]
    public async Task Validator_WhenEntityExists_ShouldReturnTrue()
    {
        // Arrange
        var repository = Substitute.For<IRepoGettable<TestEntity>>();
        Expression<Func<TestEntity, bool>> predicate = e => e.Id == 1;
        const string description = "Entity reference must exist";
        var existingEntity = new TestEntity { Id = 1 };

        repository.GetSingle(predicate, Arg.Any<CancellationToken>())
            .Returns(Task.FromResult<TestEntity?>(existingEntity));

        var rule = new EntityReferenceRule<TestEntity>(repository, predicate, description);

        // Act
        var result = await rule.Validator(CancellationToken.None);

        // Assert
        rule.Description.ShouldBe(description);
        result.ShouldBeTrue();
    }

    [Fact]
    public async Task Validator_WhenEntityDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        var repository = Substitute.For<IRepoGettable<TestEntity>>();
        Expression<Func<TestEntity, bool>> predicate = e => e.Id == 999;
        const string description = "Entity reference must exist";

        repository.GetSingle(predicate, Arg.Any<CancellationToken>())
            .Returns(Task.FromResult<TestEntity?>(null));

        var rule = new EntityReferenceRule<TestEntity>(repository, predicate, description);

        // Act
        var result = await rule.Validator(CancellationToken.None);

        // Assert
        rule.Description.ShouldBe(description);
        result.ShouldBeFalse();
    }

    public class TestEntity
    {
        public int Id { get; set; }
    }
}
