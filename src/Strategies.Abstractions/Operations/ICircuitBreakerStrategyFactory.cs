// <copyright file="ICircuitBreakerStrategyFactory.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Base;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Resilience.CircuitBreaker;

public interface
    ICircuitBreakerStrategyFactory<in TService> : IStrategyFactory<TService, ICircuitBreakerStrategyFactory<TService>>
    where TService : class
{
    ICircuitBreakerStrategyFactory<TService> WithDefaultCircuitKey(string circuitKey);

    ICircuitBreakerStrategyFactory<TService> WithDefaultConsecutiveFailureThreshold(int consecutiveFailureThreshold);

    ICircuitBreakerStrategyFactory<TService> WithDefaultFailureRatio(double failureRatio);

    ICircuitBreakerStrategyFactory<TService> WithDefaultSamplingDuration(int samplingDurationMs);

    ICircuitBreakerStrategyFactory<TService> WithDefaultMinimumThroughput(int minimumThroughput);

    ICircuitBreakerStrategyFactory<TService> WithDefaultDurationOfBreak(int durationOfBreakMs);

    ICircuitBreakerStrategyFactory<TService> WithDefaultHandledException<TException>()
        where TException : Exception;

    ICircuitBreakerStrategyFactory<TService> WithDefaultHandledException(Func<Exception, bool> predicate);

    ICircuitBreakerStrategyFactory<TService> WithDefaultHandledException(
        Func<Exception, CancellationToken, bool> predicate);

    ICircuitBreakerStrategyFactory<TService> WithDefaultExcludedException<TException>()
        where TException : Exception;

    ICircuitBreakerStrategyFactory<TService> WithDefaultExcludedException(Func<Exception, bool> predicate);

    ICircuitBreakerStrategyFactory<TService> WithDefaultExcludedException(
        Func<Exception, CancellationToken, bool> predicate);

    ICircuitBreakerStrategyFactory<TService> WithDefaultOnBreak(Action<Exception?, TimeSpan> onBreakAction);

    ICircuitBreakerStrategyFactory<TService> WithDefaultOnReset(Action onResetAction);

    ICircuitBreakerStrategyFactory<TService> WithDefaultOnHalfOpen(Action onHalfOpenAction);

    ICircuitBreakerStrategy<TService> BuildCircuitBreakerStrategy();
}
