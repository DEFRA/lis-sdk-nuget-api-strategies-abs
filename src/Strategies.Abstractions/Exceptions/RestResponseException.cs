// <copyright file="RestResponseException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public sealed class RestResponseException : HttpClientResponseException
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
