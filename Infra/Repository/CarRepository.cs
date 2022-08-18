using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarContext carContext) : base(carContext) { }
        
        public async Task<Car> GetCarMaker(Guid id)
        {
            return await _carContext.Cars.AsNoTracking().Include(m => m.Maker)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Car>> GetCarsByMaker(Guid makerId)
        {
            return await _carContext.Cars.Where(c => c.MakerId == makerId).ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetCarsMakers()
        {
            return await _carContext.Cars.AsNoTracking().Include(m => m.Maker)
                .OrderBy(c => c.Name).ToListAsync();
        }
    }
}
