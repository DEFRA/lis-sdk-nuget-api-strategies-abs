// <copyright file="ISoapSchemaBuilder.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Soap.Schemas.Builders;

using System.Reflection;
using System.Xml.Schema;

public interface ISoapSchemaBuilder
{
    ISoapSchemaBuilder Add(params string[] schemaFiles);

    ISoapSchemaBuilder Add(IEnumerable<string> schemaFiles);

    ISoapSchemaBuilder Add(Assembly assembly, string resourceNamespace);

    XmlSchemaSet Build();
}
