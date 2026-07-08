// <copyright file="IPredicateRule.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Rules;

public interface IPredicateRule<in T>
    where T : class
{
    Func<T, bool> Predicate { get; }

    string Description { get; }

    string? ErrorMessage { get; }
}
