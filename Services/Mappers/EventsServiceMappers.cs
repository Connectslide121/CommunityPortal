using Core.NewsClasses;
using Core.UserClasses;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    internal class EventsServiceMappers
    {
        public List<EventDTO> MapEventsToEventDTOs(List<Event> events)
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

        public EventDTO MapEventToEventDTO(Event evnt)
        {
            EventDTO eventDTO = new EventDTO
            {
                EventId = evnt.EventId,
                Title = evnt.Title,
                Description = evnt.Description,
                Location = evnt.Location,
                StartTime = evnt.StartTime,
                EndTime = evnt.EndTime,
            };

            return eventDTO;
        }

        public Event MapEventDTOToEvent(EventDTO eventDTO)
        {
            Event newEvent = new Event
            {
                EventId = eventDTO.EventId,
                Title = eventDTO.Title,
                Description = eventDTO.Description,
                Location = eventDTO.Location,
                StartTime = eventDTO.StartTime,
                EndTime = eventDTO.EndTime,
            };

            return newEvent;
        }

        public List<UserDTO> MapUserToUserDTO(List<User> users)
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
