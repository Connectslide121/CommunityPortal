using Core;
using Core.CommunityClasses;
using Core.NewsClasses;
using Core.UserClasses;
using DataBaseConnection;
using DataBaseConnection.Migrations;
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
    public class UsersService : IUsersService
    {
        private readonly DataContext _dataContext;
        private UserServiceMappers _mapper;

        public UsersService(DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapper = new UserServiceMappers();
        }

        public List<UserDTO> GetUsers()
        {
            List<User> users = _dataContext.Users
                .Include(u => u.PostHistory)
                .Include(u => u.EventsAttended)
                .Include(u => u.BlogComments)
                .Include(u => u.NewsComments)
                .ToList();

            return _mapper.MapUsersToUserDTOs(users);
        }

        public UserDTO GetUserById(int userId) //****************************Handle NULL exception????? make sure that this UserID always exists.
        {
            User? user = _dataContext.Users
               .Where(u => u.UserId == userId)
               .Include(u => u.PostHistory)
               .Include(u => u.EventsAttended)
               .Include(u => u.BlogComments)
               .Include(u => u.NewsComments)
               .FirstOrDefault();

            return _mapper.MapUserToUserDTO(user);
        }

        public List<GuestDTO> GetGuests()
        {
            List<Guest> guests = _dataContext.Guests
                .Include(g => g.PostHistory)
                .Include(g => g.EventsAttended)
                .Include(g => g.BlogComments)
                    .ThenInclude(c => c.Blog)
                        .ThenInclude(b => b.User)
                .Include(g => g.NewsComments)
                    .ThenInclude(c => c.News)
                        .ThenInclude(n => n.User)
                .ToList();

            return _mapper.MapGuestsToGuestDTOs(guests);
        }

        public List<AdminDTO> GetAdmins() 
        {
            List<Admin> admins = _dataContext.Admins
                .Include(a => a.PostHistory)
                .Include(a => a.EventsAttended)
                .Include(a => a.BlogComments)
                    .ThenInclude(c => c.Blog)
                        .ThenInclude(b => b.User)
                .Include(a => a.NewsComments)
                    .ThenInclude(c => c.News)
                        .ThenInclude(n => n.User)
                .ToList();

            return _mapper.MapAdminsToAdminDTOs(admins);
        }

        public List<ModeratorDTO> GetModerators()
        {
            List<Moderator> moderators = _dataContext.Moderators
                .Include(m => m.PostHistory)
                .Include(m => m.EventsAttended)
                .Include(m => m.BlogComments)
                    .ThenInclude(c => c.Blog)
                        .ThenInclude(b => b.User)
                .Include(m => m.NewsComments)
                    .ThenInclude(c => c.News)
                        .ThenInclude(n => n.User)
                .ToList();

            return _mapper.MapModeratorsToModeratorDTOs(moderators);
        }
    }
}
