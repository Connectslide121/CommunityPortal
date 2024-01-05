using Core.CommunityClasses;
using Core.NewsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class BlogDTO : PostDTO
    {
        public int BlogId { get; set; } //Blog
        public BlogCategory BlogCategory { get; set; } //Blog
        public List<BlogCommentDTO> BlogComments { get; set; } //Blog

    }
}
