namespace XUnitTestProject1
{
    using FDMC.App;
    using Microsoft.AspNetCore.Mvc.Testing;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;
    public class IntegrationTests
    {
        [Fact]
        public async Task IndexPageShouldReturn200OK()
        {
            var server = new WebApplicationFactory<Startup>();
            var client = server.CreateClient();
            var response = await client.GetAsync("/Home/Index");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}