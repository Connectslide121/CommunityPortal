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
                .Include(p => p.Comments)
                .ToList();

            return _mappers.MapPostsToPostDTOs(posts);
        }

        public PostDTO GetPostById(int postId)//************Handle NULL exception????? make sure that this UserID always exists.
        {
            Post? post = _dataContext.Posts
                .Where(u => u.PostId == postId)
                .Include(u => u.User)
                .Include(u => u.Comments)
                .FirstOrDefault();

            return _mappers.MapPostToPostDTO(post);
        }

        public List<BlogDTO> GetBlogs()
        {
            List<Blog> blogs = _dataContext.Blogs
                .Include(b => b.User)
                .Include(b => b.Comments)
                    .ThenInclude(c => c.User)
                .ToList();

            return _mappers.MapBlogsToBlogDTOs(blogs);
        }

        public List<NewsDTO> GetNews()
        {
            List<News> news = _dataContext.News
                .Include(n => n.User)
                .Include(n => n.Comments)
                    .ThenInclude(c => c.User)
                .ToList();

            return _mappers.MapNewsToNewsDTOs(news);
        }

        public void AddPost(PostDTO post)
        {
            _dataContext.Posts.Add(_mappers.MapPostDTOtoPost(post));
            _dataContext.SaveChanges();
        }

        public bool UpdatePost(PostDTO postDTO)/////////////Is this a good approach with the bool????????
        {
            Post newPost = _mappers.MapPostDTOtoPost(postDTO);
            Post? existingPost = _dataContext.Posts.Find(postDTO.PostId);
            bool postExists = false;

            if (existingPost != null)
            {
                _dataContext.Entry(existingPost).CurrentValues.SetValues(newPost);
                _dataContext.SaveChanges();
                postExists = true;
            }

            return postExists;
        }

        public bool DeletePost(int postId)/////////////Is this a good approach with the bool????????
        {
            var postToDelete = _dataContext.Posts.Find(postId);
            bool postExists = false;

            if (postToDelete != null)
            {
                _dataContext.Posts.Remove(postToDelete);
                _dataContext.SaveChanges();
                postExists = true;
            }

            return postExists;
        }

    }
}
