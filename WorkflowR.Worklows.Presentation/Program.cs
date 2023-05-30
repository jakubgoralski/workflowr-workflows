using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Options;
using System.Net;
using WorkflowR.Worklows.Presentation.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPresentation();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    var port = 443;


    serverOptions.Listen(IPAddress.Any, port, listenOptions => {
        // Enable support for HTTP1 and HTTP2 (required if you want to host gRPC endpoints)
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
        // Configure Kestrel to use a certificate from a local .PFX file for hosting HTTPS
        listenOptions.UseHttps();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.MapGraphQL();

app.Run();