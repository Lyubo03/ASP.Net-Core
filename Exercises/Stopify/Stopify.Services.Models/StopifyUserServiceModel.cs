using Microsoft.AspNetCore.Identity;
using Stopify.Data.Models;
using Stopify.Services.Mapping;
using System.Collections.Generic;

namespace Stopify.Services.Models
{
    public class StopifyUserServiceModel : IdentityUser, IMapFrom<StopifyUser>
    {
        public string FullName { get; set; }
        public List<OrderServiceModel> Orders { get; set; } = new List<OrderServiceModel>();
    }
}