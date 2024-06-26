using AutoMapper;
using Backend.Models;
using Backend.DTOs;

namespace Backend.Automappers
{
    public class MappingProfile : Profile //Profile, clase dentro del nuget de automapper
    {
        public MappingProfile()
        {
            CreateMap<BeerInsertDto, Beer>(); //<BeerInsertDto(Objeto entrada),Beer(objeto destino)> --Cuando los dods tienen los mismos nombres en los campos con esto ya es suficiente. 
            CreateMap<Beer, BeerDto>().ForMember(dto => dto.Id, m => m.MapFrom(b => b.BeerId)); //Cuando los campos se llaman diferente (dto => dto.Id(Destino), m => m.MapFrom(b => b.BeerId(origen)))
            CreateMap<BeerUpdateDto, Beer>();

            //CreateMap<Source, Destination>()
                //.ForMember(dest => dest.Secret, opt => opt.Ignore());
        }
    }
}
