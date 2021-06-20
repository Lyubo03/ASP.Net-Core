namespace Message.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using Models;
    using Domain;
    using System;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class MessageController : ApiController
    {
        private readonly MessageDbContext context;

        public MessageController(MessageDbContext context)
        {
            this.context = context;
        }

        [HttpPost(Name = "Create")]
        [Route("create")]
        public async Task<ActionResult> Create(MessageCreateBindingModel messageCreate)
        {
            var user = await this.context.Users
                .SingleOrDefaultAsync(u => u.Username == messageCreate.User.Username);

            var message = new Message
            {
                User = user,
                Content = messageCreate.Message,
                CreatedOn = DateTime.UtcNow
            };

            await context.Messages.AddAsync(message);
            await context.SaveChangesAsync();
            return this.Ok();
        }

        [HttpGet(Name = "All")]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Message>>> AllOrderedByCreatedAscending()
        {
            return this.context
                .Messages
                .OrderBy(x => x.CreatedOn)
                .ToList();
        }
    }
}