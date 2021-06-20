namespace WorkingWithData.Tests
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WorkingWithData.Data;
    using WorkingWithData.Services;
    using Xunit;

    public class UserServiceTests
    {
        [Fact]
        public async Task LatestUsernmaeShouldReturnCorrectValuesSortedByEmails()
        {
            //Arrange
            var context = await GetDbContext();
            var service = new UserService(context);

            var actual = service.LatestUsername("email");

            //Assert
            Assert.Equal("Stoyan", actual);
        }
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var users = new List<IdentityUser>
            {
                new IdentityUser { UserName = "Gosho", Email = "pesho@abv.bg"},
                new IdentityUser { UserName = "Stoyan", Email = "stoyan@abv.bg"},
                new IdentityUser { UserName = "Ivan", Email = "ivan@abv.bg"}
            };

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("inMemoryDb");

            var context =  new ApplicationDbContext(optionsBuilder.Options);

            await context.Users.AddRangeAsync(users);

            await context.SaveChangesAsync();

            return context;
        }
    }
}