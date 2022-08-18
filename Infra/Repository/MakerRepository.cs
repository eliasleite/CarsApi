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
    public class MakerRepository : Repository<Maker>, IMakerRepository
    {
        public MakerRepository(CarContext carContext) : base(carContext) { }

        public async Task<Maker> GetMaker(Guid id)
        {
            return await _carContext.Makers.AsNoTracking().Include(c => c.Cars)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
