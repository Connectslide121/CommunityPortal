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
        void AddEvent(EventDTO newEvent);
        void UpdateEvent(EventDTO newEvent);
        void DeleteEvent(int eventId);

    }
}
