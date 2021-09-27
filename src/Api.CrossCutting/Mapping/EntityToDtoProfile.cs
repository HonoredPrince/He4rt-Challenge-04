using Api.Domain.DTOs.Pokemon;
using Api.Domain.DTOs.Trainer;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            //Trainer
            CreateMap<TrainerDTO, TrainerEntity>().ReverseMap();
            CreateMap<TrainerCompleteDTO, TrainerEntity>().ReverseMap();
            CreateMap<TrainerCreateResultDTO, TrainerEntity>().ReverseMap();
            CreateMap<TrainerUpdateResultDTO, TrainerEntity>().ReverseMap();

            //Pokemon
            CreateMap<PokemonDTO, PokemonEntity>().ReverseMap();
            CreateMap<PokemonCreateResultDTO, PokemonEntity>().ReverseMap();
            CreateMap<PokemonUpdateResultDTO, PokemonEntity>().ReverseMap();
        }
    }
}
