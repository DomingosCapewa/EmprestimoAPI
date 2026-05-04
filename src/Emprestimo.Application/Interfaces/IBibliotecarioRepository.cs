using Emprestimo.Application.DTOs;

namespace Emprestimo.Application.Interfaces;

public interface IBibliotecarioRepository
{
    IEnumerable<LivroDTO> GetAllLivros();
    LivroDTO RegisterLivro(LivroCreateDTO livro);
    void RemoveLivro(LivroDTO livro);
    LivroDTO? ConsultarLivro(Guid livroId);
}
