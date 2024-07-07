using Business.Dto.Post;
using Business.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;

        public PostController(IPostService postService)
        {
            _service = postService;
        }

        [HttpPost("CreatePost")]
        [Authorize]
        public async Task<IActionResult> CreatePost(PostDto dto)
        {
            await _service.CreatePost(dto);
            return Ok(dto);
        }

        [HttpGet("GetById")]
        public async Task<PostDto> GetPostById(int id)
        {
            var post=await _service.GetPostById(id);
            return post;
        }


        [HttpGet("GetAll")]
        public async Task<List<PostDto>> GetPosts()
        {
            var posts = await _service.GetPosts();
            return posts;
        }

        [HttpGet("GetAllPagination")]
        public async Task<List<PostDto>> GetPosts(int page, int pageSize)
        {
            var posts = await _service.GetPosts(page, pageSize);
            return posts;
        }

    }
}
