using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Tests
{  
    public class CarsServiceTests
    {
        private readonly ICarService _carService;
        private readonly Mock<ICarRepository> _mock = new Mock<ICarRepository>();
        private readonly Mock<ILogger<CarService>> _logger = new Mock<ILogger<CarService>>();
        public Car car;

        public CarsServiceTests()
        {
            _carService = new CarService(_mock.Object, _logger.Object);
            car = new Car
            {
                Id = Guid.NewGuid(),
                Name = "Tesla",
                Description = "electric car",
                Price = 79000,
                MakerId = Guid.NewGuid(),
                Active = true,
                Maker = new Maker
                {
                    Active = true,
                    Id = Guid.NewGuid(),
                    Name = "Tesla Motors"
                }
            };
        }

        [Fact]
        public void AddCar_NewCar_ShouldSave()
        {           
            //Act            
            _carService.Add(car);

            //Assert
            _mock.Verify(r => r.Add(car), Times.Once);
        }

        [Fact]
        public void DeleteCar_Delete_ShouldDelete() 
        {            
            //Act            
            _carService.Add(car);
            _carService.Delete(car.Id);

            //Assert
            _mock.Verify(r => r.Delete(car.Id), Times.Once);
        }

        [Fact]
        public void UpdateCar_Update_ShouldUpdate() 
        {            
            //Act            
            _carService.Add(car);
            _carService.Update(car);

            //Assert
            _mock.Verify(r => r.Update(car), Times.Once);
        }
    }
}
