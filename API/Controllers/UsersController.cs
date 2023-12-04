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


        [HttpGet("users")]
        public List<UserDTO> GetUsers() 
        { 
            return _usersService.GetUsers();
        }

        [HttpGet("guests")]
        public List<GuestDTO> GetGuests() 
        { 
            return _usersService.GetGuests();
        }

        [HttpGet("admins")]
        public List<AdminDTO> GetAdmins() 
        { 
            return _usersService.GetAdmins();
        }

        [HttpGet("moderators")]
        public List<ModeratorDTO> GetModerators() 
        { 
            return _usersService.GetModerators();
        }

        [HttpGet("user/{id}")]
        public IActionResult GetUserById(int id)
        {
            UserDTO userById = _usersService.GetUserById(id);

            return User == null ? NotFound() : Ok(userById);
        }

    }
}
