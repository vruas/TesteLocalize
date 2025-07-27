using AutoMapper;
using LocalizaEmpresas.Data;
using LocalizaEmpresas.Dtos;
using LocalizaEmpresas.Models;
using LocalizaEmpresas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LocalizaEmpresas.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações relacionadas às empresas.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmpresaController : ControllerBase
    {
        private EmpresaContext _context;
        private IMapper _mapper;
        private ReceitaWsService _receitaWsService;

    
        public EmpresaController(EmpresaContext context, IMapper mapper, ReceitaWsService receitaWsService)
        {
            _context = context;
            _mapper = mapper;
            _receitaWsService = receitaWsService;
        }

        /// <summary>
        /// Cadastra uma nova empresa com base no CNPJ consultado via ReceitaWS.
        /// </summary>
        /// <param name="dto">Objeto contendo o CNPJ para cadastro da empresa.</param>
        /// <returns>Retorna a empresa criada ou erro caso o CNPJ não seja encontrado.</returns>
        /// <response code="201">Empresa cadastrada com sucesso.</response>
        /// <response code="404">CNPJ não encontrado ou inválido.</response>
        [HttpPost]
        public async Task<IActionResult> CadastrarEmpresa([FromBody] CadastroEmpresaDto dto)
        {
            var dadosReceita = await _receitaWsService.ConsultaCnpjAsync(dto.Cnpj);

            if (dadosReceita == null)
            {
                return NotFound("CNPJ não encontrado ou inválido.");
            }

            var empresa = _mapper.Map<Empresa>(dadosReceita);

            string usuarioId = User.FindFirstValue("id");
            empresa.UsuarioId = usuarioId;

            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CadastrarEmpresa), new { id = empresa.Id }, empresa);
        }

        /// <summary>
        /// Lista empresas do usuário autenticado com suporte a paginação.
        /// </summary>
        /// <param name="skip">Quantidade de registros a ignorar.</param>
        /// <param name="take">Quantidade de registros a retornar.</param>
        /// <returns>Lista paginada de empresas do usuário.</returns>
        /// <response code="200">Empresas retornadas com sucesso.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListarEmpresasDto>>> ListarEmpresas([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            string usuarioId = User.FindFirstValue("id");

            var empresas = await _context.Empresas
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            var empresasDto = _mapper.Map<IEnumerable<ListarEmpresasDto>>(empresas);

            return Ok(empresasDto);
        }

        /// <summary>
        /// Lista empresas associadas a um usuário específico com suporte a paginação.
        /// </summary>
        /// <param name="idUsuario">ID do usuário.</param>
        /// <param name="skip">Quantidade de registros a ignorar.</param>
        /// <param name="take">Quantidade de registros a retornar.</param>
        /// <returns>Lista de empresas do usuário informado.</returns>
        /// <response code="200">Empresas retornadas com sucesso.</response>
        /// <response code="404">Nenhuma empresa encontrada para o usuário informado.</response>
        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> ListarEmpresasPorUsuario(string idUsuario, [FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var empresas = await _context.Empresas
                .Where(e => e.UsuarioId == idUsuario)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            if (empresas == null || !empresas.Any())
            {
                return NotFound("Nenhuma empresa encontrada para este usuário.");
            }

            return Ok(empresas);
        }
    }
}
