// <copyright file="RequestValidationResult.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Validation;

public class RequestValidationResult
{
    private List<RequestValidationFailure> errors;

    public RequestValidationResult(IEnumerable<RequestValidationFailure> failures)
    {
        errors = failures.Where(failure => failure != null).ToList();
    }

    public RequestValidationResult(IEnumerable<RequestValidationResult> otherResults)
    {
        var requestValidationResults = otherResults as RequestValidationResult[] ?? otherResults.ToArray();

        errors = requestValidationResults.SelectMany(x => x.Errors).ToList();

        RuleSetsExecuted = requestValidationResults.Where(x => x.RuleSetsExecuted != null)
            .SelectMany(x => x.RuleSetsExecuted)
            .Distinct().ToArray();
    }

    public bool IsValid => Errors.Count == 0;

    public List<RequestValidationFailure> Errors
    {
        get => errors;
        set
        {
            ArgumentNullException.ThrowIfNull(value);

            errors = value.Where(failure => failure != null).ToList();
        }
    }

    public string[] RuleSetsExecuted { get; set; } = [];

    public override string ToString()
    {
        return string.Join(Environment.NewLine, errors.Select(failure => failure.ErrorMessage));
    }

    public IDictionary<string, string[]> ToDictionary()
    {
        return Errors
            .GroupBy(x => x.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.ErrorMessage).ToArray());
    }
}
