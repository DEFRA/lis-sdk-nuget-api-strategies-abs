// <copyright file="IOperatorContext.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Context;

using System.Security.Claims;

public interface IOperatorContext
{
    Operator Operator { get; }

    bool HasOperator { get; }

    bool HasAuthenticatedOperator { get; }

    IOperatorContext SetAuthenticatedOperatorById(string id);

    IOperatorContext SetOperatorByClaimsPrincipal(ClaimsPrincipal claimsPrincipal);
}
