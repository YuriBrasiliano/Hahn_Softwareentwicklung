using Hahn_Softwareentwicklung.Api;
using Hahn_Softwareentwicklung.Application;
using Hahn_Softwareentwicklung.Infrastructure;


var builder = WebApplication.CreateBuilder(args);


{   
    builder.Services.AddCors();
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
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

