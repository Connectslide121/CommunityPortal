using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;
using Services.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService _eventsService;

        public EventsController(IEventsService eventsService) 
        {
            _eventsService = eventsService;
        }

        [HttpGet("events")]

        public IActionResult GetEvents()
        {
            List<EventDTO> events = _eventsService.GetEvents();
            return events == null ? NotFound() : Ok(events);
        }

        [HttpPost("events")]

        public IActionResult CreateEvent([FromBody] EventDTO newEvent)
        {
            if (newEvent == null)
            {
                return BadRequest("Invalid data");
            }

            UserDTO createdUser = _eventsService.CreateEvent(newEvent);

            // Assuming your service returns the created user
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }
    }
}
