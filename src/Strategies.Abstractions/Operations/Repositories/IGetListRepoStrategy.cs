// <copyright file="IGetListRepoStrategy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Repositories;

using System.Linq.Expressions;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;

public interface
    IGetListRepoStrategy<in TService, TEntity> : IRepoStrategy<TService, IGetListRepoStrategy<TService, TEntity>>
    where TService : class
    where TEntity : class
{
    IGetListRepoStrategy<TService, TEntity> WithRepository<TRepository>(TRepository repository)
        where TRepository : IRepoListable<TEntity>;

    IGetListRepoStrategy<TService, TEntity> WithEntityFilter(Expression<Func<TEntity, bool>> entityFilter);

    Task<List<TEntity>> Execute();

    Task<List<TResult>> ExecuteAndMap<TResult>(Func<TEntity, TResult> map)
        where TResult : class;

    Task<TResult> ExecuteAndTransform<TResult>(Func<List<TEntity>, TResult> transform)
        where TResult : class;
}
