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

        [HttpGet()]
        public IActionResult ListarEmpresas([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            string usuarioId = User.FindFirstValue("id");

            var empresas = _context.Empresas
                .Where(empresas => empresas.UsuarioId == usuarioId)
                .Skip(skip)
                .Take(take)
                .ToList();
            return Ok(empresas);
        }

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
