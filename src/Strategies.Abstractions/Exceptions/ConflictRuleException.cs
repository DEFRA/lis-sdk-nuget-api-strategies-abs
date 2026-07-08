// <copyright file="ConflictRuleException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public sealed class ConflictRuleException : Exception
{
    public ConflictRuleException(string message)
        : base(message)
    {
    }
}
