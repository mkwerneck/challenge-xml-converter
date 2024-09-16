using Bogus.Extensions.Brazil;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Xml;

namespace Mustaxe.Ubiminds.CSharpTest.Tests.Domain.Models.Raw.CompanyMetadataUnitTests;

public class MapToXmlShould : CompanyMetadataBaseTest
{
    [Fact(DisplayName = "Map appropriatelly to Xml")]
    [Trait("Category", "Unit")]
    public void MapAppropriatellyToXml()
    {
        //Arrange
        _companyMetadata.CompanyName = _faker.Company.CompanyName();
        _companyMetadata.RegistrationNumber = _faker.Company.Cnpj();
        _companyMetadata.Address = _faker.Address.FullAddress();
        _companyMetadata.FoundedDate = _faker.Date.Past();

        //Act
        var result = _companyMetadata.MapToXml();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<XmlCompanyMetadata>(result);

        Assert.Equal(_companyMetadata.CompanyName, result.Name);
        Assert.Equal(_companyMetadata.Address, result.Address);
        Assert.Equal(_companyMetadata.RegistrationNumber, result.RegistrationNo);
        Assert.Equal(_companyMetadata.FoundedDate.ToString(), result.FoundedAt);
    }
}
