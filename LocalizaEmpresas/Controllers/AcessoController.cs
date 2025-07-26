using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalizaEmpresas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessoController : ControllerBase
    {
        [HttpGet()]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Acesso permitido!");
        }
    }
}
