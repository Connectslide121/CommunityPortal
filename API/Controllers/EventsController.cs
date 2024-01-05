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

        [HttpGet("all")]

        public IActionResult GetEvents()
        {
            List<EventDTO> events = _eventsService.GetEvents();
            return events == null ? NotFound() : Ok(events);
        }

        [HttpPost("create")]

        public void CreateEvent(EventDTO newEvent) //////Is "void" a good return????????? shoudl it be IActionResult returning NoContent()??
                                                   //////or return CreatedAtAction()???
                                                   //////or the event itself???
        {
            _eventsService.AddEvent(newEvent);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateEvent(int id, EventDTO updatedEvent)/////Is this a better approach than the above?  PROBABLY
        {
            if (updatedEvent == null || id != updatedEvent.EventId)
            {
                return BadRequest("Invalid data");
            }

            bool eventUpdated = _eventsService.UpdateEvent(updatedEvent);

            if (!eventUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            bool eventDeleted = _eventsService.DeleteEvent(id);

            if (!eventDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
