// <copyright file="IRepoListable.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;

using System.Linq.Expressions;

public interface IRepoListable<TEntity> : IRepoCapability
    where TEntity : class
{
    Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}
