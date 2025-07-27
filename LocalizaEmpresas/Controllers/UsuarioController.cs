using LocalizaEmpresas.Dtos;
using LocalizaEmpresas.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocalizaEmpresas.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações de cadastro, login e listagem de usuários.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        /// <summary>
        /// Construtor do controlador de usuários.
        /// </summary>
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="dto">Objeto com os dados do usuário a ser cadastrado.</param>
        /// <returns>Mensagem de sucesso após o cadastro.</returns>
        /// <response code="200">Usuário cadastrado com sucesso.</response>
        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CadastraUsuarioDto dto)
        {
            await _usuarioService.CadastrarUsuarioAsync(dto);
            return Ok("Usuário cadastrado com sucesso!");
        }

        /// <summary>
        /// Realiza o login do usuário.
        /// </summary>
        /// <param name="dto">Credenciais do usuário.</param>
        /// <returns>Token JWT e dados do usuário autenticado.</returns>
        /// <response code="200">Login realizado com sucesso.</response>
        /// <response code="401">Credenciais inválidas.</response>
        [HttpPost("login")]
        public async Task<IActionResult> LoginUsuario([FromBody] LoginUsuarioDto dto)
        {
            var usuario = await _usuarioService.LoginUsuarioAsync(dto);
            return Ok(usuario);
        }

        /// <summary>
        /// Lista todos os usuários cadastrados.
        /// </summary>
        /// <returns>Lista de usuários.</returns>
        /// <response code="200">Lista de usuários retornada com sucesso.</response>
        [HttpGet("listarUsuarios")]
        public async Task<IActionResult> ObterUsuarios()
        {
            var usuarios = await _usuarioService.ObterUsuariosAsync();
            return Ok(usuarios);
        }
    }
}
