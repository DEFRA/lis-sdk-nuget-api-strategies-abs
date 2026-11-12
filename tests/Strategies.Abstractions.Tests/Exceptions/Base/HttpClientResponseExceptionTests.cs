// <copyright file="HttpClientResponseExceptionTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Exceptions.Base;

public class HttpClientResponseExceptionTests
{
    [Fact]
    public void Constructor_WithMessage_ShouldSetMessageProperty()
    {
        // Arrange
        const string message = "HTTP client response error";

        // Act
        var exception = new TestHttpClientResponseException(message);

        // Assert
        exception.ShouldSatisfyAllConditions(
            x => x.Message.ShouldBe(message),
            x => x.InnerException.ShouldBeNull());
    }

    [Fact]
    public void Constructor_WithMessageAndInnerException_ShouldSetProperties()
    {
        // Arrange
        const string message = "HTTP client response error with inner";
        var innerException = new InvalidOperationException("Inner error");

        // Act
        var exception = new TestHttpClientResponseException(message, innerException);

        // Assert
        exception.ShouldSatisfyAllConditions(
            x => x.Message.ShouldBe(message),
            x => x.InnerException.ShouldBeSameAs(innerException));
    }

    private sealed class TestHttpClientResponseException : HttpClientResponseException
    {
        public TestHttpClientResponseException(string message)
            : base(message)
        {
        }

        public TestHttpClientResponseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
