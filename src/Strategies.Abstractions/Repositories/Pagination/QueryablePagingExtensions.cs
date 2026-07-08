// <copyright file="QueryablePagingExtensions.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories.Pagination;

using System.Linq.Expressions;

public static class QueryablePagingExtensions
{
    public static async Task<PagedEntities<TEntity>> ToPaged<TEntity, TOrderBy>(
        this IQueryable<TEntity> query,
        int pageNumber,
        int pageSize,
        Expression<Func<TEntity, TOrderBy>> orderBy,
        bool orderByDescending,
        Func<IQueryable<TEntity>, CancellationToken, Task<int>> countAsyncFunc,
        Func<IQueryable<TEntity>, CancellationToken, Task<List<TEntity>>> toListAsyncFunc,
        CancellationToken cancellationToken = default)
    {
        query = orderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

        var totalCount = await countAsyncFunc(query, cancellationToken);
        var totalPages = (totalCount + pageSize - 1) / pageSize;

        var pagedQuery = query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        var resultsList = await toListAsyncFunc(pagedQuery, cancellationToken);

        return new PagedEntities<TEntity>(resultsList, totalCount, totalPages, pageNumber, pageSize);
    }
}
