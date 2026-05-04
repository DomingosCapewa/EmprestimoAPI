using Emprestimo.Application.Extensions;
using Emprestimo.Infra;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication();
var configuredConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(configuredConnectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' não configurada.");
}

builder.Services.AddInfra(options =>
    options.UseMySql(
        configuredConnectionString,
        ServerVersion.AutoDetect(configuredConnectionString)
    ));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Emprestimo API",
        Version = "v1"
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Emprestimo API v1");
        options.RoutePrefix = "swagger";
    });
}

app.MapGet("/", () =>
{
    return Results.Redirect("/swagger");
});
app.UseHttpsRedirection();

app.MapControllers();


app.Run();
