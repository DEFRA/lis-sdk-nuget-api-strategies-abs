// <copyright file="ISoapStrategyFactory.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Base;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Soap;

public interface ISoapStrategyFactory<in TService> : IStrategyFactory<TService, ISoapStrategyFactory<TService>>
    where TService : class
{
    ISoapStrategyFactory<TService> WithDefaultApiDescription(string entityDescription);

    ISoapStrategyFactory<TService> WithDefaultBaseUrl(string baseUrl);

    ISoapStrategyFactory<TService> WithDefaultServiceUrl(string serviceUrl);

    ISoapStrategyFactory<TService> WithDefaultSoapAction(string soapAction);

    ISoapStrategyFactory<TService> WithDefaultMediaType(string mediaType);

    ISoapStrategyFactory<TService> WithDefaultXmlDeclaration(bool withDefaultXmlDeclaration);

    ISoapStrategyFactory<TService> WithDefaultVerboseOutput(Action<string, string?> verboseOutputAction);

    ISoapStrategy<TService> BuildSoapStrategy();
}
