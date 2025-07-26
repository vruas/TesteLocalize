using AutoMapper;
using LocalizaEmpresas.Dtos;
using LocalizaEmpresas.Models;
using Microsoft.AspNetCore.Identity;

namespace LocalizaEmpresas.Services;

public class UsuarioService
{
    private readonly IMapper _mapper;
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly TokenService _tokenService;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
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

    public async Task<string> LoginUsuarioAsync(LoginUsuarioDto dto)
    {
        var resultado = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, isPersistent: false, lockoutOnFailure: false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Erro ao realizar login: usuario ou senha inválidos.");
        }

        var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.UserName.ToUpper());

       if (usuario == null)
        {
            throw new ApplicationException("Usuário não encontrado.");
        }

        var token = _tokenService.GerarToken(usuario);

        return token;
    }
}