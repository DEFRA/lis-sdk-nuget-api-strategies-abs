// <copyright file="StrategyPreConditionException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public abstract class StrategyPreConditionException : StrategyException
{
    protected StrategyPreConditionException(string message)
        : base(message)
    {
    }

    protected StrategyPreConditionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
