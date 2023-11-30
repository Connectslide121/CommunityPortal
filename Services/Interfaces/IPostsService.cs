using Core;
using Core.CommunityClasses;
using Core.NewsClasses;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPostsService
    {
        List<PostDTO> GetPosts();
        List<Blog> GetBlogs();
        List<News> GetNews();
    }
}
