using Emprestimo.Application.DTOs;

namespace Emprestimo.Application.Interfaces
{
    public interface IBibliotecarioService
    {
        IEnumerable<LivroDTO> GetAllLivros();
        LivroDTO RegistrarLivro(LivroCreateDTO livro);
        void RemoverLivro(LivroDTO livro);
        LivroDTO? ConsultarLivro(Guid livroId);
    }
}