using Emprestimo.Domain.Entities;
using Emprestimo.Domain.Repositories;
using Emprestimo.Infra.Persistence;

namespace Emprestimo.Infra.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly BibliotecaDbContext _context;

    public LivroRepository(BibliotecaDbContext context)
    {
        _context = context;
    }

    public Livro? ObterPorId(Guid id)
    {
        return _context.Livros.FirstOrDefault(livro => livro.Id == id);
    }

    public void Salvar(Livro livro)
    {
        _context.Livros.Add(livro);
        _context.SaveChanges();
    }
}