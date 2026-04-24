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
        _emprestimoService.EmprestarLivro(livroId);
        return NoContent();
    }

    [HttpPost("{livroId:guid}/devolver")]
    public IActionResult Devolver()
    {
        return NoContent();
    }
}
