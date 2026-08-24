// <copyright file="QueryablePagingExtensionsTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Repositories.Pagination;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories.Pagination;
using Shouldly;
using Xunit;

public class QueryablePagingExtensionsTests
{
    [Fact]
    public async Task ToPaged_Ascending_ShouldOrderAndPageCorrectly()
    {
        // Arrange
        var data = new List<TestItem>
        {
            new() { Id = 3, Name = "Item C" },
            new() { Id = 1, Name = "Item A" },
            new() { Id = 2, Name = "Item B" },
            new() { Id = 5, Name = "Item E" },
            new() { Id = 4, Name = "Item D" },
        }.AsQueryable();

        // Act
        var result = await data.ToPaged(
            pageNumber: 2,
            pageSize: 2,
            orderBy: x => x.Id,
            orderByDescending: false,
            countAsyncFunc: (q, ct) => Task.FromResult(q.Count()),
            toListAsyncFunc: (q, ct) => Task.FromResult(q.ToList()),
            cancellationToken: TestContext.Current.CancellationToken);

        // Assert
        result.TotalCount.ShouldBe(5);
        result.TotalPages.ShouldBe(3);
        result.PageNumber.ShouldBe(2);
        result.PageSize.ShouldBe(2);
        result.Items.Count.ShouldBe(2);
        result.Items[0].Id.ShouldBe(3);
        result.Items[1].Id.ShouldBe(4);
    }

    [Fact]
    public async Task ToPaged_Descending_ShouldOrderDescendingAndPageCorrectly()
    {
        // Arrange
        var data = new List<TestItem>
        {
            new() { Id = 3, Name = "Item C" },
            new() { Id = 1, Name = "Item A" },
            new() { Id = 2, Name = "Item B" },
            new() { Id = 5, Name = "Item E" },
            new() { Id = 4, Name = "Item D" },
        }.AsQueryable();

        // Act
        var result = await data.ToPaged(
            pageNumber: 1,
            pageSize: 2,
            orderBy: x => x.Id,
            orderByDescending: true,
            countAsyncFunc: (q, ct) => Task.FromResult(q.Count()),
            toListAsyncFunc: (q, ct) => Task.FromResult(q.ToList()),
            cancellationToken: TestContext.Current.CancellationToken);

        // Assert
        result.TotalCount.ShouldBe(5);
        result.TotalPages.ShouldBe(3);
        result.PageNumber.ShouldBe(1);
        result.PageSize.ShouldBe(2);
        result.Items.Count.ShouldBe(2);
        result.Items[0].Id.ShouldBe(5);
        result.Items[1].Id.ShouldBe(4);
    }

    [Theory]
    [InlineData(0, 10, 0)]
    [InlineData(10, 10, 1)]
    [InlineData(11, 10, 2)]
    [InlineData(20, 10, 2)]
    public async Task ToPaged_TotalPagesCalculation_ShouldBeAccurate(int totalCount, int pageSize, int expectedTotalPages)
    {
        // Arrange
        var items = Enumerable.Range(1, totalCount).Select(i => new TestItem { Id = i }).AsQueryable();

        // Act
        var result = await items.ToPaged(
            pageNumber: 1,
            pageSize: pageSize,
            orderBy: x => x.Id,
            orderByDescending: false,
            countAsyncFunc: (q, ct) => Task.FromResult(q.Count()),
            toListAsyncFunc: (q, ct) => Task.FromResult(q.ToList()),
            cancellationToken: TestContext.Current.CancellationToken);

        // Assert
        result.TotalPages.ShouldBe(expectedTotalPages);
        result.TotalCount.ShouldBe(totalCount);
    }

    private class TestItem
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
