using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Model { get; set; }
        [Range(1900, 2050)]
        public int Year { get; set; }
        public Color Color { get; set; }
    }
}