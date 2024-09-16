
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mustaxe.Ubiminds.CSharpTest.Api.Contracts.ConvertToXml;
using Mustaxe.Ubiminds.CSharpTest.Application.Commands.ConvertToXml;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

namespace Mustaxe.Ubiminds.CSharpTest.Api.Controllers;

[Route("/api/converter")]
public class ConverterController : ApiController
{
    private readonly ISender _sender;

    public ConverterController(
        IHttpContextAccessor contextAccessor, 
        ISender sender) : base(contextAccessor)
    {
        _sender = sender;
    }

    [HttpPost("convert-to-xml-user")]
    public async Task<IActionResult> ConvertToXmlUser([FromBody] ConvertToXmlRequest<UserMetadata> request)
    {
        var result = await _sender.Send(new ConvertToXmlCommand<UserMetadata>(request));

        return result.Match(
            sucess => Ok(new ConvertToXmlResponse(result.Value)),
            errors => Problem(errors));
    }

    [HttpPost("convert-to-xml-company")]
    public async Task<IActionResult> ConvertToXmlCompany([FromBody] ConvertToXmlRequest<CompanyMetadata> request)
    {
        var result = await _sender.Send(new ConvertToXmlCommand<CompanyMetadata>(request));

        return result.Match(
            sucess => Ok(new ConvertToXmlResponse(result.Value)),
            errors => Problem(errors));
    }
}
