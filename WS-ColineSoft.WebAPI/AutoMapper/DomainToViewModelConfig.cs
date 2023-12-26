using AutoMapper;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Functions;

namespace WS_ColineSoft.WebAPI.AutoMapper
{
    public class DomainToViewModelConfig : Profile
    {
        public DomainToViewModelConfig()
        {
            CreateMap<TesteEntity, TesteDTO>()
                .ForMember(dest => dest.TamanhoExtenso, opt => opt.MapFrom(src => src.Tamanho.Extenso()));

            //REVERSES
            CreateMap<GrupoUsuarioEntity, GrupoUsuarioDTO>().ReverseMap();
            CreateMap<CorEntity, CorDTO>().ReverseMap();
            CreateMap<StatusGeralEntity, StatusGeralDTO>().ReverseMap();
            CreateMap<UsuarioEntity, UsuarioDTO>().ReverseMap();
            CreateMap<PessoaEntity, PessoaDTO>().ReverseMap();
            CreateMap<PessoaEnderecoEntity, PessoaEnderecoDTO>().ReverseMap();
        }
    }
}
