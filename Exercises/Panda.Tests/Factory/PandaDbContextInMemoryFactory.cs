namespace Panda.Tests.Factory
{
    using Microsoft.EntityFrameworkCore;
    using System;

    using Data;

    public class PandaDbContextInMemoryFactory
    {
        public static PandaDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<PandaDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            return new PandaDbContext(options);
        }
    }
}