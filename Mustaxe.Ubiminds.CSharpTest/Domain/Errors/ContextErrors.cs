using ErrorOr;

namespace Mustaxe.Ubiminds.CSharpTest.Domain.Errors;

public static class ContextErrors
{
    public static Error ErrorParsingXml(string message) =>
        Error.Failure("Xml.Parsing", $"Could not parse the input model: {message}");
}
