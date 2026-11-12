// <copyright file="HttpResponseException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

public abstract class HttpResponseException : Exception
{
    protected HttpResponseException(string message)
        : base(message)
    {
    }

    protected HttpResponseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
