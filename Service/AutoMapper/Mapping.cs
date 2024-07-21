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
using Business.Dto.CommentRequest;

namespace Business.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //CreateMap<T,T>().ReverseMap();
            CreateMap<PostDto,Post>().ReverseMap();
            CreateMap<Post, CreatePostDto>().ReverseMap();
            
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();

            CreateMap<MessageDto,Message>().ReverseMap();

            CreateMap<CreateCommentDto, Comment>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();

            CreateMap<CommentRequestDto, Comment>().ReverseMap();

            CreateMap<CommentRequest, Comment>().ReverseMap();
            CreateMap<CreateCommentRequestDto, Comment>().ReverseMap();
            CreateMap<CommentRequest, CommentRequestDto>().ReverseMap();
            CreateMap<CommentRequest, CreateCommentRequestDto>().ReverseMap();
        }
    }
}
