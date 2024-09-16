using ErrorOr;
using MediatR;
using Mustaxe.Ubiminds.CSharpTest.Domain.Errors;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;
using Newtonsoft.Json;

namespace Mustaxe.Ubiminds.CSharpTest.Application.Commands.ConvertToXml;

public class ConvertToXmlCommandHandler<T> : IRequestHandler<ConvertToXmlCommand<T>, ErrorOr<string>>
    where T : RawMetadata
{
    public async Task<ErrorOr<string>> Handle(ConvertToXmlCommand<T> request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var validator = new ConvertToXmlCommandValidator<T>();
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
            return validationResult.Errors
                .Select(s => Error.Validation(s.ErrorCode, s.ErrorMessage))
                .ToList();

        var xmlModel = request.Data.MapToXml();
        var serializedModel = JsonConvert.SerializeObject(xmlModel);

        try
        {
            var document = JsonConvert.DeserializeXmlNode(serializedModel);

            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
            string folderPath = Path.Combine(projectRoot, "Infrastructure", "ConvertionResult");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fullPath = Path.Combine(folderPath, $"{request.Data.ReportMetaData?.SectionName}-{request.Data.Id}.xml");

            document!.Save(fullPath);

            return fullPath;
        }
        catch (Exception ex) 
        {
            return ContextErrors.ErrorParsingXml(ex.Message);
        }
    }
}
