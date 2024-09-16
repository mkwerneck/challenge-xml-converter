using ErrorOr;
using MediatR;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

namespace Mustaxe.Ubiminds.CSharpTest.Application.Commands.ConvertToXml;

public class ConvertToXmlCommand<T> : IRequest<ErrorOr<string>>
    where T : RawMetadata
{
    public RawData<T> Data { get; set; }

    public ConvertToXmlCommand(RawData<T> data)
    {
        Data = data;
    }
}
