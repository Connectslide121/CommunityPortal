using Core;
using Core.UserClasses;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    internal class CommentsServiceMappers
    {
        public List<CommentDTO> MapCommentsToCommentDTOs(List<Comment> comments)
        {
            List<CommentDTO> commentDTOs = new List<CommentDTO>();

            foreach (Comment comment in comments)
            {
                CommentDTO commentDTO = new CommentDTO
                {
                    CommentId = comment.CommentId,
                    CommentContent = comment.CommentContent,
                    Post = MapPostToPostDTO(comment.Post),
                    User = MapUserToUserDTO(comment.User)
                };

                commentDTOs.Add(commentDTO);
            }

            return commentDTOs;
        }

        public CommentDTO MapCommentToCommentDTO(Comment comment)
        {
            CommentDTO commentDTO = new CommentDTO
            {
                CommentId = comment.CommentId,
                CommentContent = comment.CommentContent,
                Post = MapPostToPostDTO(comment.Post),
                User = MapUserToUserDTO(comment.User)
            };

            return commentDTO;
        }

        public Comment MapCommentDTOToComment(CommentDTO commentDTO)
        {
            Comment comment = new Comment
            {
                CommentId = commentDTO.CommentId,
                CommentContent = commentDTO.CommentContent,
                Post = MapPostDTOToPost(commentDTO.Post),
                User = MapUserDTOToUser(commentDTO.User)
            };

            return comment;
        }

        public PostDTO MapPostToPostDTO(Post post)
        {
            PostDTO postDTO = new PostDTO
            {
                PostId = post.PostId,
                User = MapUserToUserDTO(post.User),
                Title = post.Title,
                PostContent = post.PostContent,
                Timestamp = post.Timestamp,
            };

            return postDTO;
        }

        public Post MapPostDTOToPost(PostDTO postDTO)
        {
            Post post = new Post
            {
                PostId = postDTO.PostId,
                User = MapUserDTOToUser(postDTO.User),
                Title = postDTO.Title,
                PostContent = postDTO.PostContent,
                Timestamp = postDTO.Timestamp,
            };

            return post;
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
    }
}
