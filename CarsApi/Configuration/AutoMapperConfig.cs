using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarsApi.ViewModels;
using Domain.Models;

namespace CarsApi.Configuration
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Maker, MakerViewModel>().ReverseMap();
            CreateMap<Car, CarViewModel>().ReverseMap();

            //CreateMap<CarViewModel, Car>();

            //CreateMap<Car, CarViewModel>()
            //    .ForMember(dest => dest.MakerName, opt => opt.MapFrom(src => src.Maker.Name));
        }
    }
}
