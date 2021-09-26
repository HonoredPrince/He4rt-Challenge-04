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
        }
    }
}
