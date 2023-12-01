using Core.UserClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService) 
        {
            _usersService = usersService;
        }


        [HttpGet("GetUsers")]
        public List<UserDTO> GetUsers() 
        { 
            return _usersService.GetUsers();
        }

        [HttpGet("GetGuests")]
        public List<GuestDTO> GetGuests() 
        { 
            return _usersService.GetGuests();
        }

        [HttpGet("GetAdmins")]
        public List<AdminDTO> GetAdmins() 
        { 
            return _usersService.GetAdmins();
        }

        [HttpGet("GetModerators")]
        public List<ModeratorDTO> GetModerators() 
        { 
            return _usersService.GetModerators();
        }
    }
}
