// <copyright file="PagedQueryTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Requests.Pagination;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests.Pagination;
using Shouldly;
using Xunit;

public class PagedQueryTests
{
    [Fact]
    public void Defaults_ShouldBeExpected()
    {
        // Act
        var query = new PagedQuery();

        // Assert
        query.ShouldSatisfyAllConditions(
            x => x.PageNumber.ShouldBe(0),
            x => x.PageSize.ShouldBe(0),
            x => x.OrderBy.ShouldBe(string.Empty),
            x => x.OrderByDescending.ShouldBe(false));
    }

    [Fact]
    public void Properties_ShouldGetAndSetCorrectly()
    {
        // Arrange & Act
        var query = new PagedQuery
        {
            PageNumber = 2, PageSize = 25, OrderBy = "CreatedDate", OrderByDescending = true,
        };

        // Assert
        query.ShouldSatisfyAllConditions(
            x => x.PageNumber.ShouldBe(2),
            x => x.PageSize.ShouldBe(25),
            x => x.OrderBy.ShouldBe("CreatedDate"),
            x => x.OrderByDescending.ShouldBe(true));
    }
}
