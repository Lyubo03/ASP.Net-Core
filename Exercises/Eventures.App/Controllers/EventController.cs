namespace Eventures.App.Controllers
{
    using App.Models.Event;
    using Eventures.Domain;
    using Eventures.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;
    using System.Linq;

    public class EventController : Controller
    {
        private readonly EventuresDbContext context;

        public EventController(EventuresDbContext context)
        {
            this.context = context;
        }
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Create(EventBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                var @event = new Event
                {
                    Name = model.Name,
                    Start = model.Start,
                    End = model.End,
                    Place = model.Place,
                    PricePerTicket = model.PricePerTicket,
                    TotalTickets = model.TotalTickets
                };

                context.Events.Add(@event);
                context.SaveChanges();
                return this.RedirectToAction("All");
            }

            return this.View();
        }
        [HttpGet]
        public IActionResult All()
        {
            var events = this.context.Events
                .Select(x => new EventDetailsBindingModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Place = x.Place,
                    Start = x.Start.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture),
                    End = x.End.ToString("dd/MM/yyyy/ hh:mm", CultureInfo.InvariantCulture),

                })
                .ToList();

            return this.View(events);
        }
    }
}