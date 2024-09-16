using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Xml;
using System;

namespace Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

public class UserMetadata : RawMetadata
{
    public List<Section> ContactSection { get; set; } = new();

    public override string SectionName => "user";

    public override XmlUserMetadata MapToXml()
    {
        var contacts = ContactSection?
                        .SelectMany(s => s.ContactInformation
                            .SelectMany(s => s.Contacts.Where(s => !string.IsNullOrEmpty(s.Email))))
                        .ToList();

        var userMetadata = new XmlUserMetadata();

        if (contacts is not null && contacts.Count > 0) 
        {
            userMetadata.PersonGroup.PersonGroupMember.Person.AddRange(contacts!.Select(s => new XmlPerson
            {
                FamilyName = s.LastName,
                GivenName = s.FirstName,
                DisplayName = s.FullName,
                JobTitle = s.Title,
                ContactInfo = new XmlContact
                {
                    Phone = new XmlPhone
                    {
                        Number = s.PhoneNumber
                    }
                }
            }).ToList());
        }

        return userMetadata;
    }
}

public class Section 
{
    public List<Information> ContactInformation { get; set; } = new();
}

public class Information 
{
    public string ContactHeader { get; set; } = string.Empty;
    public List<Contact> Contacts { get; set; } = new();
}

public class Contact 
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Accreditation { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";
}