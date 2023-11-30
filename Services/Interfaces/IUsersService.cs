using Core.UserClasses;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUsersService
    {
        List<UsersUserDTO> GetUsers();
        List<Guest> GetGuests();
        List<Admin> GetAdmins();
        List<Moderator> GetModerators();
    }
}
