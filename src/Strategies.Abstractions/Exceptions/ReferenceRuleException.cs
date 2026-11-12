// <copyright file="ReferenceRuleException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public sealed class ReferenceRuleException : StrategyPreConditionException
{
    public ReferenceRuleException(string message)
        : base(message)
    {
    }
}
