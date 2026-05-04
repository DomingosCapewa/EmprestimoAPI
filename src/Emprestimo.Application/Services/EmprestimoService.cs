using Emprestimo.Application.Interfaces;

namespace Emprestimo.Application.Services;

public class EmprestimoService : IEmprestimoService
{
    private readonly ILivroRepository _livroRepository;

    public EmprestimoService(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public void DevolverLivro(Guid livroId)
    {
        var livro = _livroRepository.ObterPorId(livroId)
            ?? throw new InvalidOperationException("Livro não encontrado.");

        livro.RealizarDevolucao();
        _livroRepository.Salvar(livro);
    }

    public void EmprestarLivro(Guid livroId)
    {
        var livro = _livroRepository.ObterPorId(livroId)
            ?? throw new InvalidOperationException("Livro não encontrado.");

        livro.RealizarEmprestimo();
        _livroRepository.Salvar(livro);
    }
}
