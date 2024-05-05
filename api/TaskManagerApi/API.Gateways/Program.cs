using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false,  reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
    {
        o.MetadataAddress = "http://localhost:8080/identity/realms/secured/.well-known/openid-configuration";
        o.RequireHttpsMetadata = false;
        o.Authority = "http://localhost:8080/realms/secured";
        o.Audience = "account";
    });

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseAuthentication();
app.UseAuthorization();

await app.UseOcelot();
await app.RunAsync();
