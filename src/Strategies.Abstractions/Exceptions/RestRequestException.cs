// <copyright file="RestRequestException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

public sealed class RestRequestException : Exception
{
    public RestRequestException(string message)
        : base(message)
    {
    }

    public RestRequestException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
