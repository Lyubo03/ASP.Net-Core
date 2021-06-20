namespace Eventures.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.Event;

    public class Event
    {
        public string Id { get; set; }

        [Required]
        [MinLength(EventNameMaxLength)]
        public string Name { get; set; }
        public string Place { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }
        public int TotalTickets { get; set; }
        public decimal PricePerTicket { get; set; }
    }
}