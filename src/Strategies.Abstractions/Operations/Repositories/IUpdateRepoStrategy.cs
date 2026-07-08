// <copyright file="IUpdateRepoStrategy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Repositories;

using System.Linq.Expressions;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests.Capabilities;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Rules.Builders;

public interface IUpdateRepoStrategy<in TService, TEntity> :
    IRepoStrategy<TService, IUpdateRepoStrategy<TService, TEntity>>
    where TService : class
    where TEntity : class
{
    IUpdateRepoStrategy<TService, TEntity> WithRepository<TRepository>(TRepository repository)
        where TRepository : IRepoGettable<TEntity>, IRepoUpdatable<TEntity>;

    IUpdateRepoStrategy<TService, TEntity> WithRequest(ILoggableById request);

    IUpdateRepoStrategy<TService, TEntity> WithEntityFilter(Expression<Func<TEntity, bool>> entityFilter);

    IUpdateRepoStrategy<TService, TEntity> WithExistenceRules(
        Action<IExistenceRulesBuilder<TService, TEntity>> builder);

    IUpdateRepoStrategy<TService, TEntity> WithReferenceRules(Action<IReferenceRulesBuilder<TService>> builder);

    IUpdateRepoStrategy<TService, TEntity> WithConflictRules(
        Action<IConflictRulesBuilder<TService, TEntity>> builder);

    IUpdateRepoStrategy<TService, TEntity> WithBusinessRules(
        Action<IBusinessRulesBuilder<TService, TEntity>> builder);

    IUpdateRepoStrategy<TService, TEntity> WithBeforeUpdate(Func<TEntity, Task> beforeUpdateAction);

    IUpdateRepoStrategy<TService, TEntity> WithUpdate(Action<TEntity> updateAction);

    IUpdateRepoStrategy<TService, TEntity> WithAfterUpdate(Func<TEntity, Task> afterUpdateAction);

    Task<TEntity> Execute();

    Task<TResult> ExecuteAndMap<TResult>(Func<TEntity, TResult> map)
        where TResult : class;
}
