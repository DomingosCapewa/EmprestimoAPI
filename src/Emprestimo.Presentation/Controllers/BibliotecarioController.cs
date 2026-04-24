using Microsoft.AspNetCore.Mvc;

namespace Emprestimo.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BibliotecarioController : ControllerBase
    {

        public BibliotecarioController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Bibliotecário API funcionando!");
        }
    }
}