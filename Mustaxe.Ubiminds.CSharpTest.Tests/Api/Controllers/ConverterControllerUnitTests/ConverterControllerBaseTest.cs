using Bogus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Moq;
using Mustaxe.Ubiminds.CSharpTest.Api.Controllers;

namespace Mustaxe.Ubiminds.CSharpTest.Tests.Api.Controllers.ConverterControllerUnitTests;

public class ConverterControllerBaseTest
{
    protected readonly Mock<ISender> _mockSender = new();
    protected readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor = new();
    protected readonly Faker _faker = new();
    protected readonly ConverterController _controller;

    public ConverterControllerBaseTest()
    {
        _mockHttpContextAccessor.Setup(s => s.HttpContext)
            .Returns(new DefaultHttpContext());

        _controller = new ConverterController(_mockHttpContextAccessor.Object, _mockSender.Object);
    }
}
