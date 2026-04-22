using Microsoft.AspNetCore.Mvc;

namespace Emprestimo.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmprestimoController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Presentation layer ativa.");
    }
}
