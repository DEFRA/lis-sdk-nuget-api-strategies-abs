// <copyright file="HttpRequestException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

public abstract class HttpRequestException : Exception
{
    protected HttpRequestException(string message)
        : base(message)
    {
    }

    protected HttpRequestException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
