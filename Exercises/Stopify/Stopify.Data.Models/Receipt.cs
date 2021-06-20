namespace Stopify.Data.Models
{
    using System;
    using System.Collections.Generic;
    public class Receipt : BaseModel<string>
    {
        public DateTime IssuedOn { get; set; }
        public List<Order> Orders { get; set; }
        public string RecipientId { get; set; }
        public StopifyUser Recipient { get; set; }
    }
}