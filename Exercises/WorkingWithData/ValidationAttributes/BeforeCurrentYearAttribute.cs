namespace WorkingWithData.ValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BeforeCurrentYearAttribute : ValidationAttribute
    {
        private readonly int afterYear;

        public BeforeCurrentYearAttribute(int afterYear)
        {
            this.afterYear = afterYear;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is int))
            {
                return new ValidationResult("Invalid " + validationContext?.DisplayName);
            }

            var intValue = (int)value;

            if (intValue > DateTime.UtcNow.Year)
            {
                return new ValidationResult(validationContext?.DisplayName + " is after " + DateTime.UtcNow.Year);
            }

            if (intValue < afterYear)
            {
                return new ValidationResult(validationContext?.DisplayName + " is before " + DateTime.UtcNow.Year);
            }

            return ValidationResult.Success;
        }
    }
}