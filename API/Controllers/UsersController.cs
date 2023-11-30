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
        public List<UsersUserDTO> GetUsers() 
        { 
            return _usersService.GetUsers();
        }

        [HttpGet("GetGuests")]
        public List<Guest> GetGuests() 
        { 
            return _usersService.GetGuests();
        }

        [HttpGet("GetAdmins")]
        public List<Admin> GetAdmins() 
        { 
            return _usersService.GetAdmins();
        }

        [HttpGet("GetModerators")]
        public List<Moderator> GetModerators() 
        { 
            return _usersService.GetModerators();
        }
    }
}
