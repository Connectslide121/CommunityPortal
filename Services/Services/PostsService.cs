using Core;
using Core.CommunityClasses;
using Core.NewsClasses;
using DataBaseConnection;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PostsService : IPostsService
    {
        private readonly DataContext _dataContext;
        
        public PostsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Post> GetPosts()
        {
            return _dataContext.Posts
                .ToList();
        }

        public List<Blog> GetBlogs()
        {
            return _dataContext.Blogs
                .ToList();
        }

        public List<News> GetNews()
        {
            return _dataContext.News
                .ToList();
        }
    }
}
