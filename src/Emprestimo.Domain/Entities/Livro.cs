namespace Emprestimo.Domain.Entities;

public class Livro
{
    public Guid Id { get; private set; }
    public string Titulo { get; private set; }
    public bool EstaEmprestado { get; private set; }

    public Livro(string titulo)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        EstaEmprestado = false;
    }

    public void RealizarEmprestimo()
    {
        if (EstaEmprestado)
            throw new Exception("Livro já está com outro usuário.");

        EstaEmprestado = true;
    }
}