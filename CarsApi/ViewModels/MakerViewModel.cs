using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.ViewModels
{
    public class MakerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} needs to be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public IEnumerable<CarViewModel> Cars { get; set; }
    }
}
