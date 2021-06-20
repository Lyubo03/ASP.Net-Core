namespace Stopify.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BaseModel<Tkey>
    {
        [Key]
        public Tkey Id { get; set; }
    }
}