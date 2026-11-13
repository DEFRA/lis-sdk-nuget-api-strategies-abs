// <copyright file="HttpClientExceptionTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Exceptions.Base;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions.Base;

public class HttpClientExceptionTests
{
    [Fact]
    public void Constructor_WithMessage_ShouldSetMessageProperty()
    {
        // Arrange
        const string message = "HTTP client request error";

        // Act
        var exception = new TestHttpClientRequestException(message);

        // Assert
        exception.ShouldSatisfyAllConditions(
            x => x.Message.ShouldBe(message),
            x => x.InnerException.ShouldBeNull());
    }

    [Fact]
    public void Constructor_WithMessageAndInnerException_ShouldSetProperties()
    {
        // Arrange
        const string message = "HTTP client request error with inner";
        var innerException = new InvalidOperationException("Inner error");

        // Act
        var exception = new TestHttpClientRequestException(message, innerException);

        // Assert
        exception.ShouldSatisfyAllConditions(
            x => x.Message.ShouldBe(message),
            x => x.InnerException.ShouldBeSameAs(innerException));
    }

    private sealed class TestHttpClientRequestException : HttpClientException
    {
        public TestHttpClientRequestException(string message)
            : base(message)
        {
        }

        public TestHttpClientRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
