namespace Mustaxe.Ubiminds.CSharpTest.Api.Contracts.ConvertToXml;

public class ConvertToXmlResponse
{
    public string FilePath { get; set; }

    public ConvertToXmlResponse(string filePath)
    {
        FilePath = filePath;
    }
}
