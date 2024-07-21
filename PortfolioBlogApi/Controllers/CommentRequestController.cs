using Business.Dto.Comment;
using Business.Dto.CommentRequest;
using Business.Services.Interface;
using Infrastructure.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentRequestController : ControllerBase
    {
        private readonly ICommentRequestService _service;

        public CommentRequestController(ICommentRequestService service)
        {
            _service = service;
        }


        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateCommentRequest(CreateCommentRequestDto dto)
        {
            await _service.CreateCommentRequest(dto);
            return Ok(dto);
        }

        [HttpGet("GetComment")]
        [Authorize]
        public async Task<CommentRequestDto> GetCommentRequest(int id)
        {
            var dto = await _service.GetCommentRequest(id);
            return dto;
        }



        [HttpGet("GetRequestByPostId")]
        [Authorize]
        public async Task<List<CommentRequestDto>> GetCommentRequestsByPostId(int postId)
        {
            var dto = await _service.GetCommentRequestsByPostId(postId);
            return dto;
        }

        [HttpGet("GetAllComment")]
        [Authorize]
        public async Task<List<CommentRequestDto>> GetAllCommentRequests()
        {
            var dto = await _service.GetAllCommentRequests();
            return dto;
        }

        [HttpDelete("DeleteComment")]
        [Authorize]
        public async Task<IActionResult> DeleteCommentRequest(int id)
        {
            bool success = await _service.DeleteCommentRequest(id);

            if (success)
            {
                return Ok("Deleted");
            }
            return BadRequest();

        }



    }
}
