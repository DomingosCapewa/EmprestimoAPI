using Emprestimo.Application.DTOs;
using Emprestimo.Application.Interfaces;
using Emprestimo.Domain.Entities;
using Emprestimo.Infra.Persistence;

namespace Emprestimo.Infra.Repositories;

public class BibliotecarioRepository : IBibliotecarioRepository
{
    private readonly BibliotecaDbContext _context;

    public BibliotecarioRepository(BibliotecaDbContext context)
    {
        _context = context;
    }

    public LivroDTO? ConsultarLivro(Guid livroId)
    {
        return _context.Livros
            .Where(item => item.Id == livroId)
            .Select(livro => new LivroDTO
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                EstaEmprestado = livro.EstaEmprestado
            })
            .FirstOrDefault();
    }

    public IEnumerable<LivroDTO> GetAllLivros()
    {
        return _context.Livros.Select(l => new LivroDTO
        {
            Id = l.Id,
            Titulo = l.Titulo,
            EstaEmprestado = l.EstaEmprestado
        }).ToList();
    }

    public LivroDTO RegisterLivro(LivroCreateDTO livro)
    {
        var entidade = new Livro(livro.Titulo);

        _context.Livros.Add(entidade);

        _context.SaveChanges();

        return new LivroDTO
        {
            Id = entidade.Id,
            Titulo = entidade.Titulo,
            EstaEmprestado = entidade.EstaEmprestado
        };
    }

    public void RemoveLivro(LivroDTO livro)
    {
        var existente = _context.Livros.FirstOrDefault(item => item.Id == livro.Id);

        if (existente is not null)
        {
            _context.Livros.Remove(existente);
        }

        _context.SaveChanges();
    }
}