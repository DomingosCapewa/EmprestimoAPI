using Emprestimo.Application.Interfaces;
using Emprestimo.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Emprestimo.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IEmprestimoService, EmprestimoService>();
        return services;
    }
}
