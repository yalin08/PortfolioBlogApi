using AutoMapper;
using Infrastructure.Entities.Concrete;
using Business.Dto.Comment;
using Business.Dto.Message;
using Business.Dto.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dto.User;

namespace Business.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //CreateMap<T,T>().ReverseMap();
            CreateMap<PostDto,Post>().ReverseMap();

            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();

            CreateMap<MessageDto,Message>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
        }
    }
}
