namespace Filter.Models
{
    using System.ComponentModel.DataAnnotations;

    public class FormInputModel 
    {
        [Required]
        public string Search { get; set; }
    }
}