// <copyright file="ServiceUnavailableException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

public sealed class ServiceUnavailableException : Exception
{
    public ServiceUnavailableException(string message)
        : base(message)
    {
    }

    public ServiceUnavailableException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
