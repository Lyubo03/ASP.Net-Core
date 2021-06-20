namespace Panda.Services.User
{
    using Data;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly PandaDbContext context;

        public UserService(PandaDbContext context)
        {
            this.context = context;
        }

        public IQueryable<PandaUser> GetAllUsers()
        {
            return context.Users;
        }

        public PandaUser GetUser(string username)
        {
            var user = context
                .Users
                .SingleOrDefault(x => x.UserName == username);

            return user;
        }
    }
}