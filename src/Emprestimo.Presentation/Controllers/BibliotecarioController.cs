using Emprestimo.Application.DTOs;
using Emprestimo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimo.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BibliotecarioController : ControllerBase
{
    private readonly IBibliotecarioService _bibliotecarioService;

    public BibliotecarioController(IBibliotecarioService bibliotecarioService)
    {
        _bibliotecarioService = bibliotecarioService;
    }

    [HttpGet("GetAllLivros")]
    public IActionResult GetAllLivros()
    {
        try
        {
            var livros = _bibliotecarioService.GetAllLivros();
            if(livros == null || !livros.Any())
                return NotFound(new { aviso = "Nenhum livro encontrado" });
            return Ok(livros);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { erro = "Erro ao obter livros, " + ex.Message });
        }
    }

    [HttpGet("{livroId:guid}")]
    public IActionResult ConsultarLivro(Guid livroId)
    {
        try
        {
            var livro = _bibliotecarioService.ConsultarLivro(livroId);
            if (livro == null)
                return NotFound(new { erro = "Livro não encontrado" });

            return Ok(livro);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { erro = "Erro ao consultar livro, " + ex.Message });
        }
    }

    [HttpPost("RegisterLivro")]
    public IActionResult RegistrarLivro([FromBody] LivroCreateDTO livro)
    {
        try
        {
            if (livro == null)
                return BadRequest(new { erro = "Livro não pode estar vazio" });

            var livroCriado = _bibliotecarioService.RegistrarLivro(livro);
            return CreatedAtAction(nameof(ConsultarLivro), new { livroId = livroCriado.Id }, livroCriado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { erro = "Erro ao registrar livro, " + ex.Message });
        }
    }

    [HttpDelete("{livroId:guid}")]
    public IActionResult RemoverLivro(Guid livroId)
    {
        try
        {
            var livro = _bibliotecarioService.ConsultarLivro(livroId);
            if (livro == null)
                return NotFound(new { erro = "Livro não encontrado" });

            _bibliotecarioService.RemoverLivro(livro);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { erro = "Erro ao remover livro, " + ex.Message });
        }
    }
}