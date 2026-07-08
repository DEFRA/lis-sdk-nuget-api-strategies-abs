// <copyright file="RequestValidationFailure.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Validation;

public class RequestValidationFailure
{
    public RequestValidationFailure(string propertyName, string errorMessage, object? attemptedValue = null)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
        AttemptedValue = attemptedValue;
    }

    public RequestValidationFailureSeverity Severity { get; set; } = RequestValidationFailureSeverity.Error;

    public string PropertyName { get; set; }

    public string ErrorMessage { get; set; }

    public object? AttemptedValue { get; set; }

    public object? CustomState { get; set; }

    public string? ErrorCode { get; set; }

    public Dictionary<string, object>? FormattedMessagePlaceholderValues { get; set; }

    public override string ToString()
    {
        return ErrorMessage;
    }
}
