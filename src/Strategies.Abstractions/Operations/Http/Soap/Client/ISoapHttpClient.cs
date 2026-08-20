// <copyright file="ISoapHttpClient.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Soap.Client;

using System.Xml.Linq;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Soap.Models;

public interface ISoapHttpClient
{
    ISoapHttpClient WithVerboseOutput(Action<string, string?>? verboseOutputAction);

    ISoapHttpClient WithBaseUrl(string baseUrl);

    ISoapHttpClient WithSoapAction(string soapAction);

    ISoapHttpClient WithMediaType(string mediaType);

    public ISoapHttpClient WithHeader(string name, string value);

    ISoapHttpClient WithXmlDeclaration(bool includeXmlDeclaration);

    Task<SoapResponse> PostAsync(string relativeUrl, XElement payload, CancellationToken cancellationToken = default);
}
