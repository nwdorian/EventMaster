using EventMaster.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventMaster.WebApi.Controllers;

[ApiController]
[Route("api/event")]
public class EventController : ControllerBase
{
    private readonly List<Event> events = new List<Event>();

    public EventController()
    {
        events = GenerateSampleEvents();
    }

    [HttpGet(Name = "GetAllEvents")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Event>))]
    public IActionResult GetAllEvents()
    {
        return Ok(events);
    }

    [HttpGet("{id}", Name = "GetEventById")]
    [ProducesResponseType(200, Type = typeof(Event))]
    [ProducesResponseType(404)]
    public IActionResult GetEventById(Guid id)
    {
        var entityById = events.SingleOrDefault(e => e.Id == id);
        return entityById != null ? Ok(entityById) : NotFound();
    }

    [HttpPost(Name = "CreateEvent")]
    [ProducesResponseType(201, Type = typeof(Event))]
    public IActionResult CreateEvent([FromBody] Event entity)
    {
        return Created("/api/event", entity);
    }

    [HttpPut("{id}", Name = "UpdateEvent")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateEvent(int id, [FromBody] Event entity)
    {
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteEvent")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteEvent(int id)
    {
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteManyEvents")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteManyEvents(int id)
    {
        return NoContent();
    }

    private List<Event> GenerateSampleEvents()
    {
        return new List<Event>
        {
                new Event
                {
                    Id = new Guid("c730d19e-7d7a-4e36-b450-92b011b7a24f"),
                    Name = "Tech Summit 2024",
                    Date = new DateTime(2024, 3, 15, 9, 0, 0),
                    Location = "Convention Center, San Francisco",
                    Speakers = new List<string> { "John Smith", "Emily Johnson", "Michael Lee" }
                },
                new Event
                {
                    Id = new Guid("f88b2443-95e4-4a89-9fc8-82b922c59391"),
                    Name = "Startup Launchpad",
                    Date = new DateTime(2024, 5, 20, 10, 0, 0),
                    Location = "Tech Hub, New York",
                    Speakers = new List<string> { "Sarah Brown", "David Clark" }
                },
                new Event
                {
                    Id = new Guid("b9284822-0e46-4ae1-bc6e-37e53a2f4e13"),
                    Name = "Data Science Conference",
                    Date = new DateTime(2024, 8, 10, 8, 30, 0),
                    Location = "University Auditorium, Chicago",
                    Speakers = new List<string> { "Alex Rodriguez", "Rachel Green", "Chris Thompson" }
                }
        };
    }
}
