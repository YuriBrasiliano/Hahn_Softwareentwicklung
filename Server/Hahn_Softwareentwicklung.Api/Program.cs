using Hahn_Softwareentwicklung.Api.Common.Errors;
using Hahn_Softwareentwicklung.Application;
using Hahn_Softwareentwicklung.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


{   
    builder.Services.AddCors();
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, HahnProblemDetailsFactory>();
}
 

var app = builder.Build();


{
    app.UseCors(c => {
        c.AllowAnyHeader();
        c.AllowAnyMethod();
        c.AllowAnyOrigin();
    });
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

