// <copyright file="RestResponseTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Operations.Http.Rest.Models;

using System.Net;
using System.Net.Http;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Rest.Models;
using Shouldly;
using Xunit;

public class RestResponseTests
{
    [Fact]
    public void Properties_ShouldGetAndSetCorrectly()
    {
        // Arrange
        using var httpResponse = new HttpResponseMessage();
        var headers = httpResponse.Headers;
        const string content = "{\"key\": \"value\"}";
        const HttpStatusCode statusCode = HttpStatusCode.OK;

        // Act
        var response = new RestResponse
        {
            HasContent = true,
            Content = content,
            StatusCode = statusCode,
            Headers = headers,
        };

        // Assert
        response.ShouldSatisfyAllConditions(
            x => x.HasContent.ShouldBeTrue(),
            x => x.Content.ShouldBe(content),
            x => x.StatusCode.ShouldBe(statusCode),
            x => x.Headers.ShouldBeSameAs(headers));
    }

    [Fact]
    public void Properties_DefaultValues_ShouldBeCorrect()
    {
        // Act
        var response = new RestResponse();

        // Assert
        response.ShouldSatisfyAllConditions(
            x => x.HasContent.ShouldBeFalse(),
            x => x.Content.ShouldBeNull(),
            x => x.StatusCode.ShouldBe(default(HttpStatusCode)),
            x => x.Headers.ShouldBeNull());
    }
}
