// <copyright file="IHttpStrategy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Base;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Base;

public interface IHttpStrategy<in TService, out TParent> : IStrategy<TService, TParent>
    where TService : class
    where TParent : class
{
    TParent WithApiDescription(string apiDescription);

    TParent WithBaseUrl(string baseUrl);

    TParent WithHeader(string name, string value);

    TParent WithMediaType(string mediaType);
}
