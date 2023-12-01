using Core.NewsClasses;
using Core.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class NewsCommentDTO
    {
        public int NewsCommentId { get; set; }
        public string Comment { get; set; }
        public NewsDTO News { get; set; }
        public UserDTO User { get; set; }
    }
}
