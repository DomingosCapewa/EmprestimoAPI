namespace Emprestimo.Domain.Entities;

public class Livro
{
    public Guid Id { get; private set; }
    public string Titulo { get; private set; }
    public bool EstaEmprestado { get; private set; }

    public Livro(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("Título inválido.", nameof(titulo));

        Id = Guid.NewGuid();
        Titulo = titulo;
        EstaEmprestado = false;
    }

    public Livro(Guid id, string titulo, bool estaEmprestado)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("Título inválido.", nameof(titulo));

        Id = id;
        Titulo = titulo;
        EstaEmprestado = estaEmprestado;
    }

    public void RealizarEmprestimo()
    {
        if (EstaEmprestado)
            throw new Exception("Livro já está com outro usuário.");

        EstaEmprestado = true;
    }

    public void RealizarDevolucao()
    {
        if (!EstaEmprestado)
            throw new Exception("Livro já está disponível.");

        EstaEmprestado = false;
    }
}