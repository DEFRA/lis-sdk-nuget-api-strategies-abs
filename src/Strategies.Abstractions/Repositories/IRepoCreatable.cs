// <copyright file="IRepoCreatable.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;

public interface IRepoCreatable<TEntity> : IRepoCapability
    where TEntity : class
{
    Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken = default);
}
