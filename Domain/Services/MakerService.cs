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
    public class MakerService : IMakerService
    {
        private readonly IMakerRepository _makerRepository;
        private readonly ILogger<MakerService> _logger;

        public MakerService(IMakerRepository makerRepository, ILogger<MakerService> logger)
        {
            _makerRepository = makerRepository;
            _logger = logger;
        }

        public async Task Add(Maker maker)
        {      
            await _makerRepository.Add(maker);
        }

        public async Task Delete(Guid id)
        {
            await _makerRepository.Delete(id);
        }

        public void Dispose()
        {
            _makerRepository?.Dispose();            
        }

        public async Task Update(Maker maker)
        {
            await _makerRepository.Update(maker);
        }
    }
}
