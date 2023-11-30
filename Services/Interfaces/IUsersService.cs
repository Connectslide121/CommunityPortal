using Core.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUsersService
    {
        List<User> GetUsers();
        List<Guest> GetGuests();
        List<Admin> GetAdmins();
        List<Moderator> GetModerators();
    }
}
