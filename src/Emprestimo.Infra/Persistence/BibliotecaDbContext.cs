using Emprestimo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Emprestimo.Infra.Persistence;

public class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Livro> Livros => Set<Livro>();
}