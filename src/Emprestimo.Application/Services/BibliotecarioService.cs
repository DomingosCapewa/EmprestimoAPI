
using Emprestimo.Application.DTOs;
using Emprestimo.Application.Interfaces;

namespace Emprestimo.Application.Services;

public class BibliotecarioService : IBibliotecarioService
{
    private readonly IBibliotecarioRepository _bibliotecarioRepository;

    public BibliotecarioService(IBibliotecarioRepository bibliotecarioRepository)
    {
        _bibliotecarioRepository = bibliotecarioRepository;
    }

    public LivroDTO RegistrarLivro(LivroCreateDTO livro)
    {
        return _bibliotecarioRepository.RegisterLivro(livro);
    }

    public void RemoverLivro(LivroDTO livro)
    {
        _bibliotecarioRepository.RemoveLivro(livro);
    }

    public LivroDTO? ConsultarLivro(Guid livroId)
    {
        return _bibliotecarioRepository.ConsultarLivro(livroId);
    }

    public IEnumerable<LivroDTO> GetAllLivros()
    {
        return _bibliotecarioRepository.GetAllLivros();
    }
}