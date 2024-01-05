using Core.NewsClasses;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEventsService
    {
        List<EventDTO> GetEvents();
        EventDTO GetEventById(int eventId);
        void AddEvent(EventDTO newEvent);
        bool UpdateEvent(EventDTO EventToUpdate);
        bool DeleteEvent(int eventId);

    }
}
