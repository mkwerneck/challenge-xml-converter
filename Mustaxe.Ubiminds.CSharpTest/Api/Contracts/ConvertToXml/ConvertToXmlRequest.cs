using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

namespace Mustaxe.Ubiminds.CSharpTest.Api.Contracts.ConvertToXml;

public class ConvertToXmlRequest<T> : RawData<T>
    where T : RawMetadata
{
}
