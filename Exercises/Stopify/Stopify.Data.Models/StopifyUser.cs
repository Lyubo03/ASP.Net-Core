namespace Stopify.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class StopifyUser : IdentityUser
    {
        public StopifyUser()
        {
        }
        public string Fullname { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}