// <copyright file="PagedEntitiesTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Repositories.Pagination;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories.Pagination;
using Shouldly;
using Xunit;

public class PagedEntitiesTests
{
    [Fact]
    public void Constructor_ShouldSetAllPropertiesCorrectly()
    {
        // Arrange
        var items = new List<string> { "item1", "item2" };
        const int totalCount = 20;
        const int totalPages = 2;
        const int pageNumber = 1;
        const int pageSize = 10;

        // Act
        var pagedEntities = new PagedEntities<string>(items, totalCount, totalPages, pageNumber, pageSize);

        // Assert
        pagedEntities.Items.ShouldBeSameAs(items);
        pagedEntities.TotalCount.ShouldBe(totalCount);
        pagedEntities.TotalPages.ShouldBe(totalPages);
        pagedEntities.PageNumber.ShouldBe(pageNumber);
        pagedEntities.PageSize.ShouldBe(pageSize);
    }
}
