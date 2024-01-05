using Core.UserClasses;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public PostDTO Post { get; set; }
        public UserDTO User { get; set; }

    }
}
