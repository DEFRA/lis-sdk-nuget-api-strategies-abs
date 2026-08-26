// <copyright file="SoapSchemaException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

public sealed class SoapSchemaException : Exception
{
    public SoapSchemaException(string message)
        : base(message)
    {
    }

    public SoapSchemaException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
