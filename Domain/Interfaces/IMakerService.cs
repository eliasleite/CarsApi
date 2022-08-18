using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMakerService: IDisposable
    {
        Task Add(Maker maker);
        Task Update(Maker maker);
        Task Delete(Guid id);
    }
}
