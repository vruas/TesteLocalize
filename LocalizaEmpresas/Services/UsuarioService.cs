using AutoMapper;
using LocalizaEmpresas.Dtos;
using LocalizaEmpresas.Models;
using Microsoft.AspNetCore.Identity;

namespace LocalizaEmpresas.Services;

public class UsuarioService
{
    private readonly IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<IdentityResult>CadastrarUsuarioAsync(CadastraUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);

        IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Erro ao cadastrar usuário: " + string.Join(", ", resultado.Errors.Select(e => e.Description)));
        }

        return resultado;
    }
}