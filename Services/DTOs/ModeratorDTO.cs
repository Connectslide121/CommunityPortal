using Core.CommunityClasses;
using Core.NewsClasses;
using Core.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class ModeratorDTO : UserDTO
    {
        public ModerationArea ModerationArea { get; set; } 
        public int ModerationExperience { get; set; } 

    }
}
