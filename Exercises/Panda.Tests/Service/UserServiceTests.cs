namespace Panda.Tests.Service
{
    using System.Collections.Generic;
    using Xunit;

    using Data;
    using Domain;
    using Panda.Services.User;
    using System.Linq;
    using Extensions;
    using Panda.Tests.Factory;

    public class UserServiceTests
    {
        private PandaDbContextInMemoryFactory contextFactory = new PandaDbContextInMemoryFactory(); 
        [Fact]
        public void TestGetAllUsers_WithoudAnyData_ShouldReturnEmpty()
        {
            var context = PandaDbContextInMemoryFactory.CreateDbContext();

            var userService = new UserService(context);

            var actualData = userService.GetAllUsers().ToList();

            Assert.True(actualData.Count() == 0,
                "UserService GetAllUsers() method does not work properly");
        }

        [Fact]
        public void TestGetUser_WithExistingUsername_ShouldReturnUser()
        {
            var context = PandaDbContextInMemoryFactory.CreateDbContext();

            SeedTestData(context);
            var userService = new UserService(context);

            var actualUser = userService.GetUser("TestUser2");
            var expectedUser = context.Users.SingleOrDefault(x => x.UserName == "TestUser2");

            AssertExtensions.EqualWithMessage(actualUser.UserRole.Name,
                expectedUser.UserRole.Name,
                 "UserService GetUser() method does not work properly");
        }

        [Fact]
        public void TestGetUser_WithNotExistingUsername_ShouldReturnNull()
        {
            var context = PandaDbContextInMemoryFactory.CreateDbContext();
            SeedTestData(context);
            var userService = new UserService(context);

            var actualUser = userService.GetUser("Stamat");

            Assert.True(actualUser == null,
                "UserService GetUser() method does not work properly");
        }

        [Fact]
        public void TestGetAllUsers_WithTestData_ShouldReturnEverySingleUserInTheService()
        {
            var context = PandaDbContextInMemoryFactory.CreateDbContext();

            SeedTestData(context);

            var userService = new UserService(context);

            var expectedData = GetTestData;
            var actualData = userService.GetAllUsers().ToList();

            Assert.Equal(expectedData.Count, actualData.Count());
            Assert.Equal<PandaUser>(expectedData, actualData);

            foreach (var actualUser in actualData)
            {
                Assert.True(expectedData.Any(user =>
                actualUser.UserName == user.UserName &&
                actualUser.Email == user.Email &&
                actualUser.UserRole.Name == user.UserRole.Name),
                "User Service GetAllUSers() doens't work properly");
            }
        }

        private void SeedTestData(PandaDbContext context)
        {
            context.Users.AddRange(GetTestData);
            context.SaveChanges();
        }
        private List<PandaUser> GetTestData = new List<PandaUser>()
        {  new PandaUser
                {
                  UserName = "TestUser1",
                  Email = "TestUser1@mail.com",
                  UserRole = new PandaUserRole{ Name = "Admin"}
                },
                new PandaUser
                {
                    UserName = "TestUser2",
                    Email = "TestUser2@mail.com",
                    UserRole = new PandaUserRole { Name = "User" }
                }
        };
    }
}