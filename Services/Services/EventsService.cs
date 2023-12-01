using Core.NewsClasses;
using Core.UserClasses;
using DataBaseConnection;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.Interfaces;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EventsService : IEventsService
    {
        private readonly DataContext _dataContext;
        private EventsServiceMappers _mapper;

        public EventsService(DataContext dataContext) 
        {
            _dataContext = dataContext;
            _mapper = new EventsServiceMappers();
        }

        public List<EventDTO> GetEvents()
        {
            List<Event> events = _dataContext.Events
                .Include(e => e.Attendants)
                .ToList();

            return _mapper.MapEventsToEventDTOs(events);
        }

    }
}
