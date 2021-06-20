namespace RazorLection.Services
{
    using Microsoft.AspNetCore.Identity;
    using RazorLection.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(object obj)
        {
            this.context.Users.Add((IdentityUser)obj);
        }

        public void Delete(object obj)
        {
            this.context.Users.Remove((IdentityUser)obj);
        }

        public int GetCount()
        {
              return this.context.Users.Count();
        }
        public IEnumerable<string> GetUsernames()
        {
            return
                this.context
                .Users
                .Select(x => x.UserName).ToList();
        }
        public object GetUsername(string userName)
        {
            return this.context.Users.Where(x => x.UserName == userName);
        }
    }
}