// <copyright file="SoapResponse.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Soap.Models;

using System.Xml.Linq;

public class SoapResponse
{
    public bool HasContent { get; init; }

    public bool HasBody { get; init; }

    public bool HasBodyContent => BodyContent != null;

    public XElement? BodyContent { get; init; }

    public bool HasSoapFault { get; init; }

    public string? SoapFaultCode { get; init; }

    public string? SoapFaultDetails { get; init; }
}
