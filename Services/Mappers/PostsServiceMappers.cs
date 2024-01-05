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
using System.Reflection.Metadata;

namespace Services.Mappers
{
    internal class PostsServiceMappers
    {
        public List<PostDTO> MapPostsToPostDTOs(List<Post> posts)
        {
            List<PostDTO> postDTOs = new List<PostDTO>();

            foreach (Post post in posts)
            {
                if (post is Blog blog)
                {
                    BlogDTO blogDTO = new BlogDTO
                    {
                        PostId = post.PostId,
                        User = MapUserToUserDTO(post.User),
                        Title = post.Title,
                        Content = post.Content,
                        Timestamp = post.Timestamp,
                        BlogId = blog.BlogId,
                        BlogCategory = blog.Category,
                        BlogComments = MapBlogCommentsToBlogCommentDTOs(blog.BlogComments)
                    };

                    postDTOs.Add(blogDTO);
                }

                else if (post is News news)
                {
                    NewsDTO newsDTO = new NewsDTO
                    {
                        PostId = post.PostId,
                        User = MapUserToUserDTO(post.User),
                        Title = post.Title,
                        Content = post.Content,
                        Timestamp = post.Timestamp,
                        NewsId = news.NewsId,
                        NewsCategory = news.Category,
                        NewsComments = MapNewsCommentsToNewsCommentDTOs(news.NewsComments)
                    };

                    postDTOs.Add(newsDTO);
                }
            }

            return postDTOs;
        }

        public Post MapPostDTOtoPost(PostDTO postDTO)
        {
            if (postDTO is NewsDTO newsDTO)
            {
                News news = new News
                {
                    PostId = postDTO.PostId,
                    User = MapUserDTOToUser(postDTO.User),
                    Title = postDTO.Title,
                    Content = postDTO.Content,
                    Timestamp = postDTO.Timestamp,
                    NewsId = newsDTO.NewsId,
                    Category = newsDTO.NewsCategory,
                    NewsComments = MapNewsCommentDTOsToNewsComments(newsDTO.NewsComments)
                };

                return news;
            }

            else if (postDTO is BlogDTO blogDTO)
            {
                Blog blog = new Blog
                {
                    PostId = postDTO.PostId,
                    User = MapUserDTOToUser(postDTO.User),
                    Title = postDTO.Title,
                    Content = postDTO.Content,
                    Timestamp = postDTO.Timestamp,
                    BlogId = blogDTO.BlogId,
                    Category = blogDTO.BlogCategory,
                    BlogComments = MapBlogCommentDTOsToBlogComments(blogDTO.BlogComments)
                };

                return blog;
            }

            else
            {
                return new Post();
            }

        }

        public UserDTO MapUserToUserDTO(User user)
        {
            if (user is Guest guest)
            {
                GuestDTO guestDTO = new GuestDTO
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    ProfilePicturePath = user.ProfilePicturePath,
                    Description = user.Description,
                    UserExperience = guest.UserExperience
                };

                return guestDTO;
            }

            else if (user is Admin admin)
            {
                AdminDTO adminDTO = new AdminDTO
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    ProfilePicturePath = user.ProfilePicturePath,
                    Description = user.Description,
                    AdminTitle = admin.AdminTitle,
                    AdminPrivilegeLevel = admin.AdminPrivilegeLevel,
                };

                return adminDTO;
            }

            else if (user is Moderator moderator)
            {
                ModeratorDTO moderatorDTO = new ModeratorDTO
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    ProfilePicturePath = user.ProfilePicturePath,
                    Description = user.Description,
                    ModerationArea = moderator.ModerationArea,
                    ModerationExperience = moderator.ModerationExperience
                };

                return moderatorDTO;
            }

            else
            {
                return new UserDTO();
            }
        }

        public User MapUserDTOToUser(UserDTO userDTO)
        {
            if (userDTO is GuestDTO guestDTO)
            {
                Guest guest = new Guest
                {
                    UserId = userDTO.UserId,
                    UserName = userDTO.UserName,
                    Password = userDTO.Password,
                    Email = userDTO.Email,
                    ProfilePicturePath = userDTO.ProfilePicturePath,
                    Description = userDTO.Description,
                    UserExperience = guestDTO.UserExperience
                };

                return guest;
            }

            else if (userDTO is AdminDTO adminDTO)
            {
                Admin admin = new Admin
                {
                    UserId = userDTO.UserId,
                    UserName = userDTO.UserName,
                    Password = userDTO.Password,
                    Email = userDTO.Email,
                    ProfilePicturePath = userDTO.ProfilePicturePath,
                    Description = userDTO.Description,
                    AdminTitle = adminDTO.AdminTitle,
                    AdminPrivilegeLevel = adminDTO.AdminPrivilegeLevel,
                };

                return admin;
            }

            else if (userDTO is ModeratorDTO moderatorDTO)
            {
                Moderator moderator = new Moderator
                {
                    UserId = userDTO.UserId,
                    UserName = userDTO.UserName,
                    Password = userDTO.Password,
                    Email = userDTO.Email,
                    ProfilePicturePath = userDTO.ProfilePicturePath,
                    Description = userDTO.Description,
                    ModerationArea = moderatorDTO.ModerationArea,
                    ModerationExperience = moderatorDTO.ModerationExperience
                };

                return moderator;
            }

            else
            {
                return new User();
            }
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
                    Title = blog.Title,
                    Content = blog.Content,
                    Timestamp = blog.Timestamp,
                    BlogId = blog.PostId,
                    BlogCategory = blog.Category,
                    BlogComments = MapBlogCommentsToBlogCommentDTOs(blog.BlogComments)
                };

                blogDTOs.Add(blogDTO);
            }

            return blogDTOs;
        }

        public List<BlogCommentDTO> MapBlogCommentsToBlogCommentDTOs(List<BlogComment> blogComments)
        {
            List<BlogCommentDTO> blogCommentDTOs = new List<BlogCommentDTO>();

            foreach (BlogComment blogComment in blogComments)
            {
                BlogCommentDTO blogCommentDTO = new BlogCommentDTO
                {
                    BlogCommentId = blogComment.BlogCommentId,
                    Comment = blogComment.Comment,
                    User = MapUserToUserDTO(blogComment.User),
                };

                blogCommentDTOs.Add(blogCommentDTO);
            }

            return blogCommentDTOs;
        }

        public List<BlogComment> MapBlogCommentDTOsToBlogComments(List<BlogCommentDTO> blogCommentDTOs)
        {
            List<BlogComment> blogComments = new List<BlogComment>();

            foreach (BlogCommentDTO blogCommentDTO in blogCommentDTOs)
            {
                BlogComment blogComment = new BlogComment
                {
                    BlogCommentId = blogCommentDTO.BlogCommentId,
                    Comment = blogCommentDTO.Comment,
                    User = MapUserDTOToUser(blogCommentDTO.User)
                };

                blogComments.Add(blogComment);
            }

            return blogComments;
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
                    Title = news.Title,
                    Content = news.Content,
                    Timestamp = news.Timestamp,
                    NewsId = news.NewsId,
                    NewsCategory = news.Category,
                    NewsComments = MapNewsCommentsToNewsCommentDTOs(news.NewsComments)
                };
                newsDTOs.Add(newsDTO);
            }

            return newsDTOs;
        }

        public List<NewsCommentDTO> MapNewsCommentsToNewsCommentDTOs(List<NewsComment> newsComments)
        {
            List<NewsCommentDTO> newsCommentDTOs = new List<NewsCommentDTO>();

            foreach (NewsComment newsComment in newsComments)
            {
                NewsCommentDTO newsCommentDTO = new NewsCommentDTO
                {
                    NewsCommentId = newsComment.NewsCommentId,
                    Comment = newsComment.Comment,
                    User = MapUserToUserDTO(newsComment.User)
                };

                newsCommentDTOs.Add(newsCommentDTO);
            }

            return newsCommentDTOs;
        }

        public List<NewsComment> MapNewsCommentDTOsToNewsComments(List<NewsCommentDTO> newsCommentDTOs)
        {
            List<NewsComment> newsComments = new List<NewsComment>();

            foreach (NewsCommentDTO newsCommentDTO in newsCommentDTOs)
            {
                NewsComment newsComment = new NewsComment
                {
                    NewsCommentId = newsCommentDTO.NewsCommentId,
                    Comment = newsCommentDTO.Comment,
                    User = MapUserDTOToUser(newsCommentDTO.User)
                };

                newsComments.Add(newsComment);
            }

            return newsComments;
        }
    }
}
