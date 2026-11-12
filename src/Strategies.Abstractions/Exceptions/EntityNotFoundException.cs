// <copyright file="EntityNotFoundException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public sealed class EntityNotFoundException : StrategyPreConditionException
{
    public EntityNotFoundException(string message)
        : base(message)
    {
    }
}
