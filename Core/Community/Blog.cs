using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Core.Community
{
    public enum BlogCategory
    {
        Uncategorized = 0,
        Movies = 1,
        Series = 2,
        Games = 3,
        Books = 4,
        FunnyImages = 5,
        FunnyClips = 6,
        Category7 = 7,
        Category8 = 8,
        Category9 = 9
    }

    public class Blog : Post
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public BlogCategory Category { get; set; }
        public List<BlogComment> BlogComments { get; set; }

    }
}