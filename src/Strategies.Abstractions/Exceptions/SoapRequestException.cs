// <copyright file="SoapRequestException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public sealed class SoapRequestException : HttpClientException
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
