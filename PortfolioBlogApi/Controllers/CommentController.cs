using Autofac.Core;
using AutoMapper;
using Business.Dto.Comment;
using Business.Dto.Post;
using Business.Services.Interface;
using Infrastructure.Repositories.Concrete;
using Infrastructure.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService commentRepo)
        {
            _service = commentRepo;
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(CommentDto dto)
        {
            await _service.CreateComment(dto);
            return Ok(dto);
        }

        [HttpGet("GetComment")]
        public async Task<List<CommentDto>> GetCommentByPostId(int postId)
        {
          var dto=await  _service.GetCommentByPostId(postId);
            return dto;
        }


    }
}
