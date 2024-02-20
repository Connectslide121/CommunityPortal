using Core.CommunityClasses;
using Core.NewsClasses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.UserClasses
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string ProfilePicturePath { get; set; }
        public string Description { get; set; }
        public List<Post> PostHistory { get; set; }
        public List<Event> EventsAttended { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
