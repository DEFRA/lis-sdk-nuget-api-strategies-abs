// <copyright file="ExistenceRuleException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

public sealed class ExistenceRuleException : Exception
{
    public ExistenceRuleException(string message)
        : base(message)
    {
    }
}
