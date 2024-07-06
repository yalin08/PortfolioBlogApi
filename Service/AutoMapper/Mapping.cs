using AutoMapper;
using Infrastructure.Entities.Concrete;
using Service.Dto.Comment;
using Service.Dto.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //CreateMap<T,T>().ReverseMap();
            CreateMap<CreatePostDto,Post>().ReverseMap();
            CreateMap<PostDto,Post>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
        }
    }
}
