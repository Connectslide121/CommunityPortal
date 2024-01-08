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

        [HttpGet("event/{id}")]

        public IActionResult GetEventById(int eventId)
        {
            EventDTO eventById = _eventsService.GetEventById(eventId);
            return eventById == null ? NotFound() : Ok(eventById);
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
            bool eventUpdated = _eventsService.UpdateEvent(updatedEvent);

            return eventUpdated == false ? NotFound() : Ok(updatedEvent);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEvent(int eventId)
        {
            bool eventDeleted = _eventsService.DeleteEvent(eventId);

            return eventDeleted == false ? NotFound() : Ok(eventId);
        }

    }
}
