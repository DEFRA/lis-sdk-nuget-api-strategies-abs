// <copyright file="IBusinessRulesBuilder.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Rules.Builders;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests;
using Microsoft.Extensions.Logging;

public interface IBusinessRulesBuilder<in TService, T>
    where TService : class
    where T : class
{
    IBusinessRulesBuilder<TService, T> Add(
        Func<T, bool> expression,
        string description,
        string? errorMessage = null);

    IBusinessRulesBuilder<TService, T> Add(IPredicateRule<T> predicateRule);

    void Validate(
        ILoggableById request,
        T modelToValidate,
        string actionDescription,
        string modelDescription,
        ILogger<TService> logger);
}
