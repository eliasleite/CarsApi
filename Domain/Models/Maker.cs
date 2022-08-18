using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Maker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        /* EF Relations */
        public IEnumerable<Car> Cars { get; set; }
    }
}
