// <copyright file="OperatorTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Context;

using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Context;
using Shouldly;
using Xunit;

public class OperatorTests
{
    [Fact]
    public void Constructor_WithIdAndIsAuthenticated_ShouldInitializeCorrectly()
    {
        // Act
        var op = new Operator("op123", true);

        // Assert
        op.Id.ShouldBe("op123");
        op.IsAuthenticated.ShouldBeTrue();
        op.Name.ShouldBeNull();
        op.Email.ShouldBeNull();
        op.Roles.ShouldBeEmpty();
        op.LoggableId.ShouldBe("op123");
    }

    [Fact]
    public void Constructor_WithIdRolesAndIsAuthenticated_ShouldInitializeCorrectly()
    {
        // Arrange
        var roles = new[] { "Admin", "User" };

        // Act
        var op = new Operator("op123", roles, false);

        // Assert
        op.Id.ShouldBe("op123");
        op.IsAuthenticated.ShouldBeFalse();
        op.Roles.Count.ShouldBe(2);
        op.Roles.ShouldContain("Admin");
        op.Roles.ShouldContain("User");
    }

    [Fact]
    public void Constructor_WithAllParameters_ShouldInitializeCorrectly()
    {
        // Arrange
        var roles = new[] { "Manager" };

        // Act
        var op = new Operator("op456", "John Doe", "john@example.com", roles, true);

        // Assert
        op.Id.ShouldBe("op456");
        op.Name.ShouldBe("John Doe");
        op.Email.ShouldBe("john@example.com");
        op.Roles.ShouldContain("Manager");
        op.IsAuthenticated.ShouldBeTrue();
        op.LoggableId.ShouldBe("op456");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_WithNullOrWhitespaceId_ShouldThrowArgumentException(string? invalidId)
    {
        // Act & Assert
        Should.Throw<ArgumentException>(() => new Operator(invalidId!, true));
        Should.Throw<ArgumentException>(() => new Operator(invalidId!, Array.Empty<string>(), true));
        Should.Throw<ArgumentException>(() => new Operator(invalidId!, "name", "email", Array.Empty<string>(), true));
    }

    [Fact]
    public void Constructor_WithNullRoles_ShouldThrowArgumentNullException()
    {
        // Act & Assert
        Should.Throw<ArgumentNullException>(() => new Operator("id", null!, true));
        Should.Throw<ArgumentNullException>(() => new Operator("id", "name", "email", null!, true));
    }

    [Fact]
    public void HasRole_WhenRoleExists_ShouldReturnTrue()
    {
        // Arrange
        var op = new Operator("op123", new[] { "Admin", "User" }, true);

        // Act & Assert
        op.HasRole("Admin").ShouldBeTrue();
        op.HasRole("User").ShouldBeTrue();
    }

    [Fact]
    public void HasRole_WhenRoleDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        var op = new Operator("op123", new[] { "User" }, true);

        // Act & Assert
        op.HasRole("Admin").ShouldBeFalse();
    }

    [Fact]
    public void GetIdAsGuid_WhenValidGuid_ShouldReturnGuid()
    {
        // Arrange
        var expectedGuid = Guid.NewGuid();
        var op = new Operator(expectedGuid.ToString(), true);

        // Act
        var result = op.GetIdAsGuid();

        // Assert
        result.ShouldBe(expectedGuid);
    }

    [Fact]
    public void GetIdAsGuid_WhenInvalidGuid_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var op = new Operator("not-a-guid", true);

        // Act & Assert
        var ex = Should.Throw<InvalidOperationException>(() => op.GetIdAsGuid());
        ex.Message.ShouldBe("Operator id is not a valid Guid");
    }

    [Fact]
    public void GetIdAsInt_WhenValidInt_ShouldReturnInt()
    {
        // Arrange
        var op = new Operator("42", true);

        // Act
        var result = op.GetIdAsInt();

        // Assert
        result.ShouldBe(42);
    }

    [Fact]
    public void GetIdAsInt_WhenInvalidInt_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var op = new Operator("not-an-int", true);

        // Act & Assert
        var ex = Should.Throw<InvalidOperationException>(() => op.GetIdAsInt());
        ex.Message.ShouldBe("Operator id is not a valid integer");
    }
}
