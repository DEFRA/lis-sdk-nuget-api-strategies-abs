// <copyright file="IReferenceRulesBuilder.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Rules.Builders;

using System.Linq.Expressions;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories;
using Microsoft.Extensions.Logging;

public interface IReferenceRulesBuilder<in TService>
    where TService : class
{
    IReferenceRulesBuilder<TService> Add<T>(
        IRepoGettable<T> repository,
        Expression<Func<T, bool>> predicate,
        string description)
        where T : class;

    IReferenceRulesBuilder<TService> Add(IReferenceRule rule);

    Task Validate(
        string actionDescription,
        string modelDescription,
        ILogger<TService> logger,
        CancellationToken cancellationToken);
}
