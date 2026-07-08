// <copyright file="RequestValidationFailureSeverity.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Validation;

public enum RequestValidationFailureSeverity
{
    /// <summary>
    /// Error.
    /// </summary>
    Error,

    /// <summary>
    /// Warning.
    /// </summary>
    Warning,

    /// <summary>
    /// Info.
    /// </summary>
    Info,
}
