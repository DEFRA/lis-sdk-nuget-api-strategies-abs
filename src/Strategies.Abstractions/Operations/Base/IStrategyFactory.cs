// <copyright file="IStrategyFactory.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Base;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Context;
using Microsoft.Extensions.Logging;

public interface IStrategyFactory<in TService, out TParent>
    where TService : class
    where TParent : class
{
    TParent WithDefaultLogger(ILogger<TService> logger);

    TParent WithDefaultOperatorContext(IOperatorContext operatorContext);
}
