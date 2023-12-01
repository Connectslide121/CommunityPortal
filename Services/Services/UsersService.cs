using Core;
using Core.CommunityClasses;
using Core.NewsClasses;
using Core.UserClasses;
using DataBaseConnection;
using DataBaseConnection.Migrations;
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
    public class UsersService : IUsersService
    {
        private readonly DataContext _dataContext;

        public UsersService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<UserDTO> GetUsers()
        {
            List<User> users = _dataContext.Users
                .Include(u => u.PostHistory)
                .ToList();

            return MapUsersToUserDTOs(users);
        }

        private List<UserDTO> MapUsersToUserDTOs(List<User> users)
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
                    PostHistory = MapPostsToPostDTOs(user.PostHistory)
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

        private List<PostDTO> MapPostsToPostDTOs(List<Post> posts)
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


        public List<GuestDTO> GetGuests()
        {
            List<Guest> guests = _dataContext.Guests
                .Include(g => g.PostHistory)
                .ToList();

            return MapGuestsToGuestDTOs(guests);
        }


        private List<GuestDTO> MapGuestsToGuestDTOs (List<Guest> guests)
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
                    PostHistory = MapPostsToPostDTOs(guest.PostHistory)
                };
                    guestDTO.UserExperience = guest.UserExperience;

                guestDTOs.Add(guestDTO);
            }

            return guestDTOs;
        }


        public List<AdminDTO> GetAdmins() 
        {
            List<Admin> admins = _dataContext.Admins
                .Include(a => a.PostHistory)
                .ToList();

            return MapAdminsToAdminDTOs(admins);
        }

        private List<AdminDTO> MapAdminsToAdminDTOs (List<Admin> admins)
        {
            List<AdminDTO> adminDTOs = new List<AdminDTO>();

            foreach(Admin admin in admins)
            {
                AdminDTO adminDTO = new AdminDTO
                {
                    UserId = admin.UserId,
                    UserName = admin.UserName,
                    Password = admin.Password,
                    Email = admin.Email,
                    ProfilePicturePath = admin.ProfilePicturePath,
                    Description = admin.Description,
                    PostHistory = MapPostsToPostDTOs(admin.PostHistory)
                };
                    adminDTO.AdminTitle = admin.AdminTitle;
                    adminDTO.AdminPrivilegeLevel = admin.AdminPrivilegeLevel;
               
                adminDTOs.Add(adminDTO);
            }

            return adminDTOs;
        }

        public List<ModeratorDTO> GetModerators()
        {
            List<Moderator> moderators = _dataContext.Moderators
                .Include(m => m.PostHistory)
                .ToList();

            return MapModeratorsToModeratorDTOs(moderators);
        }

        private List<ModeratorDTO> MapModeratorsToModeratorDTOs (List<Moderator> moderators)
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
                    PostHistory = MapPostsToPostDTOs(moderator.PostHistory)
                };
                    moderatorDTO.ModerationArea = moderator.ModerationArea;
                    moderatorDTO.ModerationExperience = moderator.ModerationExperience;

                moderatorDTOs.Add(moderatorDTO);
            }

            return moderatorDTOs;
        }
    }
}
