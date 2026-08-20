// <copyright file="IRepoStrategy.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Repositories.Base;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Base;

public interface IRepoStrategy<in TService, out TParent> : IStrategy<TService, TParent>
    where TService : class
    where TParent : class
{
    TParent WithEntityDescription(string entityDescription);
}
