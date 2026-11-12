// <copyright file="HttpResponseExceptionTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Exceptions;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Exceptions;
using Shouldly;
using Xunit;

public class HttpResponseExceptionTests
{
    [Fact]
    public void Constructor_WithMessage_ShouldSetMessageProperty()
    {
        // Arrange
        const string message = "HTTP response error";

        // Act
        var exception = new TestHttpResponseException(message);

        // Assert
        exception.ShouldSatisfyAllConditions(
            x => x.Message.ShouldBe(message),
            x => x.InnerException.ShouldBeNull());
    }

    [Fact]
    public void Constructor_WithMessageAndInnerException_ShouldSetProperties()
    {
        // Arrange
        const string message = "HTTP response error with inner";
        var innerException = new InvalidOperationException("Inner error");

        // Act
        var exception = new TestHttpResponseException(message, innerException);

        // Assert
        exception.ShouldSatisfyAllConditions(
            x => x.Message.ShouldBe(message),
            x => x.InnerException.ShouldBeSameAs(innerException));
    }

    private sealed class TestHttpResponseException : HttpResponseException
    {
        public TestHttpResponseException(string message)
            : base(message)
        {
        }

        public TestHttpResponseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
