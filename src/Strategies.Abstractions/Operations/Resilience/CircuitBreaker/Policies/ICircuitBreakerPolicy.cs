// <copyright file="ICircuitBreakerPolicy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Resilience.CircuitBreaker.Policies;

public interface ICircuitBreakerPolicy
{
    public void Execute<TService>(ICircuitBreakerStrategy<TService> circuitBreakerStrategy)
        where TService : class;
}
