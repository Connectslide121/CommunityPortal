using Core.CommunityClasses;
using Core.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class BlogCommentDTO
    {
        public int BlogCommentId { get; set; }
        public string Comment { get; set; }
        public BlogDTO Blog { get; set; }
        public UserDTO User { get; set; }
    }
}
