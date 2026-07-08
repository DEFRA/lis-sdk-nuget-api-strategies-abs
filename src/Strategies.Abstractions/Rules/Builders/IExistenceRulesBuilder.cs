// <copyright file="IExistenceRulesBuilder.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Rules.Builders;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests;
using Microsoft.Extensions.Logging;

public interface IExistenceRulesBuilder<in TService, T>
    where TService : class
    where T : class
{
    IExistenceRulesBuilder<TService, T> Add(Func<T, bool> expression, string description);

    IExistenceRulesBuilder<TService, T> Add(IPredicateRule<T> predicateRule);

    void Validate(ILoggableById request, T modelToValidate, string modelDescription, ILogger<TService> logger);
}
