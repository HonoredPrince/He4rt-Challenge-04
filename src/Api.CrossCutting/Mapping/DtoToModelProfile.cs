using Api.Domain.DTOs.Pokemon;
using Api.Domain.DTOs.Trainer;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            //Trainer
            CreateMap<TrainerModel, TrainerDTO>().ReverseMap();
            CreateMap<TrainerModel, TrainerCreateDTO>().ReverseMap();
            CreateMap<TrainerModel, TrainerUpdateDTO>().ReverseMap();

            //Pokemon
            CreateMap<PokemonModel, PokemonDTO>().ReverseMap();
            CreateMap<PokemonModel, PokemonAddDTO>().ReverseMap();
            CreateMap<PokemonModel, PokemonCreateDTO>().ReverseMap();
            CreateMap<PokemonModel, PokemonUpdateDTO>().ReverseMap();
        }
    }
}
