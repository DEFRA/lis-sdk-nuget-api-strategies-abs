// <copyright file="RequestValidationFailureSeverityTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Validation;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Validation;
using Shouldly;
using Xunit;

public class RequestValidationFailureSeverityTests
{
    [Fact]
    public void EnumValues_ShouldHaveExpectedNamesAndValues()
    {
        // Assert
        ((int)RequestValidationFailureSeverity.Error).ShouldBe(0);
        ((int)RequestValidationFailureSeverity.Warning).ShouldBe(1);
        ((int)RequestValidationFailureSeverity.Info).ShouldBe(2);

        Enum.GetNames<RequestValidationFailureSeverity>().ShouldBe(new[] { "Error", "Warning", "Info" });
    }
}
