using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;

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


        [HttpGet("GetEvents")]

        public List<EventDTO> GetEvents()
        {
            return _eventsService.GetEvents();
        }





    }

}
