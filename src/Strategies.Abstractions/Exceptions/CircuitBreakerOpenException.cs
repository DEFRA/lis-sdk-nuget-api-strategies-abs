// <copyright file="CircuitBreakerOpenException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

public class CircuitBreakerOpenException : Exception
{
    public CircuitBreakerOpenException(string message)
        : base(message)
    {
    }

    public CircuitBreakerOpenException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
