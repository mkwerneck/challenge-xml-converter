using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Xml;

namespace Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

public abstract class RawMetadata : IXmlConvertible
{
    public abstract string SectionName { get; }
    public string Title { get; set; } = string.Empty;

    public abstract IXmlConverted MapToXml();
}
