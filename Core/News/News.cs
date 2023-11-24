using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.News
{
    public class News : Post
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public List<NewsComment> NewsComments { get; set; }

    }
}
