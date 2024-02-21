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
                        PostContent = post.PostContent,
                        Timestamp = post.Timestamp,
                        BlogId = blog.BlogId,
                        BlogCategory = blog.BlogCategory,
                        Comments = MapCommentsToCommentDTOs(blog.Comments)
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
                        PostContent = post.PostContent,
                        Timestamp = post.Timestamp,
                        NewsId = news.NewsId,
                        NewsCategory = news.NewsCategory,
                        Comments = MapCommentsToCommentDTOs(news.Comments)
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
                    PostContent = postDTO.PostContent,
                    Timestamp = postDTO.Timestamp,
                    NewsId = newsDTO.NewsId,
                    NewsCategory = newsDTO.NewsCategory,
                    Comments = MapCommentsToCommentDTOs(newsDTO.Comments)
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
                    PostContent = postDTO.PostContent,
                    Timestamp = postDTO.Timestamp,
                    BlogId = blogDTO.BlogId,
                    BlogCategory = blogDTO.BlogCategory,
                    Comments = MapCommentsToCommentDTOs(blogDTO.Comments)
                };

                return blog;
            }

            else
            {
                return new Post();
            }
        }

        public PostDTO MapPostToPostDTO(Post post)
        {
            if (post is News news)
            {
                NewsDTO newsDTO = new NewsDTO
                {
                    PostId = post.PostId,
                    User = MapUserToUserDTO(post.User),
                    Title = post.Title,
                    PostContent = post.PostContent,
                    Timestamp = post.Timestamp,
                    NewsId = news.NewsId,
                    NewsCategory = news.NewsCategory,
                    Comments = MapCommentsToCommentDTOs(news.Comments)
                };

                return newsDTO;
            }

            else if (post is Blog blog)
            {
                BlogDTO blogDTO = new BlogDTO
                {
                    PostId = post.PostId,
                    User = MapUserToUserDTO(post.User),
                    Title = post.Title,
                    PostContent = post.PostContent,
                    Timestamp = post.Timestamp,
                    BlogId = blog.BlogId,
                    BlogCategory = blog.BlogCategory,
                    Comments = MapCommentsToCommentDTOs(blog.Comments)
                };

                return blogDTO;
            }

            else
            {
                return new PostDTO();
            }
        }

        public UserDTO MapUserToUserDTO(User user)
        {
            if (user is Guest guest)
            {
                GuestDTO guestDTO = new GuestDTO
                {
                    UserId = user.Id,
                    UserName = user.UserName,
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
                    UserId = user.Id,
                    UserName = user.UserName,
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
                    UserId = user.Id,
                    UserName = user.UserName,
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
                    Id = userDTO.UserId,
                    UserName = userDTO.UserName,
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
                    Id = userDTO.UserId,
                    UserName = userDTO.UserName,
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
                    Id = userDTO.UserId,
                    UserName = userDTO.UserName,
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
                    PostContent = blog.PostContent,
                    Timestamp = blog.Timestamp,
                    BlogId = blog.PostId,
                    BlogCategory = blog.BlogCategory,
                    Comments = MapCommentsToCommentDTOs(blog.Comments)
                };

                blogDTOs.Add(blogDTO);
            }

            return blogDTOs;
        }

        public List<CommentDTO> MapCommentsToCommentDTOs(List<Comment> comments)
        {
            List<CommentDTO> CommentDTOs = new List<CommentDTO>();

            foreach (Comment Comment in comments)
            {
                CommentDTO CommentDTO = new CommentDTO
                {
                    CommentId = Comment.CommentId,
                    CommentContent = Comment.CommentContent,
                    User = MapUserToUserDTO(Comment.User),
                };

                CommentDTOs.Add(CommentDTO);
            }

            return CommentDTOs;
        }

        public List<Comment> MapCommentsToCommentDTOs(List<CommentDTO> blogCommentDTOs)
        {
            List<Comment> blogComments = new List<Comment>();

            foreach (CommentDTO blogCommentDTO in blogCommentDTOs)
            {
                Comment blogComment = new Comment
                {
                    CommentId = blogCommentDTO.CommentId,
                    CommentContent = blogCommentDTO.CommentContent,
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
                    PostContent = news.PostContent,
                    Timestamp = news.Timestamp,
                    NewsId = news.NewsId,
                    NewsCategory = news.NewsCategory,
                    Comments = MapCommentsToCommentDTOs(news.Comments)
                };
                newsDTOs.Add(newsDTO);
            }

            return newsDTOs;
        }
    }
}
