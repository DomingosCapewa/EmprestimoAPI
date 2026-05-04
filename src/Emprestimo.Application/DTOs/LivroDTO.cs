namespace Emprestimo.Application.DTOs
{
    public class LivroDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public bool EstaEmprestado { get; set; }
    }
}