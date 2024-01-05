using Core;
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
        private EventsServiceMappers _mappers;

        public EventsService(DataContext dataContext) 
        {
            _dataContext = dataContext;
            _mappers = new EventsServiceMappers();
        }

        public List<EventDTO> GetEvents()
        {
            List<Event> events = _dataContext.Events
                .Include(e => e.Attendants)
                .ToList();

            return _mappers.MapEventsToEventDTOs(events);
        }

        public EventDTO GetEventById(int eventId)
        {
            Event? evnt = _dataContext.Events
                .Where(u => u.EventId == eventId)
                .Include(u => u.Attendants)
                .FirstOrDefault();

            return _mappers.MapEventToEventDTO(evnt);
        }

        public void AddEvent(EventDTO newEvent)
        {
            _dataContext.Events.Add(_mappers.MapEventDTOToEvent(newEvent));
            _dataContext.SaveChanges();
        }

        public bool UpdateEvent(EventDTO eventDTO)/////////////Is this a good approach with the bool????????
        {
            Event newEvent = _mappers.MapEventDTOToEvent(eventDTO);
            Event? existingEvent = _dataContext.Events.Find(eventDTO.EventId);
            bool eventExists = false;

            if (existingEvent != null)
            {
                _dataContext.Entry(existingEvent).CurrentValues.SetValues(newEvent);
                _dataContext.SaveChanges();
                eventExists = true;
            }

            return eventExists;
        }

        public bool DeleteEvent(int eventId)/////////////Is this a good approach with the bool????????
        {
            var eventToDelete = _dataContext.Events.Find(eventId);
            bool eventExists = false;

            if (eventToDelete != null)
            {
                _dataContext.Events.Remove(eventToDelete);
                _dataContext.SaveChanges();
                eventExists = true;
            }

            return eventExists;
        }

    }
}
