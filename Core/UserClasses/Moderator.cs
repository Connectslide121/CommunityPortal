using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UserClasses
{
    public enum ModerationArea
    {
        Uncategorized = 0,
        News = 1,
        Community = 2
    }

    public class Moderator : User
    {
        public ModerationArea ModerationArea { get; set; }
        public int ModerationExperience { get; set; } = 0; //based on moderation activity

    }
}
