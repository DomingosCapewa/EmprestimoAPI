namespace Emprestimo.Application.Interfaces;

public interface IEmprestimoService
{
    void EmprestarLivro(Guid livroId);
    void DevolverLivro(Guid livroId);
}
