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
            CreateMap<ReceitaWsDto, Empresa>()
                .ForMember(dest => dest.NomeEmpresarial, opt => opt.MapFrom(src => src.NomeEmpresarial))
                .ForMember(dest => dest.NomeFantasia, opt => opt.MapFrom(src => src.NomeFantasia))
                .ForMember(dest => dest.Situacao, opt => opt.MapFrom(src => src.Situacao))
                .ForMember(dest => dest.Abertura, opt => opt.MapFrom(src => src.Abertura))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.NaturezaJuridica, opt => opt.MapFrom(src => src.NaturezaJuridica))
                .ForMember(dest => dest.AtividadePrincipal, opt => opt.MapFrom(src => src.AtividadePrincipal.FirstOrDefault()));


            CreateMap<AtividadePrincipalDto, AtividadePrincipal>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao));


        }
    }
}
