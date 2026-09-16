// <copyright file="IRestStrategyFactory.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations;

using System.Text.Json;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Base;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Rest;

public interface IRestStrategyFactory<in TService> : IHttpStrategyFactory<TService, IRestStrategyFactory<TService>>
    where TService : class
{
    IRestStrategyFactory<TService> WithDefaultResourceUrl(string resourceUrl);

    IRestStrategyFactory<TService> WithDefaultJsonSerializerOptions(JsonSerializerOptions jsonSerializerOptions);

    IRestStrategy<TService> BuildRestStrategy();
}
