using Emprestimo.Domain.Entities;

namespace Emprestimo.Application.Interfaces;

public interface ILivroRepository
{
    Livro? ObterPorId(Guid id);

    void Salvar(Livro livro);
}