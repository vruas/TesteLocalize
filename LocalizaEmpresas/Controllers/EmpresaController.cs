using AutoMapper;
using LocalizaEmpresas.Data;
using LocalizaEmpresas.Dtos;
using LocalizaEmpresas.Models;
using LocalizaEmpresas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CadastrarEmpresa), new { id = empresa.Id }, empresa);
        }

        [HttpGet()]
        public IActionResult ListarEmpresas()
        {
            var empresas = _context.Empresas.ToList();
            return Ok(empresas);
        }
    }
}
