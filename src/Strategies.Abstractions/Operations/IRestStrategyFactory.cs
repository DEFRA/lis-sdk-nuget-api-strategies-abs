// <copyright file="IRestStrategyFactory.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations;

using System.Text.Json;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Base;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Rest;

public interface IRestStrategyFactory<in TService> : IStrategyFactory<TService, IRestStrategyFactory<TService>>
    where TService : class
{
    IRestStrategyFactory<TService> WithDefaultApiDescription(string entityDescription);

    IRestStrategyFactory<TService> WithDefaultBaseUrl(string baseUrl);

    IRestStrategyFactory<TService> WithDefaultResourceUrl(string resourceUrl);

    IRestStrategyFactory<TService> WithDefaultMediaType(string mediaType);

    IRestStrategyFactory<TService> WithDefaultJsonSerializerOptions(JsonSerializerOptions jsonSerializerOptions);

    IRestStrategyFactory<TService> WithDefaultVerboseOutput(Action<string, string?> verboseOutputAction);

    IRestStrategy<TService> BuildRestStrategy();
}
