using AutoMapper;
using Infrastructure.Entities.Concrete;
using Infrastructure.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Business.Dto.Post;
using Business.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories.Interface;

namespace Business.Services.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostRepo _postRepo;
        private readonly IMapper _mapper;

        public PostService(IPostRepo postRepo, IMapper mapper)
        {
            _postRepo = postRepo;
            _mapper = mapper;
        }



        public async Task CreatePost(PostDto dto)
        {
            Post post = _mapper.Map<Post>(dto);
            post.PostedDate = DateTime.Now;
            await _postRepo.Create(post);
        }

        public async Task<PostDto> GetPostById(int id)
        {
            var post = await _postRepo.GetDefault(x=>x.Id==id);

            var dto = _mapper.Map<PostDto>(post);

            return dto;
        }


        public async Task<List<PostDto>> GetPosts()
        {
            var posts = await _postRepo.GetDefaults(x => true);

            var dtos = posts.Select(p => new PostDto
            {

                Title = p.Title,
                Content = p.Content,
                PostedDate = p.PostedDate,

            })
                .ToList();


            return dtos;
        }


        public async Task<List<PostDto>> GetPosts(int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;
            var skip = (page - 1) * pageSize;

            var posts = await _postRepo.GetDefaults(x => true);

            var dtos = posts.Skip(skip).Take(pageSize).Select(p => _mapper.Map<PostDto>(p))
                .ToList();


            return dtos;
        }


    }
}
