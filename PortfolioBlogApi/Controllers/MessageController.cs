using Business.Dto.Message;
using Business.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            _service = service;
        }

        [HttpPost("CreateMessage")]
        public async Task<IActionResult> CreateMessage(MessageDto dto)
        {
            await _service.CreateMesage(dto);
            return Ok(dto);
        }

        [HttpGet("GetAllMessages")]
        public async Task<List<MessageDto>> GetAllMessages()
        {
            var dtos= await _service.GetAllMessages();
            return dtos;
        }
        [HttpGet("GetMessageById")]
        public async Task<MessageDto> GetMessageById(int id)
        {
            var dto=await _service.GetMessageById(id);
            return dto;
        }

    }
}
