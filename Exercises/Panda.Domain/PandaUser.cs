namespace Panda.Domain
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class PandaUser : IdentityUser
    { 

        public string UserRoleId { get; set; }
        public PandaUserRole UserRole { get; set; }
        public ICollection<Package> Packages { get; set; } = new List<Package>();
        public ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    }
}