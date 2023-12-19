﻿using AutoMapper;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Functions;

namespace WS_ColineSoft.WebAPI.AutoMapper
{
    public class ViewModelToDomainConfig : Profile
    {
        public ViewModelToDomainConfig()
        {
            CreateMap<TesteDTO, TesteEntity>()
                .ForMember(dest => dest.Tamanho, opt => opt.MapFrom(src => Uteis.ExtensoToInteiro(src.TamanhoExtenso)));
            CreateMap<CorDTO, CorEntity>()
                .ForMember(dest => dest.IdStatusGeral, opt => opt.MapFrom(src => src.IdStatusGeral));
        }
    }
}