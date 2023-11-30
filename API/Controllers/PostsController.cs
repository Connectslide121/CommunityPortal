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


        [HttpGet("GetPosts")]
        public List<PostsPostDTO> GetPosts()
        {
            return _postsService.GetPosts();           
        }

        [HttpGet("GetBlogs")]
        public List<Blog> GetBlogs()
        {
            return _postsService.GetBlogs();
        }

        [HttpGet("GetNews")]
        public List<News> GetNews()
        {
            return _postsService.GetNews();
        }



    }
}
