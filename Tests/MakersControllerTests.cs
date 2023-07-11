using AutoMapper;
using CarsApi.Controllers;
using CarsApi.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class MakersControllerTests
    {
        private readonly Mock<IMakerRepository> _mockMakerRepository;
        private readonly Mock<IMakerService> _mockMakerService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly MakersController _makersController;

        public MakersControllerTests()
        {
            _mockMakerRepository = new Mock<IMakerRepository>();
            _mockMakerService = new Mock<IMakerService>();
            _mockMapper = new Mock<IMapper>();

            _makersController = new MakersController(
                _mockMakerRepository.Object,
                _mockMakerService.Object,
                _mockMapper.Object
            );
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllMakers()
        {
            // Arrange
            var expectedMakers = new List<Maker>
            {
                new Maker { Id = Guid.NewGuid(), Name = "Maker 1", Active = true },
                new Maker { Id = Guid.NewGuid(), Name = "Maker 2", Active = true }
            };

            _mockMakerRepository.Setup(repo => repo.GetAll()).ReturnsAsync(expectedMakers);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<MakerViewModel>>(It.IsAny<IEnumerable<Maker>>()))
                .Returns(expectedMakers.Select(maker => new MakerViewModel { Id = maker.Id }));

            // Act
            var result = await _makersController.GetAll();

            // Assert
            var okObjectResult = Assert.IsAssignableFrom<IEnumerable<MakerViewModel>>(result);
            var makers = Assert.IsAssignableFrom<IEnumerable<MakerViewModel>>(okObjectResult);

            Assert.Equal(expectedMakers.Count, makers.Count());            
        }

        [Fact]
        public async Task GetById_ExistingId_ShouldReturnMaker()
        {
            // Arrange
            var expectedId = Guid.NewGuid();
            var expectedMaker = new Maker { Id = expectedId, Name = "Maker 1", Active = true };

            _mockMakerRepository.Setup(repo => repo.GetById(expectedId)).ReturnsAsync(expectedMaker);
            _mockMapper.Setup(mapper => mapper.Map<MakerViewModel>(It.IsAny<Maker>()))
                .Returns(new MakerViewModel { Id = expectedMaker.Id });

            // Act
            var result = await _makersController.GetById(expectedId);

            // Assert
            var okObjectResult = Assert.IsType<ActionResult<MakerViewModel>>(result);
            var makerViewModel = Assert.IsType<MakerViewModel>(okObjectResult.Value);

            Assert.Equal(expectedId, makerViewModel.Id);
        }


        [Fact]
        public async Task Add_ValidMakerViewModel_ShouldReturnOkResultAndMakerViewModel()
        {
            // Arrange
            var makerViewModel = new MakerViewModel { Name = "New Maker", Active = true };
            var maker = new Maker { Id = Guid.NewGuid(), Name = makerViewModel.Name, Active = makerViewModel.Active };

            _mockMapper.Setup(mapper => mapper.Map<Maker>(It.IsAny<MakerViewModel>())).Returns(maker);
            _mockMakerService.Setup(service => service.Add(It.IsAny<Maker>())).Verifiable();

            // Act
            var result = await _makersController.Add(makerViewModel);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMakerViewModel = Assert.IsType<MakerViewModel>(okObjectResult.Value);

            Assert.Equal(makerViewModel.Name, returnedMakerViewModel.Name);
            Assert.Equal(makerViewModel.Active, returnedMakerViewModel.Active);
            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);

            _mockMakerService.Verify(service => service.Add(It.IsAny<Maker>()), Times.Once);
        }

        [Fact]
        public async Task Update_ExistingIdAndValidMakerViewModel_ShouldReturnOkResultAndUpdatedMakerViewModel()
        {
            // Arrange
            var id = Guid.NewGuid();
            var makerViewModel = new MakerViewModel { Id = id, Name = "Updated Maker", Active = true };
            var existingMaker = new Maker { Id = id, Name = "Maker 1", Active = true };

            _mockMakerRepository.Setup(repo => repo.GetById(id)).ReturnsAsync(existingMaker);
            _mockMapper.Setup(mapper => mapper.Map<Maker>(It.IsAny<MakerViewModel>())).Returns(existingMaker);
            _mockMakerService.Setup(service => service.Update(It.IsAny<Maker>())).Verifiable();

            // Act
            var result = await _makersController.Update(id, makerViewModel);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnedMakerViewModel = Assert.IsType<MakerViewModel>(okObjectResult.Value);

            Assert.Equal(makerViewModel.Name, returnedMakerViewModel.Name);
            Assert.Equal(makerViewModel.Active, returnedMakerViewModel.Active);
            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);

            _mockMakerService.Verify(service => service.Update(It.IsAny<Maker>()), Times.Once);
        }

        [Fact]
        public async Task Delete_ExistingId_ShouldReturnOkResultAndDeletedMakerViewModel()
        {
            // Arrange
            var id = Guid.NewGuid();
            var existingMaker = new Maker { Id = id, Name = "Maker 1", Active = true };

            _mockMakerRepository.Setup(repo => repo.GetById(id)).ReturnsAsync(existingMaker);
            _mockMakerService.Setup(service => service.Delete(id)).Verifiable();

            // Act
            var result = await _makersController.Delete(id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedMaker = Assert.IsType<Maker>(okObjectResult.Value);

            Assert.Equal(existingMaker.Id, returnedMaker.Id);

            _mockMakerService.Verify(service => service.Delete(id), Times.Once);
        }

    }
}
