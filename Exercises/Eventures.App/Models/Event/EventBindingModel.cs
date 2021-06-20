namespace Eventures.App.Models.Event
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Eventures.Models.DataValidation.Event;


    public class EventBindingModel
    {
        private static Random random = new Random();

        public string Id { get; set; }
        [Required]
        [MinLength(EventNameMaxLength)]
        public string Name { get; set; }
        public string Place { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; } = DateTime.UtcNow;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; } = DateTime.UtcNow.AddDays(random.Next(5, 40));
        public int TotalTickets { get; set; }
        public decimal PricePerTicket { get; set; }
    }
}