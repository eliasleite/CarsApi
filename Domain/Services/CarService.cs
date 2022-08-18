using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<CarService> _logger;

        public CarService(ICarRepository carRepository, ILogger<CarService> logger)
        {
            _carRepository = carRepository;
            _logger = logger;
        }

        public async Task Add(Car Car)
        {
            await _carRepository.Add(Car);
        }

        public async Task Delete(Guid id)
        {
            await _carRepository.Delete(id);
        }

        public void Dispose()
        {
            _carRepository?.Dispose();
        }

        public async Task Update(Car Car)
        {
            await _carRepository.Update(Car);
        }
    }
}
