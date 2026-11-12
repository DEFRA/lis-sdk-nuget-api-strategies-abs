// <copyright file="HttpClientRequestException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public abstract class HttpClientRequestException : Exception
{
    protected HttpClientRequestException(string message)
        : base(message)
    {
    }

    protected HttpClientRequestException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
