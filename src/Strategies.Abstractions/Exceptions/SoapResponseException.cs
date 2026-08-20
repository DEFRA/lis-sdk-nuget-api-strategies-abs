// <copyright file="SoapResponseException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public sealed class SoapResponseException : Exception
{
    public SoapResponseException(string message)
        : base(message)
    {
    }

    public SoapResponseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
