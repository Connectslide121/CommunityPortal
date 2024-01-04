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
                .Include(p => (p as Blog).BlogComments)
                .Include(p => (p as News).NewsComments)
                .ToList();

            return _mappers.MapPostsToPostDTOs(posts);
        }

        public List<BlogDTO> GetBlogs()
        {
            List<Blog> blogs = _dataContext.Blogs
                .Include(b => b.User)
                .Include(b => b.BlogComments)
                    .ThenInclude(c => c.User)
                .ToList();

            return _mappers.MapBlogsToBlogDTOs(blogs);
        }

        public List<NewsDTO> GetNews()
        {
            List<News> news = _dataContext.News
                .Include(n => n.User)
                .Include(n => n.NewsComments)
                    .ThenInclude(c => c.User)
                .ToList();

            return _mappers.MapNewsToNewsDTOs(news);
        }

        public void AddPost(Post post)/////////////will we get Post or PostDTO????????
        {
            _dataContext.Posts.Add(post);
            _dataContext.SaveChanges();
        }

        public void UpdatePost(Post post)/////////////will we get Post or PostDTO????????
        {
            var existingPost = _dataContext.Posts.Find(post.PostId);

            if (existingPost != null)
            {
                _dataContext.Entry(existingPost).CurrentValues.SetValues(post);
                _dataContext.SaveChanges();
            }
        }

        public void DeletePost(int postId)
        {
            var postToDelete = _dataContext.Posts.Find(postId);

            if (postToDelete != null)
            {
                _dataContext.Posts.Remove(postToDelete);
                _dataContext.SaveChanges();
            }
        }

    }
}
