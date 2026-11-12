// <copyright file="StrategyException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public abstract class StrategyException : Exception
{
    protected StrategyException(string message)
        : base(message)
    {
    }

    protected StrategyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
