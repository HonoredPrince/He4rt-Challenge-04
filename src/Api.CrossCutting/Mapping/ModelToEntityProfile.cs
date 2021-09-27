using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mapping
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            //Trainer
            CreateMap<TrainerModel, TrainerEntity>().ReverseMap();

            //Pokemon
            CreateMap<PokemonModel, PokemonEntity>().ReverseMap();
        }
    }
}
