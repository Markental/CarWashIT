using CarWashIT.Models.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashIT.Models
{
    public class Order : IValidatableObject
    {
        public int Id { get; set; }

        [PositiveNumber]
        public float Price { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime DeadLine { get; set; }

        public IList<OrderCar> OrderCars { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CreationDate > DeadLine)
                yield return new ValidationResult("Creation date cannot be later than dead line!", new[] { nameof(CreationDate)});

            if (DeadLine.DayOfWeek == DayOfWeek.Saturday || DeadLine.DayOfWeek == DayOfWeek.Sunday)
                yield return new ValidationResult("Dead line cannot be a weekend!", new[] { nameof(DeadLine) });
        }
    }
}
