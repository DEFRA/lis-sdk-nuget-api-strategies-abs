// <copyright file="SoapSchemaBuilderException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public sealed class SoapSchemaBuilderException : StrategyPreConditionException
{
    public SoapSchemaBuilderException(string message)
        : base(message)
    {
    }

    public SoapSchemaBuilderException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
