// <copyright file="Operator.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Context;

using System.Collections.Frozen;

public class Operator
{
    public Operator(string id, bool isAuthenticated)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);

        this.Id = id;
        Roles = [];
        IsAuthenticated = isAuthenticated;
    }

    public Operator(string id, string[] roles, bool isAuthenticated)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(roles);

        this.Id = id;
        Roles = roles.Select(r => r).ToFrozenSet();
        IsAuthenticated = isAuthenticated;
    }

    public Operator(string id, string? name, string? email, string[] roles, bool isAuthenticated)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(roles);

        this.Id = id;
        Name = name;
        Email = email;
        Roles = roles.Select(r => r).ToFrozenSet();
        IsAuthenticated = isAuthenticated;
    }

    public string Id { get; }

    public string LoggableId => Id;

    public string? Name { get; }

    public string? Email { get; }

    public FrozenSet<string> Roles { get; }

    public bool IsAuthenticated { get; }

    public bool HasRole(string role) => Roles.Contains(role);

    public Guid GetIdAsGuid() => Guid.TryParse(Id, out var guidValue)
        ? guidValue
        : throw new InvalidOperationException("Operator id is not a valid Guid");

    public int GetIdAsInt() => int.TryParse(Id, out var intValue)
        ? intValue
        : throw new InvalidOperationException("Operator id is not a valid integer");
}
