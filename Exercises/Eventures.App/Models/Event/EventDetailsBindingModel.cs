namespace Eventures.App.Models.Event
{
    using System.ComponentModel.DataAnnotations;
    using static Eventures.Models.DataValidation.Event;
    public class EventDetailsBindingModel
    {
        public string Id { get; set; }
        [Required]
        [MinLength(EventNameMaxLength)]
        public string Name { get; set; }
        public string Place { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
}