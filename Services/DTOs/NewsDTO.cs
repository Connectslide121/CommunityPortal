using Core.CommunityClasses;
using Core.NewsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class NewsDTO
    {
        public int PostId { get; set; }
        public UserDTO User { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public int NewsId { get; set; } //News
        public string NewsTitle { get; set; } //News
        public NewsCategory NewsCategory { get; set; } //News
        public List<NewsCommentDTO> NewsComments { get; set; } //News

    }
}
