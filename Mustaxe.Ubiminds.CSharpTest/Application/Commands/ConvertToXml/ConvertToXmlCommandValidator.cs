using FluentValidation;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

namespace Mustaxe.Ubiminds.CSharpTest.Application.Commands.ConvertToXml;

public class ConvertToXmlCommandValidator<T> : AbstractValidator<ConvertToXmlCommand<T>>
    where T : RawMetadata
{
    public ConvertToXmlCommandValidator()
    {
        RuleFor(r => r.Data.Status).Equal(Status.Valid)
            .WithMessage("Invalid Status value");

        RuleFor(r => r.Data.PublishDate).GreaterThanOrEqualTo(new DateTime(2024, 8, 24))
            .WithMessage("Invalid Publish Date value");

        RuleFor(r => r.Data.TestRun).Equal(true)
            .WithMessage("Invalid TestRun value");
    }
}
