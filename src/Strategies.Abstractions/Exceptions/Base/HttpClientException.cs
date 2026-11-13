// <copyright file="HttpClientException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public abstract class HttpClientException : Exception
{
    protected HttpClientException(string message)
        : base(message)
    {
    }

    protected HttpClientException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
