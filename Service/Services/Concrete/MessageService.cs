using AutoMapper;
using Infrastructure.Entities.Concrete;
using Infrastructure.Repositories.Concrete;
using Business.Dto.Message;
using Business.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class MessageService:IMessageService
    {
        private readonly MessageRepo _messageRepo;
        private readonly IMapper _mapper;

        public MessageService(MessageRepo messageRepo,IMapper mapper)
        {
            _messageRepo = messageRepo;
            _mapper = mapper;
        }

        public async Task CreateMesage(MessageDto dto)
        {
            var message=_mapper.Map<Message>(dto);
            message.PostedDate = DateTime.Now;
            await _messageRepo.Create(message);
        }

        public async Task<List<MessageDto>>  GetAllMessages()
        {
           var messages=await _messageRepo.GetDefaults();
            var dtos = messages.Select(x => _mapper.Map<MessageDto>(x)).ToList();
            return dtos;
        }

        public async Task<MessageDto> GetMessageById(int id)
        {
            var message=await _messageRepo.GetDefault(x=>x.Id==id);
            var dto=_mapper.Map<MessageDto>(message);
            return dto;
        }

    }
}
