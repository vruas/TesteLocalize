using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalizaEmpresas.Controllers
{
    /// <summary>
    /// Controller responsável por verificar o acesso autorizado à API.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AcessoController : ControllerBase
    {
        /// <summary>
        /// Endpoint protegido que retorna uma mensagem de acesso permitido.
        /// </summary>
        /// <remarks>
        /// Esse endpoint exige autenticação via token JWT.
        /// </remarks>
        /// <returns>Mensagem indicando que o acesso foi permitido.</returns>
        /// <response code="200">Acesso permitido com sucesso.</response>
        [HttpGet()]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Acesso permitido!");
        }
    }
}
