// <copyright file="IRepoStrategy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Repositories;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Context;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Validation;
using Microsoft.Extensions.Logging;

public interface IRepoStrategy<in TService, out TParent>
    where TService : class
    where TParent : class
{
    TParent WithLogger(ILogger<TService> logger);

    TParent WithCancellationToken(CancellationToken cancellationToken);

    TParent WithOperatorContext(IOperatorContext operatorContext);

    TParent WithRequiresAuthenticatedOperator();

    TParent WithEntityDescription(string entityDescription);

    TParent WithActionDescription(string actionDescription);

    TParent WithBeforeExecute(Func<Task> beforeExecuteAction);

    TParent WithRequestValidation(Func<Task<RequestValidationResult>> validateAction);

    TParent WithAfterExecute(Func<Task> afterExecuteAction);
}
