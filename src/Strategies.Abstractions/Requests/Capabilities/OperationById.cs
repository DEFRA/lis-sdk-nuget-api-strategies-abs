// <copyright file="OperationById.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field required to allow url route ids to be mapped into body payloads
namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests.Capabilities;

using System.ComponentModel;

public abstract class OperationById<T> : IOperationById<T>
    where T : IComparable
{
    [Description("The identifier of the object")]
    public T Id { get; set; }

    public string GetLoggableId()
    {
        return Id?.ToString() ?? throw new InvalidOperationException("Operation id has not been set");
    }
}
