namespace WorkingWithData.Models.CarAd
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WorkingWithData.ModelBinders;
    using WorkingWithData.ValidationAttributes;

    public class CarBrandAndModel : IValidatableObject
    {
        [Required]
        public string Brand { get; set; }

        [Required (ErrorMessage = "Invalid Model name!")]
        [MinLength(2)]
        public string Model { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validation)
        {
            if (this.Brand== "Audi" && !this.Model.StartsWith("Q") && !this.Model.StartsWith("A"))
            {
                yield return new ValidationResult("Invalid Audi model");
            }
        }
    }
    public class CreateInputModel
    {
        [Required(ErrorMessage = "Invalid car")]
        public CarBrandAndModel Car { get; set; }

        [Required]
        public CarType Type { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [BeforeCurrentYear(1900)]
        public int Year { get; set; }

        //[DataType(DataType.Date)]
        //[ModelBinder(typeof(DateTimeToYearModelBinder))]
        //public int Year { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public byte[] Image { get; set; }
    }
}