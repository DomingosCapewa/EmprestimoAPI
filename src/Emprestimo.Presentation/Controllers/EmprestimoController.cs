using Emprestimo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimo.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmprestimoController : ControllerBase
{
    private readonly IEmprestimoService _emprestimoService;

    public EmprestimoController(IEmprestimoService emprestimoService)
    {
        _emprestimoService = emprestimoService;
    }

    [HttpPost("{livroId:guid}/emprestar")]
    public IActionResult Emprestar(Guid livroId)
    {
        try
        {
            _emprestimoService.EmprestarLivro(livroId);
            return Ok(new { mensagem = "Livro emprestado com sucesso" });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { erro = "Erro ao emprestar livro" });
        }
    }

    [HttpPost("{livroId:guid}/devolver")]
    public IActionResult Devolver(Guid livroId)
    {
        try
        {
            _emprestimoService.DevolverLivro(livroId);
            return Ok(new { mensagem = "Livro devolvido com sucesso" });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { erro = "Erro ao devolver livro" });
        }
    }
}
