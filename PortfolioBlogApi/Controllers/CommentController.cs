using Autofac.Core;
using AutoMapper;
using Business.Dto.Comment;
using Business.Dto.Post;
using Business.Services.Interface;
using Infrastructure.Entities.Concrete;
using Infrastructure.Repositories.Concrete;
using Infrastructure.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly ICommentRequestService _commentRequestService;

        public CommentController(ICommentService service, ICommentRequestService commentRequestService)
        {
            _commentService = service;
            _commentRequestService = commentRequestService;
        }

        [HttpPost("CreateComment")]
        [Authorize]
        public async Task<IActionResult> CreateComment(int id)
        {
            var request = await _commentRequestService.GetCommentRequest(id);
            request.Id = 0;
            await _commentService.CreateComment(request);

            await _commentRequestService.DeleteCommentRequest(id);

            return Ok(request);
        }

        [HttpGet("GetComment")]
        public async Task<List<CommentDto>> GetCommentByPostId(int postId)
        {
            var dto = await _commentService.GetCommentByPostId(postId);
            return dto;
        }

        [HttpGet("GetAllComment")]
        [Authorize]
        public async Task<List<CreateCommentDto>> GetAllComments()
        {
            var dto = await _commentService.GetAllComments();
            return dto;
        }

        [HttpDelete("DeleteComment")]
        [Authorize]
        public async Task<IActionResult> DeleteComment(int id)
        {
            bool success = await _commentService.DeleteComment(id);

            if (success)
            {
                return Ok("Deleted");
            }
            return BadRequest();

        }




    }
}
