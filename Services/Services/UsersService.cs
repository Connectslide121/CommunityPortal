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
    public class UsersService : IUsersService
    {
        private readonly DataContext _dataContext;

        public UsersService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<UsersUserDTO> GetUsers()
        {
            List<User> users = _dataContext.Users
                .Include(u => u.PostHistory)
                .ToList();

            return MapUsersToUserDTOs(users);
        }

        private List<UsersUserDTO> MapUsersToUserDTOs(List<User> users)
        {
            List<UsersUserDTO> userDTOs = new List<UsersUserDTO>();

            foreach (User user in users) 
            {
                UsersUserDTO userDTO = new UsersUserDTO
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

        private List<UsersPostDTO> MapPostsToPostDTOs(List<Post> posts)
        {
            List<UsersPostDTO> postDTOs = new List<UsersPostDTO>();

            foreach (Post post in posts)
            {
                UsersPostDTO postDTO = new UsersPostDTO
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


        public List<Guest> GetGuests()
        {
            return _dataContext.Guests
                .ToList();
        }

        public List<Admin> GetAdmins() 
        {
            return _dataContext.Admins
                .ToList();
        }

        public List<Moderator> GetModerators()
        {
            return _dataContext.Moderators
                .ToList();
        }
    }
}
