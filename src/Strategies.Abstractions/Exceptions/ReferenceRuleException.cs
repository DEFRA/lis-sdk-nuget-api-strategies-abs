// <copyright file="ReferenceRuleException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

public sealed class ReferenceRuleException : Exception
{
    public ReferenceRuleException(string message)
        : base(message)
    {
    }
}
