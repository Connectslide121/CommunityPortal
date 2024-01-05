using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewsClasses
{
    public enum NewsCategory
    {
        Uncategorized = 0,
        Movies = 1,
        Series = 2,
        Games = 3,
        Books = 4,
        FunnyImages = 5,
        FunnyClips = 6,
        Music = 7,
        Category8 = 8,
        Category9 = 9
    }

    public class News : Post
    {
        public int NewsId { get; set; }
        public NewsCategory Category { get; set; }
    }
}
