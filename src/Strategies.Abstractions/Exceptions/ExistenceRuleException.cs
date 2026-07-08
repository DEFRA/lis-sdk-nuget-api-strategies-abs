// <copyright file="ExistenceRuleException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public sealed class ExistenceRuleException : Exception
{
    public ExistenceRuleException(string message)
        : base(message)
    {
    }
}
