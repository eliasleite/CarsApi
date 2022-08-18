using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class MakerServiceTests
    {
        private readonly IMakerService _MakerService;
        private readonly Mock<IMakerRepository> _mock = new Mock<IMakerRepository>();
        private readonly Mock<ILogger<MakerService>> _logger = new Mock<ILogger<MakerService>>();
        public Maker Maker;

        public MakerServiceTests()
        {
            _MakerService = new MakerService(_mock.Object, _logger.Object);
            Maker = new Maker
            {
                Active = true,
                Id = Guid.NewGuid(),
                Name = "Tesla Motors"
            };
        }

        [Fact]
        public void AddMaker_NewMaker_ShouldSave()
        {
            //Act            
            _MakerService.Add(Maker);

            //Assert
            _mock.Verify(r => r.Add(Maker), Times.Once);
        }

        [Fact]
        public void DeleteMaker_Delete_ShouldDelete()
        {
            //Act            
            _MakerService.Add(Maker);
            _MakerService.Delete(Maker.Id);

            //Assert
            _mock.Verify(r => r.Delete(Maker.Id), Times.Once);
        }

        [Fact]
        public void UpdateMaker_Update_ShouldUpdate()
        {
            //Act            
            _MakerService.Add(Maker);
            _MakerService.Update(Maker);

            //Assert
            _mock.Verify(r => r.Update(Maker), Times.Once);
        }
    }
}
