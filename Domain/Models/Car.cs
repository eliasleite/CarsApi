using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Car
    {
        public Guid MakerId { get; set; }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }

        /* EF Relations */
        public Maker Maker { get; set; }
    }
}
