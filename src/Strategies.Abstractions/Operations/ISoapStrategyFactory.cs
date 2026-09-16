// <copyright file="ISoapStrategyFactory.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Base;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Soap;

public interface ISoapStrategyFactory<in TService> : IHttpStrategyFactory<TService, ISoapStrategyFactory<TService>>
    where TService : class
{
    ISoapStrategyFactory<TService> WithDefaultServiceUrl(string serviceUrl);

    ISoapStrategyFactory<TService> WithDefaultSoapAction(string soapAction);

    ISoapStrategyFactory<TService> WithDefaultXmlDeclaration(bool withDefaultXmlDeclaration);

    ISoapStrategy<TService> BuildSoapStrategy();
}
