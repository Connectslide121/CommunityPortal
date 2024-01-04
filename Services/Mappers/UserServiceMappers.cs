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
using DataBaseConnection.Migrations;

namespace Services.Mappers
{
    internal class UserServiceMappers
    {
        public List<UserDTO> MapUsersToUserDTOs(List<User> users)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();

            foreach (User user in users)
            {
                UserDTO userDTO = new UserDTO
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    ProfilePicturePath = user.ProfilePicturePath,
                    Description = user.Description,
                    PostHistory = MapPostsToPostDTOs(user.PostHistory),
                    EventsAttended = MapEventsToEventDTOs(user.EventsAttended),
                    BlogComments = MapBlogCommentsToBlogCommentDTOs(user.BlogComments),
                    NewsComments = MapNewsCommentsToNewsCommentDTOs(user.NewsComments)
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
                    userDTO.ModerationExperience = moderator.ModerationExperience;
                    userDTO.ModerationArea = moderator.ModerationArea;
                }

                userDTOs.Add(userDTO);
            }

            return userDTOs;
        }

        public UserDTO MapUserToUserDTO(User user)
        {
            UserDTO userDTO = new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                ProfilePicturePath = user.ProfilePicturePath,
                Description = user.Description,
                EventsAttended = MapEventsToEventDTOs(user.EventsAttended), //Write custom mapper for this method
                PostHistory = MapPostsToPostDTOs(user.PostHistory), //Write custom mapper for this method
                NewsComments = MapNewsCommentsToNewsCommentDTOs(user.NewsComments), //Write custom mapper for this method
                BlogComments = MapBlogCommentsToBlogCommentDTOs(user.BlogComments), //Write custom mapper for this method
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
                userDTO.ModerationExperience = moderator.ModerationExperience;
                userDTO.ModerationArea = moderator.ModerationArea;
            }

            return userDTO;
        }


        public List<GuestDTO> MapGuestsToGuestDTOs(List<Guest> guests)
        {
            List<GuestDTO> guestDTOs = new List<GuestDTO>();

            foreach (Guest guest in guests)
            {
                GuestDTO guestDTO = new GuestDTO
                {
                    UserId = guest.UserId,
                    UserName = guest.UserName,
                    Password = guest.Password,
                    Email = guest.Email,
                    ProfilePicturePath = guest.ProfilePicturePath,
                    Description = guest.Description,
                    PostHistory = MapPostsToPostDTOs(guest.PostHistory),
                    EventsAttended = MapEventsToEventDTOs(guest.EventsAttended),
                    BlogComments = MapBlogCommentsToBlogCommentDTOs(guest.BlogComments),
                    NewsComments = MapNewsCommentsToNewsCommentDTOs(guest.NewsComments)
                };
                guestDTO.UserExperience = guest.UserExperience;

                guestDTOs.Add(guestDTO);
            }

            return guestDTOs;
        }

        public List<AdminDTO> MapAdminsToAdminDTOs(List<Admin> admins)
        {
            List<AdminDTO> adminDTOs = new List<AdminDTO>();

            foreach (Admin admin in admins)
            {
                AdminDTO adminDTO = new AdminDTO
                {
                    UserId = admin.UserId,
                    UserName = admin.UserName,
                    Password = admin.Password,
                    Email = admin.Email,
                    ProfilePicturePath = admin.ProfilePicturePath,
                    Description = admin.Description,
                    PostHistory = MapPostsToPostDTOs(admin.PostHistory),
                    EventsAttended = MapEventsToEventDTOs(admin.EventsAttended),
                    BlogComments = MapBlogCommentsToBlogCommentDTOs(admin.BlogComments),
                    NewsComments = MapNewsCommentsToNewsCommentDTOs(admin.NewsComments)

                };
                adminDTO.AdminTitle = admin.AdminTitle;
                adminDTO.AdminPrivilegeLevel = admin.AdminPrivilegeLevel;

                adminDTOs.Add(adminDTO);
            }

            return adminDTOs;
        }

        public List<ModeratorDTO> MapModeratorsToModeratorDTOs(List<Moderator> moderators)
        {
            List<ModeratorDTO> moderatorDTOs = new List<ModeratorDTO>();

            foreach (Moderator moderator in moderators)
            {
                ModeratorDTO moderatorDTO = new ModeratorDTO
                {
                    UserId = moderator.UserId,
                    UserName = moderator.UserName,
                    Password = moderator.Password,
                    Email = moderator.Email,
                    ProfilePicturePath = moderator.ProfilePicturePath,
                    Description = moderator.Description,
                    PostHistory = MapPostsToPostDTOs(moderator.PostHistory),
                    EventsAttended = MapEventsToEventDTOs(moderator.EventsAttended),
                    BlogComments = MapBlogCommentsToBlogCommentDTOs(moderator.BlogComments),
                    NewsComments = MapNewsCommentsToNewsCommentDTOs(moderator.NewsComments)
                };
                moderatorDTO.ModerationArea = moderator.ModerationArea;
                moderatorDTO.ModerationExperience = moderator.ModerationExperience;

                moderatorDTOs.Add(moderatorDTO);
            }

            return moderatorDTOs;
        }

        public List<PostDTO> MapPostsToPostDTOs(List<Post> posts)
        {
            List<PostDTO> postDTOs = new List<PostDTO>();

            foreach (Post post in posts)
            {
                PostDTO postDTO = new PostDTO
                {
                    PostId = post.PostId,
                    Content = post.Content,
                    Timestamp = post.Timestamp
                };

                if (post is Blog blog)
                {
                    postDTO.BlogId = blog.BlogId;
                    postDTO.BlogTitle = blog.Title;
                    postDTO.BlogCategory = blog.Category;
                }

                if (post is News news)
                {
                    postDTO.NewsId = news.NewsId;
                    postDTO.NewsTitle = news.Title;
                    postDTO.NewsCategory = news.Category;
                }

                postDTOs.Add(postDTO);
            }

            return postDTOs;
        }

        public BlogDTO MapBlogToBlogDTO(Blog blog)
        {
            BlogDTO blogDTO = new BlogDTO
            {
                PostId = blog.PostId,
                BlogId = blog.BlogId,
                BlogTitle = blog.Title,
                Content = blog.Content,
                User = MapUserToUserDTO(blog.User)
            };

            return blogDTO;
        }

        public NewsDTO MapNewsToNewsDTO(News news)
        {
            NewsDTO newsDTO = new NewsDTO
            {
                PostId = news.PostId,
                NewsId = news.NewsId,
                NewsTitle = news.Title,
                Content = news.Content,
                User = MapUserToUserDTO(news.User)
            };

            return newsDTO;
        }

        public List<EventDTO> MapEventsToEventDTOs(List<Event> events)
        {
            List<EventDTO> eventDTOs = new List<EventDTO>();

            foreach (Event evnt in events)
            {
                EventDTO eventDTO = new EventDTO
                {
                    EventId = evnt.EventId,
                    Title = evnt.Title,
                    Description = evnt.Description,
                    Location = evnt.Location,
                    StartTime = evnt.StartTime,
                    EndTime = evnt.EndTime,
                };

                eventDTOs.Add(eventDTO);
            }

            return eventDTOs;
        }

        public List<BlogCommentDTO> MapBlogCommentsToBlogCommentDTOs(List<BlogComment> comments)
        {
            List<BlogCommentDTO> commentsDTO = new List<BlogCommentDTO>();

            foreach (BlogComment comment in comments)
            {
                BlogCommentDTO commentDTO = new BlogCommentDTO
                {
                    BlogCommentId = comment.BlogCommentId,
                    Comment = comment.Comment,
                    Blog = MapBlogToBlogDTO(comment.Blog)
                };

                commentsDTO.Add(commentDTO);
            }

            return commentsDTO;
        }

        public List<NewsCommentDTO> MapNewsCommentsToNewsCommentDTOs(List<NewsComment> comments)
        {
            List<NewsCommentDTO> commentsDTO = new List<NewsCommentDTO>();

            foreach (NewsComment comment in comments)
            {
                NewsCommentDTO commentDTO = new NewsCommentDTO
                {
                    NewsCommentId = comment.NewsCommentId,
                    Comment = comment.Comment,
                    News = MapNewsToNewsDTO(comment.News)
                };

                commentsDTO.Add(commentDTO);
            }

            return commentsDTO;
        }
    }
}
