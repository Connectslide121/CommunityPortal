using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{ 
    public class UsersDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ProfilePicturePath { get; set; }
        public string Description { get; set; }
        public List<Post> PostHistory { get; set; }
        public int UserExperience { get; set; } //based on activity
        public string AdminTitle { get; set; }
        public int AdminPrivilegeLevel { get; set; }
        public enum ModerationArea { News, Community }
        public int ModerationExperience { get; set; } //based on moderation activity

    }
}
