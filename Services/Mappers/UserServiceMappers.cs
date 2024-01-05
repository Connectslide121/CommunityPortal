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
using System.Reflection.Metadata;

namespace Services.Mappers
{
    internal class UserServiceMappers
    {
        public List<UserDTO> MapUsersToUserDTOs(List<User> users)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();

            foreach (User user in users)
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
                        PostHistory = MapPostsToPostDTOs(user.PostHistory),
                        EventsAttended = MapEventsToEventDTOs(user.EventsAttended),
                        Comments = MapCommentsToCommentDTOs(user.Comments), 
                        UserExperience = guest.UserExperience
                    };
                    userDTOs.Add(guestDTO);
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
                        PostHistory = MapPostsToPostDTOs(user.PostHistory),
                        EventsAttended = MapEventsToEventDTOs(user.EventsAttended),
                        Comments = MapCommentsToCommentDTOs(user.Comments), 
                        AdminTitle = admin.AdminTitle,
                        AdminPrivilegeLevel = admin.AdminPrivilegeLevel
                    };
                    userDTOs.Add(adminDTO);
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
                        PostHistory = MapPostsToPostDTOs(user.PostHistory),
                        EventsAttended = MapEventsToEventDTOs(user.EventsAttended),
                        Comments = MapCommentsToCommentDTOs(user.Comments),
                        ModerationExperience = moderator.ModerationExperience,
                        ModerationArea = moderator.ModerationArea,
                    };
                    userDTOs.Add(moderatorDTO);
                }
            }

            return userDTOs;
        }

        public UserDTO MapUserToUserDTO(User user)
        {
            if (user is Guest guest)
            {
                GuestDTO guestDTO = new GuestDTO
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email,
                    ProfilePicturePath = user.ProfilePicturePath,
                    Description = user.Description,
                    EventsAttended = MapEventsToEventDTOs(user.EventsAttended), //Write custom mapper for this method
                    PostHistory = MapPostsToPostDTOs(user.PostHistory), //Write custom mapper for this method
                    Comments = MapCommentsToCommentDTOs(user.Comments), //Write custom mapper for this method
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
                    Email = user.Email,
                    ProfilePicturePath = user.ProfilePicturePath,
                    Description = user.Description,
                    EventsAttended = MapEventsToEventDTOs(user.EventsAttended), //Write custom mapper for this method
                    PostHistory = MapPostsToPostDTOs(user.PostHistory), //Write custom mapper for this method
                    Comments = MapCommentsToCommentDTOs(user.Comments), //Write custom mapper for this method
                    AdminTitle = admin.AdminTitle,
                    AdminPrivilegeLevel = admin.AdminPrivilegeLevel
                };

                return adminDTO;
            }

            else if (user is Moderator moderator)
            {
                ModeratorDTO moderatorDTO = new ModeratorDTO
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email,
                    ProfilePicturePath = user.ProfilePicturePath,
                    Description = user.Description,
                    EventsAttended = MapEventsToEventDTOs(user.EventsAttended), //Write custom mapper for this method
                    PostHistory = MapPostsToPostDTOs(user.PostHistory), //Write custom mapper for this method
                    Comments = MapCommentsToCommentDTOs(user.Comments), //Write custom mapper for this method
                    ModerationExperience = moderator.ModerationExperience,
                    ModerationArea = moderator.ModerationArea,
                };

                return moderatorDTO;
            }

            else
            {
                return new UserDTO();
            }
        }

        public UserDTO MapUserToUserDTOShort(User user)
        {
            UserDTO userDTO = new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                ProfilePicturePath = user.ProfilePicturePath,
                Description = user.Description,
            };

            return userDTO;
        }

        public User MapUserDTOToUser(UserDTO userDTO)
        {
            User user = new User
            {
                UserId = userDTO.UserId,
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                ProfilePicturePath = userDTO.ProfilePicturePath,
                Description = userDTO.Description,
            };

            return user;
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
                    Comments = MapCommentsToCommentDTOs(guest.Comments),
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
                    Comments = MapCommentsToCommentDTOs(admin.Comments),

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
                    Comments = MapCommentsToCommentDTOs(moderator.Comments),
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
                if (post is Blog blog)
                {
                    BlogDTO blogDTO = new BlogDTO
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        PostContent = post.PostContent,
                        Timestamp = post.Timestamp,
                        BlogId = blog.BlogId,
                        BlogCategory = blog.BlogCategory,
                        Comments = MapCommentsToCommentDTOsShort(blog.Comments)
                    };

                    postDTOs.Add(blogDTO);
                }

                if (post is News news)
                {
                    NewsDTO newsDTO = new NewsDTO
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        PostContent = post.PostContent,
                        Timestamp = post.Timestamp,
                        NewsId = news.NewsId,
                        NewsCategory = news.NewsCategory,
                        Comments = MapCommentsToCommentDTOsShort(news.Comments)
                    };

                    postDTOs.Add(newsDTO);
                }
            }

            return postDTOs;
        }

        public PostDTO MapPostToPostDTO(Post post)
        {
            PostDTO postDTO = new PostDTO
            {
                PostId = post.PostId,
                Title = post.Title,
                PostContent = post.PostContent,
                User = MapUserToUserDTOShort(post.User)
            };

            return postDTO;
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

        public List<CommentDTO> MapCommentsToCommentDTOs(List<Comment> comments)
        {
            List<CommentDTO> commentsDTO = new List<CommentDTO>();

            foreach (Comment comment in comments)
            {
                CommentDTO commentDTO = new CommentDTO
                {
                    CommentId = comment.CommentId,
                    CommentContent = comment.CommentContent,
                    Post = MapPostToPostDTO(comment.Post)
                };

                commentsDTO.Add(commentDTO);
            }

            return commentsDTO;
        }

        public List<CommentDTO> MapCommentsToCommentDTOsShort(List<Comment> comments)
        {
            List<CommentDTO> commentsDTO = new List<CommentDTO>();

            foreach (Comment comment in comments)
            {
                CommentDTO commentDTO = new CommentDTO
                {
                    CommentId = comment.CommentId,
                    CommentContent = comment.CommentContent,
                    User = MapUserToUserDTOShort(comment.User)
                };

                commentsDTO.Add(commentDTO);
            }

            return commentsDTO;
        }
    }
}
