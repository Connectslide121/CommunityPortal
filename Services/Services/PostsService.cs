using Core;
using Core.CommunityClasses;
using Core.NewsClasses;
using Core.UserClasses;
using DataBaseConnection;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
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

        public List<PostDTO> GetPosts()
        { 
             List<Post> posts = _dataContext.Posts
                .Include(p => p.User)
                .ToList();

            return MapPostsToPostDTOs(posts);
        }

        private List<PostDTO> MapPostsToPostDTOs(List<Post> posts)
        {
            List<PostDTO> postDTOs = new List<PostDTO>();

            foreach (Post post in posts)
            {
                PostDTO postDTO = new PostDTO
                {
                    PostId = post.PostId,
                    User = MapUserToUserDTO(post.User),
                    Content = post.Content,
                    Timestamp = post.Timestamp,
                };

                if (post is Blog blog)
                {
                    postDTO.BlogId = blog.BlogId;
                    postDTO.BlogTitle = blog.Title;
                    postDTO.BlogCategory = blog.Category;
                }

                else if (post is News news)
                {
                    postDTO.NewsId = news.NewsId;
                    postDTO.NewsTitle = news.Title;
                    postDTO.NewsCategory = news.Category;
                }

                postDTOs.Add(postDTO);
            }

            return postDTOs;
        }

        private UserDTO MapUserToUserDTO(User user)
        {
            UserDTO userDTO = new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                ProfilePicturePath = user.ProfilePicturePath,
                Description = user.Description,
            };

            if (user is Guest guest)
            {
                userDTO.UserExperience = guest.UserExperience;
            }

            else if (user is Admin admin)
            {
                userDTO.AdminTitle = admin.AdminTitle;
                userDTO.AdminPrivilegeLevel = admin.AdminPrivilegeLevel;
            }

            else if (user is Moderator moderator)
            {
                userDTO.ModerationArea = moderator.ModerationArea;
                userDTO.ModerationExperience = moderator.ModerationExperience;
            }

            return userDTO;
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
