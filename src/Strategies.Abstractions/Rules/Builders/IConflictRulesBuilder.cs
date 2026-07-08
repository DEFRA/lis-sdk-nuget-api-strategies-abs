// <copyright file="IConflictRulesBuilder.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Rules.Builders;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests.Capabilities;
using Microsoft.Extensions.Logging;

public interface IConflictRulesBuilder<in TService, T>
    where TService : class
    where T : class
{
    IConflictRulesBuilder<TService, T> Add(
        Func<T, bool> expression,
        string description,
        string? errorMessage = null);

    IConflictRulesBuilder<TService, T> Add(IPredicateRule<T> predicateRule);

    void Validate(
        ILoggableById request,
        T modelToValidate,
        string actionDescription,
        string modelDescription,
        ILogger<TService> logger);
}
