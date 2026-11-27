# lis-sdk-nuget-api-strategies-abs

Part of the Livestock Information Service (LIS), which lets livestock keepers, owners, agents and
delegates record and manage their animals.

`Defra.Livestock.Sdk.Api.Strategies.Abstractions` is a shared NuGet package that holds the contracts for the LIS strategies package (`Defra.Livestock.Sdk.Api.Strategies`): fluent strategy and factory interfaces for repository, REST, SOAP and circuit breaker operations, repository capability interfaces, business rule builders, pagination and validation models, and the strategy exception types.

Used by: [lis-sdk-nuget-api-strategies](https://github.com/DEFRA/lis-sdk-nuget-api-strategies), which implements these interfaces, and LIS .NET services that depend on the contracts without taking the implementation.

## Installation

```bash
dotnet add package Defra.Livestock.Sdk.Api.Strategies.Abstractions
```

The project produces the `Defra.Livestock.Sdk.Api.Strategies.Abstractions` package and targets `net10.0`. Its only runtime dependency is `Microsoft.Extensions.Logging.Abstractions`. Publishing is configured in the [tag-triggered workflow](https://github.com/DEFRA/lis-sdk-nuget-api-strategies-abs/blob/main/.github/workflows/publish.yml) and [composite NuGet action](https://github.com/DEFRA/lis-github-actions/blob/5f5557f64c1344efb6ed44e482452f9cfe6bea51/actions/publish-nuget/action.yml).

## Usage

The package contains interfaces and simple models only. It has no configuration and needs no dependency injection registration; register the implementations from `Defra.Livestock.Sdk.Api.Strategies` instead.

### Strategy factories (`Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations`)

Each factory sets defaults that every strategy it builds inherits, then builds a strategy for a single operation.

| Factory | Builds |
|---|---|
| `IRepoStrategyFactory<TService>` | Create, update, upsert, get, get-list and get-paged repository strategies |
| `IRestStrategyFactory<TService>` | `IRestStrategy<TService>` for REST calls through `IRestHttpClient` |
| `ISoapStrategyFactory<TService>` | `ISoapStrategy<TService>` for SOAP calls through `ISoapHttpClient` |
| `ICircuitBreakerStrategyFactory<TService>` | `ICircuitBreakerStrategy<TService>` with failure thresholds, break duration and handled or excluded exceptions |

All strategies share the fluent options on `IStrategy<TService, TParent>`: logger, cancellation token, operator context, authenticated operator requirement, action description, before and after hooks, request validation, and `When(...)` for conditional configuration.

```csharp
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests;

public class HoldingService(
    IRepoStrategyFactory<HoldingService> strategies,
    IHoldingRepository repository,
    ILogger<HoldingService> logger)
{
    public Task<Holding> Get(IOperationById<Guid> request, CancellationToken cancellationToken) =>
        strategies
            .WithDefaultLogger(logger)
            .WithDefaultEntityDescription("holding")
            .BuildGetStrategy<Holding>()
            .WithCancellationToken(cancellationToken)
            .WithRepository(repository) // implements IRepoGettable<Holding>
            .WithRequest(request)
            .WithEntityFilter(holding => holding.Id == request.Id)
            .Execute();
}
```

### Repository capabilities (`Defra.Livestock.Sdk.Api.Strategies.Abstractions.Repositories`)

Repositories opt in to the operations they support by implementing `IRepoCreatable<TEntity>`, `IRepoGettable<TEntity>`, `IRepoListable<TEntity>`, `IRepoPageable<TEntity>` and `IRepoUpdatable<TEntity>`. `EntityPredicateRule` and `EntityReferenceRule` describe existence, conflict and reference checks that the rule builders under `Rules.Builders` evaluate.

### Pagination

`PagedQuery` carries `PageNumber`, `PageSize`, `OrderBy` and `OrderByDescending`. `QueryablePagingExtensions` applies it to an `IQueryable<T>` to produce `PagedEntities<T>`, and `PagedEntitiesExtensions` maps that to a `PagedResults<T>` response.

### Validation (`Defra.Livestock.Sdk.Api.Strategies.Abstractions.Validation`)

`RequestValidationResult` collects `RequestValidationFailure` entries, each with a `RequestValidationFailureSeverity`. `IsValid` is true when there are no errors.

### Exceptions (`Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions`)

Strategies throw these so that the calling service can map them to HTTP responses.

| Type | Base | Thrown when |
|---|---|---|
| `EntityNotFoundException` | `StrategyPreConditionException` | A requested entity does not exist |
| `ExistenceRuleException` | `StrategyPreConditionException` | An existence rule fails |
| `ConflictRuleException` | `StrategyPreConditionException` | A conflict rule fails |
| `ReferenceRuleException` | `StrategyPreConditionException` | A referenced entity does not exist |
| `BusinessRuleException` | `StrategyPreConditionException` | A business rule fails |
| `RequestValidationException` | `StrategyPreConditionException` | Request validation fails |
| `SoapSchemaBuilderException` | `StrategyPreConditionException` | A SOAP schema cannot be built |
| `RestRequestException` / `RestResponseException` | `HttpClientException` | A REST request fails or returns an error response |
| `SoapRequestException` / `SoapResponseException` | `HttpClientException` | A SOAP request fails or returns an error response |
| `CircuitBreakerOpenException` | `Exception` | A call is rejected because the circuit is open |

## Prerequisites

- .NET 10 SDK (the project targets `net10.0`). SDK selection and the Microsoft Testing Platform runner are configured in [global.json](https://github.com/DEFRA/lis-sdk-nuget-api-strategies-abs/blob/main/global.json).
- To try a change in a consuming service: a local clone of [lis-dev](https://github.com/DEFRA/lis-dev), which runs a local NuGet server

## Setup

### Development

```bash
dotnet restore Strategies.Abstractions.slnx
dotnet build Strategies.Abstractions.slnx
```

## Running in development

This is a library, so it has no service of its own. To try a change in a consuming service before
publishing, pack it and push it to the local NuGet server that lis-dev runs on port 5555
(`nuget-server` in its compose stack, already listed in lis-dev's `nuget.config`):

```bash
dotnet pack src/Strategies.Abstractions/Strategies.Abstractions.csproj -c Release -o ./artifacts /p:Version=0.0.0-local.1
dotnet nuget push "./artifacts/*.nupkg" --source http://localhost:5555/v3/index.json --api-key LOCAL-NUGET-API-KEY
```

Then reference that version from the consuming service.

## Running tests

Tests use xUnit v3 with Shouldly assertions, NSubstitute and Microsoft Testing Platform. Coverage includes exception messages, pagination, rules, operation requests, REST and SOAP response models and validation results.

Run the xUnit test executable directly after building:

```bash
dotnet build tests/Strategies.Abstractions.Tests/Strategies.Abstractions.Tests.csproj
dotnet tests/Strategies.Abstractions.Tests/bin/Debug/net10.0/Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.dll
```

## Pipelines

GitHub Actions use the composite actions under `actions/` in `DEFRA/lis-github-actions`. Every workflow pins these actions to the `v0.11.0` release commit (`5f5557f64c1344efb6ed44e482452f9cfe6bea51`). Update all `uses:` references together when moving to a newer release.

| Workflow | Trigger | Configured behaviour |
|---|---|---|
| [Prerelease](https://github.com/DEFRA/lis-sdk-nuget-api-strategies-abs/blob/main/.github/workflows/prerelease.yml) | Push to `feature/**` or `hotfix/**` | Calculate a prerelease version, validate and run Sonar analysis, then tag the commit when validation succeeds and the quality gate passes |
| [Pull Request Validation](https://github.com/DEFRA/lis-sdk-nuget-api-strategies-abs/blob/main/.github/workflows/pull-request.yml) | Pull request opened, updated or reopened against `main` | Calculate a prospective version, validate and run Sonar analysis; aggregate the job results into a required check |
| [Release](https://github.com/DEFRA/lis-sdk-nuget-api-strategies-abs/blob/main/.github/workflows/release.yml) | Pull request merged into `main` | Calculate a stable version, validate and run Sonar analysis, then tag the merged commit when validation succeeds and the quality gate passes |
| [Publish](https://github.com/DEFRA/lis-sdk-nuget-api-strategies-abs/blob/main/.github/workflows/publish.yml) | Push of a tag matching `*.*.*` | Run the central composite NuGet publishing action in a local job |

NuGet's trusted publishing policy must use repository owner `DEFRA`, repository `lis-sdk-nuget-api-strategies-abs`, workflow filename `publish.yml`, and environment `release`. The `NUGET_USERNAME` secret identifies the policy creator. The publishing job stays in this repository because NuGet rejects authentication inside a reusable workflow hosted in another repository.

Publishing requires an artifact built from the tagged commit by a successful prerelease or release workflow. The artifact records its commit, version, workflow run and attempt; publishing waits for that attempt to finish successfully before authenticating with NuGet.

Dependabot branches receive patch versions. Their PR validation versions use the label `dependabot-alpha.<run>.<attempt>`; feature and hotfix prereleases require an LREG ticket.

## Branching policy

The repo uses mainline development. Branch from `main` and name the branch:

- `feature/LREG-<ticket>-<short-kebab-description>`
- `hotfix/LREG-<ticket>-<short-kebab-description>`

`LREG` must be uppercase, because the GitHub ruleset rejects other branch names. Rebase onto `main`
rather than merging `main` in.

## Contributing to this project

- Follow the [Defra software development standards](https://github.com/DEFRA/software-development-standards).
- Code style is configured in `.editorconfig` and `stylecop.json`, with StyleCop and .NET analyzers enabled during builds. Warnings are treated as errors. Run `dotnet format Strategies.Abstractions.slnx --verify-no-changes` to check formatting locally.
- Open a pull request against `main`. CI must pass and the Sonar quality gate must be green before merge.

## Licence

THIS INFORMATION IS LICENSED UNDER THE CONDITIONS OF THE OPEN GOVERNMENT LICENCE found at:

<http://www.nationalarchives.gov.uk/doc/open-government-licence/version/3>

The following attribution statement MUST be cited in your products and applications when using this information.

> Contains public sector information licensed under the Open Government licence v3

### About the licence

The Open Government Licence (OGL) was developed by the Controller of His Majesty's Stationery Office (HMSO) to enable information providers in the public sector to license the use and re-use of their information under a common open licence.

It is designed to encourage use and re-use of information freely and flexibly, with only a few conditions.

## Maintaining code analysis and public APIs

The build runs the .NET 10 recommended analyzer rules, StyleCop and SonarAnalyzer. Tests also receive xUnit analyzers through `xunit.v3`. Analyzer warnings are treated as errors; CA1707 is disabled for test code to allow descriptive names with underscores.

Some rules are suppressed in `src/Strategies.Abstractions/Directory.Build.props` because fixing them would break the existing public API: CA1716 (`Operator` and `When` clash with Visual Basic keywords) and RS0026 (the `When` overloads have optional parameters). CS1591 (missing XML documentation) is suppressed in both the library and the tests until the public members are documented.

The library uses `Microsoft.CodeAnalysis.PublicApiAnalyzers` to track its public surface, including nullability and default parameter values. These files make API changes visible during review and help catch accidental changes to the contract used by consuming services.

Every merged PR to `main` enters the release pipeline, so there is no separate release preparation step. Update `src/Strategies.Abstractions/PublicAPI.Shipped.txt` in the same PR as the API change: it records the API contract that will be released on merge. Include both new types and their public members; for example, a new exception needs entries for both the type and its public constructor. The RS0016 code fix can generate declarations in `src/Strategies.Abstractions/PublicAPI.Unshipped.txt`; move those additions into the shipped file before merging.

Keep `PublicAPI.Unshipped.txt` empty apart from `#nullable enable` unless it contains intentional `*REMOVED*` entries. Retain `#nullable enable` at the top of both files. Preserve previously shipped declarations as the compatibility record, and represent intentional removals using `*REMOVED*` entries in the unshipped file. Review breaking changes explicitly, since consuming services can still depend on earlier package versions.
