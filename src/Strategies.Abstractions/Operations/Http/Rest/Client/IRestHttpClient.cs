// <copyright file="IRestHttpClient.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Rest.Client;

using System.Net.Http;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Rest.Models;

public interface IRestHttpClient
{
    IRestHttpClient WithVerboseOutput(Action<string, string?>? verboseOutputAction);

    IRestHttpClient WithBaseUrl(string baseUrl);

    IRestHttpClient WithMediaType(string mediaType);

    IRestHttpClient WithHeader(string name, string value);

    IRestHttpClient WithQueryParameter(string name, string value);

    Task<RestResponse> SendAsync(
        HttpMethod httpMethod,
        string? relativeUrl,
        string? payload = null,
        CancellationToken cancellationToken = default);
}
