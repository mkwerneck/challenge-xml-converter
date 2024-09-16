using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Xml;

namespace Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

public class CompanyMetadata : RawMetadata
{
    public string CompanyName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string RegistrationNumber { get; set; } = string.Empty;
    public DateTime FoundedDate { get; set; }
    public override string SectionName => "company";

    public override XmlCompanyMetadata MapToXml()
    {
        return new XmlCompanyMetadata
        {
            Address = Address,
            FoundedAt = FoundedDate.ToString(),
            Name = CompanyName,
            RegistrationNo = RegistrationNumber,
        };
    }
}
