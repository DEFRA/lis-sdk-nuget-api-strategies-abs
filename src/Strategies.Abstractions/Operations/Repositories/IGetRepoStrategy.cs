// <copyright file="IGetRepoStrategy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Repositories;

using System.Linq.Expressions;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Rules.Builders;

public interface IGetRepoStrategy<in TService, TEntity> :
    IRepoStrategy<TService, IGetRepoStrategy<TService, TEntity>>
    where TService : class
    where TEntity : class
{
    IGetRepoStrategy<TService, TEntity> WithRepository<TRepository>(TRepository repository)
        where TRepository : IRepoGettable<TEntity>, IRepoUpdatable<TEntity>;

    IGetRepoStrategy<TService, TEntity> WithRequest(ILoggableById request);

    IGetRepoStrategy<TService, TEntity> WithEntityFilter(Expression<Func<TEntity, bool>> entityFilter);

    IGetRepoStrategy<TService, TEntity> WithExistenceRules(Action<IExistenceRulesBuilder<TService, TEntity>> builder);

    Task<TResult> ExecuteAndMap<TResult>(Func<TEntity, TResult> map)
        where TResult : class;
}
