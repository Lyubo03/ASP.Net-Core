namespace IdentityAndSecurityDemo.Data
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class ApplicationUser : IdentityUser
    {
        public DateTime? DateOfBirth { get; set; }
    }
}