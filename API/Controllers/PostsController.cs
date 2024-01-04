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


        [HttpGet("posts")]
        public IActionResult GetPosts()
        {
            List<PostDTO> posts = _postsService.GetPosts();
            return posts == null ? NotFound() : Ok(posts);           
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

        public void CreatePost(PostDTO post) //////Is "void" a good return?????????????????????????????????
        {
            _postsService.AddPost(post);
        }

    }
}
