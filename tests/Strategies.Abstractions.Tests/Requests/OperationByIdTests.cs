// <copyright file="OperationByIdTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Requests;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Requests;
using Shouldly;
using Xunit;

public class OperationByIdTests
{
    [Fact]
    public void GetLoggableId_WhenIdIsSet_ShouldReturnStringRepresentation()
    {
        // Arrange
        var operation = new TestOperationById<int> { Id = 42 };

        // Act
        var loggableId = operation.GetLoggableId();

        // Assert
        loggableId.ShouldBe("42");
    }

    [Fact]
    public void GetLoggableId_WhenIdIsNull_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var operation = new TestOperationById<string> { Id = null! };

        // Act & Assert
        var ex = Should.Throw<InvalidOperationException>(operation.GetLoggableId);

        ex.Message.ShouldBe("Operation id has not been set");
    }

    private class TestOperationById<T> : OperationById<T>
        where T : IComparable
    {
    }
}
