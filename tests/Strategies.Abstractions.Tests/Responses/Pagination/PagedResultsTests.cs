// <copyright file="PagedResultsTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Responses.Pagination;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Responses.Pagination;
using Shouldly;
using Xunit;

public class PagedResultsTests
{
    [Fact]
    public void Constructor_ShouldSetAllPropertiesCorrectly()
    {
        // Arrange
        var items = new[] { "result1", "result2" };

        const int totalCount = 50;
        const int totalPages = 5;
        const int pageNumber = 2;
        const int pageSize = 10;

        // Act
        var pagedResults = new PagedResults<string>(items, totalCount, totalPages, pageNumber, pageSize);

        // Assert
        pagedResults.ShouldSatisfyAllConditions(
            x => x.Items.ShouldBeSameAs(items),
            x => x.TotalCount.ShouldBe(totalCount),
            x => x.TotalPages.ShouldBe(totalPages),
            x => x.PageNumber.ShouldBe(pageNumber),
            x => x.PageSize.ShouldBe(pageSize));
    }
}
