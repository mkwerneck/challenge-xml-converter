using Bogus;
using Mustaxe.Ubiminds.CSharpTest.Application.Commands.ConvertToXml;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

namespace Mustaxe.Ubiminds.CSharpTest.Tests.Application.Commands.ConvertToXml.ConvertToXmlCommandHandlerUnitTests;

public class ConvertToXmlCommandHandlerBaseTest
{
    protected readonly Faker _faker = new();
    protected readonly ConvertToXmlCommandHandler<UserMetadata> _handler = new();
    protected readonly CancellationToken _cancellationToken = new();
}
