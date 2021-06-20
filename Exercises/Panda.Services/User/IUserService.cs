namespace Panda.Services.User
{
    using Domain;
    using System.Linq;

    public interface IUserService
    {
        PandaUser GetUser(string username);
        IQueryable<PandaUser> GetAllUsers();
    }
}