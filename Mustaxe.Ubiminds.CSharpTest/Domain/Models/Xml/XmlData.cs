namespace Mustaxe.Ubiminds.CSharpTest.Domain.Models.Xml;

public class XmlData
{
    public string Title { get; set; } = string.Empty;
    public List<string> Countries { get; set; } = new();
    public string PublishedDate { get; set; } = string.Empty;
    public XmlMetadata? ContactInformation { get; set; }
}
