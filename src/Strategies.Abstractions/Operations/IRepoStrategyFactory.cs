// <copyright file="IRepoStrategyFactory.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Base;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Repositories;

public interface IRepoStrategyFactory<in TService> : IStrategyFactory<TService, IRepoStrategyFactory<TService>>
    where TService : class
{
    IRepoStrategyFactory<TService> WithDefaultEntityDescription(string entityDescription);

    ICreateRepoStrategy<TService, TEntity> BuildCreateStrategy<TEntity>()
        where TEntity : class;

    IUpdateRepoStrategy<TService, TEntity> BuildUpdateStrategy<TEntity>()
        where TEntity : class;

    IUpsertRepoStrategy<TService, TEntity> BuildUpsertStrategy<TEntity>()
        where TEntity : class;

    IGetRepoStrategy<TService, TEntity> BuildGetStrategy<TEntity>()
        where TEntity : class;

    IGetListRepoStrategy<TService, TEntity> BuildGetListStrategy<TEntity>()
        where TEntity : class;

    IGetPagedRepoStrategy<TService, TEntity> BuildGetPagedStrategy<TEntity>()
        where TEntity : class;
}
