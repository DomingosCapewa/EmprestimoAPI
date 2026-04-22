using Emprestimo.Domain.Repositories;
using Emprestimo.Infra.Persistence;
using Emprestimo.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<BibliotecaDbContext>(options =>
    options.UseInMemoryDatabase("EmprestimoDb"));
builder.Services.AddScoped<ILivroRepository, LivroRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
   
    return "Api rodando!";
});

app.Run();
