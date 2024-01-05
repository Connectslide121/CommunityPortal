using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICommentsService
    {
        List<CommentDTO> GetComments();
        CommentDTO GetCommentById(int commentId);
        void AddComment(CommentDTO newComment);
        bool UpdateComment(CommentDTO CommentToUpdate);
        bool DeleteComment(int eventId);

    }
}
