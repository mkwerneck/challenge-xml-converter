using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Mustaxe.Ubiminds.CSharpTest.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    private readonly IHttpContextAccessor _contextAccessor;

    public ApiController(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    protected IActionResult Problem(List<Error> errors) 
    {
        if (errors.Count is 0)
            return Problem();

        if (errors.All(error => error.Type == ErrorType.Validation))
            return ValidationProblem(errors);

        _contextAccessor.HttpContext!.Items["Errors"] = errors;

        var firstError = errors[0];

        return Problem(firstError);
    }

    private IActionResult ValidationProblem(List<Error> errors) 
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var error in errors) 
        {
            modelStateDictionary.AddModelError(
                error.Code, 
                error.Description);
        }

        return ValidationProblem(
            modelStateDictionary: modelStateDictionary,
            instance: _contextAccessor.HttpContext?.Request.Path);
    }

    private IActionResult Problem(Error error) 
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation or ErrorType.Failure => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(
            statusCode: statusCode,
            detail: $"{error.Code} - {error.Description}",
            instance: _contextAccessor.HttpContext?.Request.Path);
    }
}
