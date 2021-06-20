namespace WorkingWithData.Services
{
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using WorkingWithData.Data;

    public class UserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string LatestUsername(string orderBy = "username")
        {
            IQueryable<IdentityUser> query = this.context.Users;

            if (orderBy.ToLower() == "username")
            {
                query = query.OrderByDescending(x => x.Email);
            }
            else if (orderBy.ToLower() == "email")
            {
                query = query.OrderByDescending(x => x.Email);
            }

            return query.Select(x => x.UserName).FirstOrDefault();
        }
        public IQueryable<string> GetUsernames(string orderBy = "username")
        {
            IQueryable<IdentityUser> query = this.context.Users;

            if (orderBy.ToLower() == "username")
            {
                query = query.OrderBy(x => x.Email);
            }

            else if (orderBy.ToLower() == "email")
            {
                query = query.OrderBy(x => x.Email);
            }

            return query.Select(x => x.UserName);
        }
    }
}