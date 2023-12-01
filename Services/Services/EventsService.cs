using Core.NewsClasses;
using Core.UserClasses;
using DataBaseConnection;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.Interfaces;
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

        public EventsService(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public List<EventDTO> GetEvents()
        {
            List<Event> events = _dataContext.Events
                .Include(e => e.Attendants)
                .ToList();

            return MapEventsToEventDTOs(events);
        }

        private List<EventDTO> MapEventsToEventDTOs(List<Event> events)
        {
            List<EventDTO> eventDTOs = new List<EventDTO>();

            foreach (Event evnt in events)
            {
                EventDTO eventDTO = new EventDTO
                {
                    EventId = evnt.EventId,
                    Title = evnt.Title,
                    Description = evnt.Description,
                    Location = evnt.Location,
                    StartTime = evnt.StartTime,
                    EndTime = evnt.EndTime,
                    Attendants = MapUserToUserDTO(evnt.Attendants)
                };

                eventDTOs.Add(eventDTO);
            }

            return eventDTOs;
        }

        private List<UserDTO> MapUserToUserDTO(List<User> users)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();

            foreach (User user in users)
            {
                UserDTO userDTO = new UserDTO
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email,
                    ProfilePicturePath = user.ProfilePicturePath,
                    Description = user.Description,
                };

                userDTOs.Add(userDTO);
            }

            return userDTOs;
        }
    }
}
