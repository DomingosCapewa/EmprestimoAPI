using Emprestimo.Application.Interfaces;
using Emprestimo.Infra.Persistence;
using Emprestimo.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Emprestimo.Infra;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfra(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder> configureDb)
    {
        services.AddDbContext<BibliotecaDbContext>(configureDb);
        services.AddScoped<ILivroRepository, LivroRepository>();
        services.AddScoped<IBibliotecarioRepository, BibliotecarioRepository>();

        return services;
    }
}
