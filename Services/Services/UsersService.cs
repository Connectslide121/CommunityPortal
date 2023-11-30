using Core.UserClasses;
using DataBaseConnection;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
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

        public UsersService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<User> GetUsers()
        {
            return _dataContext.Users
                .ToList();
        }

        public List<Guest> GetGuests()
        {
            return _dataContext.Guests
                .ToList();
        }

        public List<Admin> GetAdmins() 
        {
            return _dataContext.Admins
                .ToList();
        }

        public List<Moderator> GetModerators()
        {
            return _dataContext.Moderators
                .ToList();
        }
    }
}
