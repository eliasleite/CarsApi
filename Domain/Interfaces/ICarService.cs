using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICarService: IDisposable
    {
        Task Add(Car Car);
        Task Update(Car Car);
        Task Delete(Guid id);
    }
}
