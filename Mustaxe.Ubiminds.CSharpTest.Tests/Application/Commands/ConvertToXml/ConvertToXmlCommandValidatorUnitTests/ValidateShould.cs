using ErrorOr;
using Mustaxe.Ubiminds.CSharpTest.Application.Commands.ConvertToXml;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;
using System.Reflection.Metadata;
using System.Threading;

namespace Mustaxe.Ubiminds.CSharpTest.Tests.Application.Commands.ConvertToXml.ConvertToXmlCommandValidatorUnitTests;

public class ValidateShould : ConvertToXmlCommandValidatorBaseTest
{
    [Fact(DisplayName = "Return Validation Error When Status Is Invalid")]
    [Trait("Category", "Unit")]
    public void ReturnValidationErrorWhenStatusIsInvalid()
    {
        //Arrange
        var rawData = new RawData<UserMetadata>
        {
            Id = Guid.NewGuid().ToString(),
            PublishDate = DateTime.Today,
            Status = Status.Invalid,
            TestRun = true,
            ReportMetaData = new UserMetadata()
        };
        var command = new ConvertToXmlCommand<UserMetadata>(rawData);
        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);
        Assert.Equal("Invalid Status value", result.Errors.FirstOrDefault()!.ErrorMessage);
    }

    [Fact(DisplayName = "Return Validation Error When TestRun Is Invalid")]
    [Trait("Category", "Unit")]
    public void ReturnValidationErrorWhenTestRunIsInvalid()
    {
        //Arrange
        var rawData = new RawData<UserMetadata>
        {
            Id = Guid.NewGuid().ToString(),
            PublishDate = DateTime.Today,
            Status = Status.Valid,
            TestRun = false,
            ReportMetaData = new UserMetadata()
        };
        var command = new ConvertToXmlCommand<UserMetadata>(rawData);
        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);
        Assert.Equal("Invalid TestRun value", result.Errors.FirstOrDefault()!.ErrorMessage);
    }

    [Fact(DisplayName = "Return Validation Error When PublishDate Is Invalid")]
    [Trait("Category", "Unit")]
    public void ReturnValidationErrorWhenPublishDateIsInvalid()
    {
        //Arrange
        var rawData = new RawData<UserMetadata>
        {
            Id = Guid.NewGuid().ToString(),
            PublishDate = new DateTime(2020, 1, 1),
            Status = Status.Valid,
            TestRun = true,
            ReportMetaData = new UserMetadata()
        };
        var command = new ConvertToXmlCommand<UserMetadata>(rawData);
        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);
        Assert.Equal("Invalid Publish Date value", result.Errors.FirstOrDefault()!.ErrorMessage);
    }

    [Fact(DisplayName = "Return Success Validation Result When All Validations Passes")]
    [Trait("Category", "Unit")]
    public void ReturnSuccessValidationResultWhenAllValidationsPasses()
    {
        //Arrange
        var rawData = new RawData<UserMetadata>
        {
            Id = Guid.NewGuid().ToString(),
            PublishDate = DateTime.Today,
            Status = Status.Valid,
            TestRun = true,
            ReportMetaData = new UserMetadata()
        };
        var command = new ConvertToXmlCommand<UserMetadata>(rawData);
        //Act
        var result = _validator.Validate(command);

        //Assert
        Assert.True(result.IsValid);
    }
}
