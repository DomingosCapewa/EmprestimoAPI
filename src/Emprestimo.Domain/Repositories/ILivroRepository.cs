using Emprestimo.Domain.Entities;

namespace Emprestimo.Domain.Repositories;

public interface ILivroRepository
{
    Livro? ObterPorId(Guid id);

    void Salvar(Livro livro);
}