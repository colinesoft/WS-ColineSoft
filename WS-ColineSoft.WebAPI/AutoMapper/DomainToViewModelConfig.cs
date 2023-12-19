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
            CreateMap<CorEntity, CorDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.StatusGeral.Descritivo));

            //REVERSES
            CreateMap<StatusGeralEntity, StatusGeralDTO>().ReverseMap();
        }
    }
}
