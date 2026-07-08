// <copyright file="IGetPagedRepoStrategy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Repositories;

using System.Linq.Expressions;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests.Pagination;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Responses.Pagination;

public interface
    IGetPagedRepoStrategy<in TService, TEntity> :
    IRepoStrategy<TService, IGetPagedRepoStrategy<TService, TEntity>>
    where TService : class
    where TEntity : class
{
    IGetPagedRepoStrategy<TService, TEntity> WithRepository<TRepository>(TRepository repository)
        where TRepository : IRepoPageable<TEntity>;

    IGetPagedRepoStrategy<TService, TEntity> WithRequest<TRequest>(TRequest request)
        where TRequest : PagedQuery;

    IGetPagedRepoStrategy<TService, TEntity> WithEntityFilter(Expression<Func<TEntity, bool>> entityFilter);

    Task<PagedResults<TResult>> ExecuteAndMap<TResult, TOrderBy>(
        Func<TEntity, TResult> map,
        Expression<Func<TEntity, TOrderBy>> orderBy)
        where TResult : class;
}
