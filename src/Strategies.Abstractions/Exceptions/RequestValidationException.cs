// <copyright file="RequestValidationException.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Validation;

public class RequestValidationException : Exception
{
    public RequestValidationException(string message)
        : this(message, [])
    {
    }

    public RequestValidationException(string message, List<RequestValidationFailure> errors)
        : base(message)
    {
        Errors = errors;
    }

    public RequestValidationException(
        string message,
        List<RequestValidationFailure> errors,
        bool appendDefaultMessage)
        : base(appendDefaultMessage ? $"{message} {BuildErrorMessage(errors)}" : message)
    {
        Errors = errors;
    }

    public RequestValidationException(List<RequestValidationFailure> errors)
        : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }

    public IEnumerable<RequestValidationFailure> Errors { get; private set; }

    private static string BuildErrorMessage(List<RequestValidationFailure> errors)
    {
        var arr = errors.Select(x =>
            $"{Environment.NewLine} -- {x.PropertyName}: {x.ErrorMessage} Severity: {x.Severity.ToString()}");

        return "Validation failed: " + string.Join(string.Empty, arr);
    }
}
