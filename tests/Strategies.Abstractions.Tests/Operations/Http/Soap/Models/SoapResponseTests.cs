// <copyright file="SoapResponseTests.cs" company="Defra">
// Copyright (c) Defra. All rights reserved.
// </copyright>

namespace Defra.Livestock.Sdk.Api.Strategies.Abstractions.Tests.Operations.Http.Soap.Models;

using System.Xml.Linq;
using Defra.Livestock.Sdk.Api.Strategies.Abstractions.Operations.Http.Soap.Models;
using Shouldly;
using Xunit;

public class SoapResponseTests
{
    [Fact]
    public void Properties_ShouldGetAndSetCorrectly()
    {
        // Arrange
        var xmlElement = new XElement("root", "content");

        // Act
        var response = new SoapResponse
        {
            HasContent = true,
            HasBody = true,
            BodyContent = xmlElement,
            HasSoapFault = true,
            SoapFaultCode = "Client",
            SoapFaultDetails = "Fault details occurred",
        };

        // Assert
        response.HasContent.ShouldBeTrue();
        response.HasBody.ShouldBeTrue();
        response.HasBodyContent.ShouldBeTrue();
        response.BodyContent.ShouldBeSameAs(xmlElement);
        response.HasSoapFault.ShouldBeTrue();
        response.SoapFaultCode.ShouldBe("Client");
        response.SoapFaultDetails.ShouldBe("Fault details occurred");
    }

    [Fact]
    public void HasBodyContent_WhenBodyContentIsNull_ShouldReturnFalse()
    {
        // Arrange
        var response = new SoapResponse
        {
            BodyContent = null,
        };

        // Assert
        response.HasBodyContent.ShouldBeFalse();
    }
}
