using Core;
using Core.CommunityClasses;
using Core.NewsClasses;
using Core.UserClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Services.DTOs;
using Services.Interfaces;
using Services.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet("all")]
        public IActionResult GetPosts()
        {
            List<PostDTO> posts = _postsService.GetPosts();
            return posts == null ? NotFound() : Ok(posts);           
        }

        [HttpGet("post/{id}")]

        public IActionResult GetPostById(int postId)
        {
            PostDTO postById = _postsService.GetPostById(postId);
            return postById == null ? NotFound() : Ok(postById);
        }

        [HttpGet("blogs")]
        public IActionResult GetBlogs()
        {
            List<BlogDTO> blogs = _postsService.GetBlogs();
            return blogs == null ? NotFound() : Ok(blogs);
        }

        [HttpGet("news")]
        public IActionResult GetNews()
        {
            List<NewsDTO> news = _postsService.GetNews();
            return news == null ? NotFound() : Ok(news);
        }

        [HttpPost("create")]

        public void CreatePost(PostDTO post) //////Is "void" a good return????????? shoudl it be IActionResult returning NoContent()??
                                             //////or return CreatedAtAction()???
                                             //////or the post itself???
        {
            _postsService.AddPost(post);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdatePost(int id, PostDTO updatedPost)/////Is this a better approach than the above?  PROBABLY
        {
            if (updatedPost == null || id != updatedPost.PostId)
            {
                return BadRequest("Invalid data");
            }

            bool postUpdated = _postsService.UpdatePost(updatedPost);

            if (!postUpdated)
            {
                return NotFound();
            }

            return Ok(updatedPost);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeletePost(int postId)
        {
            bool postDeleted = _postsService.DeletePost(postId);

            return postDeleted == false ? NotFound() : Ok(postId);
        }

    }
}
