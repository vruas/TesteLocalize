using LocalizaEmpresas.Dtos;
using LocalizaEmpresas.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocalizaEmpresas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CadastraUsuarioDto dto)
        {
            await _usuarioService.CadastrarUsuarioAsync(dto);
            return Ok("Usuário cadastrado com sucesso!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUsuario([FromBody] LoginUsuarioDto dto)
        {
            var usuario = await _usuarioService.LoginUsuarioAsync(dto);
            return Ok(usuario);
        }

        [HttpGet("listarUsuarios")]
        public async Task<IActionResult> ObterUsuarios()
        {
            var usuarios = await _usuarioService.ObterUsuariosAsync();
            return Ok(usuarios);
        }


    }
}
