using Core;
using Core.CommunityClasses;
using Core.NewsClasses;
using Core.UserClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;

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


        [HttpGet("posts")]
        public List<PostDTO> GetPosts()
        {
            return _postsService.GetPosts();           
        }

        [HttpGet("blogs")]
        public List<BlogDTO> GetBlogs()
        {
            return _postsService.GetBlogs();
        }

        [HttpGet("news")]
        public List<NewsDTO> GetNews()
        {
            return _postsService.GetNews();
        }



    }
}
