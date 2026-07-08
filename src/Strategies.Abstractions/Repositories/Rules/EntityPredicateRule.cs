// <copyright file="EntityPredicateRule.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories.Rules;

using System.Diagnostics.CodeAnalysis;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Rules;

[ExcludeFromCodeCoverage]
public class EntityPredicateRule<TEntity> : IPredicateRule<TEntity>
    where TEntity : class
{
    public EntityPredicateRule(Func<TEntity, bool> predicate, string description, string? errorMessage = null)
    {
        this.Predicate = predicate;
        this.Description = description;
        this.ErrorMessage = errorMessage;
    }

    public Func<TEntity, bool> Predicate { get; }

    public string Description { get; }

    public string? ErrorMessage { get; }
}
