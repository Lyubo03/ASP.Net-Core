using System.Collections.Generic;

namespace RazorLection.Services
{
    public interface IUserService
    {
        int GetCount();
        void Add(object obj);
        void Delete(object obj);
        object GetUsername(string name);
        IEnumerable<string> GetUsernames();

    }
}