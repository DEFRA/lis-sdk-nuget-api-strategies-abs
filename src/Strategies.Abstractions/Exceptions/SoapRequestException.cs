// <copyright file="SoapRequestException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

public sealed class SoapRequestException : Exception
{
    public SoapRequestException(string message)
        : base(message)
    {
    }

    public SoapRequestException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
