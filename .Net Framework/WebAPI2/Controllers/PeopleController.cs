namespace WebAPI2.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using WebAPI2.Models;
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();
        public PeopleController()
        {
            people.Add(new Person { FirstName = "Stamat", LastName = "Ivanow", Id = 1, Age = 5 });
            people.Add(new Person { FirstName = "Spiderman", LastName = "Marvelov", Id = 2, Age = 32 });
            people.Add(new Person { FirstName = "Harry", LastName = "Potter", Id = 3, Age = 32 });
            people.Add(new Person { FirstName = "Stamat", LastName = "Ivanow", Id = 4, Age = 32 });
        }
        //If you want more than one request in a API Controller point out the route
        //Always give the controller name as a route!

        /*[HttpGet]*/
        [Route("api/People/GetNames/{userId:int}/{age:int}")]
        public List<string> GetNames(int userId, int age)
        {
            return people.Where(x => x.Age == age && userId == x.Id)
                .Select(x => $"{x.FirstName}  {x.LastName}")
                .ToList();
        }

        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.SingleOrDefault(x => x.Id == id);
        }

        // POST: api/People
        public void Post(Person person)
        {
            if (person != null)
            {
                people.Add(person);
            }
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}