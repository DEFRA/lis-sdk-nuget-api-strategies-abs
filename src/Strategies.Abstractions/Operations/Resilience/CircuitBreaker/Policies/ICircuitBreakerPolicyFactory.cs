// <copyright file="ICircuitBreakerPolicyFactory.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Resilience.CircuitBreaker.Policies;

public interface ICircuitBreakerPolicyFactory
{
    public ICircuitBreakerPolicy CreateHttpPolicy();
}
