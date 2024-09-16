using Mustaxe.Ubiminds.CSharpTest.Application.Commands.ConvertToXml;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

namespace Mustaxe.Ubiminds.CSharpTest.Tests.Application.Commands.ConvertToXml.ConvertToXmlCommandValidatorUnitTests;

public class ConvertToXmlCommandValidatorBaseTest
{
    protected readonly ConvertToXmlCommandValidator<UserMetadata> _validator = new();
}
