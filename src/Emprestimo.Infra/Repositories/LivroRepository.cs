using Emprestimo.Application.Interfaces;
using Emprestimo.Domain.Entities;
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
        var existente = _context.Livros.FirstOrDefault(item => item.Id == livro.Id);

        if (existente is null)
        {
            _context.Livros.Add(livro);
        }
        else
        {
            _context.Entry(existente).CurrentValues.SetValues(livro);
        }

        _context.SaveChanges();
    }
}