// <copyright file="IRepoPageable.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;

using System.Linq.Expressions;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories.Pagination;

public interface IRepoPageable<TEntity> : IRepoCapability
    where TEntity : class
{
    Task<PagedEntities<TEntity>> GetPaged<TOrderBy>(
        Expression<Func<TEntity, bool>> predicate,
        int pageNumber,
        int pageSize,
        Expression<Func<TEntity, TOrderBy>> orderBy,
        bool orderByDescending,
        CancellationToken cancellationToken = default);
}
