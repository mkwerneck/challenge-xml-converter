using ErrorOr;
using MediatR;
using Mustaxe.Ubiminds.CSharpTest.Application.Commands.ConvertToXml;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

    builder.Services.AddTransient<IRequestHandler<ConvertToXmlCommand<UserMetadata>, ErrorOr<string>>, ConvertToXmlCommandHandler<UserMetadata>>();
    builder.Services.AddTransient<IRequestHandler<ConvertToXmlCommand<CompanyMetadata>, ErrorOr<string>>, ConvertToXmlCommandHandler<CompanyMetadata>>();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

