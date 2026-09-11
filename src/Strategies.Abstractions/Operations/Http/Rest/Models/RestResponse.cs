// <copyright file="RestResponse.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Rest.Models;

using System.Net;
using System.Net.Http.Headers;

public class RestResponse
{
    public bool HasContent { get; init; }

    public string? Content { get; init; }

    public HttpStatusCode StatusCode { get; init; }

    public HttpResponseHeaders? Headers { get; init; }
}
