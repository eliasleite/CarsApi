using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<IEnumerable<Car>> GetCarsByMaker(Guid makerId);
        Task<IEnumerable<Car>> GetCarsMakers();
        Task<Car> GetCarMaker(Guid id);
    }
}
