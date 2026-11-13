// <copyright file="SoapResponseException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public sealed class SoapResponseException : HttpClientException
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
