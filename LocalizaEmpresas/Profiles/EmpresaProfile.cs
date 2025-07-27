using AutoMapper;
using LocalizaEmpresas.Dtos;
using LocalizaEmpresas.Models;

namespace LocalizaEmpresas.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<CadastroEmpresaDto, ReceitaWsDto>();
            CreateMap<ReceitaWsDto, Empresa>();
                



        }
    }
}
