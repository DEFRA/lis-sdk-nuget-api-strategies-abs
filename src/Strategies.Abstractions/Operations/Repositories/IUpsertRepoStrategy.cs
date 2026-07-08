// <copyright file="IUpsertRepoStrategy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Repositories;

using System.Linq.Expressions;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests.Capabilities;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Rules.Builders;

public interface IUpsertRepoStrategy<in TService, TEntity> :
    IRepoStrategy<TService, IUpsertRepoStrategy<TService, TEntity>>
    where TService : class
    where TEntity : class
{
    IUpsertRepoStrategy<TService, TEntity> WithRepository<TRepository>(TRepository repository)
        where TRepository : IRepoGettable<TEntity>, IRepoCreatable<TEntity>, IRepoUpdatable<TEntity>;

    IUpsertRepoStrategy<TService, TEntity> WithRequest(ILoggableById request);

    IUpsertRepoStrategy<TService, TEntity> WithEntityFilter(Expression<Func<TEntity, bool>> entityFilter);

    IUpsertRepoStrategy<TService, TEntity> WithExistenceRules(
        Action<IExistenceRulesBuilder<TService, TEntity>> builder);

    IUpsertRepoStrategy<TService, TEntity> WithReferenceRules(Action<IReferenceRulesBuilder<TService>> builder);

    IUpsertRepoStrategy<TService, TEntity> WithConflictRules(
        Action<IConflictRulesBuilder<TService, TEntity>> builder);

    IUpsertRepoStrategy<TService, TEntity> WithBusinessRules(
        Action<IBusinessRulesBuilder<TService, TEntity>> builder);

    IUpsertRepoStrategy<TService, TEntity> WithCreate(Func<TEntity> createAction);

    IUpsertRepoStrategy<TService, TEntity> WithUpdate(Action<TEntity> updateAction);

    IUpsertRepoStrategy<TService, TEntity> WithAfterCreate(Func<TEntity, Task> afterCreateAction);

    IUpsertRepoStrategy<TService, TEntity> WithAfterUpdate(Func<TEntity, Task> afterUpdateAction);

    Task<TEntity> Execute();

    Task<TResult> ExecuteAndMap<TResult>(Func<TEntity, TResult> map)
        where TResult : class;
}
