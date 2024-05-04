using Ocelot.DependencyInjection;
using Ocelot.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false,  reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
await app.UseOcelot();
app.Run();
