using RestWithASPNET10.Configurations;
using RestWithASPNET10.Services;
using RestWithASPNET10.Services.Impl;

var builder = WebApplication.CreateBuilder(args);
builder.AddSerilogLogging();
builder.Services.AddControllers();
builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
builder.Services.AddOpenApi();
builder.Services.AddDatabaseConfiguration(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment()){app.MapOpenApi();}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
