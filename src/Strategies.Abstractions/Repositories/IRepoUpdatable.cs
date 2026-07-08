// <copyright file="IRepoUpdatable.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;

public interface IRepoUpdatable<TEntity> : IRepoCapability
    where TEntity : class
{
    Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default);
}
