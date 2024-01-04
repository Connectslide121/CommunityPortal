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
        List<UserDTO> GetUsers();
        List<GuestDTO> GetGuests();
        List<AdminDTO> GetAdmins();
        List<ModeratorDTO> GetModerators();
        UserDTO GetUserById(int id);
        void AddUser(UserDTO user);
        void UpdateUser(UserDTO user);
        void DeleteUser(int userId);
    }
}
