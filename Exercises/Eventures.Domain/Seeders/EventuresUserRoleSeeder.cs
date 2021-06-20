namespace Eventures.Domain
{
    using Eventures.Models;
    using Seeders;
    using System.Linq;

    public class EventuresUserRoleSeeder : ISeeder
    {
        public void Seed(EventuresDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new EventuresUserRole { Name = "Admin", NormalizedName = "ADMIN" });
                context.Roles.Add(new EventuresUserRole { Name = "User", NormalizedName = "USER" });

                context.SaveChanges();
            }

        }
    }
}