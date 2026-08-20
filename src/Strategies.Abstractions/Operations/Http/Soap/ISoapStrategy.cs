// <copyright file="ISoapStrategy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Soap;

using System.Xml.Linq;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Base;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Soap.Schemas.Builders;

public interface
    ISoapStrategy<in TService> : IHttpStrategy<TService,
    ISoapStrategy<TService>>
    where TService : class
{
    ISoapStrategy<TService> WithServiceUrl(string serviceUrl);

    ISoapStrategy<TService> WithSoapAction(string soapAction);

    ISoapStrategy<TService> WithXmlDeclaration(bool includeXmlDeclaration);

    ISoapStrategy<TService> WithSchemas(Action<ISoapSchemaBuilder> builder);

    ISoapStrategy<TService> WithPayload(Func<XElement> payloadAction);

    ISoapStrategy<TService> WithPayload<TRequest>(Func<TRequest> payloadAction);

    ISoapStrategy<TService> WithPayload<TRequest>(TRequest payload);

    ISoapStrategy<TService> WithValidatePreTransformPayloadSchema(string? targetElementName = null);

    ISoapStrategy<TService> WithValidatePayloadSchema(string? targetElementName = null);

    ISoapStrategy<TService> WithPayloadTransformer(Func<XElement?, XElement?> payloadTransformerAction);

    ISoapStrategy<TService> WithResponseTransformer(Func<XElement?, XElement?> responseTransformerAction);

    ISoapStrategy<TService> WithVerboseOutput(Action<string, string?> verboseOutputAction);

    Task<XElement> Execute();

    Task<TResult> Execute<TResult>()
        where TResult : class;

    Task<TResult> ExecuteAndTransform<TResult>(Func<XElement, TResult> transform)
        where TResult : class;

    Task<TResult> ExecuteAndTransform<TResponse, TResult>(Func<TResponse, TResult> transform)
        where TResponse : class
        where TResult : class;

    Task<TResult> ExecuteAndTransform<TResponse, TResult>(
        Func<TResponse, Func<XElement, TResult>, TResult> transform)
        where TResponse : class
        where TResult : class;

    Task ExecuteWithoutResponse();
}
