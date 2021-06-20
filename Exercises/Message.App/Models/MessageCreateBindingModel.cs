namespace Message.App.Models
{
    using System;
    using Message.Domain;

    public class MessageCreateBindingModel
    {
        public User User { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}