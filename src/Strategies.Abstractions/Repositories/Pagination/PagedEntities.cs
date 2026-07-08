// <copyright file="PagedEntities.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories.Pagination;

public class PagedEntities<TEntity>
{
    public PagedEntities(List<TEntity> items, int totalCount, int totalPages, int pageNumber, int pageSize)
    {
        Items = items;
        TotalCount = totalCount;
        TotalPages = totalPages;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public List<TEntity> Items { get; }

    public int TotalCount { get; }

    public int TotalPages { get; }

    public int PageNumber { get; }

    public int PageSize { get; }
}
