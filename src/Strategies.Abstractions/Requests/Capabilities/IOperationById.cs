// <copyright file="IOperationById.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests.Capabilities;

public interface IOperationById<T> : ILoggableById
{
    T Id { get; set; }
}
