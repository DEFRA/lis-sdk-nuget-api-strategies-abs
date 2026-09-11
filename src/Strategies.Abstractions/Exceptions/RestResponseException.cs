// <copyright file="RestResponseException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

public sealed class RestResponseException : Exception
{
    public RestResponseException(string message)
        : base(message)
    {
    }

    public RestResponseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
