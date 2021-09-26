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
            CreateMap<TrainerCreateResultDTO, TrainerEntity>().ReverseMap();
            CreateMap<TrainerUpdateResultDTO, TrainerEntity>().ReverseMap();
        }
    }
}
