using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Core.Community
{
    public enum ThreadCategory
    {
        Uncategorized = 0,
        Category1 = 1,
        Category2 = 2,
        Category3 = 3,
        Category4 = 4,
        Category5 = 5,
        Category6 = 6,
        Category7 = 7,
        Category8 = 8,
        Category9 = 9
    }

    public class Thread : Post
    {
        public int ThreadId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public List<ThreadComment> ThreadComments { get; set; }

    }
}
