using AutoMapper;
using LocalizaEmpresas.Dtos;
using LocalizaEmpresas.Models;

namespace LocalizaEmpresas.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CadastraUsuarioDto, Usuario>();
            
        }
    }
}
