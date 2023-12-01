using Core.CommunityClasses;
using Core.NewsClasses;
using Core.UserClasses;
using Core;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    internal class PostsServiceMappers
    {
        public List<PostDTO> MapPostsToPostDTOs(List<Post> posts)
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

        public UserDTO MapUserToUserDTO(User user)
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

        public List<BlogDTO> MapBlogsToBlogDTOs(List<Blog> blogs)
        {
            List<BlogDTO> blogDTOs = new List<BlogDTO>();

            foreach (Blog blog in blogs)
            {
                BlogDTO blogDTO = new BlogDTO
                {
                    PostId = blog.PostId,
                    User = MapUserToUserDTO(blog.User),
                    Content = blog.Content,
                    Timestamp = blog.Timestamp
                };

                blogDTO.BlogId = blog.BlogId;
                blogDTO.BlogTitle = blog.Title;
                blogDTO.BlogCategory = blog.Category;

                blogDTOs.Add(blogDTO);
            }

            return blogDTOs;
        }

        public List<NewsDTO> MapNewsToNewsDTOs(List<News> newsList)
        {
            List<NewsDTO> newsDTOs = new List<NewsDTO>();

            foreach (News news in newsList)
            {
                NewsDTO newsDTO = new NewsDTO
                {
                    PostId = news.PostId,
                    User = MapUserToUserDTO(news.User),
                    Content = news.Content,
                    Timestamp = news.Timestamp
                };

                newsDTO.NewsId = news.NewsId;
                newsDTO.NewsTitle = news.Title;
                newsDTO.NewsCategory = news.Category;

                newsDTOs.Add(newsDTO);
            }

            return newsDTOs;
        }

    }
}
