using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;
using Services.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet("all")]

        public IActionResult GetComments()
        {
            List<CommentDTO> comments = _commentsService.GetComments();
            return comments == null ? NotFound() : Ok(comments);
        }

        [HttpGet("comment/{id}")]

        public IActionResult GetCommentById(int commentId)
        {
            CommentDTO commentById = _commentsService.GetCommentById(commentId);
            return commentById == null ? NotFound() : Ok(commentById);
        }


        [HttpPost("create")]

        public void CreateComment(CommentDTO newComment) //////Is "void" a good return????????? shoudl it be IActionResult returning NoContent()??
                                                   //////or return CreatedAtAction()???
                                                   //////or the event itself???
        {
            _commentsService.AddComment(newComment);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateComment(int commentId, CommentDTO updatedComment)/////Is this a better approach than the above?  PROBABLY
        {
            if (updatedComment == null || commentId != updatedComment.CommentId)
            {
                return BadRequest("Invalid data");
            }

            bool commentUpdated = _commentsService.UpdateComment(updatedComment);

            if (!commentUpdated)
            {
                return NotFound();
            }

            return Ok(updatedComment);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteComment(int commentId)
        {
            bool commentDeleted = _commentsService.DeleteComment(commentId);

            return commentDeleted == false ? NotFound() : Ok(commentId);
        }

    }
}
