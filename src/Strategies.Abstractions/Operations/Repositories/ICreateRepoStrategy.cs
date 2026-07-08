// <copyright file="ICreateRepoStrategy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Repositories;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Rules.Builders;

public interface
    ICreateRepoStrategy<in TService, TEntity> : IRepoStrategy<TService, ICreateRepoStrategy<TService, TEntity>>
    where TService : class
    where TEntity : class
{
    ICreateRepoStrategy<TService, TEntity> WithRepository(IRepoCreatable<TEntity> repository);

    ICreateRepoStrategy<TService, TEntity> WithReferenceRules(Action<IReferenceRulesBuilder<TService>> builder);

    ICreateRepoStrategy<TService, TEntity> WithCreate(Func<TEntity> createAction);

    ICreateRepoStrategy<TService, TEntity> WithAfterCreate(Func<TEntity, Task> afterCreateAction);

    Task<TEntity> Execute();

    Task<TResult> ExecuteAndMap<TResult>(Func<TEntity, TResult> map)
        where TResult : class;
}
