// <copyright file="IRestStrategy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Rest;

using System.Text.Json;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Base;

public interface
    IRestStrategy<in TService> : IHttpStrategy<TService,
    IRestStrategy<TService>>
    where TService : class
{
    IRestStrategy<TService> WithResourceUrl(string resourceUrl);

    IRestStrategy<TService> WithGet();

    IRestStrategy<TService> WithPost();

    IRestStrategy<TService> WithPut();

    IRestStrategy<TService> WithDelete();

    IRestStrategy<TService> WithPatch();

    IRestStrategy<TService> WithHead();

    IRestStrategy<TService> WithOptions();

    IRestStrategy<TService> WithQueryParameter(string name, string value);

    IRestStrategy<TService> WithQueryParameters(IDictionary<string, string> queryParameters);

    IRestStrategy<TService> WithPayload<TRequest>(Func<TRequest> payloadAction);

    IRestStrategy<TService> WithPayload<TRequest>(TRequest payload);

    IRestStrategy<TService> WithJsonSerializerOptions(JsonSerializerOptions jsonSerializerOptions);

    IRestStrategy<TService> WithVerboseOutput(Action<string, string?> verboseOutputAction);

    Task<TResult> Execute<TResult>()
        where TResult : class;

    Task<TResult> ExecuteAndTransform<TResponse, TResult>(Func<TResponse, TResult> transform)
        where TResponse : class
        where TResult : class;

    Task ExecuteWithoutResponse();
}
