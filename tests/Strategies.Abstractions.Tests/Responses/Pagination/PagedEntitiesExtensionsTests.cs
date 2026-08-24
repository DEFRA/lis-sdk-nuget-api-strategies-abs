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
        var entities = new List<SourceEntity>
        {
            new() { Id = 1, Name = "Alice" },
            new() { Id = 2, Name = "Bob" },
        };

        var pagedEntities = new PagedEntities<SourceEntity>(
            items: entities,
            totalCount: 10,
            totalPages: 5,
            pageNumber: 1,
            pageSize: 2);

        // Act
        var pagedResults = pagedEntities.ToPagedResults(e => new TargetDto
        {
            DtoId = e.Id,
            DisplayName = e.Name.ToUpperInvariant(),
        });

        // Assert
        pagedResults.TotalCount.ShouldBe(10);
        pagedResults.TotalPages.ShouldBe(5);
        pagedResults.PageNumber.ShouldBe(1);
        pagedResults.PageSize.ShouldBe(2);

        var resultList = pagedResults.Items.ToList();
        resultList.Count.ShouldBe(2);
        resultList[0].DtoId.ShouldBe(1);
        resultList[0].DisplayName.ShouldBe("ALICE");
        resultList[1].DtoId.ShouldBe(2);
        resultList[1].DisplayName.ShouldBe("BOB");
    }

    private class SourceEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }

    private class TargetDto
    {
        public int DtoId { get; set; }

        public string DisplayName { get; set; } = string.Empty;
    }
}
