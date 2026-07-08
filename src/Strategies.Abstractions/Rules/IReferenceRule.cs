// <copyright file="IReferenceRule.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Rules;

public interface IReferenceRule
{
    string Description { get; }

    Func<CancellationToken, Task<bool>> Validator { get; }
}
