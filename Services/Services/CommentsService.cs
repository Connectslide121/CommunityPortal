using Core;
using Core.NewsClasses;
using Core.UserClasses;
using DataBaseConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.DTOs;
using Services.Interfaces;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly DataContext _dataContext;
        private CommentsServiceMappers _mappers;

        public CommentsService(DataContext dataContext)
        {
            _dataContext = dataContext;
            _mappers = new CommentsServiceMappers();
        }


        public List<CommentDTO> GetComments()
        {
            List<Comment> comments = _dataContext.Comments
               .Include(p => p.Post)
               .Include(p => p.User)
               .ToList();

            return _mappers.MapCommentsToCommentDTOs(comments);
        }

        public CommentDTO GetCommentById(int commentId)//************Handle NULL exception????? make sure that this UserID always exists.
        {
            Comment? comment = _dataContext.Comments
                .Where(c => c.CommentId == commentId)
                .Include(c => c.Post)
                .Include(c => c.User)
                .FirstOrDefault();

            return _mappers.MapCommentToCommentDTO(comment);
        }

        public void AddComment(CommentDTO newComment)
        {
            _dataContext.Comments.Add(_mappers.MapCommentDTOToComment(newComment));
            _dataContext.SaveChanges();

        }

        public bool UpdateComment(CommentDTO commentDTO)/////////////Is this a good approach with the bool????????
        {
            Comment newComment = _mappers.MapCommentDTOToComment(commentDTO);
            Comment? existingComment = _dataContext.Comments.Find(commentDTO.CommentId);
            bool commentExists = false;

            if (existingComment != null)
            {
                _dataContext.Entry(existingComment).CurrentValues.SetValues(newComment);
                _dataContext.SaveChanges();
                commentExists = true;
            }

            return commentExists;
        }

        public bool DeleteComment(int commentId)/////////////Is this a good approach with the bool????????
        {
            var commentToDelete = _dataContext.Comments.Find(commentId);
            bool commentExists = false;

            if (commentToDelete != null)
            {
                _dataContext.Comments.Remove(commentToDelete);
                _dataContext.SaveChanges();
                commentExists = true;
            }

            return commentExists;
        }

    }
}
