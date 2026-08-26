// <copyright file="PagedEntitiesExtensionsTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Responses.Pagination;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories.Pagination;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Responses.Pagination;
using Shouldly;
using Xunit;

public class PagedEntitiesExtensionsTests
{
    [Fact]
    public void ToPagedResults_ShouldMapItemsAndPreservePaginationMetadata()
    {
        // Arrange
        var entities = new List<SourceEntity> { new() { Id = 1, Name = "Alice" }, new() { Id = 2, Name = "Bob" }, };

        var pagedEntities = new PagedEntities<SourceEntity>(
            items: entities,
            totalCount: 10,
            totalPages: 5,
            pageNumber: 1,
            pageSize: 2);

        // Act
        var pagedResults = pagedEntities.ToPagedResults(e => new TargetDto
        {
            DtoId = e.Id, DisplayName = e.Name.ToUpperInvariant(),
        });

        // Assert
        pagedResults.ShouldSatisfyAllConditions(
            x => x.TotalCount.ShouldBe(10),
            x => x.TotalPages.ShouldBe(5),
            x => x.PageNumber.ShouldBe(1),
            x => x.PageSize.ShouldBe(2));

        var resultList = pagedResults.Items.ToList();

        resultList.ShouldSatisfyAllConditions(
            x => x.Count.ShouldBe(2),
            x => x[0].DtoId.ShouldBe(1),
            x => x[0].DisplayName.ShouldBe("ALICE"),
            x => x[1].DtoId.ShouldBe(2),
            x => x[1].DisplayName.ShouldBe("BOB"));
    }

    private class SourceEntity
    {
        public int Id { get; init; }

        public string Name { get; init; } = string.Empty;
    }

    private class TargetDto
    {
        public int DtoId { get; init; }

        public string DisplayName { get; init; } = string.Empty;
    }
}
