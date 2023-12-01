using Core;
using Core.CommunityClasses;
using Core.NewsClasses;
using Core.UserClasses;
using DataBaseConnection;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.Interfaces;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PostsService : IPostsService
    {
        private readonly DataContext _dataContext;
        private PostsServiceMappers _mappers;
        
        public PostsService(DataContext dataContext)
        {
            _dataContext = dataContext;
            _mappers = new PostsServiceMappers();
        }

        public List<PostDTO> GetPosts()
        { 
             List<Post> posts = _dataContext.Posts
                .Include(p => p.User)
                .ToList();

            return _mappers.MapPostsToPostDTOs(posts);
        }

        public List<BlogDTO> GetBlogs()
        {
            List<Blog> blogs = _dataContext.Blogs
                .Include(b => b.User)
                .ToList();

            return _mappers.MapBlogsToBlogDTOs(blogs);
        }

        public List<NewsDTO> GetNews()
        {
            List<News> news = _dataContext.News
                .Include(n => n.User)
                .ToList();

            return _mappers.MapNewsToNewsDTOs(news);
        }

    }
}
