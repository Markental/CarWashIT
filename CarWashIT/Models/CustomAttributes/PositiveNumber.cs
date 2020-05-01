using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashIT.Models.CustomAttributes
{
    public class PositiveNumber : ValidationAttribute
    {
        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }

        public override bool Match(object obj)
        {
            return base.Match(obj);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var number = (float)value;
                if (number >= 0)
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Only positive numbers are valid.");
            }
            catch (Exception)
            {
                return new ValidationResult("Not a number.");
            }
        }
    }
}
