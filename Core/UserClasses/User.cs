using Core.NewsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.UserClasses
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ProfilePicturePath { get; set; }
        public string Description { get; set; }
        public List<Post> PostHistory { get; set; }
        public List<Event> EventsAttended { get; set; }
    }
}
