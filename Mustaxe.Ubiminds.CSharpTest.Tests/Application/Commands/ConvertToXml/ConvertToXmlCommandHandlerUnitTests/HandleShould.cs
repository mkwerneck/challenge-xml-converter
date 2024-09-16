using Bogus;
using ErrorOr;
using Mustaxe.Ubiminds.CSharpTest.Application.Commands.ConvertToXml;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Xml;

namespace Mustaxe.Ubiminds.CSharpTest.Tests.Application.Commands.ConvertToXml.ConvertToXmlCommandHandlerUnitTests;

public class HandleShould : ConvertToXmlCommandHandlerBaseTest
{
    [Fact(DisplayName = "Return validation errors when validation do not pass")]
    [Trait("Category", "Unit")]
    public async Task ReturnValidationErrorsWhenValidationDoNotPass()
    {
        //Arrange
        var rawData = new RawData<UserMetadata>
        {
            PublishDate = new DateTime(2020, 1, 1),
            Status = Status.Invalid,
            TestRun = false
        };
        var command = new ConvertToXmlCommand<UserMetadata>(rawData);
        //Act
        var result = await _handler.Handle(command, _cancellationToken);

        //Assert
        Assert.IsType<ErrorOr<string>>(result);

        Assert.True(result.IsError);
        Assert.Equal(3, result.Errors.Where(s => s.Type == ErrorType.Validation).Count());
    }

    [Fact(DisplayName = "Create Xml And Return The File Path")]
    [Trait("Category", "Unit")]
    public async Task CreateXmlAndReturnTheFilePath()
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
        var result = await _handler.Handle(command, _cancellationToken);

        //Assert
        Assert.IsType<ErrorOr<string>>(result);

        Assert.False(result.IsError);
        Assert.True(File.Exists(result.Value));

        File.Delete(result.Value);
    }
}
