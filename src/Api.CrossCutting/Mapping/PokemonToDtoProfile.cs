using Api.Domain.DTOs.Pokemon;
using AutoMapper;
using PokeApiNet;

namespace Api.CrossCutting.Mapping
{
    public class PokemonToDtoProfile : Profile
    {
        public PokemonToDtoProfile()
        {
            CreateMap<Pokemon, PokemonPokeApiDTO>()
                .ForMember(p => p.ImageUrl, map => map.MapFrom(src => src.Sprites.FrontDefault))
                .ForMember(p => p.Attribute, map => map.MapFrom(src => src.Types[0].Type.Name))
                .ReverseMap();
        }
    }
}
