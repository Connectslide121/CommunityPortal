using Core.UserClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using Services.Interfaces;
using System.Collections.Generic;

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
        public IActionResult GetUsers() 
        { 
            List<UserDTO> users = _usersService.GetUsers();
            return users == null ? NotFound() : Ok(users);
        }

        [HttpGet("guests")]
        public IActionResult GetGuests() 
        { 
            List<GuestDTO> guests = _usersService.GetGuests();
            return guests == null ? NotFound() : Ok(guests);
        }

        [HttpGet("admins")]
        public IActionResult GetAdmins() 
        {
            List<AdminDTO> admins = _usersService.GetAdmins();
            return admins == null ? NotFound() : Ok(admins);
        }

        [HttpGet("moderators")]
        public IActionResult GetModerators()
        {
            List<ModeratorDTO> moderators = _usersService.GetModerators();
            return moderators == null ? NotFound() : Ok(moderators);
        }

        [HttpGet("user/{id}")]
        public IActionResult GetUserById(int id)
        {
            UserDTO userById = _usersService.GetUserById(id);
            return userById == null ? NotFound() : Ok(userById);
        }
    }
}
