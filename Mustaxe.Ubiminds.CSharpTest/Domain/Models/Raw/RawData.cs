using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Xml;

namespace Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

public class RawData<T> : IXmlConvertible 
    where T : RawMetadata
{
    public string Id { get; set; } = string.Empty;
    public List<string> CountryIds { get; set; } = new();
    public string Title { get; set; } = string.Empty;
    public T? ReportMetaData { get; set; }
    public DateTime PublishDate { get; set; }
    public Status Status { get; set; }
    public bool TestRun { get; set; }

    public IXmlConverted MapToXml()
    {
        return new XmlRoot
        {
            PublishedItem = new XmlData
            {
                PublishedDate = PublishDate.ToString(),
                Countries = CountryIds,
                Title = Title,
                ContactInformation = (XmlMetadata)ReportMetaData?.MapToXml()
            }
        };
    }
}
