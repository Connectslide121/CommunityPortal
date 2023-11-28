using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UserClasses
{
    public class Admin : User
    {
        public string AdminTitle { get; set; }
        public int AdminPrivilegeLevel { get; set; }

    }
}
