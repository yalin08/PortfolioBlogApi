using Microsoft.AspNetCore.Identity;
using Business.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dto.Message;
using Business.Dto.Post;

namespace Business.Services.Interface
{
    public interface IMessageService
    {
        Task CreateMesage(MessageDto dto);
        Task<List<MessageDto>> GetAllMessages();
        Task<MessageDto> GetMessageById(int id);

    }
}
