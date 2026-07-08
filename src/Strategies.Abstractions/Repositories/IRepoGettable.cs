// <copyright file="IRepoGettable.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;

using System.Linq.Expressions;

public interface IRepoGettable<TEntity> : IRepoCapability
    where TEntity : class
{
    Task<TEntity?> GetSingle(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}
