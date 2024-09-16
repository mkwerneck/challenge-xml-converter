namespace Mustaxe.Ubiminds.CSharpTest.Domain.Models.Xml;

public class XmlUserMetadata : XmlMetadata
{
    
    public XmlPersonGroup PersonGroup { get; set; } = new();
}

public class XmlPersonGroup 
{
    public string Name => "Analytical Contacts";
    public XmlPersonGroupMember PersonGroupMember { get; set; } = new();

}

public class XmlPersonGroupMember 
{
    public List<XmlPerson> Person { get; set; } = new();
}

public class XmlPerson 
{
    public string FamilyName { get; set; } = string.Empty;
    public string GivenName { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public XmlContact ContactInfo { get; set; } = new();
}

public class XmlContact 
{
    public XmlPhone Phone { get; set; } = new();
}

public class XmlPhone 
{
    public string Number { get; set; } = string.Empty;
}