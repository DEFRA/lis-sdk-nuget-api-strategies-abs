// <copyright file="EntityReferenceRule.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories.Rules;

using System.Linq.Expressions;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Rules;

public class EntityReferenceRule<TEntity> : IReferenceRule
    where TEntity : class
{
    public EntityReferenceRule(
        IRepoGettable<TEntity> repository,
        Expression<Func<TEntity, bool>> predicate,
        string description)
    {
        Description = description;
        Predicate = predicate;
        Repository = repository;
    }

    public string Description { get; }

    public Func<CancellationToken, Task<bool>> Validator =>
        async cancellationToken =>
            await Repository.GetSingle(Predicate, cancellationToken) != null;

    private IRepoGettable<TEntity> Repository { get; }

    private Expression<Func<TEntity, bool>> Predicate { get; }
}
