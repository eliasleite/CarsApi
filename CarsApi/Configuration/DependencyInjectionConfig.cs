using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CarContext>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IMakerService, MakerService>();
            
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IMakerRepository, MakerRepository>();

            return services;
        }
    }
}
