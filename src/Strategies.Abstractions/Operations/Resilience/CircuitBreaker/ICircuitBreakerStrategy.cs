// <copyright file="ICircuitBreakerStrategy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Resilience.CircuitBreaker;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Base;

public interface ICircuitBreakerStrategy<in TService> : IStrategy<TService, ICircuitBreakerStrategy<TService>>
    where TService : class
{
    ICircuitBreakerStrategy<TService> WithCircuitKey(string circuitKey);

    ICircuitBreakerStrategy<TService> WithAction(Func<CancellationToken, Task> action);

    ICircuitBreakerStrategy<TService> WithAction<TResult>(Func<CancellationToken, Task<TResult>> action);

    ICircuitBreakerStrategy<TService> WithConsecutiveFailureThreshold(int consecutiveFailureThreshold);

    ICircuitBreakerStrategy<TService> WithFailureRatio(double failureRatio);

    ICircuitBreakerStrategy<TService> WithSamplingDuration(int samplingDurationMs);

    ICircuitBreakerStrategy<TService> WithMinimumThroughput(int minimumThroughput);

    ICircuitBreakerStrategy<TService> WithDurationOfBreak(int durationOfBreakMs);

    ICircuitBreakerStrategy<TService> WithHandledException<TException>()
        where TException : Exception;

    ICircuitBreakerStrategy<TService> WithHandledException(Func<Exception, bool> predicate);

    ICircuitBreakerStrategy<TService> WithHandledException(Func<Exception, CancellationToken, bool> predicate);

    ICircuitBreakerStrategy<TService> WithExcludedException<TException>()
        where TException : Exception;

    ICircuitBreakerStrategy<TService> WithExcludedException(Func<Exception, bool> predicate);

    ICircuitBreakerStrategy<TService> WithExcludedException(Func<Exception, CancellationToken, bool> predicate);

    ICircuitBreakerStrategy<TService> WithHandledResult<TResult>(Func<TResult, bool> predicate);

    ICircuitBreakerStrategy<TService> WithFallback(Func<CancellationToken, Task> fallbackAction);

    ICircuitBreakerStrategy<TService> WithFallback<TResult>(Func<CancellationToken, Task<TResult>> fallbackAction);

    ICircuitBreakerStrategy<TService> OnBreak(Action<Exception?, TimeSpan> onBreakAction);

    ICircuitBreakerStrategy<TService> OnReset(Action onResetAction);

    ICircuitBreakerStrategy<TService> OnHalfOpen(Action onHalfOpenAction);

    Task ExecuteAsync();

    Task<TResult> ExecuteAsync<TResult>();
}
