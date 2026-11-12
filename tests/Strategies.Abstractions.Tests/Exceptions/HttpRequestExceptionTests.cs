// <copyright file="HttpRequestExceptionTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;
using Shouldly;
using Xunit;

public class HttpRequestExceptionTests
{
    [Fact]
    public void Constructor_WithMessage_ShouldSetMessageProperty()
    {
        // Arrange
        const string message = "HTTP request error";

        // Act
        var exception = new TestHttpRequestException(message);

        // Assert
        exception.ShouldSatisfyAllConditions(
            x => x.Message.ShouldBe(message),
            x => x.InnerException.ShouldBeNull());
    }

    [Fact]
    public void Constructor_WithMessageAndInnerException_ShouldSetProperties()
    {
        // Arrange
        const string message = "HTTP request error with inner";
        var innerException = new InvalidOperationException("Inner error");

        // Act
        var exception = new TestHttpRequestException(message, innerException);

        // Assert
        exception.ShouldSatisfyAllConditions(
            x => x.Message.ShouldBe(message),
            x => x.InnerException.ShouldBeSameAs(innerException));
    }

    private sealed class TestHttpRequestException : HttpRequestException
    {
        public TestHttpRequestException(string message)
            : base(message)
        {
        }

        public TestHttpRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
