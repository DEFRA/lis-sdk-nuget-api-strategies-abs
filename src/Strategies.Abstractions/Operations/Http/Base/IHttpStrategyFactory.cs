// <copyright file="IHttpStrategyFactory.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Base;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Base;

public interface IHttpStrategyFactory<in TService, out TParent> : IStrategyFactory<TService, TParent>
    where TService : class
    where TParent : class
{
    TParent WithDefaultApiDescription(string apiDescription);

    TParent WithDefaultBaseUrl(string baseUrl);

    TParent WithDefaultMediaType(string mediaType);

    TParent WithDefaultBasicAuth(string username, string password);

    TParent WithDefaultVerboseOutput(Action<string, string?> verboseOutputAction);
}
