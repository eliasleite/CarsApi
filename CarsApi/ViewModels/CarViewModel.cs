using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsApi.ViewModels
{
    public class CarViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Guid MakerId { get; set; }

        [Required(ErrorMessage = "The Field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} needs to be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Field {0} is required")]
        [StringLength(1000, ErrorMessage = "The field {0} needs to be between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Field {0} is required")]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }

        public bool Active { get; set; }

        //[ScaffoldColumn(false)]
        //public string MakerName { get; set; }

    }
}
