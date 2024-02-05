using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UserClasses
{
    public class ApplicationUser : IdentityUser
    {
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public string[] Posts { get; set; }
        public string[] Comments { get; set; }
        public string[] Events { get; set; }


    }
}
