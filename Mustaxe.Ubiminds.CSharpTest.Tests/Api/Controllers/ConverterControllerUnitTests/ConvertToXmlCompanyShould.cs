using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Mustaxe.Ubiminds.CSharpTest.Api.Contracts.ConvertToXml;
using Mustaxe.Ubiminds.CSharpTest.Application.Commands.ConvertToXml;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

namespace Mustaxe.Ubiminds.CSharpTest.Tests.Api.Controllers.ConverterControllerUnitTests;

public class ConvertToXmlCompanyShould : ConverterControllerBaseTest
{
    [Fact(DisplayName = "Return Problem With Errors When Result Is An Error")]
    [Trait("Category", "Unit")]
    public async Task ReturnProblemWithErrorsWhenResultIsAError()
    {
        //Arrange
        var request = new ConvertToXmlRequest<CompanyMetadata>
        {
            Id = Guid.NewGuid().ToString(),
            PublishDate = DateTime.Today,
            Status = Status.Valid,
            TestRun = true
        };
        var response = Error.Failure("code", "description");

        var senderResult = _mockSender.Setup(s => s.Send(It.IsAny<ConvertToXmlCommand<CompanyMetadata>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);
        
        //Act
        var result = await _controller.ConvertToXmlCompany(request);
        var objectResult = (ObjectResult)result;

        //Assert
        Assert.NotNull(objectResult);
        Assert.Equal(StatusCodes.Status400BadRequest, objectResult.StatusCode);
    }

    [Fact(DisplayName = "Return Ok When Result Is Not An Error")]
    [Trait("Category", "Unit")]
    public async Task ReturnOkWhenResultIsNotAnError()
    {
        //Arrange
        var request = new ConvertToXmlRequest<CompanyMetadata>
        {
            Id = Guid.NewGuid().ToString(),
            PublishDate = DateTime.Today,
            Status = Status.Valid,
            TestRun = true
        };
        var response = _faker.Internet.Url();

        var senderResult = _mockSender.Setup(s => s.Send(It.IsAny<ConvertToXmlCommand<CompanyMetadata>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        //Act
        var result = await _controller.ConvertToXmlCompany(request);
        var objectResult = (ObjectResult)result;

        //Assert
        Assert.NotNull(objectResult);
        Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
    }
}
