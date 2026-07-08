// <copyright file="PagedResults.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Responses.Pagination;

using System.ComponentModel;

public class PagedResults<T>
{
    public PagedResults(IEnumerable<T> items, int totalCount, int totalPages, int pageNumber, int pageSize)
    {
        Items = items;
        TotalCount = totalCount;
        TotalPages = totalPages;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    [Description("The collection of items in the returned page")]
    public IEnumerable<T> Items { get; }

    [Description("The total number of items in the results")]
    public int TotalCount { get; }

    [Description("The total number of pages in the results")]
    public int TotalPages { get; }

    [Description("The page number returned")]
    public int PageNumber { get; }

    [Description("The page size returned")]
    public int PageSize { get; }
}
