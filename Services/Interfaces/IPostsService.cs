using Core;
using Core.CommunityClasses;
using Core.NewsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPostsService
    {
        List<Post> GetPosts();
        List<Blog> GetBlogs();
        List<News> GetNews();
    }
}
