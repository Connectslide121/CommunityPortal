using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User
{
    public class Moderator : User
    {
        public enum ModerationArea { News, Community }
        public int ModerationExperience { get; set; } //based on moderation activity

    }
}
