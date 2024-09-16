using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Xml;

namespace Mustaxe.Ubiminds.CSharpTest.Tests.Domain.Models.Raw.UserMetadataUnitTests;

public class MapToXmlShould : UserMetadataBaseTest
{

    [Fact(DisplayName = "Map appropriatelly to Xml")]
    [Trait("Category", "Unit")]
    public void MapAppropriatellyToXml() 
    {
        //Arrange
        var contact = new Contact
        {
            Accreditation = _faker.Company.Bs(),
            Email = _faker.Person.Email,
            FirstName = _faker.Person.FirstName,
            LastName = _faker.Person.LastName,
            PhoneNumber = _faker.Phone.PhoneNumber(),
            Title = _faker.Company.CatchPhrase()
        };

        _userMetadata.Title = _faker.Lorem.Word();
        _userMetadata.ContactSection.Add(new Section
        {
            ContactInformation = new List<Information> 
            {
                new Information 
                {
                    ContactHeader = _faker.Lorem.Word(),
                    Contacts = new List<Contact> { contact }
                }
            }
        });

        //Act
        var result = _userMetadata.MapToXml();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<XmlUserMetadata>(result);

        Assert.Equal(1, result.PersonGroup?.PersonGroupMember?.Person?.Count());

        Assert.Equal(contact.FirstName, result.PersonGroup!.PersonGroupMember.Person.FirstOrDefault()!.GivenName);
        Assert.Equal(contact.LastName, result.PersonGroup!.PersonGroupMember.Person.FirstOrDefault()!.FamilyName);
        Assert.Equal(contact.FullName, result.PersonGroup!.PersonGroupMember.Person.FirstOrDefault()!.DisplayName);
        Assert.Equal(contact.Title, result.PersonGroup!.PersonGroupMember.Person.FirstOrDefault()!.JobTitle);
        Assert.Equal(contact.PhoneNumber, result.PersonGroup!.PersonGroupMember.Person.FirstOrDefault()!.ContactInfo.Phone.Number);
    }
}
