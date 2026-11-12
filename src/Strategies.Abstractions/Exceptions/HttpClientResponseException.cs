// <copyright file="HttpClientResponseException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

public abstract class HttpClientResponseException : Exception
{
    protected HttpClientResponseException(string message)
        : base(message)
    {
    }

    protected HttpClientResponseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
